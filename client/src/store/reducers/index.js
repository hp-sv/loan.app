import { combineReducers } from "redux";
import clients from "./clientReducer";
import accounts from "./accountReducer";
import apiCallsInProgress from "./apiStatusReducer";
import filters from "./filterReducer";

const rootReducer = combineReducers({
  clients,
  accounts,
  apiCallsInProgress,
  filters,
});

export default rootReducer;
