import { combineReducers } from "redux";
import clientState from "./clientReducer";
import accounts from "./accountReducer";
import apiCallsInProgress from "./apiStatusReducer";
import filters from "./filterReducer";
import lookupSets from "./lookupSetReducer";

const rootReducer = combineReducers({
  clientState,
  accounts,
  apiCallsInProgress,
  filters,
  lookupSets,
});

export default rootReducer;
