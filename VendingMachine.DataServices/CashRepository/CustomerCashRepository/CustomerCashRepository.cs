namespace VendingMachine.DataServices.CashRepository.CustomerCashRepository
{
            DenominationBalances = new Dictionary<Demonination, int>();
        }

        public void Add(Demonination denomination)
        {
            DenominationBalances[denomination] = DenominationBalances[denomination] + 1;
        }
}
