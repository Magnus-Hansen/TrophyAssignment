using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyAssignment.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void ValidateCompetitionTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Trophy(1, null, 2000).ValidateCompetition());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Trophy(1, "42", 2000).ValidateCompetition());

            Trophy trophy = new Trophy(1, "uwu", 2000);
            trophy.ValidateCompetition();
        }
        [TestMethod()]
        public void ValidateYearTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Trophy(1, "fail", 1969).ValidateYear());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Trophy(1, "fail", 2025).ValidateYear());

            Trophy trophy1 = new Trophy(1, "Applelousa applebucking competition", 1970);
            Trophy trophy2 = new Trophy(2, "Cloudsdale flying competition", 2024);

            trophy1.ValidateYear();
            trophy2.ValidateYear();
        }
        [TestMethod()]
        public void ToStringTest()
        {
            Trophy trophy = new Trophy(1, "Applelousa applebucking competition", 1970);

            Assert.AreNotEqual("Id: 2 -- Competition: Applelousa applebucking competition -- Year: 1970", trophy.ToString());
            Assert.AreNotEqual("Id: 1 -- Competition: Applelousa applebucking -- Year: 1970", trophy.ToString());
            Assert.AreNotEqual("Id: 1 -- Competition: Applelousa applebucking competition -- Year: 1969", trophy.ToString());

            Assert.AreEqual("Id: 1 -- Competition: Applelousa applebucking competition -- Year: 1970", trophy.ToString());
        }
    }
}