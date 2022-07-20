﻿namespace Loan.Interface.Constants
{
    public static class ClientRoutes
    {
        public const string ROUTE = "api/client";
        public const string ID = "{id}";
        public const string GET_CLIENT_ROUTE_NAME = "GetClientRoute";
        public const string SEARCH = "search";
    }

    public static class AccountRoutes
    {
        public const string ROUTE = "api/account";        
        public const string ID = "{id}";
        public const string GET_ACCOUNT_ROUTE_NAME = "GetAccountRoute";
        public const string SEARCH = "search";
        public const string APPROVE = "approve";
        public const string DECLINE = "{id}/decline";
        public const string CANCEL = "{id}/cancel";
        public const string COMMENT = "{id}/comment";
        public const string GET_ACCOUNT_COMMENT = "GetAccountCommentRoute";
        public const string ACCOUNT_COMMENT = "{aId}/comment/{id}";
    }

    public static class LookupSetRoutes
    {
        public const string ROUTE = "api/lookupset";
        public const string ID = "{id}";
        public const string GET_LOOKUP_ROUTE_NAME = "GetLookupRoute";
        
    }

}
