using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Sum()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Sum(x, y);

            Assert.IsTrue(sum == 30);
        }

        [TestMethod]
        public void Divide()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Divide(x, y);

            Assert.IsTrue(sum == 2);
        }

        [TestMethod]
        public void DivideZero()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 0;
            var sum = test.Divide(x, y);

            Assert.IsTrue(sum == 0);
        }

        [TestMethod]
        public void Multiply()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Multiply(x, y);

            Assert.IsTrue(sum == 200);
        }

        [TestMethod]
        public void Substract()
        {
            var test = new Calc.Helper();
            int x = 20;
            int y = 10;
            var sum = test.Substract(x, y);

            Assert.IsTrue(sum == 10);
        }
    }
}
