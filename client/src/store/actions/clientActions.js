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

export function saveClientSuccess(client) {
  return { type: types.SAVE_CLIENT_SUCCESS, client };
}

export function deleteClientSuccess(client) {
  return { type: types.DELETE_CLIENT_SUCCESS, client };
}

export function searchClients(filter) {
  return function (dispatch) {
    dispatch(beginApiCall());
    return toast.promise(clientApi.searchClients(filter), {
      pending: "Searching client. Please wait.",
      success: {
        render(result) {
          dispatch(searchClientSuccess(result.data));
          return "Search client completed.";
        },
      },
      error: {
        render(data) {
          dispatch(apiCallError(data));
          return "Ooops something went wrong.";
        },
      },
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

    var saveMessage = client.id
      ? "Update client completed."
      : "Save new client completed.";

    return toast.promise(clientApi.saveClient(client), {
      pending: "Saving client. Please wait.",
      success: {
        render(result) {
          dispatch(saveClientSuccess(result.data));
          return saveMessage;
        },
      },
      error: {
        render(data) {
          dispatch(apiCallError(data));
          return "Ooops something went wrong.";
        },
      },
    });

    /*
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
*/
  };
}

export function deleteClient(client) {
  //eslint-disable-next-line no-unused-vars
  return function (dispatch, getState) {
    dispatch(beginApiCall());

    return toast.promise(clientApi.deleteClient(client.id), {
      pending: "Deleting client. Please wait.",
      success: {
        render() {
          dispatch(deleteClientSuccess(client));
          return "Delete client completed.";
        },
      },
      error: {
        render(data) {
          dispatch(apiCallError(data));
          return "Ooops something went wrong.";
        },
      },
    });
  };
}
