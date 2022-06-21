import * as types from "../actions/clientActionTypes";
import initialState from "./initialState";

export default function clientReducer(state = initialState.clients, action) {
  switch (action.type) {
    case types.LOAD_CLIENTS_SUCCESS:
      return action.clients;
    case types.CREATE_CLIENT_SUCCESS:
      return action.client;
    case types.UPDATE_CLIENT_SUCCESS:
      return action.client;
    default:
      return state;
  }
}
