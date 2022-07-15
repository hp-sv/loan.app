import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function clientReducer(
  state = initialState.clientState,
  action
) {
  switch (action.type) {
    case types.SET_CLIENT_FILTER_COMPLETED:
      return { ...state, filterBy: action.filterBy };

    case types.SEARCH_CLIENT_SUCCESS:
      if(action.searchResult.results.length > 0 )            
        return { ...state, ...action.searchResult };      
      else 
        return state;

    case types.GET_CLIENT_SUCCESS:
      if (state.results.length > 0) {
        return {
          ...state,
          results: state.results.map((client) =>
            client.id === action.client.id ? action.client : client
          ),
        };
      } else {
        return { ...state, results: [action.client] };
      }

    case types.SAVE_CLIENT_SUCCESS:
      var existingClient = state.results.find(
        (client) => client.id === action.client.id
      );

      if (existingClient) {
        return {
          ...state,
          results: state.results.map((client) =>
            client.id === action.client.id ? action.client : client
          ),
        };
      } else {        
        return { ...state, results: [ ...state.results, action.client] };
      }
    case types.DELETE_CLIENT_SUCCESS:
      return {
        ...state,
        results: state.results.filter(
          (client) => client.id !== action.client.id
        ),
      };
    default:
      return state;
  }
}
