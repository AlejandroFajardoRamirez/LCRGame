using LCRModel;
using NUnit.Framework;
using System;

namespace LCRTest.LCRGameTests
{
    public class SetNextPlayerInTurnTest
    {
        LCRGame _sut;

        [SetUp]
        public void Setup()
        {  
           _sut = new LCRGame(3);
        }




        [Test]
        public void SetNextPlayerInTurn_CurrentTurnIsNull_ReturnTurnEqualsZero()
        {
            int? _currentPlayerInTurn = null;

            var result = _sut.SetNextPlayerInTurn(_currentPlayerInTurn);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(0, result.Value);
        }


        [Test]
        public void SetNextPlayerInTurn_CurrentTurnIsOne_ReturnTurnTwo()
        {
            int? _currentPlayerInTurn = 1;

            var result = _sut.SetNextPlayerInTurn(_currentPlayerInTurn);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(2, result.Value);
        }


        [Test]
        public void SetNextPlayerInTurn_CurrentTurnIsTwo_ReturnTurnEqualsZero()
        {
            int? _currentPlayerInTurn = 2;

            var result = _sut.SetNextPlayerInTurn(_currentPlayerInTurn);

            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(0, result.Value);
        }
    }
}