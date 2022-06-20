import * as types from "../actions/clientActionTypes";
import initialState from "./initialState";

export default function clientReducer(state = initialState.clients, action) {
  switch (action.type) {
    case types.CREATE_CLIENT:
      return [...state, { ...action.clients }];
    case types.LOAD_CLIENTS_SUCCESS:
      return action.clients;
    default:
      return state;
  }
}
