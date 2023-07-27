using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        [TestCase(100, 100, 100, 100)]
        public void AxeShouldInitializeWithCorrectValues(int attack, int durability, int expectedAttack, int expectedDurability)
        {
            Axe axe = new Axe(attack, durability);

            Assert.AreEqual(axe.AttackPoints, expectedAttack);
            Assert.AreEqual(axe.DurabilityPoints, expectedDurability);

        }

        [Test]
        [TestCase(10, 10, 10, 10, 9)]
        public void AxeShouldLooseDurabilityAfterAttack(int attack, int durability, int health, int experience, int expectedAxeDurability)
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, expectedAxeDurability);
        }

        [Test]
        [TestCase(10, 0, 10, 10)]
        public void AxeShouldNotBeUsedWhenBroken(int attack, int durability, int health, int xp)
        {
            Axe axe = new Axe(attack, durability);
            Dummy dummy = new Dummy(health, xp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);

            }, "Axe is broken.");
        }
    }
}