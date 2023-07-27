namespace Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defaultDb;

        [SetUp]
        public void SetUp()
        {
            this.defaultDb = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 ,15, 16 })]
        public void ConstructorShouldAddCorrectCountOfElements(int[] data)
        {
            Database db = new Database(data);

            int expectedLength = data.Length;
            int actualCount = db.Count;

            Assert.AreEqual(expectedLength, actualCount);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddTheCorrectElementsToTheCollection(int[] data)
        {
            Database db = new Database(data);

            CollectionAssert.AreEqual(data, db.Fetch());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 , 17})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void ConstructorShouldThrowAnExceptionWhenGivenMoreThan16Elements(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldAddElementsToTheCollection()
        {
            int[] expectedElements = new int[5];
            for (int i = 1; i <= 5; i++)
            {
                this.defaultDb.Add(i);
                expectedElements[i - 1] = i;
            }

            int[] actualElements = this.defaultDb.Fetch();

            CollectionAssert.AreEqual(expectedElements, actualElements);
        }

        [Test]
        public void AddingMoreThan16ElementsToTheCollectionShouldThrowAnException()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.defaultDb.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.Add(17);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldIncreaseCountProperty()
        {
            int expectedCount = 5;
            for (int i = 1; i <= expectedCount; i++)
            {
                this.defaultDb.Add(i);
            }

            int actualCount = this.defaultDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldRemoveElementsFromTheCollection()
        {
            for (int i = 1; i <= 5; i++)
            {
                this.defaultDb.Add(i);
            }

            int elementsToRemove = 2;
            for (int i = 1; i <= elementsToRemove; i++)
            {
                this.defaultDb.Remove();
            }

            int[] expectedElements = new int[] { 1, 2, 3 };
            int[] actualElements = this.defaultDb.Fetch();

            CollectionAssert.AreEqual(expectedElements, actualElements);
        }

        [Test]
        public void RemovingAnElementWhenTheCollectionIsEmptyShouldThrowAnException()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "The collection is empty!");
        }

        [Test]
        public void RemoveingAnElementFromTheCollectionShouldDecreaseTheCount()
        {
            for (int i = 1; i <= 5; i++)
            {
                this.defaultDb.Add(i);
            }

            for (int i = 1; i <= 2; i++)
            {
                this.defaultDb.Remove();
            }

            int expectedCount = 3;
            int actualCount = this.defaultDb.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TheFetchMethodShouldReturnTheCollectionWithTheCorrectElements()
        {
            int[] expectedElements = new int[5];
            for (int i = 1; i <= 5; i++)
            {
                this.defaultDb.Add(i);
                expectedElements[i - 1] = i;
            }

            int[] actualElements = this.defaultDb.Fetch();

            CollectionAssert.AreEqual(expectedElements, actualElements);
        }
    }
}
