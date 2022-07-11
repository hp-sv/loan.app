namespace Loan.Interface.Constants
{
    public static class LookupIds
    {
        /*Seed Data Id*/
        /* LastValue: 16        
         */
        public static class LookupSetId
        {
            public const int TransactionTypeSetId = 10001;
            public const int DurationTypeSetId = 10002;
            public const int RepaymentScheduleId = 10003;
            public const int RecordStatusSetId = 10014;
            public const int SeedTypeSetId = 10018;
            public const int ChangeOperationSetId = 10022;
            public const int AccountStatusId = 10026;
        }

        public static class TransactionType
        {
            public const int Credit = 10001;
            public const int Debit = 10002;
            public const int Interest = 10003;
            public const int Adjustment = 10004;
        }

        public static class DurationType
        {
            public const int Month = 10005;
            public const int Week = 10006;
            public const int Quarter = 10007;
            public const int HalfYear = 10008;
            public const int Year = 10009;
        }

        public static class RepaymentSchedule
        {
            public const int Daily = 10010;
            public const int Weekly = 10011;
            public const int Monthly = 10012;
            public const int TwiceMonthly = 10013;
        }

        public static class RecordStatus
        {
            public const int Active = 10015;
            public const int Deleted = 10016;
            public const int Archive = 10017;
            public const int Pending = 10018;            
        }

        public static class SeedTypes
        {
            public const int Constant = 10019;
            public const int UserUpdated = 10020;
            public const int Updatable = 10021;
        }

        public static class ChangeOperations
        {
            public const int Create = 10023;
            public const int Update = 10024;
            public const int Delete = 10025;
        }

        public static class AccountStatuses
        {
            public const int Pending = 10027;
            public const int Approved = 10028;
            public const int Active = 10029;
            public const int Cancelled = 10030;
            public const int Declined = 10031;
        }
    }
}
