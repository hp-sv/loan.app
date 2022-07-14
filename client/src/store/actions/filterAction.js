import * as types from "./actionTypes";

export function setAccounttFilterByCompleted(accountFilter) {
  return { type: types.SET_ACCOUNT_FILTER_BY_COMPLETED, accountFilter };
}

export function setAccountFilterBy(filter) {
  const accountFilter = { filterBy: filter };
  return function (dispatch) {
    return dispatch(setAccounttFilterByCompleted(accountFilter));
  };
}
