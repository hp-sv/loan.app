import { combineReducers } from "redux";
import clients from "./clientReducer";
import page from "./pageReducer";
import apiCallsInProgress from "./apiStatusReducer";
import filters from "./filterReducer";

const rootReducer = combineReducers({
  clients,
  page,
  apiCallsInProgress,
  filters,
});

export default rootReducer;
