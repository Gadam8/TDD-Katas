// Copyright (c) Gaurav Aroraa
// Licensed under the MIT License. See License.txt in the project root for license information.
using NUnit.Framework;

namespace TDD_Katas_project.ThePokerHandsKata
{
    [TestFixture]
    [Category("PokerHandsKata")]
    public class TestPokerHands
    {
        private PokerHands _pokerHands;

        [SetUp]
        public void Setup()
        {
            _pokerHands = new PokerHands();
        }
        [TearDown]
        public void TearDown()
        {
            _pokerHands = null;
        }

        [Test]
        [TestCase(
            new [] {"3H", "3D", "7S", "10C", "QH"}, 
            new [] {"2D", "7D", "2S", "JC", "10H"}, 
            "Hand 1 wins - high card: Queen"
        )]
        public void CanDetermineHighCardWinner(string[] hand1, string[] hand2, string result)
        {   
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"6S", "2S", "KD", "2C", "KH"}, 
            new [] {"4H", "3D", "10S", "QC", "10H"}, 
            "Hand 1 wins - pair: King"
        )]
        public void CanDeterminePairWinner(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"5C", "9S", "AC", "JD", "9H"}, 
            new [] {"4D", "4H", "JS", "8C", "JH"}, 
            "Hand 2 wins - two pairs: 4 and Jack"
        )]
        public void CanDetermineTwoPairsWinner(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"7H", "KC", "7S", "7D", "QH"}, 
            new [] {"2D", "4S", "4H", "JC", "10H"}, 
            "Hand 1 wins - three of a kind: 7"
        )]
        public void CanDetermineThreeOfaKindWinner(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"7C", "6S", "5S", "4H", "3H"},
            new [] {"2D", "7D", "2S", "JC", "10H"},
            "Hand 1 wins - straight: 7 high"
        )]
        public void CanDetermineStraightWinner(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"5C", "9S", "AC", "JD", "9H"}, 
            new [] {"KC", "10C", "7C", "6C", "4C"}, 
            "Hand 2 wins - flush: King high"
        )]
        public void CanDetermineFlushWinner(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"3H", "3D", "7S", "10C", "QH"}, 
            new [] {"JC", "JH", "2S", "JD", "2H"}, 
            "Hand 2 wins - full house: Jack over 2"
        )]
        public void CanDetermineFullHouseWinner(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"AH", "3S", "AD", "AS", "AC"}, 
            new [] {"3D", "7D", "2S", "JC", "9H"}, 
            "Hand 1 wins - four of a kind: Jack"
        )]
        public void CanDetermineFourOfaKindWinner(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"JC", "JS", "2S", "JD", "2H"}, 
            new [] {"8H", "QH", "10H", "JH", "9H"}, 
            "Hand 2 wins - straight flush: Queen high"
        )]
        public void CanDetermineStraightFlushWinner(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"2H", "3D", "5S", "9C", "KD"}, 
            new [] {"2D", "3H", "5C", "9S", "KH"}, 
            "Tie"
        )]
        public void CanProcessTies(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"10C", "AC", "KC", "JC", "QC"}, 
            new [] {"8H", "QH", "10H", "JH", "9H"}, 
            "Hand 1 wins - straight flush: Ace high"
        )]
        [TestCase(
            new [] {"7C", "6S", "5S", "4H", "3H"},
            new [] {"5C", "9S", "7H", "6C", "8D"},
            "Hand 2 wins - straight: 9 high"
        )]
        [TestCase(
            new [] {"7H", "KC", "7S", "7D", "QH"}, 
            new [] {"10H", "KH", "10S", "10D", "QC"}, 
            "Hand 2 wins - three of a kind: 10"
        )]
        public void CanProcessDetermineWinnerFromInitialTie(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }

        [Test]
        [TestCase(
            new [] {"3H", "3D", "7S", "10C"}, 
            new [] {"2D", "7D", "2S", "JC", "10H"}, 
            "Invalid input: Both hands must contain 5 cards"
        )]
        [TestCase(
            new [] {"3H", "3D", "7S", "10C", "4D"}, 
            new [] {"2D", "7D", "2S", "JC", "10H"}, 
            "Invalid input: Both hands must be unique"
        )]
        [TestCase(
            new [] {"12H", "3D", "7S", "10C", "4D"}, 
            new [] {"2D", "7D", "2S", "JC", "10H"}, 
            "Invalid input: Cards must have a valid value (2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A) and valid suit (H, D, C, S)"
        )]
        public void CanHandleInvalidInput(string[] hand1, string[] hand2, string result)
        {
            Assert.AreEqual(result, _pokerHands.ProcessCards(hand1, hand2));
        }
    }
}
