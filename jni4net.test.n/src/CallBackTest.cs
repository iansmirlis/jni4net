#region Copyright (C) 2009 by Pavel Savara
/*
This file is part of tools for jni4net - bridge between Java and .NET
http://jni4net.sourceforge.net/

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using java.lang;
using net.sf.jni4net.jni;
using net.sf.jni4net.nio;
using net.sf.jni4net.tested;
using net.sf.jni4net.utils;
using NUnit.Framework;
using Exception = java.lang.Exception;
using Object = java.lang.Object;
using String = java.lang.String;

namespace net.sf.jni4net.test
{
    [TestFixture]
    public class CallBackTest : TestBase
    {
        [Test]
        public void CallMeFromJava()
        {
            Class testClass = env.FindClass("net/sf/jni4net/tested/JavaToClrReflection");
            Object test = testClass.newInstance();
            test.getClass().Invoke("reflect", "()V");
        }

        [Test]
        public void CallBackExceptionPropagate()
        {
            Assert.Throws<NullReferenceException>(() => JavaCallBack.callBackExceptionPropagate(), "clr");
        }

        [Test]
        public void CallMeFromJavaException()
        {
            JavaCallBack.callBackException();
        }

        [Test]
        public void CallMeFromJavaComparison()
        {
            int res = JavaCallBack.callBackComparison();
            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void CallMeFromJavaComparison2()
        {
            int res = JavaCallBack.callBackComparison2();
            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void CallBackRun()
        {
            int res = JavaCallBack.callBackRun();
            Assert.That(res, Is.EqualTo(3));
        }

        [Test]
        public void CallBackStatic()
        {
            int res = JavaCallBack.callBackStatic(1,3);
            Assert.That(res, Is.EqualTo(4));
        }

        [Test]
        public void ClosedProxyReleasesManagedHandleImmediately()
        {
            const int iterations = 1000;
            Class testClass = env.FindClass("net/sf/jni4net/tested/JavaToClrReflection");
            MethodId methodId = env.GetStaticMethodID(testClass, "allocateClosedProxy", "()V");
            long initialAllocated = IntHandle.AllocatedCount;
            long initialFreed = IntHandle.FreedCount;

            for (int i = 0; i < iterations; i++)
                env.CallStaticVoidMethod(testClass, methodId);

            Assert.That(IntHandle.AllocatedCount - initialAllocated, Is.EqualTo(iterations));
            Assert.That(IntHandle.FreedCount - initialFreed,
                        Is.EqualTo(IntHandle.AllocatedCount - initialAllocated));
        }

        [Test]
        [Explicit]
        public void HeavyCallMeFromJava()
        {
            int batches = GetIterationCount("JNI4NET_HEAVY_BATCHES", 100);
            int callsPerBatch = GetIterationCount("JNI4NET_HEAVY_CALLS_PER_BATCH", 1000);
            Class testClass = env.FindClass("net/sf/jni4net/tested/JavaToClrReflection");
            MethodId methodId = env.GetStaticMethodID(testClass, "allocateTransientProxies", "()V");
            long initialAllocated = IntHandle.AllocatedCount;
            long initialFreed = IntHandle.FreedCount;
            long initialOutstanding = IntHandle.OutstandingCount;

            WriteHandleCounts("baseline", initialAllocated, initialFreed, initialOutstanding);
            for (int batch = 1; batch <= batches; batch++)
            {
                for (int call = 0; call < callsPerBatch; call++)
                    env.CallStaticVoidMethod(testClass, methodId);

                WriteHandleCounts("after " + (batch * callsPerBatch) + " calls",
                                  initialAllocated, initialFreed, initialOutstanding);
            }

            long allocationsFromCalls = IntHandle.AllocatedCount - initialAllocated;
            long outstandingBeforeCollection = IntHandle.OutstandingCount;

            java.lang.System.gc();
            java.lang.System.runFinalization();
            java.lang.System.gc();
            java.lang.System.runFinalization();

            WriteHandleCounts("after Java GC/finalization",
                              initialAllocated, initialFreed, initialOutstanding);
            TestContext.Progress.WriteLine("Outstanding handles released after collection request: {0}",
                                           outstandingBeforeCollection - IntHandle.OutstandingCount);

            Assert.That(allocationsFromCalls, Is.GreaterThan(0),
                        "The stress callback should create managed proxy handles.");
        }

        private static void WriteHandleCounts(string phase, long initialAllocated,
                                              long initialFreed, long initialOutstanding)
        {
            long allocated = IntHandle.AllocatedCount;
            long freed = IntHandle.FreedCount;
            long outstanding = allocated - freed;
            TestContext.Progress.WriteLine(
                "{0}: allocated +{1}, freed +{2}, outstanding={3} (delta {4})",
                phase, allocated - initialAllocated, freed - initialFreed,
                outstanding, outstanding - initialOutstanding);
        }

        private static int GetIterationCount(string environmentVariable, int defaultValue)
        {
            string configuredValue = Environment.GetEnvironmentVariable(environmentVariable);
            int configuredCount;
            if (int.TryParse(configuredValue, out configuredCount) && configuredCount > 0)
                return configuredCount;

            return defaultValue;
        }
    
    }
}
