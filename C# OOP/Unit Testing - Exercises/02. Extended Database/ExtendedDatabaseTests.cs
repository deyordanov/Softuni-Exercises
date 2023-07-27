namespace DatabaseExtended.Tests
{
    using System;
    using ExtendedDatabase;
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database defaultDb;
        [SetUp]
        public void SetUp()
        {
            this.defaultDb = new Database();
        }

        [TestCase(01, "ivo_kenov", 02, "viktor_dakov", 03, "niki_kostov")]
        public void ConstructorShouldInitializeACollectionWithTheGivenUsers(long id1, string usnm1, long id2, string usnm2, long id3, string usnm3)
        {
            Database db = new Database(new Person[] { new Person(id1, usnm1), new Person(id2, usnm2), new Person(id3, usnm3)});

            int expectedCount = 3;
            //assume that the count property works correctly
            int actualCount = db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(1, "a", 2, "b", 3, "c", 4, "d", 5, "e", 6, "f", 7, "g", 8, "h", 9, "i", 10, "j", 11, "k", 12, "l", 13,
            "m", 14, "n", 15, "o", 16, "p", 17, "q")]
        public void ConstructorShouldThrowAnExceptionWhenCreatingAnInstanceWithMoreThan16People(long id1, string usnm1, long id2, string usnm2, long id3, string usnm3, long id4, string usnm4, long id5, string usnm5, long id6, string usnm6, long id7, string usnm7, long id8, string usnm8, long id9, string usnm9, long id10, string usnm10, long id11, string usnm11, long id12, string usnm12, long id13, string usnm13, long id14, string usnm14, long id15, string usnm15, long id16, string usnm16, long id17, string usnm17)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Database db = new Database(new Person[]
                {
                    new(id1, usnm1), new(id2, usnm2), new(id3, usnm3), new(id4, usnm4), new(id5, usnm5), new(id6, usnm6),
                    new(id7, usnm7), new(id8, usnm8), new(id9, usnm9), new(id10, usnm10), new(id11, usnm11),
                    new(id12, usnm12), new(id13, usnm13), new(id14, usnm14), new(id15, usnm15), new(id16, usnm16),
                    new(id17, usnm17)
                });
            }, "Provided data length should be in range [0..16]!");
        }
        [Test]
        public void TheAddMethodShouldAddUsersToTheCollection()
        {
            int expectedCountOfUsersToAdd = 3;
            for (int i = 1; i <= expectedCountOfUsersToAdd; i++)
            {
                this.defaultDb.Add(new Person((long)i, $"{i}"));
            }

            int acturalCountOfAddedUsers = this.defaultDb.Count;

            Assert.AreEqual(expectedCountOfUsersToAdd, acturalCountOfAddedUsers);
        }

        [Test]
        public void AddingMoreThan16UsersInTheCollectionShouldThrowAnException()
        {
            for (int i = 1; i <= 16; i++)
            {
                this.defaultDb.Add(new Person(i, $"{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.Add(new Person(17, "17"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(1, "1", 2)]
        public void AddingAUserWithAnAlreadyExistingUsernameShouldThrowAnException(long id1, string usnm1, long id2)
        {
            this.defaultDb.Add(new Person(id1, usnm1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.Add(new Person(id2, usnm1));
            }, "There is already user with this username!");
        }
        [TestCase(1, "1", "2")]
        public void AddingUserWithAnAlreadyExistingIdShouldThrowAnException(long id1, string usnm1, string usnm2)
        {
            this.defaultDb.Add(new Person(id1, usnm1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.Add(new Person(id1, usnm2));
            }, "There is already user with this Id!");
        }

        [Test]
        public void TheRemoveMethodShouldRemoveUsersFromTheCollection()
        {
            for (int i = 1; i <= 3; i++)
            {
                this.defaultDb.Add(new Person(i, $"'{i}"));
            }

            int usersToRemove = 1;
            for (int i = 1; i <= usersToRemove; i++)
            {
                this.defaultDb.Remove();
            }

            int expectedUsersCount = 2;
            int actualUsersCount = this.defaultDb.Count;

            Assert.AreEqual(expectedUsersCount, actualUsersCount);
        }

        [Test]
        public void RemovingAUserFromAnEmptyCollectionShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.Remove();
            });
        }

        [TestCase(1, "1")]
        public void TheFindByUsernameMethodShouldFindAnExistingUserByHisUsername(long id, string usnm)
        {
            this.defaultDb.Add(new Person(id, usnm));

            Assert.IsNotNull(defaultDb.FindByUsername(usnm));
        }

        [Test]
        public void TheFindByUsernameMethodShouldThrowAnExceptionWhenGiveNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.defaultDb.FindByUsername(null);
            }, "Username parameter is null!");
        }

        [TestCase(1, "1", "2")]
        public void TheFindByUsernameMethodShouldThrowAnExceptionWhenThereIsNoUserWithSuchAUsername(long id1, string usnm1, string usnm2)
        {
            this.defaultDb.Add(new Person(id1, usnm1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.FindByUsername(usnm2);
            }, "No user is present by this username!");
        }

        [TestCase(1, "1")]
        public void TheFindByIdMethodShouldFindAnExistingUserByHisId(long id, string usnm)
        {
            this.defaultDb.Add(new Person(id, usnm));

            Assert.IsNotNull(this.defaultDb.FindById(id));
        }

        [TestCase(-1)]
        public void TheFindByIdMethodShouldThrowAnExceptionWhenGivenAnIdThatIsLessThanZero(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.defaultDb.FindById(id);
            }, "Id should be a positive number!");
        }

        [TestCase(1)]
        public void TheFindByIdMethodShouldThrowAnExceptionWhenThereIsNoUserWithSuchAnId(long id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultDb.FindById(id);
            }, "No user is present by this ID!");
        }
    }
}