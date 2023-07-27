using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        [TestCase(10, 100, 10)]
        public void DummyShouldInitializeWithCorrectValuesForHealth(int health, int xp, int expectedHealth)
        {
            Dummy dummy = new Dummy(health, xp);

            Assert.AreEqual(dummy.Health, expectedHealth);
        }

        [Test]
        [TestCase(0, 10, 10)]
        public void DummyShouldInitializeWithCorrectValuesForXp(int health, int xp, int expectedXp)
        {
            Dummy dummy = new Dummy(health, xp);

            Assert.AreEqual(dummy.GiveExperience(), expectedXp);
        }
        [Test]
        [TestCase(10, 10, 15, 10, 5)]
        public void DummyShouldLoseHpIfAttacked(int attack, int durability, int health, int xp, int expectedDummyHp)
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(15, 10);

            axe.Attack(dummy);

            Assert.AreEqual(dummy.Health, expectedDummyHp);
        }

        [Test]
        [TestCase(10, 10, 0, 10)]

        public void DummyShouldNotBeAttackedWhenDead(int attack, int durability, int health, int xp)
        {
            Axe axe = new Axe(attack, durability);
            Dummy dummy = new Dummy(health, xp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Dummy is dead.");
        }

        [Test]
        [TestCase(0, 10, 10)]
        public void DeadDummyShouldGiveXp(int health, int xp, int expectedXp)
        {
            Dummy dummy = new Dummy(health, xp);

            Assert.AreEqual(dummy.GiveExperience(), expectedXp);
        }

        [Test]
        [TestCase(1, 10, 0)]
        public void AliveDummyShouldNotGiveXp(int health, int xp, int expectedExperience)
        {
            Dummy dummy = new Dummy(health, xp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                Assert.AreEqual(dummy.GiveExperience(), expectedExperience);
            }, "Target is not dead.");
        }
    }
}