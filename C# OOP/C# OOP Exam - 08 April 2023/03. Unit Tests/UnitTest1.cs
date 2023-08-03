using NUnit.Framework;

namespace RobotFactory.Tests
{
    using System.Collections.Generic;

    public class Tests
    {
        private Factory defaultFactory1;
        private Factory defaultFactory5;
        private Robot defaultRobot;
        private Supplement defaultSupplement1;
        private Supplement defaultSupplement3;

        [SetUp]
        public void Setup()
        {
            this.defaultFactory1 = new Factory("factory1", 1);
            this.defaultFactory5 = new Factory("factory5", 5);
            this.defaultRobot = new Robot("Rick-090", 1000, 1);
            this.defaultSupplement1 = new Supplement("Laser MachineGun", 1);
            this.defaultSupplement3 = new Supplement("Laser Gun", 3);
        }


        [Test]
        public void ConstructorShouldInitializeFactory()
        {
            Factory factory = new Factory("factory", 1);

            Assert.IsNotNull(factory);
        }

        [Test]
        public void ConstructorShouldInitializeNameProperty()
        {
            Factory factory = new Factory("factory", 1);

            string expectedName = "factory";
            string actualnaName = factory.Name;

            Assert.AreEqual(expectedName, actualnaName);
        }

        [Test]
        public void ConstrucorShouldInitializeCapacityProperty()
        {
            Factory factory = new Factory("factory", 1);

            int expectedCapacity = 1;
            int actualCapacity = factory.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void ConstructorShouldInitializeAnEmptyRobotCollection()
        {
            Factory factory = new Factory("factory", 1);

            Assert.IsNotNull(factory.Robots);
            Assert.IsEmpty(factory.Robots);
        }

        [Test]
        public void ConstrucorShouldInitializeAnEmptySupplementCollection()
        {
            Factory factory = new Factory("factory", 1);

            Assert.IsNotNull(factory.Supplements);
            Assert.IsEmpty(factory.Supplements);
        }

        [Test]
        public void ProduceRobotMethodShouldAddRobotToTheRobotCollection()
        {
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);

            int expectedRobotCount = 1;
            int actualRobotCount = this.defaultFactory1.Robots.Count;

            Assert.AreEqual(expectedRobotCount, actualRobotCount);
        }

        [Test]
        public void ProduceRobotMethodShouldAddCorrectRobotToTheCollection()
        {
            string expectedResult = $"Produced --> {this.defaultRobot}";
            string actualResult = this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ProduceRobotMethodShouldNotAddRobotToTheCollectionWhenAboveCapacity()
        {
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);

            int expectedRobotCount = 1;
            int actualRobotCount = this.defaultFactory1.Robots.Count;

            Assert.AreEqual(expectedRobotCount, actualRobotCount);
        }

        [Test]
        public void ProduceMethodShouldReturnCorrectMessageWhenOverCapacity()
        {
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);

            string expectedResult = $"The factory is unable to produce more robots for this production day!";
            string actualResult = this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ProduceSupplementMethodShouldAddSupplementToTheCollection()
        {
            this.defaultFactory1.ProduceSupplement(this.defaultSupplement3.Name,
                this.defaultSupplement3.InterfaceStandard);
            this.defaultFactory1.ProduceSupplement(this.defaultSupplement3.Name,
                this.defaultSupplement3.InterfaceStandard);

            int expectedSupplementCount = 2;
            int actualSupplementCount = this.defaultFactory1.Supplements.Count;

            Assert.AreEqual(expectedSupplementCount, actualSupplementCount);
        }

        [Test]
        public void ProduceSupplementMethodShouldAddCorrectSupplementToTheCollection()
        {
            string expectedResult = this.defaultSupplement3.ToString();
            string actualResult = this.defaultFactory1.ProduceSupplement(this.defaultSupplement3.Name,
                this.defaultSupplement3.InterfaceStandard);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void UpgradeRobotMethodShouldAddSupplementToRobot()
        {
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);
            this.defaultFactory1.ProduceSupplement(this.defaultSupplement1.Name,
                this.defaultSupplement1.InterfaceStandard);

            this.defaultFactory1.UpgradeRobot(this.defaultRobot, this.defaultSupplement1);

            List<Supplement> expectedSupplements = new List<Supplement>() { this.defaultSupplement1 };
            List<Supplement> actualSupplements = this.defaultRobot.Supplements;

            CollectionAssert.AreEqual(expectedSupplements, actualSupplements);
        }

        [Test]
        public void UpgradeRobotMethodShouldReturnTrueWhenSuccessful()
        {
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);
            this.defaultFactory1.ProduceSupplement(this.defaultSupplement1.Name,
                this.defaultSupplement1.InterfaceStandard);

            bool expectedResult = true;
            bool actualResult = this.defaultFactory1.UpgradeRobot(this.defaultRobot, this.defaultSupplement1);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void UpgradeRobotMethodShouldReturnFalseIfRobotAlreadyHasSupplement()
        {
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);
            this.defaultFactory1.ProduceSupplement(this.defaultSupplement1.Name,
                this.defaultSupplement1.InterfaceStandard);

            this.defaultFactory1.UpgradeRobot(this.defaultRobot, this.defaultSupplement1);

            bool expectedResult = false;
            bool actualResult = this.defaultFactory1.UpgradeRobot(this.defaultRobot, this.defaultSupplement1);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void UpgradeRobotMethodShouldReturnFalseIfInterfaceStarndardsDontMatch()
        {
            this.defaultFactory1.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);
            this.defaultFactory1.ProduceSupplement(this.defaultSupplement3.Name,
                this.defaultSupplement3.InterfaceStandard);

            bool expectedResult = false;
            bool actualResult = this.defaultFactory1.UpgradeRobot(this.defaultRobot, this.defaultSupplement3);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SellRobotMethodShouldFirstRobotWhosePriceIsLessThanOrEqualToTheGiven()
        {
            this.defaultFactory5.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);
            this.defaultFactory5.ProduceRobot("Daryl-100", 1000, 1);
            this.defaultFactory5.ProduceRobot("Negan-999", 5000, 5);
            this.defaultFactory5.ProduceRobot("Michonne-0", 10, 1);

            string expectedSoldRobot = this.defaultRobot.ToString();
            string actualSoldRobot = this.defaultFactory5.SellRobot(1000).ToString();

            Assert.AreEqual(expectedSoldRobot, actualSoldRobot);
        }

        [Test]
        public void SellRobotMethodShouldReturnNullWhenThereAreNoMatches()
        {
            this.defaultFactory5.ProduceRobot(this.defaultRobot.Model, this.defaultRobot.Price,
                this.defaultRobot.InterfaceStandard);
            this.defaultFactory5.ProduceRobot("Daryl-100", 1000, 1);
            this.defaultFactory5.ProduceRobot("Negan-999", 5000, 5);
            this.defaultFactory5.ProduceRobot("Michonne-0", 10, 1);

            Robot expectedSoldRobot = null;
            Robot actualSoldRobot = this.defaultFactory5.SellRobot(5);

            Assert.AreEqual(expectedSoldRobot, actualSoldRobot);
        }
}
}