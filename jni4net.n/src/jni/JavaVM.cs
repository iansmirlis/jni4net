#region Copyright (C) 2009 by Pavel Savara

/*
This file is part of jni4net library - bridge between Java and .NET
http://jni4net.sourceforge.net/

This content is released under the (http://opensource.org/licenses/MIT) MIT License, see license/jni4net-MIT.txt.
*/

#endregion

using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace net.sf.jni4net.jni
{
    
    
    public unsafe partial class JavaVM
    {
        private readonly IntPtr native;
        private JNIInvokeInterface functions;

        public JavaVM(IntPtr native)
        {
            this.native = native;
            functions = *(*(JavaPtr*) native.ToPointer()).functions;
        }

        internal JNIResult AttachCurrentThread(out JNIEnv penv, JavaVMInitArgs? args)
        {
            if (attachCurrentThread == null)
            {
                MethodWrapper.GetDelegateForFunctionPointer(functions.AttachCurrentThread, ref attachCurrentThread);
            }
            IntPtr env;
            JNIResult result;
            if (args.HasValue)
            {
                JavaVMInitArgs initArgs = args.Value;
                result = attachCurrentThread.Invoke(native, out env, &initArgs);
            }
            else
            {
                result = attachCurrentThread.Invoke(native, out env, null);
            }
            penv = new JNIEnv(env);
            return result;
        }

        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public JNIResult AttachCurrentThreadAsDaemon(out JNIEnv penv, JavaVMInitArgs? args)
        {
            if (attachCurrentThreadAsDaemon == null)
            {
                MethodWrapper.GetDelegateForFunctionPointer(functions.AttachCurrentThreadAsDaemon,
                                                            ref attachCurrentThreadAsDaemon);
            }
            IntPtr env;
            JNIResult result;
            if (args.HasValue)
            {
                JavaVMInitArgs value = args.Value;
                result = attachCurrentThreadAsDaemon.Invoke(native, out env, &value);
            }
            else
            {
                result = attachCurrentThreadAsDaemon.Invoke(native, out env, null);
            }
            if (result == JNIResult.JNI_OK)
            {
                penv = new JNIEnv(env);
            }
            else
            {
                penv = null;
            }
            return result;
        }

        public JNIResult DestroyJavaVM()
        {
            if (destroyJavaVM == null)
            {
                MethodWrapper.GetDelegateForFunctionPointer(functions.DestroyJavaVM, ref destroyJavaVM);
            }
            return destroyJavaVM.Invoke(native);
        }

        public JNIResult DetachCurrentThread()
        {
            if (detachCurrentThread == null)
            {
                MethodWrapper.GetDelegateForFunctionPointer(functions.DetachCurrentThread, ref detachCurrentThread);
            }
            return detachCurrentThread.Invoke(native);
        }

        public JNIResult GetEnv(out JNIEnv penv, int version)
        {
            if (getEnv == null)
            {
                MethodWrapper.GetDelegateForFunctionPointer(functions.GetEnv, ref getEnv);
            }
            IntPtr env;
            JNIResult result = getEnv.Invoke(native, out env, version);
            penv = new JNIEnv(env);
            return result;
        }

        #region Nested type: JNIInvokeInterface

        [StructLayout(LayoutKind.Sequential), NativeCppClass]
        public struct JNIInvokeInterface
        {
            public IntPtr reserved0;
            public IntPtr reserved1;
            public IntPtr reserved2;

            public IntPtr DestroyJavaVM;
            public IntPtr AttachCurrentThread;
            public IntPtr DetachCurrentThread;
            public IntPtr GetEnv;
            public IntPtr AttachCurrentThreadAsDaemon;
        }

        #endregion
    }
}