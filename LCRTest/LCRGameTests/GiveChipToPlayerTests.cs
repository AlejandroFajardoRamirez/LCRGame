using LCRModel;
using LCRModel.Entities;
using NUnit.Framework;
using System;

namespace LCRTest.LCRGameTests
{
    public class GiveChipToPlayerTests
    {

        LCRGame _sut;

        [SetUp]
        public void Setup()
        {  
           _sut = new LCRGame(3);
            _sut.BuildPlayers();
        }      

        [Test]
        public void GiveChipToPlayer_PlayerZeroFaceL_GiveChipToPlayerTwo() {

            var player = _sut.Players[0];
            var currentChips = player.Chips;

            var dieFace = DieFace.L;

            var leftPlayer = _sut.Players[2];
            var leftPlayerCurrentChips = leftPlayer.Chips;

            _sut.GiveChipToPlayer(player, dieFace);

            Assert.AreEqual(currentChips - 1, player.Chips,"Player lose one chip");
            Assert.AreEqual(leftPlayerCurrentChips + 1, leftPlayer.Chips, "Left Player gain one chip");
        }

        [Test]
        public void GiveChipToPlayer_PlayerZeroFaceR_GiveChipToPlayerOne()
        {
            var player = _sut.Players[0];
            var currentChips = player.Chips;

            var dieFace = DieFace.R;

            var rightPlayer = _sut.Players[1];
            var rightPlayerCurrentChips = rightPlayer.Chips;

            _sut.GiveChipToPlayer(player, dieFace);

            Assert.AreEqual(currentChips - 1, player.Chips, "Player lose one chip");
            Assert.AreEqual(rightPlayerCurrentChips + 1, rightPlayer.Chips, "Right Player gain one chip");
        }

        [Test]
        public void GiveChipToPlayer_PlayerZeroFaceC_KeepsTheyChips()
        {
            var player = _sut.Players[0];
            var currentChips = player.Chips;

            var dieFace = DieFace.DOT;

            var rightPlayer = _sut.Players[1];
            var rightPlayerCurrentChips = rightPlayer.Chips;

            var leftPlayer = _sut.Players[2];
            var leftPlayerCurrentChips = leftPlayer.Chips;

            _sut.GiveChipToPlayer(player, dieFace);

            Assert.AreEqual(currentChips, player.Chips, "Player keeps they chips");
            
            
            Assert.AreEqual(rightPlayerCurrentChips, rightPlayer.Chips, "Right Player they chips");
            Assert.AreEqual(leftPlayerCurrentChips, leftPlayer.Chips, "Left Player they chips");
        }

        [Test]
        public void GiveChipToPlayer_PlayerZeroFaceDOT_KeepsTheyChips()
        {
            var player = _sut.Players[0];
            var currentChips = player.Chips;

            var dieFace = DieFace.DOT;

            var rightPlayer = _sut.Players[1];
            var rightPlayerCurrentChips = rightPlayer.Chips;

            var leftPlayer = _sut.Players[2];
            var leftPlayerCurrentChips = leftPlayer.Chips;

            _sut.GiveChipToPlayer(player, dieFace);

            Assert.AreEqual(currentChips, player.Chips, "Player keeps they chips");


            Assert.AreEqual(rightPlayerCurrentChips, rightPlayer.Chips, "Right Player they chips");
            Assert.AreEqual(leftPlayerCurrentChips, leftPlayer.Chips, "Left Player they chips");
        }
    }
}
