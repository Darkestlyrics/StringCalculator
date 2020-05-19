using System;
using System.Collections;
using System.Collections.Generic;
using String_Calculator;
using StringCalculatorTests.Classes;
using Xunit;

namespace StringCalculatorTests
{
    public class CalculatorTests
    {
        [Theory]
        [ClassData(typeof(ReturnsZeroTestData))]
        public void Add_ShouldBeZero(TestData testData)
        {
            //Arrange
            int actual = 0;
            int expected = testData.Result;
            Calculator calc = new Calculator();
            //Act
            actual = calc.Add(testData.Numbers);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(BasicTestData))]
        [ClassData(typeof(ComplexTestData))]
        public void Add_ValidTests(TestData testData)
        {
            //Arrange
            int actual = 0;
            int expected = testData.Result;
            Calculator calc = new Calculator();
            //Act
            actual = calc.Add(testData.Numbers);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [ClassData(typeof(ExceptionTestData))]
        public void Add_ExceptionTests(TestData testData)
        {
            //Arrange
            int actual = 0;
            int expected = testData.Result;
            Calculator calc = new Calculator();
            //Act


            //Assert
            Assert.Throws<Exception>(() => calc.Add(testData.Numbers));
        }
    }

    public class BasicTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new TestData("1", 1) };
            yield return new object[] { new TestData("2", 2) };
            yield return new object[] { new TestData("1,2", 3) };
            yield return new object[] { new TestData("1,3", 4) };
            yield return new object[] { new TestData("10,30", 40) };
            yield return new object[] { new TestData("10,20,30,40,50,60,70,80,90", 450) };
            yield return new object[] { new TestData("1001,1", 1) };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class ComplexTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new TestData("1\n2", 3) };
            yield return new object[] { new TestData("//A\n1A2", 3) };
            yield return new object[] { new TestData("//B\n1B2", 3) };
            yield return new object[] { new TestData("//AAA\n1AAA2AAA3", 6) };
            yield return new object[] { new TestData("//[AB][bc]\n1AB2bc3", 6) };
            yield return new object[] { new TestData("//[***]\n1***2***3", 6) };
            yield return new object[] { new TestData("//[*][%]\n1*2%3", 6) };


        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class ReturnsZeroTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new TestData("", 0) };
            yield return new object[] { new TestData("\n", 0) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ExceptionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new TestData("-1", 0) };
            yield return new object[] { new TestData("-3", 0) };
            yield return new object[] { new TestData("-3,-5,1", 0) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
