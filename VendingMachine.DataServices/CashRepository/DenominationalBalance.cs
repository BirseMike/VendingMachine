namespace VendingMachine.DataServices
{ 
    public enum Demonination
    {
        Nickel,
        Dime,
        Quarter,
        Single,
        Fiver
    }

    class DenominationalBalance
    {
        public Demonination Denomination { get; set; }
        public int Count { get; set; }
    }
}
