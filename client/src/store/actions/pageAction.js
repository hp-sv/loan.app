import * as types from "./pageActionTypes";

export function setPageTitle(title) {
  const pageTitle = { title };
  return { type: types.SET_APP_PAGE_TITLE, pageTitle };
}

export function setCurrentPageTitleSuccess(pageTitle) {
  return { type: types.SET_APP_PAGE_TITLE_SUCCESS, pageTitle };
}

export function setCurrentPageTitle(title) {
  const pageTitle = { title };
  return function (dispatch) {
    return dispatch(setCurrentPageTitleSuccess(pageTitle));
  };
}
