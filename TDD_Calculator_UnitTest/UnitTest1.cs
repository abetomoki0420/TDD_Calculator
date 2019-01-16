using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Calculator;

namespace TDD_Calculator_UnitTest
{
    [TestClass]
    public class Calculator_UnitTest
    {
        private Calculator calculator;
        [TestInitialize]
        public void TestInitialize()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Calculator_Add_Test1()
        {
            calculator.setValue(1);
            calculator.Calculate("Add");
            calculator.setValue(2);
            var result = calculator.Equal();
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void Calculator_Add_Test2()
        {
            calculator.setValue(4);
            calculator.Calculate("Add");
            calculator.setValue(8);
            var result = calculator.Equal();
            Assert.AreEqual(result, 12);
        }


        [TestMethod]
        public void Calculator_Subtract_Test1()
        {
            calculator.setValue(10);
            calculator.Calculate("Subtract");
            calculator.setValue(2);
            var result = calculator.Equal();
            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public void Calculator_Subtract_Test2()
        {
            calculator.setValue(0);
            calculator.Calculate("Subtract");
            calculator.setValue(2);
            var result = calculator.Equal();
            Assert.AreEqual(result, -2);
        }

        [TestMethod]
        public void Calculator_Multiply_Test1()
        {
            calculator.setValue(2);
            calculator.Calculate("Multiply");
            calculator.setValue(3);
            var result = calculator.Equal();
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void Calculator_Multiply_Test2()
        {
            calculator.setValue(2);
            calculator.Calculate("Multiply");
            calculator.setValue(-3);
            var result = calculator.Equal();
            Assert.AreEqual(result, -6);
        }

        [TestMethod]
        public void Calculator_Devide_Test1()
        {
            calculator.setValue(4);
            calculator.Calculate("Divide");
            calculator.setValue(2);
            var result = calculator.Equal();
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void Calculator_Devide_Test2()
        {
            calculator.setValue(5);
            calculator.Calculate("Divide");
            calculator.setValue(2);
            var result = calculator.Equal();
            Assert.AreEqual(result, 2.5);
        }

        [TestMethod]
        public void Calculator_Devide_Test3()
        {
            calculator.setValue(-10);
            calculator.Calculate("Divide");
            calculator.setValue(-2);
            var result = calculator.Equal();
            Assert.AreEqual(result, 5);
        }


        [TestMethod]
        public void Calculator_MultiCaluculation_Test1()
        {
            //2 + 5 - 3 = 4
            calculator.setValue(2);
            calculator.Calculate("Add");
            calculator.setValue(5);
            calculator.Calculate("Subtract");
            calculator.setValue(3);
            var result = calculator.Equal();
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void Calculator_MultiCaluculation_Test2()
        {
            //2 * 5 + 6 = 16
            calculator.setValue(2);
            calculator.Calculate(Operator.Multiply);
            calculator.setValue(5);
            calculator.Calculate(Operator.Add);
            calculator.setValue(6);
            var result = calculator.Equal();
            Assert.AreEqual(result, 16);
        }

        [TestMethod]
        public void Calculator_MultiCaluculation_Test3()
        {
            //10 / 5 - 4 = -2
            calculator.setValue(10);
            calculator.Calculate(Operator.Divide);
            calculator.setValue(5);
            calculator.Calculate(Operator.Subtract);
            calculator.setValue(4);
            var result = calculator.Equal();
            Assert.AreEqual(result, -2);
        }

        [TestMethod]
        public void Calculator_MultiCaluculation_Progress_Test1()
        {
            //1 + 3 = 4
            //4 + 5 = 9
            calculator.setValue(1);
            calculator.Calculate(Operator.Add);
            calculator.setValue(3);
            var result = calculator.Calculate(Operator.Add);
            Assert.AreEqual(result, 4);
            calculator.setValue(5);
            Assert.AreEqual(calculator.Equal(), 9);
        }

        [TestMethod]
        public void Calculator_MultiCaluculation_Progress_Test2()
        {
            //3 - 2 = 1
            //1 - 2 = -1
            calculator.setValue(3);
            calculator.Calculate(Operator.Subtract);
            calculator.setValue(2);
            var result = calculator.Calculate(Operator.Subtract);
            Assert.AreEqual(result, 1);
            calculator.setValue(2);
            Assert.AreEqual(calculator.Equal(), -1);
        }

        [TestMethod]
        public void Calculator_MultiCaluculation_Progress_Test3()
        {
            //3 * 4 = 12
            //12 / 2 = 6
            calculator.setValue(3);
            calculator.Calculate(Operator.Multiply);
            calculator.setValue(4);
            var result = calculator.Calculate(Operator.Divide);
            Assert.AreEqual(result, 12);
            calculator.setValue(2);
            result = calculator.Equal();
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void Calculator_Clear_Test1()
        {
            calculator.setValue(1);
            calculator.Calculate(Operator.Add);
            calculator.setValue(2);
            calculator.Clear();
            var result = calculator.Equal();
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void Calculator_Clear_Test2()
        {
            calculator.setValue(1);
            calculator.Calculate(Operator.Add);
            calculator.setValue(2);
            calculator.Clear();
            calculator.setValue(4);
            calculator.Calculate(Operator.Multiply);
            calculator.setValue(3);
            var result = calculator.Equal();
            Assert.AreEqual(result, 12);
        }

        [TestMethod]
        public void Calculator_Continuty_Test1()
        {
            calculator.setValue(1);
            calculator.Calculate(Operator.Add);
            calculator.setValue(2);
            var result = calculator.Equal();
            Assert.AreEqual(result, 3);
            calculator.setValue(result);
            calculator.Calculate(Operator.Add);
            calculator.setValue(3);
            result = calculator.Equal();
            Assert.AreEqual(result, 6);
            calculator.setValue(result);
            calculator.Calculate(Operator.Subtract);
            calculator.setValue(1);
            result = calculator.Equal();
            Assert.AreEqual(result, 5);
        }
    }
}
