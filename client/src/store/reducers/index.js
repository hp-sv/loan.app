import { combineReducers } from "redux";
import clientState from "./clientReducer";
import accountState from "./accountReducer";
import apiCallsInProgress from "./apiStatusReducer";
import lookupSets from "./lookupSetReducer";

const rootReducer = combineReducers({
  clientState,
  accountState,
  apiCallsInProgress,  
  lookupSets,
});

export default rootReducer;
