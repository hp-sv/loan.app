import * as types from "./actionTypes";
import * as clientApi from "../../api/clientApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";
import { toast } from "react-toastify";

export function searchClientSuccess(clients) {
  return { type: types.SEARCH_CLIENT_SUCCESS, clients };
}

export function getClientSuccess(client) {
  return { type: types.GET_CLIENT_SUCCESS, client };
}

export function updateClientSuccess(client) {
  return { type: types.UPDATE_CLIENT_SUCCESS, client };
}

export function createClientSuccess(client) {
  return { type: types.CREATE_CLIENT_SUCCESS, client };
}

export function searchClients(filter) {
  return function (dispatch) {
    dispatch(beginApiCall());

    return toast.promise(
      clientApi.searchClients(filter),
      {
        pending: 'Searching client.. please wait.',
        success: {          
          render(result){
            dispatch(searchClientSuccess(result.data));            
            return false;
          }
        },
        error: {
          render(data){            
            dispatch(apiCallError(data));            
            throw data;
          }
        }
      });

      /*
    
    return clientApi
      .searchClients(filter)
      .then((clients) => {
        dispatch(searchClientSuccess(clients));
      })
      .catch((error) => {
        dispatch(apiCallError(error));
        throw error;
      });
      */

  };
}

export function getClientById(id) {
  return function (dispatch) {
    dispatch(beginApiCall());
    
    return clientApi
      .getClientById(id)
      .then((client) => {
        dispatch(getClientSuccess(client));
      })
      .catch((error) => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}

export function saveClient(client) {
  //eslint-disable-next-line no-unused-vars
  return function (dispatch, getState) {
    dispatch(beginApiCall());
    return clientApi
      .saveClient(client)
      .then((savedClient) => {
        client.id
          ? dispatch(updateClientSuccess(savedClient))
          : dispatch(createClientSuccess(savedClient));
      })
      .catch((error) => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}
