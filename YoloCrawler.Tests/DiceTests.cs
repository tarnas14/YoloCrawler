﻿namespace YoloCrawler.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using NUnit.Framework;

    [TestFixture]
    public class DiceTests
    {
        private readonly YoloDice _yoloDice = new YoloDice();

        [Test]
        public void ShouldRollNumberFrom1To100WhenRolingK100()
        {
            // when
            var result = _yoloDice.RollK100();

            // then
            Assert.That(result, Is.InRange(1, 100));
        }

        [Test]
        public void ShouldRollForPlaceOnTheWallWhenPassigRoomWallSize()
        {
            // given
            const int wallSize = 10;

            // when
            var placeOnTheWall = _yoloDice.RollForPlaceOnTheWall(wallSize);

            // then
            Assert.That(placeOnTheWall, Is.InRange(1, 9));
        }

        [Test]
        public void ShouldRollForRandomRoomIndexBasedOnRoomCount()
        {
            // given
            const int roomCount = 4;

            // when
            var randomRoomIndex = _yoloDice.RollForRandomRoomIndex(roomCount);

            // then
            Assert.That(randomRoomIndex, Is.InRange(0, 3));
        }

        [Test]
        public void ShouldRollForHitpointsWhenMinAndMaxHitpointsValuesAreProvided()
        {
            // given
            const int minHitpoints = 1;
            const int maxHitpoints = 2;

            // when
            var hitpoints = _yoloDice.RollForHitpoints(minHitpoints, maxHitpoints);

            // then
            Assert.That(hitpoints, Is.InRange(minHitpoints, maxHitpoints));
        }

        [Test]
        public void ShouldRollForMonsterNameIndex()
        {
            // given
            const int monstersCount = 4;

            // when
            var nameIndexes = new List<int>();

            for (var i = 0; i < 100000; i++)
            {
                var nameIndex = _yoloDice.RollForMonsterNameIndex(monstersCount);
                nameIndexes.Add(nameIndex);
            }
            
            // then
            Assert.That(nameIndexes, Is.All.InRange(0, 3));
            Assert.That(nameIndexes.Contains(3), Is.True);
        }

        [Test]
        public void ShouldRollPositionInRoomWithMarginForWall()
        {
            // given
            var roomSize = new Size(20, 20);
            const int marginForWall = 1;

            // when
            var roomPositionX = new List<int>();
            var roomPositionY = new List<int>();

            for (var i = 0; i < 100000; i++)
            {
                var position = _yoloDice.RollPosition(roomSize.Width, roomSize.Height);
                roomPositionX.Add(position.X);
                roomPositionY.Add(position.Y);
            }

            // then
            Assert.That(roomPositionX, Is.All.InRange(1, roomSize.Width - marginForWall));
            Assert.That(roomPositionY, Is.All.InRange(1, roomSize.Height - marginForWall));
        }
    }
}