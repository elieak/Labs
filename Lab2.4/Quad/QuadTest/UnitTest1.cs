using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuadTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class QuadTestClass
        {
            [TestMethod]
            public void QuadNumberArgumentsTestMethodSuccess()
            {
                var programInstance = new Quad.Program();
                string[] stringArr = { "2", "3", "2" };
                Assert.AreEqual(true, programInstance.CheckArguments(stringArr));

            }

            [TestMethod]
            public void QuadNumberArgumentsTestMethodFailed()
            {
                var programInstance = new Quad.Program();
                string[] stringArr = { "2", "3" };
                Assert.AreEqual(false, programInstance.CheckArguments(stringArr));

            }

            [TestMethod]
            public void QuadParseArgumentsTestMethodSuccess()
            {
                double a, b, c;
                var programInstance = new Quad.Program();
                string[] stringArr = { "2", "3", "2" };
                Assert.AreEqual(true, programInstance.CheckParse(stringArr, out a, out b, out c));

            }

            [TestMethod]
            public void QuadParseArgumentsTestMethodFailed()
            {
                var programInstance = new Quad.Program();
                double a, b, c;
                string[] stringArr = { "2", "3", "a" };
                Assert.AreEqual(false, programInstance.CheckParse(stringArr, out a, out b, out c));

            }

            [TestMethod]
            public void Test_OneSolutionA_IsTrue()
            {
                var q = new Quad.Program();
                double a = 0, b = 4, c = 2;

                Assert.AreEqual(-0.5, q.SolutionA(a, b, c));

            }
            [TestMethod]
            public void Test_OneSolutionB_IsTrue()
            {
                var programInstance = new Quad.Program();
                double a = 4, b = 8, c = 4;

                Assert.AreEqual(-1, programInstance.SolutionB(a, b, c));

            }

            [TestMethod]
            public void Test_noSolution_IsFalse()
            {
                double sqrt;
                var programInstance = new Quad.Program();
                double a = 4, b = 0, c = 4;

                Assert.AreEqual(false, programInstance.NoSolution(out sqrt, a, b, c));

            }

            [TestMethod]
            public void Test_noSolution_IsTrue()
            {
                double sqrt;
                double a = 4, b = 10, c = 4;
                var programInstance = new Quad.Program();
                Assert.AreEqual(true, programInstance.NoSolution(out sqrt, a, b, c));

            }

            [TestMethod]
            public void Test_SqrtCheck_Is4()
            {
                double sqrt;
                var programInstance = new Quad.Program();
                double a = 4, b = 2, c = 0;
                programInstance.NoSolution(out sqrt, a, b, c);
                Assert.AreEqual(4, sqrt);

            }

        }
    }
}

