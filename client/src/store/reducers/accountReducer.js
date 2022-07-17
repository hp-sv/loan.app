import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function accountReducer(
  state = initialState.accountState,
  action
) {
  switch (action.type) {
    case types.SET_ACCOUNT_FILTER_COMPLETED:
      return { ...state, filterBy: action.filterBy };
    case types.SEARCH_ACCOUNT_SUCCESS:
      if (action.searchResult.results.length > 0)
        return { ...state, ...action.searchResult };
      else return state;

    case types.GET_ACCOUNT_SUCCESS:
      if (state.results.length > 0) {
        return {
          ...state,
          results: state.results.map((account) =>
            account.id === action.account.id ? action.account : account
          ),
        };
      } else {
        return { ...state, results: [action.account] };
      }

    case types.APPROVE_ACCOUNT_SUCCESS:
    case types.SAVE_ACCOUNT_SUCCESS:
      var existingAccount = state.results.find(
        (account) => account.id === action.account.id
      );

      if (existingAccount) {
        return {
          ...state,
          results: state.results.map((account) =>
            account.id === action.account.id ? action.account : account
          ),
        };
      } else {
        return { ...state, results: [...state.results, action.account] };
      }

    case types.DELETE_ACCOUNT_SUCCESS:
      return {
        ...state,
        results: state.results.filter(
          (account) => account.id !== action.account.id
        ),
      };
    default:
      return state;
  }
}
