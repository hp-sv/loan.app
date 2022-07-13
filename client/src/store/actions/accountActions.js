import * as types from "./actionTypes";
import * as accountApi from "../../api/accountApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";
import { message } from "antd";

export function searchAccountSuccess(accounts) {
  return { type: types.SEARCH_ACCOUNT_SUCCESS, accounts };
}

export function getAccountSuccess(account) {
  return { type: types.GET_ACCOUNT_SUCCESS, account };
}

export function saveAccountSuccess(account) {
  return { type: types.SAVE_ACCOUNT_SUCCESS, account };
}

export function deleteAccountSuccess(account) {
  return { type: types.DELETE_ACCOUNT_SUCCESS, account };
}

export function searchAccounts(filter) {
  return function (dispatch) {
    dispatch(beginApiCall());

    const msgKey = "__searchAccount__";
    message.loading({
      content: "Searching account... Please wait.",
      key: msgKey,
      duration: 10,
    });

    return accountApi
      .searchAccounts(filter)
      .then((accounts) => {
        dispatch(searchAccountSuccess(accounts));
        message.destroy(msgKey);
        message.success({
          content: "Search account completed.",
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
        throw error;
      });
  };
}

export function getAccountById(id) {
  return function (dispatch) {
    dispatch(beginApiCall());

    return accountApi
      .getAccountById(id)
      .then((account) => {
        dispatch(getAccountSuccess(account));
      })
      .catch((error) => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}

export function saveAccount(account) {
  //eslint-disable-next-line no-unused-vars
  return function (dispatch, getState) {
    dispatch(beginApiCall());

    const msgKey = `__saveAccount__${account.id}`;
    var saveMessage = account.id
      ? "Updating account, please wait..."
      : "Saving new account, please wait...";

    var completedMessage = account.id
      ? "Updated account."
      : "Saved new account.";

    message.loading({ content: saveMessage, key: msgKey, duration: 10 });
    return accountApi
      .saveAccount(account)
      .then((savedAccount) => {
        dispatch(saveAccountSuccess(savedAccount));
        message.destroy(msgKey);
        message.success({
          content: completedMessage,
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
        throw error;
      });
  };
}

export function deleteAccount(account) {
  //eslint-disable-next-line no-unused-vars
  return function (dispatch, getState) {
    dispatch(beginApiCall());

    const msgKey = `__deleteAccount__${account.id}`;
    message.loading({
      content: "Deleting account... please wait.",
      key: msgKey,
      duration: 10,
    });

    return accountApi
      .deleteAccount(account.id)
      .then(() => {
        dispatch(deleteAccountSuccess(account));
        message.destroy(msgKey);
        message.success({
          content: "Account deleted.",
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
