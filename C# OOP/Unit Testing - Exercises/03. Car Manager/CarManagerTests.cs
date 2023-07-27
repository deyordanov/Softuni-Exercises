namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    [TestFixture]
    public class CarManagerTests
    {
        private Car defaultCar;

        [SetUp]
        public void SetUp()
        {
            defaultCar = new Car("Toyota", "Land Cruiser Prado", 13, 85);
        }


        [Test]
        public void ConstructorShouldInitializeCarMake()
        {
            string expectedMake = "Toyota";
            Car car = new Car(expectedMake, "Land Cruiser Prado", 13, 85);

            string actualMake = car.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void ConstructorShouldInitializeCarModel()
        {
            string expectedModel = "Land Cruiser Prado";
            Car car = new Car("Toyota", expectedModel, 13, 85);

            string actualModel = car.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void ConstructorShouldInitializeCarFuelConsumption()
        {
            double expectedFuelConsumption = 13;
            Car car = new Car("Toyota", "Land Cruiser Prado", expectedFuelConsumption, 85);

            double actualFuelConsumption = car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        public void ConstructorShouldInitializeCarFuelCapacity()
        {
            double expectedFuelCapacity = 85;
            Car car = new Car("Toyota", "Land Cruiser Prado", 13, expectedFuelCapacity);

            double actualFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void ConstructorShouldInitializeCarFuelAmountAtZero()
        {
            double expectedFuelAmount = 0;
            Car car = new Car("Toyota", "Land Cruiser Prado", 13, 85);

            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase("T")]
        [TestCase("Mercedes")]
        [TestCase("Very very very very very very very very very very very very very very very very very long make")]
        [TestCase(" ")]
        public void MakeSetterShouldSetTheCorrectValue(string make)
        {
            string expectedMake = make;
            Car car = new Car(expectedMake, "Land Cruiser Prado", 13, 85);

            string actualMake = car.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [TestCase(null)]
        public void MakeSetterShouldThrowAnExceptionIfValueIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "Land Cruiser Prado", 13, 85);
            }, "Make cannot be null or empty!");
        }

        [TestCase("Land Cruiser Prado")]
        [TestCase("M")]
        [TestCase(" ")]
        [TestCase("Very very very very very very very very very very very very very very very very very long make")]
        public void ModelSetterShouldSetTheCorrectValue(string model)
        {
            string expectedModel = model;
            Car car = new Car("Toyota", expectedModel, 13, 85);

            string actualModel = car.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }

        [TestCase(null)]
        public void ModelSetterShouldThrowAnExceptionIfValueIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", model, 13, 85);
            }, "Model cannot be null or empty!");
        }

        [TestCase(0.0001)]
        [TestCase(100000)]
        public void FuelConsumptionSetterShouldSetTheCorrectValue(double fuelConsumption)
        {
            double expectedFuelConsumption = fuelConsumption;
            Car car = new Car("Toyota", "Land Cruiser Prado", expectedFuelConsumption, 85);

            double actualFuelConsumption = car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [TestCase(0)]
        [TestCase(-0.00001)]
        [TestCase(-1000000000)]
        public void FuelConsumptionSetterShouldThrowAnExceptionIfValueLessThanOrEqualToZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", "Land Cruiser Prado", fuelConsumption, 85);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0.000001)]
        [TestCase(10000000)]
        public void FuelCapacitySetterShouldSetTheCorrectValue(double fuelCapacity)
        {
            double expectedFuelCapacity = fuelCapacity;
            Car car = new Car("Toyota", "Land Cruiser Prado", 13, expectedFuelCapacity);

            double actualFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-0.000001)]
        [TestCase(-1000000)]
        public void FuelCapacitySetterShouldThrowAnExceptionIfValueLessThanOrEqualToZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", "Land Cruiser Prado", 13, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0.001)]
        [TestCase(84.99)]
        [TestCase(40)]
        public void RefuelMethodShouldIncreaseCarFuelAmount(double fuel)
        {
            double expectedFuelAmount = fuel;
            this.defaultCar.Refuel(fuel);

            double actualFuelAmount = this.defaultCar.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(85.1)]
        [TestCase(10000)]
        public void RefuelMethodShouldNotIncreaseFuelAmountAboveFuelCapacity(double fuel)
        {
            double expectedFuelAmount = 85;
            
            this.defaultCar.Refuel(fuel);
            double actualFuelAmount = this.defaultCar.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(-0.0001)]
        [TestCase(0)]
        [TestCase(-100000)]
        public void RefuelMethodShouldNotRefuelWithValueLessThanOrEqualToZero(double fuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.defaultCar.Refuel(fuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(85, 30)]
        [TestCase(85, 0.1)]
        [TestCase(85, 100)]
        public void DriveMethodShouldDecreaseFuelAmount(double fuel, double distance)
        {
            double fuelNeeded = (distance / 100) * this.defaultCar.FuelConsumption;
            double expectedFuelAmount = fuel - fuelNeeded;

            this.defaultCar.Refuel(fuel);
            this.defaultCar.Drive(distance);
            double actualFuelAmount = this.defaultCar.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(1000)]
        [TestCase(0.0001)]
        [TestCase(200)]
        public void DriveMethodShouldThrowAnExceptionIfFuelAmountIsInsufficientForADrive(double distance)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultCar.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }
    }
}