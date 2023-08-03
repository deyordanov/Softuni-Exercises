using NUnit.Framework;

namespace Computers.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Tests
    {
        private ComputerManager defaultPcManager;
        private Computer defaultPc;
        [SetUp]
        public void Setup()
        {
            this.defaultPcManager = new ComputerManager();
            this.defaultPc = new Computer("Dell", "G15", 5000);
        }

            [Test]
        public void ConstructorShouldInitializeComputerManager()
        {
            ComputerManager pc = new ComputerManager();

            Assert.IsNotNull(pc);
        }

        [Test]
        public void ConstructorShouldInitializeInnerCollection()
        {
            ComputerManager pc = new ComputerManager();

            Assert.IsEmpty(pc.Computers);
        }

        [Test]
        public void CountMethodShouldReturnCorrectCount()
        {
            this.defaultPcManager.AddComputer(this.defaultPc);

            int expectedCount = 1;
            int actualCount = this.defaultPcManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddComputerMethodShouldIncreaseCollectionCount()
        {
            this.defaultPcManager.AddComputer(this.defaultPc);

            int expectedCount = 1;
            int actualCount = this.defaultPcManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddComputerMethodShouldAddCorrectComputersToTheCollection()
        {
            this.defaultPcManager.AddComputer(this.defaultPc);

            Computer expectedPc = this.defaultPc;
            Computer actualPc = this.defaultPcManager.GetComputer(this.defaultPc.Manufacturer, this.defaultPc.Model);

            Assert.AreEqual(expectedPc, actualPc);
        }

        [Test]
        public void AddComputerMethodShouldThrowAnExceptionWhenGivenNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.defaultPcManager.AddComputer(null);
            }, "Can not be null!");
        }

        [Test]
        public void AddComputerMethodShouldThrowAnExceptionWhenAddingAnAlreadyExistingComputer()
        {
            this.defaultPcManager.AddComputer(this.defaultPc);

            Assert.Throws<ArgumentException>(() =>
            {
                this.defaultPcManager.AddComputer(this.defaultPc);
            }, "This computer already exists.");
        }

        [Test]
        public void RemoveComputerMethodShouldDecreaseCount()
        {
            this.defaultPcManager.AddComputer(this.defaultPc);

            this.defaultPcManager.RemoveComputer(this.defaultPc.Manufacturer, this.defaultPc.Model);

            int expectedPcCount = 0;
            int actualPcCount = this.defaultPcManager.Count;

            Assert.AreEqual(expectedPcCount, actualPcCount);
        }

        [Test]
        public void RemoveMethodShouldRemoveCorrectComputer()
        {
            this.defaultPcManager.AddComputer(this.defaultPc);

            Computer expectedPc = this.defaultPc;

            Computer actualPc = this.defaultPcManager.RemoveComputer(this.defaultPc.Manufacturer, this.defaultPc.Model);

            Assert.AreEqual(expectedPc, actualPc);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionWithInvalidComputer()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.defaultPcManager.GetComputer("Asus", "Sad");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerMethodShouldThrowAnExceptionIfGivenNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.defaultPcManager.GetComputer(null, "G15");
            }, "Can not be null!");
        }

        [Test]
        public void GetComputerMethodShouldThrowAnExceptionWhenGivenNullModel()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.defaultPcManager.GetComputer("Dell", null);
            }, "Can not be null!");
        }

        [Test]
        public void GetComputerMethodShouldThrowAnExceptionWhenSuchAComputerDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.defaultPcManager.GetComputer("Asus", "Sad");
            }, "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerMethodShouldReturnCorrectComputer()
        {
            this.defaultPcManager.AddComputer(this.defaultPc);

            Computer expectedPc = this.defaultPc;
            Computer actualPc = this.defaultPcManager.GetComputer(this.defaultPc.Manufacturer, this.defaultPc.Model);

            Assert.AreEqual(expectedPc, actualPc);
        }

        [Test]
        public void GetComputersByManufacturerMethodShouldThrowAnExceptionWhenGivenNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.defaultPcManager.GetComputersByManufacturer(null);
            }, "Can not be null!");
        }

        [Test]
        public void GetComputersByManufacturerMethodShouldReturnACollectionOfComputers()
        {
            Computer pc1 = new Computer("Dell", "G14", 4000);
            Computer pc2 = new Computer("Asus", "Sad", 100);
            this.defaultPcManager.AddComputer(pc1);
            this.defaultPcManager.AddComputer(pc2);
            this.defaultPcManager.AddComputer(this.defaultPc);

            List<Computer> expectedComputers = new List<Computer>() { pc1, this.defaultPc };
            List<Computer> actualComputers = this.defaultPcManager.GetComputersByManufacturer("Dell").ToList();

            CollectionAssert.AreEqual(expectedComputers, actualComputers);
        }

        [Test]
        public void GetComputersByManufacturerMethodShouldReturnEmptyCollectionWhenThereAreNotMatches()
        {
            int expectedCount = 0;
            int actualCount = this.defaultPcManager.GetComputersByManufacturer("Dell").Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}