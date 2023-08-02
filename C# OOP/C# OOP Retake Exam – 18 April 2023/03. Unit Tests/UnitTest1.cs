using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Garage defaultGarage1;
        private Garage defaultGarage3;
        private Vehicle defaultVehicle1;
        private Vehicle defaultVehicle2;
        private Vehicle defaultVehicle3;
        [SetUp]
        public void Setup()
        {
            this.defaultGarage1 = new Garage(1);
            this.defaultGarage3 = new Garage(3);
            this.defaultVehicle1 = new Vehicle("Toyota", "Land Cruiser 300", "77KING77");
            this.defaultVehicle2 = new Vehicle("Toyoya", "Supra", "777777");
            this.defaultVehicle3 = new Vehicle("BMW", "X7", "X7X7X7X7");
        }

        [Test]
        public void ConstructorShouldCreateAnInstanceOfGarage()
        {
            Garage garage = new Garage(1);

            Assert.IsNotNull(garage);
        }

        [TestCase(1)]
        [TestCase(100)]
        [TestCase(999999)]
        public void ConstructorShouldInitializeCapacityProperty(int capacity)
        {
            Garage garage = new Garage(capacity);

            int expectedCapacity = capacity;
            int actualCapacity = garage.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void ConstructorShouldInitializeVehicleCollection()
        {
            Garage garage = new Garage(1);

            Assert.IsNotNull(garage.Vehicles);
        }

        [Test]
        public void ConstructorShouldInitializeAnEmptyVehicleCollection()
        {
            Garage garage = new Garage(1);

            Assert.IsEmpty(garage.Vehicles);
        }

        [Test]
        public void AddVehicleMethodShouldReturnFalseWhenOverCapacity()
        {
            this.defaultGarage1.AddVehicle(this.defaultVehicle1);


            bool expectedResult = false;
            bool actualResult = this.defaultGarage1.AddVehicle(new Vehicle("Toyota", "Supra", "777777"));

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddVehicleMethodShouldReturnFalseWhenAddingVehicleWithExistingLicensePlate()
        {
            this.defaultGarage3.AddVehicle(this.defaultVehicle1);

            bool expectedResult = false;
            bool actualResult = this.defaultGarage3.AddVehicle(this.defaultVehicle1);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void Garage_AddVehicle_LicensePlateAlreadyExists()
        {
            Garage garage = new Garage(3);

            Vehicle car = new Vehicle("Peugoet", "208", "CT7006H");

            garage.AddVehicle(car);

            bool actualResult = garage.AddVehicle(car);
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void AddMethodShouldReturnTrueWhenSuccessful()
        {
            bool expectedResult = true;
            bool actualResult = this.defaultGarage1.AddVehicle(this.defaultVehicle1);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void DriveVehicleMethodShouldDecreaseBatteryLevel()
        {
            this.defaultGarage1.AddVehicle(this.defaultVehicle1);
            this.defaultGarage1.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 10, false);

            int expectedBatteryLevel = 90;
            int actualBatteryLevel = this.defaultVehicle1.BatteryLevel;

            Assert.AreEqual(expectedBatteryLevel, actualBatteryLevel);
        }

        [Test]
        public void DriveMethodShouldChangeVehicleIsDamagedStatusIfAccidentOccurred()
        {
            this.defaultGarage1.AddVehicle(this.defaultVehicle1);
            this.defaultGarage1.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 50, true);

            bool actualIsDamagedStatus = this.defaultVehicle1.IsDamaged;

            Assert.IsTrue(actualIsDamagedStatus);
        }

        [Test]
        public void DriveVehicleMethodShouldNotDecreaseBatteryWhenTheVehicleIsDamaged()
        {
            this.defaultGarage1.AddVehicle(this.defaultVehicle1);
            this.defaultGarage1.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 10, true);

            this.defaultGarage1.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 90, true);

            int expectedBatteryLevel = 90;
            int actualBatteryLevel = this.defaultVehicle1.BatteryLevel;

            Assert.AreEqual(expectedBatteryLevel, actualBatteryLevel);
        }

        [Test]
        public void DriveVehicleMethodShouldNotDecreaseBatteryWhenBatteryDrainageIsAbove100()
        {
            this.defaultGarage1.AddVehicle(this.defaultVehicle1);
            this.defaultGarage1.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 101, false);

            int expectedBatteryLevel = 100;
            int actualBatteyLevel = this.defaultVehicle1.BatteryLevel;

            Assert.AreEqual(expectedBatteryLevel, actualBatteyLevel);
        }

        [Test]
        public void DriveVehicleMethodShouldNotDecreaseBatteryWhenBatteryLevelIsBelowBatteryDrainage()
        {
            this.defaultGarage1.AddVehicle(this.defaultVehicle1);
            this.defaultGarage1.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 10, false);

            this.defaultGarage1.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 100, false);

            int expectedBatteryLevel = 90;
            int actualBatteryLevel = this.defaultVehicle1.BatteryLevel;

            Assert.AreEqual(expectedBatteryLevel, actualBatteryLevel);
        }

        [Test]
        public void ChargeVehiclesMethodShouldRechargeAllVehiclesWhoseBatteryLevelIsBelowTheGivenValue()
        {
            this.defaultGarage3.AddVehicle(this.defaultVehicle1);
            this.defaultGarage3.AddVehicle(this.defaultVehicle2);
            this.defaultGarage3.AddVehicle(this.defaultVehicle3);

            this.defaultGarage3.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 50, false);
            this.defaultGarage3.DriveVehicle(this.defaultVehicle2.LicensePlateNumber, 30, false);
            this.defaultGarage3.DriveVehicle(this.defaultVehicle3.LicensePlateNumber, 50, false);

            this.defaultGarage3.ChargeVehicles(60);

            int expectedBatteryLevelVehicle1 = 100;
            int expectedBatteryLevelVehicle3 = 100;
            int actualBatteryLevelVehicle1 = this.defaultVehicle1.BatteryLevel;
            int actualBatteryLevelVehicle3 = this.defaultVehicle3.BatteryLevel;

            Assert.AreEqual(expectedBatteryLevelVehicle1, actualBatteryLevelVehicle1);
            Assert.AreEqual(expectedBatteryLevelVehicle3, actualBatteryLevelVehicle3);
        }

        [Test]
        public void ChargeVehiclesMethodShouldReturnCorrectCountOfRechargedVehicles()
        {
            this.defaultGarage3.AddVehicle(this.defaultVehicle1);
            this.defaultGarage3.AddVehicle(this.defaultVehicle2);
            this.defaultGarage3.AddVehicle(this.defaultVehicle3);

            this.defaultGarage3.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 50, false);
            this.defaultGarage3.DriveVehicle(this.defaultVehicle2.LicensePlateNumber, 30, false);
            this.defaultGarage3.DriveVehicle(this.defaultVehicle3.LicensePlateNumber, 50, false);

            int expectedRechargedCount = 2;
            int actualRechargedCount = this.defaultGarage3.ChargeVehicles(60);

            Assert.AreEqual(expectedRechargedCount, actualRechargedCount);
        }

        [Test]
        public void RepairVehiclesMethodShouldRepairAllDamagedVehicles()
        {
            this.defaultGarage3.AddVehicle(this.defaultVehicle1);
            this.defaultGarage3.AddVehicle(this.defaultVehicle2);
            this.defaultGarage3.AddVehicle(this.defaultVehicle3);

            this.defaultGarage3.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 50, true);
            this.defaultGarage3.DriveVehicle(this.defaultVehicle2.LicensePlateNumber, 50, false);
            this.defaultGarage3.DriveVehicle(this.defaultVehicle3.LicensePlateNumber, 50, true);

            this.defaultGarage3.RepairVehicles();

            bool expectedDamageOnVehicle1 = false;
            bool expectedDamageOnVehicle3 = false;
            bool actualDamageOnVehicle1 = this.defaultVehicle1.IsDamaged;
            bool actualDamageOnVehicle3 = this.defaultVehicle3.IsDamaged;

            Assert.AreEqual(expectedDamageOnVehicle1, actualDamageOnVehicle1);
            Assert.AreEqual(expectedDamageOnVehicle3, actualDamageOnVehicle3);
        }

        [Test]
        public void RepairVehiclesMethodShouldReturnCorrectCountOfRepairedVehicles()
        {
            this.defaultGarage3.AddVehicle(this.defaultVehicle1);
            this.defaultGarage3.AddVehicle(this.defaultVehicle2);
            this.defaultGarage3.AddVehicle(this.defaultVehicle3);

            this.defaultGarage3.DriveVehicle(this.defaultVehicle1.LicensePlateNumber, 50, true);
            this.defaultGarage3.DriveVehicle(this.defaultVehicle2.LicensePlateNumber, 50, false);
            this.defaultGarage3.DriveVehicle(this.defaultVehicle3.LicensePlateNumber, 50, true);

            string expectedRepairedCount = $"Vehicles repaired: 2";
            string actualRepairedCount = this.defaultGarage3.RepairVehicles();

            Assert.AreEqual(expectedRepairedCount, actualRepairedCount);
        }
    }
}