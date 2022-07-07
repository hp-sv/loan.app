import { combineReducers } from "redux";
import clients from "./clientReducer";
import accounts from "./accountReducer";
import apiCallsInProgress from "./apiStatusReducer";
import filters from "./filterReducer";
import lookupSets from "./lookupSetReducer";

const rootReducer = combineReducers({
  clients,
  accounts,
  apiCallsInProgress,
  filters,
  lookupSets
});

export default rootReducer;
