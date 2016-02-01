using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonExtensions.Tests
{
    [TestClass]
    public class ReflectionTests
    {
        public class TestObject
        {
            public string ExampleProperty { get; set; }

            public string OtherProperty { get; set; }
        }

        #region Properties
        
        [TestMethod]
        public void IsProperty()
        {
            var o = new TestObject();

            Assert.AreEqual("ExampleProperty",o.GetPropertyName(() => o.ExampleProperty));

            Assert.IsTrue("ExampleProperty".IsProperty(() => o.ExampleProperty));
            Assert.IsFalse("BadProperty".IsProperty(() => o.ExampleProperty));

            Assert.IsTrue("OtherProperty".IsProperty(() => o.ExampleProperty, () => o.OtherProperty));
            Assert.IsFalse("BadProperty".IsProperty(() => o.ExampleProperty, () => o.OtherProperty));

        }
        
        #endregion

    }
}
