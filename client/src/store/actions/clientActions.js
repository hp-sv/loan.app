import * as types from "./clientActionTypes";
import * as clientApi from "../../api/clientApi";

export function loadClientSuccess(clients) {
  return { type: types.LOAD_CLIENTS_SUCCESS, clients };
}

export function updateClientSuccess(client) {
  return { type: types.UPDATE_CLIENT_SUCCESS, client };
}

export function createClientSuccess(client) {
  return { type: types.CREATE_CLIENT_SUCCESS, client };
}

export function loadClients() {
  return function (dispatch) {
    return clientApi
      .getClients()
      .then((clients) => {
        dispatch(loadClientSuccess(clients));
      })
      .catch((error) => {
        throw error;
      });
  };
}

export function saveClient(client) {
  //eslint-disable-next-line no-unused-vars
  return function (dispatch, getState) {
    return clientApi
      .saveClient(client)
      .then((savedClient) => {
        client.id
          ? dispatch(updateClientSuccess(savedClient))
          : dispatch(createClientSuccess(savedClient));
      })
      .catch((error) => {
        throw error;
      });
  };
}
