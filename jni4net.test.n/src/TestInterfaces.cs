using System;
using java.lang;
using java_.lang;
using net.sf.jni4net.inj;
using net.sf.jni4net.jni;
using net.sf.jni4net.tested;
using NUnit.Framework;
using Object=java.lang.Object;
using String=java.lang.String;

namespace net.sf.jni4net.test
{
    [TestFixture]
    public class TestInterfaces : TestBase
    {
        private JInterfacesHelper testInstance;

        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();
            testInstance = new JInterfacesHelper();
        }

        [Test]
        public void jIface()
        {
            var cw1 = new CWithJavaInterface(1);
            var cw2 = new CWithJavaInterface(2);
            Object other = (Object)Bridge.WrapCLR(cw2);
            Assert.That(cw1.compareTo(other), Is.EqualTo(1));

            cw2.run();
            Assert.That(cw2.Value, Is.EqualTo(3));
        }

        [Test]
        public void jIfaceUnreg()
        {
            var cw1 = new CWithJavaInterfaceUnreg(1);
            var cw2 = new CWithJavaInterfaceUnreg(2);

            Object other = (Object)Bridge.WrapCLR(cw2);
            Assert.That(cw1.compareTo(other), Is.EqualTo(1));

            cw2.run();
            Assert.That(cw2.Value, Is.EqualTo(3));
        }

        [Test]
        public void cIface()
        {
            var cw1 = new JWithClrInterface(1);
            var cw2 = new JWithClrInterface(2);

            int res = cw1.CompareTo(cw2);

            Assert.That(res, Is.EqualTo(1));

            cw2.run();
            Assert.That(cw2.getValue(), Is.EqualTo(3));
        }

        [Test]
        public void cIfaceCant()
        {
            var cw1 = new JWithClrInterface(1);
            Assert.Throws<JNIException>(() => Bridge.WrapCLR(cw1));
        }

        [Test]
        public void cIfaceCant2()
        {
            var cw1 = new String("sdfd");
            Assert.Throws<JNIException>(() => Bridge.UnwrapCLR<IClrProxy>(cw1));
        }

        [Test]
        public void cIfaceCanString()
        {
            var cw1 = "sdfd";
            Object proxy = Bridge.WrapCLR(cw1);
            Class clazz = proxy.getClass();
            Assert.That(clazz, Is.EqualTo(System.String_._class));
            object res = Bridge.UnwrapCLR<object>(proxy);
            Assert.That(res, Is.SameAs(cw1));
        }

        [Test]
        public void cIfaceCanInt()
        {
            var cw1 = 1;
            Object proxy = Bridge.WrapCLR(cw1);
            Class clazz = proxy.getClass();
            //TODO Assert.AreEqual(System.Int32_._class, clazz);
            object res = Bridge.UnwrapCLR<object>(proxy);
            Assert.That(res, Is.EqualTo(cw1));
        }

        [Test]
        public void cIfaceUnreg()
        {
            IComparable cw1 = testInstance.createJWithClrInterfaceUnreg(1);
            IComparable cw2 = testInstance.createJWithClrInterfaceUnreg(2);

            Assert.That(cw1.CompareTo(cw2), Is.EqualTo(1));

            ((Object) cw2).Invoke<int>("run", "()V");
            Assert.That(((Object)cw2).Invoke<int>("getValue","()I"), Is.EqualTo(3));
        }

        [Test]
        public void cIfaceUnreg2()
        {
            IComparable comparable = testInstance.createJWithClrInterfaceUnreg(1);
            Runnable cw1 = Bridge.Cast<Runnable>(comparable);
            cw1.run();
            cw1.run();
            cw1.run();
            var cw2 = testInstance.createJWithClrInterfaceUnreg(4);

            Assert.That(cw2.CompareTo(cw1), Is.EqualTo(0));

            cw1.run();
            Assert.That((String)cw1.ToString(), Is.EqualTo((String)"5"));
        }

        [Test]
        public void cIfaceUnreg3()
        {
            Runnable runnable = testInstance.createJWithClrInterfaceUnregRun(1);
            runnable.run();
            runnable.run();
            runnable.run();
            var cw2 = testInstance.createJWithClrInterfaceUnreg(4);

            IComparable comparable = Bridge.Cast<IComparable>(runnable);

            Assert.That(comparable.CompareTo(cw2), Is.EqualTo(0));

            runnable.run();
            Assert.That((String)runnable.ToString(), Is.EqualTo((String)"5"));
        }

        [Test]
        public void Interfaces1()
        {
            CWithJavaInterface a = new CWithJavaInterface(4);
            Runnable cw = testInstance.getCWithJavaInterface(a);
            CWithJavaInterface cwi = testInstance.getCWithJavaInterfaceC(a);
            cwi.run();
            cw.run();
            CWithJavaInterface tt = cw as CWithJavaInterface;
            Assert.That(tt.Value, Is.EqualTo(6));
        }

        [Test]
        public void InterfacesstringArray()
        {
            Class loadClass = ICInterface_._class.getClassLoader().loadClass("net.sf.jni4net.tested.CInterfaceImpl");
            ICInterface impl = Bridge.Cast<ICInterface>(loadClass.newInstance());
            impl.xx(new []{"a",null,"b"});
        }
        
    }
}
