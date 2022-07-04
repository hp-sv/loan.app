import * as types from "./actionTypes";

export function setCurrentPageTitleSuccess(pageTitle) {
  return { type: types.SET_APP_PAGE_TITLE_COMPLETED, pageTitle };
}

export function setCurrentPageTitle(title) {
  const pageTitle = { title };
  return function (dispatch) {
    return dispatch(setCurrentPageTitleSuccess(pageTitle));
  };
}
