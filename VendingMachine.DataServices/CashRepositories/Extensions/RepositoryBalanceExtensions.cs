using System;
using System.Collections.Generic;

namespace VendingMachine.DataServices.CashRepositories
{
    public static class RepositoryBalanceExtensions
    {
        public static double GetBalanceSum(this Dictionary<Demonination, int> cashBalances)
        {
            double balance = 0;

            foreach (KeyValuePair<Demonination, int> entry in cashBalances)
            {
                switch (entry.Key)
                {
                    case Demonination.Dime:
                        balance += entry.Value * 0.05;
                        break;
                    case Demonination.Nickel:
                        balance += entry.Value * 0.10;
                        break;
                    case Demonination.Quarter:
                        balance += entry.Value * 0.25;
                        break;
                    case Demonination.Single:
                        balance += entry.Value;
                        break;
                    case Demonination.Fiver:
                        balance += entry.Value * 5;
                        break;
                }
            }
            return balance;
        }

        public static bool IsSufficient(this Dictionary<Demonination, int> cashBalances, double valueToCheck)
        {
            bool hasEnoughFunds = valueToCheck <= cashBalances.GetBalanceSum();

            if (!hasEnoughFunds)
            {
                return false;
            }

            //TODO: Make this more elegant
            var sum = Convert.ToInt32(valueToCheck * 100);

            var NoOfFivers = sum / 500;
            if (NoOfFivers > cashBalances[Demonination.Fiver])
                NoOfFivers = cashBalances[Demonination.Fiver];
            var FiversRequired = (NoOfFivers * 500);

            var NoOfSingles = (sum - FiversRequired) / 100;
            if (NoOfSingles > cashBalances[Demonination.Single])
                NoOfSingles = cashBalances[Demonination.Single];
            var SinglesRequired = (NoOfSingles * 100);

            var NoOfQuarters = (sum - FiversRequired - SinglesRequired) / 25;
            if (NoOfQuarters > cashBalances[Demonination.Quarter])
                NoOfQuarters = cashBalances[Demonination.Quarter];
            var QuartersRequired = NoOfQuarters * 25;

            var NoOfNickels = (sum - FiversRequired - SinglesRequired - QuartersRequired) / 10;
            if (NoOfNickels > cashBalances[Demonination.Nickel])
                NoOfNickels = cashBalances[Demonination.Nickel];
            var NickelsRequired = NoOfNickels * 10;

            var NoOfDimes = (sum - FiversRequired - SinglesRequired - QuartersRequired - NickelsRequired) / 5;
            if (NoOfDimes > cashBalances[Demonination.Dime])
                NoOfDimes = cashBalances[Demonination.Dime];
            var DimesRequired = NoOfDimes * 5;

            return (sum - FiversRequired - SinglesRequired - QuartersRequired - NickelsRequired - DimesRequired) == 0; 
        }
    }
}
