using System;
using System.Runtime.InteropServices;

namespace net.sf.jni4net
{
    public static class CoreClrEntryPoint
    {
        [UnmanagedCallersOnly]
        public static int Initialize(IntPtr env, IntPtr clazz)
        {
            return Bridge.initDotNetImpl(env, clazz);
        }
    }
}
