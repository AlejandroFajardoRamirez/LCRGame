using LCRModel;
using NUnit.Framework;
using System;

namespace LCRTest.LCRGameTests
{
    public class ConstructorTests
    {
        [Test]
        public void GameConstructor_LowNumberOfPlayers_ThrowException()
        {
            int numberOfPlayers = 2;
            Assert.Throws<ApplicationException>(() => new LCRGame(numberOfPlayers));
        }

    }
}