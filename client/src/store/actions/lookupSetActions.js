import * as types from "./actionTypes";
import * as lookupApi from "../../api/lookupApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";
import * as constants from "../../constants/Common";

export function getLookupSetSuccess(lookupSet) {
  switch (lookupSet.id) {
    case constants.ACCOUNT_STATUS:
      return { type: types.GET_ACCOUNT_STATUS_SUCCESS, lookupSet };
    case constants.TRANSACTION_TYPE:
      return { type: types.GET_TRANSACTION_TYPE_SUCCESS, lookupSet };
    case constants.DURATION_TYPE:
      return { type: types.GET_DURATION_TYPE_SUCCESS, lookupSet };
    case constants.REPAYMENT_SCHEDULE:
      return { type: types.GET_REPAYMENT_SCHEDULE_SUCCESS, lookupSet };
    case constants.RECORD_STATUS:
      return { type: types.GET_RECORD_STATUS_SUCCESS, lookupSet };
    case constants.SEED_CONSTANT_TYPE:
      return { type: types.GET_SEED_CONSTANT_TYPE_SUCCESS, lookupSet };
    case constants.CHANGE_OPERATIONS:
      return { type: types.GET_CHANGE_OPERATIONS_SUCCESS, lookupSet };
    default:
      return lookupSet;
  }
}

export function getLookupSetById(id) {
  return function (dispatch) {
    dispatch(beginApiCall());

    return lookupApi
      .getLookupBySetId(id)
      .then((lookupSet) => {
        dispatch(getLookupSetSuccess(lookupSet));
      })
      .catch((error) => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}
