import * as types from "./actionTypes";
import * as clientApi from "../../api/clientApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";
import { message } from "antd";

export function searchClientSuccess(searchResult) {
  return { type: types.SEARCH_CLIENT_SUCCESS, searchResult };
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

export function setClientFilterCompleted(filterBy) {
  return { type: types.SET_CLIENT_FILTER_COMPLETED, filterBy };
}

export function setClientFilter(filterBy) {
  return function (dispatch) {
    dispatch(setClientFilterCompleted(filterBy));
  };
}

export function searchClients(filter, page, pageSize) {
  return function (dispatch) {
    dispatch(beginApiCall());

    const msgKey = "__searchClient__";
    message.loading({
      content: "Searching client, please wait...",
      key: msgKey,
    });

    return clientApi
      .searchClients(filter, page, pageSize)
      .then((searchResult) => {
        dispatch(searchClientSuccess(searchResult));
        message.destroy(msgKey);
        message.success({
          content: "Search client completed.",
          key: msgKey,
          duration: 1,
        });
      })
      .catch((error) => {
        message.destroy(msgKey);
        message.error({
          content: "Ooops something went wrong. ",
          key: msgKey,
          duration: 1,
        });
        dispatch(apiCallError(error));
        throw error;
      });
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

    const msgKey = `__saveClient__${client.id}`;
    var saveMessage = client.id
      ? "Updating client, please wait..."
      : "Saving new client, please wait...";

    var completedMessage = client.id ? "Updated client." : "Saved new client.";

    message.loading({ content: saveMessage, key: msgKey, duration: 10 });

    return clientApi
      .saveClient(client)
      .then((savedClient) => {
        dispatch(saveClientSuccess(savedClient));
        message.destroy(msgKey);
        message.success({
          content: completedMessage,
          key: msgKey,
          duration: 1,
        });
      })
      .catch((error) => {
        dispatch(apiCallError(error));
        message.destroy(msgKey);
        message.error({
          content: "Ooops something went wrong. ",
          key: msgKey,
          duration: 1,
        });
        throw error;
      });
  };
}

export function deleteClient(client) {
  //eslint-disable-next-line no-unused-vars
  return function (dispatch, getState) {
    dispatch(beginApiCall());

    const msgKey = `__deleteClient__${client.id}`;

    message.loading({
      content: "Deleting client... please wait.",
      key: msgKey,
      duration: 1,
    });

    return clientApi
      .deleteClient(client.id)
      .then(() => {
        dispatch(deleteClientSuccess(client));
        message.destroy(msgKey);
        message.success({
          content: "Client deleted.",
          key: msgKey,
          duration: 1,
        });
      })
      .catch((error) => {
        dispatch(apiCallError(error));
        message.destroy(msgKey);
        message.error({
          content: "Ooops something went wrong. ",
          key: msgKey,
          duration: 1,
        });
      });
  };
}
