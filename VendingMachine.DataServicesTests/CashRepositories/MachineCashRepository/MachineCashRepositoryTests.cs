using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.DataServices.CashRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.DataServices.CashRepositories.Tests
{
    [TestClass()]
    public class MachineCashRepositoryTests
    {
        [TestMethod()]
        public async Task HasChange_ValueLessThanBalance_ReturnsTrue()
        {
            var repository = GetRepository();

            var result = await repository.HasChange(5.25);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public async Task HasChange_ValueIncludesLowDenomination_ReturnsFalse()
        {
            var repository = GetRepository();

            var result = await repository.HasChange(5.26);

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public async Task HasChange_ValueLargerThanBalance_ReturnsFalse()
        {
            var repository = GetRepository();

            var result = await repository.HasChange(50);

            Assert.IsFalse(result);
        }

        private MachineCashRepository GetRepository()
        {
            return new MachineCashRepository();
        }
    }
}