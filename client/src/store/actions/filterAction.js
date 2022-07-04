import * as types from "./actionTypes";

export function setClientFilterByCompleted(clientFilter) {
  return { type: types.SET_CLIENT_FILTER_BY_COMPLETED, clientFilter };
}

export function setClientFilterBy(filter) {
  const clientFilter = { filterBy: filter };
  return function (dispatch) {
    return dispatch(setClientFilterByCompleted(clientFilter));
  };
}
