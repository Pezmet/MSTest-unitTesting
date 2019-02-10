using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterTest
    {
        [TestMethod]
        public void BeInexperiacedWhenNew()
        {
            var sut = new PlayerCharacter();

            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        public void NotHaveNickNameByDefault()
        {
            var sut = new PlayerCharacter();

            Assert.IsNull(sut.Nickname);
        }

        [TestMethod]
        public void StartWithDefaultHealth()
        {
            var sut = new PlayerCharacter();

            Assert.AreEqual(100, sut.Health);
        }

        [TestMethod]
        public void TakeDamage()
        {
            var sut = new PlayerCharacter();

            sut.TakeDamage(1);

            Assert.AreEqual(99, sut.Health);
        }

        [TestMethod]
        public void TakeDamage_NotEqual()
        {
            var sut = new PlayerCharacter();

            sut.TakeDamage(1);

            Assert.AreNotEqual(100, sut.Health);
        }

        [TestMethod]
        public void IncreaseHealthAfterSleeping()
        {
            var sut = new PlayerCharacter();

            sut.Sleep(); // increase between 1 to 100

            Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Noob";
            sut.LastName = "Player";

            Assert.AreEqual("Noob Player", sut.FullName);
            //Assert.AreEqual("NOOB Player", sut.FullName); Will fail
            Assert.AreEqual("Noob Player", sut.FullName, true);
        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Noob";
            sut.LastName = "Player";

            //Assert.IsTrue(sut.FullName.StartsWith("Noob"));

            StringAssert.StartsWith(sut.FullName, "Noob");
        }
        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Noob";
            sut.LastName = "Player";

            //Assert.IsTrue(sut.LastName.EndsWith("Player"));

            StringAssert.EndsWith(sut.FullName, "Player");
        }
        [TestMethod]
        public void HaveFullNameContainSpace()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Noob";
            sut.LastName = "Player";

            StringAssert.Contains(sut.FullName, "ob Pl");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Noob";
            sut.LastName = "Player";

            StringAssert.Matches(sut.FullName, new System.Text.RegularExpressions.Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            var sut = new PlayerCharacter();

            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }
        [TestMethod]
        public void NotHaveAStaffOfWander()
        {
            var sut = new PlayerCharacter();

            CollectionAssert.DoesNotContain(sut.Weapons, "Staff of Wander");
        }
        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
            var sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            }; //same expected order

            CollectionAssert.AreEqual(expectedWeapons, sut.Weapons);
        }
        [TestMethod]
        public void HaveAllExpectedWeapons_NoOrder()
        {
            var sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Sword",
                "Short Bow"        
            };

            CollectionAssert.AreEquivalent(expectedWeapons, sut.Weapons);
        }
        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
            var sut = new PlayerCharacter();

            //sut.Weapons.Add("Short Bow");

            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOnceKindOfSword()
        {
            var sut = new PlayerCharacter();

            Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            var sut = new PlayerCharacter();

            Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));
        }
    }
}
