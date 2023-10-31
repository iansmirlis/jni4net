using System.Security.Permissions;
using NUnit.Framework;

namespace net.sf.jni4net.test
{
    
    
    
    
    [TestFixture]
    public class SecurityBasicTest : BasicTests
    {
        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();
        }
    }

    
    
    
    
    [TestFixture]
    public class SecurityCallBackTest : CallBackTest
    {
        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();
        }
    }

    
    
    
    
    [TestFixture]
    public class SecurityExceptionsTest : ExceptionsTest
    {
        [OneTimeSetUp]
        public override void Setup()
        {
            base.Setup();
        }
    }
    
    
}
