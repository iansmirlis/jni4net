using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using selvin.exportdllattribute;

namespace net.sf.jni4net
{
    internal static class BridgeExport
    {
        [ExportDll("Java_net_sf_jni4net_Bridge_initDotNet", CallingConvention.StdCall)]
        internal static int InitDotNet(IntPtr env, IntPtr clazz)
        {
            try
            {
                string bridgePath = Path.Combine(
                    Path.GetDirectoryName(typeof(BridgeExport).Assembly.Location),
                    "jni4net.n-0.8.9.0.dll");
                if (!File.Exists(bridgePath))
                {
                    Console.Error.WriteLine("jni4net Framework launcher: missing managed bridge: " + bridgePath);
                    return -102;
                }

                Assembly assembly = Assembly.LoadFile(bridgePath);
                Type type = assembly.GetType("net.sf.jni4net.Bridge", true);
                MethodInfo method = type.GetMethod("initDotNetImpl", BindingFlags.NonPublic | BindingFlags.Static);
                if (method == null)
                {
                    Console.Error.WriteLine("jni4net Framework launcher: managed initialization entry point was not found.");
                    return -103;
                }

                return (int)method.Invoke(null, new object[] { env, clazz });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("jni4net Framework launcher: " + ex.Message);
                Console.Error.WriteLine(ex);
                return -100;
            }
        }
    }
}
