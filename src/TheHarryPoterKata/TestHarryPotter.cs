// Copyright (c) Gaurav Aroraa
// Licensed under the MIT License. See License.txt in the project root for license information.
using NUnit.Framework;

namespace TDD_Katas_project.TheHarryPotterKata
{
    [TestFixture]
    [Category("HarryPotterKata")]
    public class TestHarryPotter
    {
        private HarryPotter _harryPotter;

        [SetUp]
        public void Setup()
        {
            //Setup
            _harryPotter = new HarryPotter();
        }
        [TearDown]
        public void TearDown()
        {
            //TearDown
            _harryPotter = null;
        }

        [Test]
        [TestCase(new [] { 1 }, 8.00)]
        [TestCase(new [] { 2 }, 8.00)]
        [TestCase(new [] { 3 }, 8.00)]
        [TestCase(new [] { 4 }, 8.00)]
        [TestCase(new [] { 5 }, 8.00)]
        public void CanCalculateOneBook(int[] bookTitles, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, _harryPotter.CalculatePrice(bookTitles));
        }

        [Test]
        [TestCase(new [] { 0 }, 0.00)]
        [TestCase(new [] { -1 }, 0.00)]
        [TestCase(new [] { 6 }, 0.00)]
        public void EmptyOrInvalidSelectionCostsNothing(int[] bookTitles, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, _harryPotter.CalculatePrice(bookTitles));
        }

        [Test]
        [TestCase(new [] { 1, 1, 1 }, 24.00)]
        public void CanHandleMultipleSameTitleBooks(int[] bookTitles, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, _harryPotter.CalculatePrice(bookTitles));
        }

        [Test]
        [TestCase(new [] { 1, 2 }, 15.20)]
        [TestCase(new [] { 1, 2, 3 }, 21.60)]
        [TestCase(new [] { 1, 2, 3, 4 }, 25.60)]
        [TestCase(new [] { 1, 2, 3, 4, 5 }, 30.00)]
        public void CanHandleSimpleDiscount(int[] bookTitles, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, _harryPotter.CalculatePrice(bookTitles));
        }

        [Test]
        [TestCase(new [] { 1, 1, 2 }, 23.20)]
        public void CanHandleMixedOrder(int[] bookTitles, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, _harryPotter.CalculatePrice(bookTitles));
        }

        [Test]
        [TestCase(new [] { 1, 1, 2, 2 }, 30.40)]
        [TestCase(new [] { 1, 1, 2, 3, 3, 4 }, 40.80)]
        [TestCase(new [] { 1, 2, 2, 3, 4, 5 }, 38.00)]
        public void CanHandleMultipleDiscounts(int[] bookTitles, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, _harryPotter.CalculatePrice(bookTitles));
        }

        [Test]
        [TestCase(new [] { 1, 1, 2, 2, 3, 3, 4, 5 }, 51.20)]
        [TestCase(new [] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5 }, 141.20)]
        public void BestDiscountComboIsApplied(int[] bookTitles, double expectedTotal)
        {
            Assert.AreEqual(expectedTotal, _harryPotter.CalculatePrice(bookTitles));
        }
    }
}
