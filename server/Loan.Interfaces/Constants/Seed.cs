namespace Loan.Interface.Constants
{
    public static class Seed
    {
        public const string SEED_USER = "la:seeduser";
        public static Guid SeedTransactionId() { return new Guid("AB3B99D9-B824-4277-B367-2151D6E403A8"); }
        public static DateTime SeedDate() { return new DateTime(1900, 1, 1); }
    }
}
