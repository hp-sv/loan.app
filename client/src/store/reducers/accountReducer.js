import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function accountReducer(state = initialState.accounts, action) {
  switch (action.type) {
    case types.SEARCH_ACCOUNT_SUCCESS:
      return action.accounts;
    case types.GET_ACCOUNT_SUCCESS:
      if (state.length > 0) {
        return state.map((account) =>
          account.id === action.account.id ? action.account : account
        );
      } else {
        return [...state, action.account];
      }
    case types.SAVE_ACCOUNT_SUCCESS:
      var existingClient = state.find(
        (client) => client.id === action.account.id
      );
      if (existingClient) {
        return state.map((account) =>
          account.id === action.account.id ? action.account : account
        );
      } else {
        return [...state, action.account];
      }
    case types.DELETE_ACCOUNT_SUCCESS:
      return state.filter((account) => account.id !== action.account.id);
    default:
      return state;
  }
}
