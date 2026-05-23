#region Copyright (C) 2009 by Pavel Savara

/*
This file is part of jni4net library - bridge between Java and .NET
http://jni4net.sourceforge.net/

This content is released under the (http://opensource.org/licenses/MIT) MIT License, see license/jni4net-MIT.txt.
*/

#endregion

using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading;

namespace net.sf.jni4net.utils
{
    public static class IntHandle
    {
        private static int diagnosticsEnabled;
        private static ConcurrentDictionary<long, byte> diagnosticHandles;
        private static long allocatedCount;
        private static long freedCount;

        public static void EnableDiagnostics()
        {
            diagnosticHandles = new ConcurrentDictionary<long, byte>();
            Interlocked.Exchange(ref allocatedCount, 0);
            Interlocked.Exchange(ref freedCount, 0);
            Volatile.Write(ref diagnosticsEnabled, 1);
        }

        public static long AllocatedCount
        {
            get { return Interlocked.Read(ref allocatedCount); }
        }

        public static long FreedCount
        {
            get { return Interlocked.Read(ref freedCount); }
        }

        public static long OutstandingCount
        {
            get { return AllocatedCount - FreedCount; }
        }

        public static void Free(long ptr)
        {
            GCHandle tgt = GCHandle.FromIntPtr(new IntPtr(ptr));
            tgt.Free();
            byte unused;
            if (Volatile.Read(ref diagnosticsEnabled) != 0 && diagnosticHandles.TryRemove(ptr, out unused))
                Interlocked.Increment(ref freedCount);
        }

        public static object ToObject(long ptr)
        {
            GCHandle tgt = GCHandle.FromIntPtr(new IntPtr(ptr));
            return tgt.Target;
        }

        public static long Alloc(object real)
        {
            GCHandle handle = GCHandle.Alloc(real);
            long ptr = GCHandle.ToIntPtr(handle).ToInt64();
            if (Volatile.Read(ref diagnosticsEnabled) != 0)
            {
                diagnosticHandles.TryAdd(ptr, 0);
                Interlocked.Increment(ref allocatedCount);
            }
            return ptr;
        }
    }
}