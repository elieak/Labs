using System;
using Lab2._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Calculations_AddMaxValue_MaxValueOverFlow()
        {
            Calculations myCalc = new Calculations();
            double _num1 = Double.MaxValue;
            double _num2 = 1;
            myCalc.Add(_num1, _num2);
        }

        [TestMethod]
        public void Calculations_SubstractMinValue_MinValueUnderFlow()
        {
            Calculations myCalc = new Calculations();
            double _num1 = Double.MinValue;
            double _num2 = 1;
            myCalc.Substract(_num1, _num2);
        }

        [TestMethod]
        public void Calculations_Add2Numbers_DoubleNumbers()
        {
            Calculations myCalc = new Calculations();
            double _num1 = 1;
            double _num2 = 9;

            Assert.AreEqual(10, myCalc.Add(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_Substract2Numbers_DoubleNumbers()
        {
            Calculations myCalc = new Calculations();
            double _num1 = 1;
            double _num2 = 9;

            Assert.AreEqual(-8, myCalc.Substract(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_SubstractPositiveNumber_FromNegativeNumber_CorrectResult()
        {
            Calculations myCalc = new Calculations();
            double _num1 = -32;
            double _num2 = 9;

            Assert.AreEqual(-41, myCalc.Substract(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_SubstractNegativeNumber_FromPositiveNumber_CorrectResult()
        {
            Calculations myCalc = new Calculations();
            double _num1 = 32;
            double _num2 = -9;

            Assert.AreEqual(41, myCalc.Substract(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_SubstractNegativeNumber_FromNegativeNumber_CorrectResult()
        {
            Calculations myCalc = new Calculations();
            double _num1 = -32;
            double _num2 = -9;

            Assert.AreEqual(-23, myCalc.Substract(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_Multiply2Numbers_DoubleNumbers()
        {
            Calculations myCalc = new Calculations();
            double _num1 = 10;
            double _num2 = 9;

            Assert.AreEqual(90, myCalc.Multiply(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_Multiply2NegativeNumbers_PositiveOutcome()
        {
            Calculations myCalc = new Calculations();
            double _num1 = -10;
            double _num2 = -9;

            Assert.AreEqual(90, myCalc.Multiply(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_Multiply1NegativeNumber_NegativeOutcome()
        {
            Calculations myCalc = new Calculations();
            double _num1 = -10;
            double _num2 = 9;

            Assert.AreEqual(-90, myCalc.Multiply(_num1, _num2));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculations_Divide_DivideByZero()
        {
            Calculations myCalc = new Calculations();
            double numerator = 9;
            double denominator = 0;
            myCalc.Divide(numerator, denominator);
        }

        [TestMethod]
        public void Calculations_Divide2Numbers_DoubleNumbers()
        {
            Calculations myCalc = new Calculations();
            double _num1 = 18;
            double _num2 = 9;

            Assert.AreEqual(2, myCalc.Divide(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_Divide2NegativeNumbers_DoubleNumbers()
        {
            Calculations myCalc = new Calculations();
            double _num1 = -18;
            double _num2 = -9;

            Assert.AreEqual(2, myCalc.Divide(_num1, _num2));
        }

        public void Calculations_DivideNegativeDenominator_DoubleNumbers()
        {
            Calculations myCalc = new Calculations();
            double _num1 = 18;
            double _num2 = -9;

            Assert.AreEqual(-2, myCalc.Divide(_num1, _num2));
        }

        [TestMethod]
        public void Calculations_DivideNegativeNominator_DoubleNumbers()
        {
            Calculations myCalc = new Calculations();
            double _num1 = -18;
            double _num2 = 9;

            Assert.AreEqual(-2, myCalc.Divide(_num1, _num2));
        }
    }
}
