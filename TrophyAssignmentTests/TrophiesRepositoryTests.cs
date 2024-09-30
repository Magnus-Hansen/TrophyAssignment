using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TrophyAssignment.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {

        [TestMethod()]
        public void AddTest()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();
            Trophy trophy = new Trophy(2, "Friendship Games6", 1966);

            int beforeAdd = trophiesRepository.Count;

            Assert.AreEqual(trophy.Competition, trophiesRepository.Add(trophy).Competition);
            int afterAdd = trophiesRepository.Count;

            Assert.AreEqual(beforeAdd + 1, afterAdd);

            Assert.AreEqual(trophy.Year, trophiesRepository.Add(trophy).Year);

        }
        [TestMethod]
        public void GetByIdTest()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();

            Assert.AreEqual("Iron Pony Competition1", trophiesRepository.GetById(1).Competition);
            Assert.AreEqual(2023, trophiesRepository.GetById(1).Year);

            Assert.AreEqual("Equestria Games5", trophiesRepository.GetById(5).Competition);
            Assert.AreEqual(2019, trophiesRepository.GetById(5).Year);

            Assert.AreEqual(null, trophiesRepository.GetById(0));
            Assert.AreEqual(null, trophiesRepository.GetById(6));
        }

        [TestMethod]
        public void GetAllTest()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();

            Assert.AreEqual(5, trophiesRepository.Get().Count);

            Assert.AreNotEqual(4, trophiesRepository.Get().Count);
            Assert.AreNotEqual(6, trophiesRepository.Get().Count);

            Assert.AreEqual("Iron Pony Competition1", trophiesRepository.Get().First().Competition);
            Assert.AreEqual("Equestria Games5", trophiesRepository.Get().Last().Competition);
        }
        [TestMethod]
        public void GetFilterTest()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();

            Assert.AreEqual(2, trophiesRepository.Get(2021).Count);
            Assert.AreEqual(4, trophiesRepository.Get(null, 2019).Count);
            Assert.AreEqual(1, trophiesRepository.Get(2021, 2019).Count);

            Assert.AreEqual("Sisterhooves Social4", trophiesRepository.Get(2021).First().Competition);
            Assert.AreEqual("Equestria Games5", trophiesRepository.Get(2021).Last().Competition);

            Assert.AreEqual("Iron Pony Competition1", trophiesRepository.Get(null, 2019).First().Competition);
            Assert.AreEqual("Sisterhooves Social4", trophiesRepository.Get(null, 2019).Last().Competition);

            Assert.AreEqual("Sisterhooves Social4", trophiesRepository.Get(2021, 2019).First().Competition);

            Assert.AreEqual(0, trophiesRepository.Get(2019).Count);
            Assert.AreEqual(0, trophiesRepository.Get(null, 2023).Count);
        }
        [TestMethod]
        public void GetSortBy()
        {
            TrophiesRepository trophiesRepository = new TrophiesRepository();

            Assert.AreEqual("Best Young Flyer Competition3", trophiesRepository.Get(null, null, "Competition").First().Competition);
            Assert.AreEqual("The Running of the Leaves2", trophiesRepository.Get(null, null, "Competition").Last().Competition);

            Assert.AreEqual("Equestria Games5", trophiesRepository.Get(null, null, "Year").First().Competition);
            Assert.AreEqual("Iron Pony Competition1", trophiesRepository.Get(null, null, "Year").Last().Competition);
        }
    }
}