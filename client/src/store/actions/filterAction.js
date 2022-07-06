import * as types from "./actionTypes";

export function setClientFilterByCompleted(clientFilter) {
  return { type: types.SET_CLIENT_FILTER_BY_COMPLETED, clientFilter };
}

export function setAccounttFilterByCompleted(accountFilter) {
  return { type: types.SET_ACCOUNT_FILTER_BY_COMPLETED, accountFilter };
}

export function setClientFilterBy(filter) {
  const clientFilter = { filterBy: filter };
  return function (dispatch) {
    return dispatch(setClientFilterByCompleted(clientFilter));
  };
}

export function setAccountFilterBy(filter) {
  const accountFilter = { filterBy: filter };
  return function (dispatch) {
    return dispatch(setAccounttFilterByCompleted(accountFilter));
  };
}
