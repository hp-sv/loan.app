import { combineReducers } from "redux";
import clients from "./clientReducer";
import page from "./pageReducer";

const rootReducer = combineReducers({
  clients,
  page,
});

export default rootReducer;
