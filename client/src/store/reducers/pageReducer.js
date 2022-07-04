import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function pageReducer(state = initialState.page, action) {
  switch (action.type) {
    case types.SET_APP_PAGE_TITLE_COMPLETED:
      return { ...state, ...{ title: action.pageTitle.title } };
    default:
      return state;
  }
}
