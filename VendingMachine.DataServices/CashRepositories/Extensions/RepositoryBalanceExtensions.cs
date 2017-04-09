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


            //TODO - convert value into balances..


    //        change = int(value * 100)
    //a = change / 500
    //print a, " - $2 Coins"
    //b = (change - (a * 200)) / 100
    //print b, " - $1 Coins"
    //c = (change - (a * 200) - (b * 100)) / 50
    //print c, " - 50c Coins"
    //d = (change - (a * 200) - (b * 100) - (c * 50)) / 20
    //print d, " - 20c Coins"
    //e = (change - (a * 200) - (b * 100) - (c * 50) - (d * 20)) / 10
    //print e, " - 10c Coins"
    //f = (change - (a * 200) - (b * 100) - (c * 50) - (d * 20) - (e * 10)) / 5
    //print f, " - 5c Coins"
            return true;
        }
    }
}
