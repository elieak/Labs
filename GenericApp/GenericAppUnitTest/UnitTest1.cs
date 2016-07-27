using GenericApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericAppUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Dictionary_AddValues_CountIncrease()
        {
            var multiDictionay = new MultiDictionary<int, string>
            {
                {1, "test1"},
                {2, "test2"}
            };

            Assert.IsTrue(multiDictionay.Count == 2);
        }

        [TestMethod]
        public void Dictionary_ClearList_CountReset()
        {
            var multiDictionay = new MultiDictionary<int, string>
            {
                {1, "test1"},
                {2, "test2"}
            };

            multiDictionay.Clear();
            Assert.IsTrue(multiDictionay.Count == 0);
        }

        [TestMethod]
        public void Dictionary_RemoveByKey_CountDecrease()
        {
            var multiDictionay = new MultiDictionary<int, string>
            {
                {1, "test1"},
                {2, "test2"}
            };

            multiDictionay.Remove(2);
            Assert.IsTrue(multiDictionay.Count == 1);
        }

        [TestMethod]
        public void Dictionary_RemoveByKeyValue_CorrectlyRemoved()
        {
            var multiDictionay = new MultiDictionary<int, string>
            {
                {1, "test1"},
                {2, "test2"}
            };
            Assert.IsTrue(multiDictionay.Remove(1, "test1"));
        }

        [TestMethod]
        public void Dictionary_RemoveByKeyValue_OnlyOneValueRemoved()
        {
            var multiDictionay = new MultiDictionary<int, string>
            {
                {1, "test1"},
                {1, "test1.1" },
                {2, "test2"}
            };

            multiDictionay.Remove(1, "test1");
            Assert.IsTrue(multiDictionay.Count == 2);
        }

        [TestMethod]
        public void Dictionary_ContainsKey_CorrectMatch()
        {
            var multiDictionay = new MultiDictionary<int, string>
            {
                {1, "test1"},
                {2, "test2"}
            };

            Assert.IsTrue(multiDictionay.ContainsKey(1));
        }

        [TestMethod]
        public void Dictionary_ContainsValue_CorrectMatch()
        {
            var multiDictionay = new MultiDictionary<int, string>
            {
                {1, "test1"},
                {2, "test2"}
            };
            Assert.IsTrue(multiDictionay.Contains(2, "test2"));
        }
    }
}
