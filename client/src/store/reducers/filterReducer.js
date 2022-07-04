import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function filterReducer(state = initialState.filters, action) {
  switch (action.type) {
    case types.SET_CLIENT_FILTER_BY_COMPLETED:
      return {
        ...state,
        ...{ clientFilterBy: action.clientFilter.filterBy },
      };

    default:
      return state;
  }
}
