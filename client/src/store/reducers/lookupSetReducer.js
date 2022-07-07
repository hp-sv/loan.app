import * as types from "../actions/actionTypes";
import initialState from "./initialState";


export default function lookupSetReducer(state = initialState.lookupSet, action) {
    switch (action.type) {                
        case types.GET_TRANSACTION_TYPE_SUCCESS:
            return {
                ...state,
                ...{ transactionType: action.lookupSet },
              };
        case types.GET_DURATION_TYPE_SUCCESS:
            return {
                ...state,
                ...{ durationType: action.lookupSet },
                };
        case types.GET_REPAYMENT_SCHEDULE_SUCCESS:
            return {
                ...state,
                ...{ repaymentSchedule: action.lookupSet },
                };
        case types.GET_RECORD_STATUS_SUCCESS:
            return {
                ...state,
                ...{ recordStatus: action.lookupSet },
                };
        case types.GET_SEED_CONSTANT_TYPE_SUCCESS:
            return {
                ...state,
                ...{ seedConstantType: action.lookupSet },
                };
        case types.GET_CHANGE_OPERATIONS_SUCCESS:
            return {
                ...state,
                ...{ changeOperations: action.lookupSet },
                };
        case types.GET_ACCOUNT_STATUS_SUCCESS:      
            return {
                ...state,
                ...{ accountStatus: action.lookupSet },
                };
      default:
        return state;
    }
  }
  