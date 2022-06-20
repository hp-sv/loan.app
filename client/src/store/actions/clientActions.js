import * as types from "./clientActionTypes";
import * as clientApi from "../../api/clientApi";

export function createClient(client) {
  return { type: types.CREATE_CLIENT, client };
}

export function loadClientSuccess(clients) {
  return { type: types.LOAD_CLIENTS_SUCCESS, clients };
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
