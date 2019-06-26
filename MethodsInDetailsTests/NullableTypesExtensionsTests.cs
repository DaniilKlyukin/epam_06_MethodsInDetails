using TasksLibrary;
using NUnit.Framework;

namespace MethodsInDetailsTests
{
    [TestFixture]
    class NullableTypesExtensionsTests
    {
        [Test]
        public void CheckIsNull()
        {
            int? i1 = 1;
            Assert.AreEqual(false, i1.IsNull());

            int? i2 = null;
            Assert.AreEqual(true, i2.IsNull());

            string s1 = null;
            Assert.AreEqual(true, s1.IsNull());

            string s2 = "Some str";
            Assert.AreEqual(false, s2.IsNull());

            object o1 = "boxing";
            Assert.AreEqual(false, o1.IsNull());

            object o2 = null;
            Assert.AreEqual(true, o2.IsNull());

            int[] arr1 = null;
            Assert.AreEqual(true, arr1.IsNull());

            int[] arr2 = { 1, 2, 3 };
            Assert.AreEqual(false, arr2.IsNull());
        }
    }
}
