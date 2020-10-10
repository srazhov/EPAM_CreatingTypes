//-----------------------------------------------------------------------
// <copyright file="CreatingTypesTests.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace CreatingTypes.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests of <see cref="CreatingTypes"/> methods
    /// </summary>
    [TestFixture]
    public class CreatingTypesTests
    {
        /// <summary>
        /// Test of <see cref="CreatingTypes.FindNthRoot(double, int, double)"/> method
        /// </summary>
        /// <param name="number">Real number</param>
        /// <param name="degree">Natural number</param>
        /// <param name="precision">Needed precision</param>
        /// <returns>Root of number with given precision</returns>
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.0000001, ExpectedResult = 0.545)]
        public double FindNthRoot_Test(double number, int degree, double precision)
        {
            return CreatingTypes.FindNthRoot(number, degree, precision);
        }

        /// <summary>
        /// Test of <see cref="CreatingTypes.FindNthRoot(double, int, double)"/> method
        /// </summary>
        /// <param name="number">Real number</param>
        /// <param name="degree">Natural number</param>
        /// <param name="precision">Needed precision</param>
        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_Number_Degree_Precision_ArgumentOutOfRangeException(double number, int degree, double precision)
        {
            var ex = Assert.Throws<System.ArgumentException>(() => { CreatingTypes.FindNthRoot(number, degree, precision); });
            Assert.AreEqual("Value does not fall within the expected range.", ex.Message);
        }

        /// <summary>
        /// Test of <see cref="CreatingTypes.BubbleSortBySum(int[,], bool)"/>
        /// </summary>
        [Test]
        public void BubbleSortBySum_ReturnsSortedMatrix()
        {
            int[,] setup = new int[,]
            {
                { 3, 5, 6 },
                { 7, 34, 2 },
                { 9, 0, 21 }
            };

            int[,] expected = new int[,]
            {
                { 7, 34, 2 },
                { 9, 0, 21 },
                { 3, 5, 6 }
            };

            // Actual
            CreatingTypes.BubbleSortBySum(setup);

            Assert.AreEqual(expected, setup);
        }

        /// <summary>
        /// Test of <see cref="CreatingTypes.BubbleSortByMin(int[,], bool)"/>
        /// </summary>
        [Test]
        public void BubbleSortByMin_ReturnsSortedMatrix()
        {
            int[,] setup = new int[,]
            {
                { 3, 5, 6 },
                { 7, 34, 2 },
                { 9, 0, 21 }
            };

            int[,] expected = new int[,]
            {
                { 3, 5, 6 },
                { 7, 34, 2 },
                { 9, 0, 21 }
            };

            // Actual
            CreatingTypes.BubbleSortByMin(setup);

            Assert.AreEqual(expected, setup);
        }

        /// <summary>
        /// Test of <see cref="CreatingTypes.BubbleSortByMax(int[,], bool)"/>
        /// </summary>
        [Test]
        public void BubbleSortByMax_ReturnsSortedMatrix()
        {
            int[,] setup = new int[,]
            {
                { 3, 5, 6 },
                { 7, 34, 2 },
                { 9, 0, 21 }
            };

            int[,] expected = new int[,]
            {
                { 7, 34, 2 },
                { 9, 0, 21 },
                { 3, 5, 6 }
            };

            // Actual
            CreatingTypes.BubbleSortByMax(setup);

            Assert.AreEqual(expected, setup);
        }
    }
}