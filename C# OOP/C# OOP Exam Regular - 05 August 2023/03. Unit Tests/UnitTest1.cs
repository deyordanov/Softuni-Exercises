using NUnit.Framework;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat defaultMat1;
        private CoffeeMat defaultMat2;

        [SetUp]
        public void Setup()
        {
            this.defaultMat1 = new CoffeeMat(10, 10);
            this.defaultMat2 = new CoffeeMat(100, 20);
        }

        [Test]
        public void ConstructorShouldInitializeCoffeeMat()
        {
            CoffeeMat mat = new CoffeeMat(30, 20);

            Assert.IsNotNull(mat);
        }

        // [Test]
        // public void ConstructorShouldInitializePropertiesCorrectly()
        // {
        //     CoffeeMat mat = new CoffeeMat(30, 20);
        //
        //     int expectedWaterCapacity = 30;
        //     int expectedButtonsCount = 20;
        //     int expectedIncome = 0;
        //
        //     Assert.AreEqual(expectedWaterCapacity, mat.WaterCapacity);
        //     Assert.AreEqual(expectedButtonsCount, mat.ButtonsCount);
        //     Assert.AreEqual(expectedIncome,mat.Income);
        // }

        [Test]
        public void SetterShouldSetWaterCap()
        {
            CoffeeMat mat = new CoffeeMat(30, 20);

            int expectedWaterCap = 30;
            int actualWaterCap = mat.WaterCapacity;
            Assert.AreEqual(expectedWaterCap, actualWaterCap);
        }

        [Test]
        public void SetterShouldSetButtonsCount()
        {
            CoffeeMat mat = new CoffeeMat(30, 20);

            int expectedButtonsCount = 20;
            int actualButtonsCount = mat.ButtonsCount;
            Assert.AreEqual(expectedButtonsCount, actualButtonsCount);
        }

        [Test]
        public void SetterShouldSetIncome()
        {
            CoffeeMat mat = new CoffeeMat(30, 20);

            double expectedIncome = 0;
            double actualIncome = mat.Income;

            Assert.AreEqual(expectedIncome , actualIncome);
        }
        [Test]
        public void FillWaterTankLevelShouldIncreaseWaterTankLevel()
        {
            string expectedResult = $"Water tank is filled with 10ml";
            
            Assert.AreEqual(expectedResult, this.defaultMat1.FillWaterTank());
        }

        [Test]
        public void FillWaterTankLevelShouldNotOverflowTank()
        {
            string expectedResult = "Water tank is already full!";
            this.defaultMat1.FillWaterTank();

            Assert.AreEqual(expectedResult, this.defaultMat1.FillWaterTank());
        }

        [Test]
        public void AddDrinkShouldReturnTrueWhenSuccessful()
        {
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(this.defaultMat1.AddDrink($"Coffee{i + 1}", i));
            }
        }

        [Test]
        public void AddDrinkShouldReturnFalseWhenUnsuccessful()
        {
            for (int i = 0; i < 10; i++)
            {
                this.defaultMat1.AddDrink($"Coffee{i + 1}", i);
            }

            for (int i = 10; i < 15; i++)
            {
                Assert.IsFalse(this.defaultMat1.AddDrink($"Coffee{i + 1}", i));
            }
        }

        [Test]
        public void AddDrinkShouldReturnFalseWhenDrinkAlreadyExists()
        {
            for (int i = 0; i < 5; i++)
            {
                this.defaultMat1.AddDrink($"Coffee{i + 1}", i);
            }

            bool actualResult = this.defaultMat1.AddDrink($"Coffee1", 1);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void BuyDrinksShouldReturnPriceIfAvailable()
        {
            this.defaultMat2.FillWaterTank();
            for (int i = 0; i < 8; i++)
            {
                this.defaultMat2.AddDrink($"Coffee{i + 1}", i + 1);
            }


            string expectedResult = $"Your bill is 1.00$";
            string actualResult = this.defaultMat2.BuyDrink("Coffee1");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BuyDrinksShoudlIncreaseIncome()
        {
            for (int i = 0; i < 8; i++)
            {
                this.defaultMat2.AddDrink($"Coffee{i + 1}", i + 1);
            }

            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee1");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee2");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee3");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee4");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee5");

            double expectedIncome = 15;
            double actualIncome = this.defaultMat2.Income;

            Assert.AreEqual(expectedIncome, actualIncome);
        }

        [Test]
        public void BuyDrinkShouldReturnNotAvailable()
        {
            this.defaultMat2.FillWaterTank();
            for (int i = 0; i < 8; i++)
            {
                this.defaultMat2.AddDrink($"Coffee{i + 1}", i + 1);
            }

            this.defaultMat2.BuyDrink("Coffee2");
            this.defaultMat2.FillWaterTank();

            string expectedResult = $"Coffee20 is not available!";
            string actualResult = this.defaultMat2.BuyDrink("Coffee20");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BuyDrinkShouldReturnOutOfWaterWhenWaterTankLessThan80()
        {
            this.defaultMat2.FillWaterTank();
            for (int i = 0; i < 8; i++)
            {
                this.defaultMat2.AddDrink($"Coffee{i + 1}", i + 1);
            }

            this.defaultMat2.BuyDrink("Coffee1");
            string expectedResult = $"CoffeeMat is out of water!";
            string actualResult = this.defaultMat2.BuyDrink("Coffee2");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BuyDrinkShouldDecreaseTankLevel()
        {
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.AddDrink($"Coffee1", 1);
            this.defaultMat2.BuyDrink("Coffee1");

            string expectedResult = "Water tank is filled with 80ml";
            string actualResult = this.defaultMat2.FillWaterTank();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CollectIncomeShouldReturnTotalIncome()
        {
            for (int i = 0; i < 8; i++)
            {
                this.defaultMat2.AddDrink($"Coffee{i + 1}", i + 1);
            }

            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee1");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee2");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee3");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee4");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee5");

            double expectedIncome = 15;
            double actualIncome = this.defaultMat2.CollectIncome();
            
            Assert.AreEqual(expectedIncome, actualIncome);
        }

        [Test]
        public void CollectIncomeShouldSetIncomeToZero()
        {
            for (int i = 0; i < 8; i++)
            {
                this.defaultMat2.AddDrink($"Coffee{i + 1}", i + 1);
            }

            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee1");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee2");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee3");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee4");
            this.defaultMat2.FillWaterTank();
            this.defaultMat2.BuyDrink("Coffee5");

            this.defaultMat2.CollectIncome();

            double expectedIncome = 0;
            double actualIncome = this.defaultMat2.Income;

            Assert.AreEqual(expectedIncome, actualIncome);
        }

    }
}