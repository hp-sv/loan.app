import * as types from "../actions/pageActionTypes";
import initialState from "./initialState";

export default function pageReducer(state = initialState.page, action) {
  switch (action.type) {
    case types.SET_APP_PAGE_TITLE:
      return { ...state, ...{ title: action.pageTitle.title } };
    case types.SET_APP_PAGE_TITLE_SUCCESS:
      return { ...state, ...{ title: action.pageTitle.title } };
    default:
      return state;
  }
}
