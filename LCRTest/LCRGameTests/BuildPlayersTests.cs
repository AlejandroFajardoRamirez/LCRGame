using LCRModel;
using NUnit.Framework;

namespace LCRTest.LCRGameTests
{
    public class BuildPlayersTests
    { 

        [Test]
        public void BuildPlayers_ReturnPlayresWith3ChipsAndATurn()
        {
            int numberOfPlayers = 4;
            var sut = new LCRGame(numberOfPlayers);

            sut.BuildPlayers();

            Assert.AreEqual(numberOfPlayers, sut.Players.Length);

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Assert.AreEqual(3, sut.Players[i].Chips);
                Assert.AreEqual(i, sut.Players[i].PlayerTurn);
            }

        }


    }
}