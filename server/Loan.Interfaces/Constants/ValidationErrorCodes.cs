﻿namespace Loan.Interface.Constants
{

    public static class CommonErrorCodes
    {
        public const int SYSTEM_CONFIGURATION_ERROR = -10000;
    }

    public static class AccountValidationErrorCodes
    {        
        public const int IVALID_CLIENT = 10010;
        public const int INVALID_DURATION = 10012;
        public const int INVALID_DURATION_TYPE = 10013;
        public const int INVALID_REPAYMENT_TYPE = 10014;
        public const int ACCOUNT_DOES_NOT_EXISTS = 10015;        
    }

    public static class ClientValidationErrorCodes
    {
        public const int IVALID_CLIENT = 20010;
        public const int CLIENT_DO_NOT_EXISTS = 20011;
        public const int CLIENT_IS_UNDER_AGE = 20012;
        public const int CLIENT_DATE_OF_BIRTH_ERROR = 20013;
        public const int CLIENT_HAS_AN_ACTIVE_ACCOUNT = 20014;

    }
}
