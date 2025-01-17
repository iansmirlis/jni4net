#region Copyright (C) 2012 by Pavel Savara

/*
This file is part of jni4net library - bridge between Java and .NET
http://jni4net.sourceforge.net/

This content is released under the (http://opensource.org/licenses/MIT) MIT License, see license/jni4net-MIT.txt.
*/

#endregion

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using JType=java.lang.reflect.Type;
using Microsoft.Win32;
using System.Reflection;
using java.util;
using System.Linq;

namespace net.sf.jni4net.jni
{
    internal static unsafe partial class JNI
    {
        public const int JNI_VERSION_1_1 = 0x00010001;
        public const int JNI_VERSION_1_2 = 0x00010002;
        public const int JNI_VERSION_1_4 = 0x00010004;
        public const int JNI_VERSION_1_6 = 0x00010006;

        private const string JRE_REGISTRY_KEY = @"HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Runtime Environment";
        private const string JDK_REGISTRY_KEY = @"HKEY_LOCAL_MACHINE\SOFTWARE\JavaSoft\Java Development Kit";
        private const string JAVA_HOME_ENV = "JAVA_HOME";
        private const string ARCH_ENV = "PROCESSOR_ARCHITECTURE";
        private const string JNI_LINUX = "libjvm.so";
        private const string JNI_WINDOWS = "jvm.dll";

        private static bool init;

        private static void Init()
        {
            if (!init)
            {
                var findJvmDir = FindJvmDir();
                AddResolvePath(findJvmDir);

                var args = new JavaVMInitArgs();
                try
                {
                    //just load DLL
                    Dll.JNI_GetDefaultJavaVMInitArgs(&args);
                    init = true;
                }
                catch (BadImageFormatException ex)
                {
                    // it didn't help, throw original exception
                    throw new JNIException("Can't initialize jni4net. (32bit vs 64bit JVM vs CLR ?)"
                                           + "\nCLR architecture: " + ((IntPtr.Size == 8) ? "64bit" : "32bit")
                                           + "\nJAVA_HOME: " + (Bridge.Setup == null || Bridge.Setup.JavaHome == null
                                                                    ? "null"
                                                                    : Path.GetFullPath(Bridge.Setup.JavaHome))
                                           , ex);
                }
            }
        }


        private static string FindJvmDir()
        {
            string directory = null;
            if (string.IsNullOrEmpty(Bridge.Setup.JavaHome))
            {
                Bridge.Setup.JavaHome = Environment.GetEnvironmentVariable(JAVA_HOME_ENV);
                if (string.IsNullOrEmpty(Bridge.Setup.JavaHome))
                {
                    Bridge.Setup.JavaHome = null;
                }
                else
                {
                    try
                    {
                        Bridge.Setup.JavaHome = Path.GetFullPath(Bridge.Setup.JavaHome.Replace("\"", ""));
                    }
                    catch(Exception ex)
                    {
                        throw new JNIException("JAVA_HOME environment variable is incorrect: " + Bridge.Setup.JavaHome, ex);
                    }
                }
            }

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                string arch = Environment.GetEnvironmentVariable(ARCH_ENV);
                var is64Arch = (arch != null && arch.Contains("64"));
                var is64Process = (IntPtr.Size == 8);

                if (Bridge.Setup.JavaHome == null)
                {
                    string jreVersion = (string)Registry.GetValue(JRE_REGISTRY_KEY, "CurrentVersion", null);
                    if (jreVersion != null)
                    {
                        string keyName = Path.Combine(JRE_REGISTRY_KEY, jreVersion);
                        directory = (string)Registry.GetValue(keyName, "RuntimeLib", null);
                        Bridge.Setup.JavaHome = (string)Registry.GetValue(keyName, "JavaHome", null);
                    }
                }

                if (Bridge.Setup.JavaHome == null)
                {
                    string jdkVersion = (string)Registry.GetValue(JDK_REGISTRY_KEY, "CurrentVersion", null);
                    if (jdkVersion != null)
                    {
                        string keyName = Path.Combine(JDK_REGISTRY_KEY, jdkVersion);
                        directory = (string)Registry.GetValue(keyName, "RuntimeLib", null);
                        Bridge.Setup.JavaHome = (string)Registry.GetValue(keyName, "JavaHome", null);
                    }
                }

                if (Bridge.Setup.JavaHome == null || Bridge.Setup.IgnoreJavaHome)
                {
                    string prfi = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                    if (is64Arch && !is64Process)
                    {
                        prfi = prfi + " (x86)";
                    }
                    if (Directory.Exists(prfi))
                    {
                        string prfijava = Path.Combine(prfi, "Java");
                        if (Directory.Exists(prfijava))
                        {
                            string[] directories = Directory.GetDirectories(prfijava, "jre*");
                            if (directories.Length > 0)
                            {
                                Array.Sort(directories);
                                Bridge.Setup.JavaHome = directories[directories.Length - 1];
                                if (Bridge.Setup.Verbose)
                                {
                                    Console.WriteLine("Guessed JAVA_HOME to " + Bridge.Setup.JavaHome);
                                }
                            }
                            else
                            {
                                directories = Directory.GetDirectories(prfijava, "jdk*");
                                if (directories.Length > 0)
                                {
                                    Array.Sort(directories);
                                    Bridge.Setup.JavaHome = directories[directories.Length - 1];
                                    if (Bridge.Setup.Verbose)
                                    {
                                        Console.WriteLine("Guessed JAVA_HOME to " + Bridge.Setup.JavaHome);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (Bridge.Setup.JavaHome == null) throw new JNIException("JAVA_HOME environment variable is not set");

            if (!string.IsNullOrEmpty(directory) && Directory.Exists(directory)) return directory;

            var possiblePaths = new[]
            {
                @"bin\server",
                @"bin\client",
                @"bin\classic",
                @"lib\server",
                @"lib\client",
                @"lib\classic",
                @"jre\bin\server",
                @"jre\bin\client",
                @"jre\bin\classic"
            };

            foreach(var path in possiblePaths)
            {
                directory = Path.Combine( new[] { Bridge.Setup.JavaHome }.Concat( path.Split('\\') ).ToArray() );
                if (Directory.Exists(directory)) return directory;
            }

            throw new JNIException("JAVA_HOME environment variable points to an invalid location: " + Bridge.Setup.JavaHome);
        }


        public static void CreateJavaVM(out JavaVM jvm, out JNIEnv env, bool attachIfExists, params string[] options)
        {
            Init();
            IntPtr njvm;
            IntPtr nenv;
            var args = new JavaVMInitArgs();
            args.version = JNI_VERSION_1_4;

            if (options.Length > 0)
            {
                args.nOptions = options.Length;
                var opt = new JavaVMOption[options.Length];
                for (int i = 0; i < options.Length; i++)
                {
                    opt[i].optionString = Marshal.StringToHGlobalAnsi(options[i]);
                }
                fixed (JavaVMOption* a = &opt[0])
                {
                    args.options = a;
                }
            }
            JNIResult result;
            if (attachIfExists)
            {
                IntPtr njvma;
                int count;
                result = Dll.JNI_GetCreatedJavaVMs(out njvma, 1, out count);
                if (result != JNIResult.JNI_OK)
                {
                    throw new JNIException("Can't enumerate current JVMs " + result);
                }
                if (count > 0)
                {
                    njvm = njvma;
                    jvm = new JavaVM(njvm);
                    result = jvm.AttachCurrentThread(out env, args);
                    if (result != JNIResult.JNI_OK)
                    {
                        throw new JNIException("Can't join current JVM " + result);
                    }
                    return;
                }
            }
            result = Dll.JNI_CreateJavaVM(out njvm, out nenv, &args);
            if (result != JNIResult.JNI_OK)
            {
                Console.Error.WriteLine("Can't load JVM (already have one ?)");
                throw new JNIException("Can't load JVM (already have one ?) " + result);
            }
            jvm = new JavaVM(njvm);
            env = new JNIEnv(nenv);
        }

        private static void AddResolvePath(string jvm)
        {
            if(Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                string path = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
                if (!path.StartsWith(jvm))
                {
                    path = jvm + Path.PathSeparator + path;
                    Environment.SetEnvironmentVariable("PATH", path);
                }
            }
            else  // On linux .net does not respect LD_LIBRARY_PATH (bug?), so we need to use DllImportResolver
            {
                NativeLibrary.SetDllImportResolver(typeof(JNI).Assembly, (name, assembly, searchPath) =>
                {
                    if (name == "jvm")
                    {
                        return NativeLibrary.Load(Path.Combine(jvm, JNI_LINUX), assembly, searchPath);
                    }
                    return IntPtr.Zero;
                });
            }

        }

        #region Nested type: Dll

        private static partial class Dll
        {
            [LibraryImport("jvm")]
            internal static partial JNIResult JNI_CreateJavaVM(out IntPtr pvm, out IntPtr penv, JavaVMInitArgs* args);

            [LibraryImport("jvm")]
            internal static partial JNIResult JNI_GetCreatedJavaVMs(out IntPtr pvm, int size, out int size2);

            [LibraryImport("jvm")]
            internal static partial JNIResult JNI_GetDefaultJavaVMInitArgs(JavaVMInitArgs* args);
        }

        #endregion
    }
}
