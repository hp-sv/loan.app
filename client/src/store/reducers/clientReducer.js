import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function clientReducer(state = initialState.clients, action) {
  switch (action.type) {
    case types.SEARCH_CLIENT_SUCCESS:
      return action.clients;
    case types.GET_CLIENT_SUCCESS:
      if (state.length > 0) {
        return state.map((client) =>
          client.id === action.client.id ? action.client : client
        );
      } else {
        return [...state, action.client];
      }    
    case types.SAVE_CLIENT_SUCCESS:
      var existingClient = state.find((client) => client.id === action.client.id);
      if(existingClient)
      {
        return state.map((client) =>
        client.id === action.client.id ? action.client : client
      );
      } 
      else 
      {
        return [...state, action.client];
      }       
      case types.DELETE_CLIENT_SUCCESS:        
        return state.filter((client) => client.id !== action.client.id)
    default:
      return state;
  }
}
