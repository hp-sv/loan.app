import * as types from "./actionTypes";
import * as accountApi from "../../api/accountApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";
import { toast } from "react-toastify";

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

    return toast.promise(accountApi.searchAccounts(filter), {
      pending: "Searching Account. Please wait.",
      success: {
        render(result) {
          dispatch(searchAccountSuccess(result.data));
          return "Search Account completed.";
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

    var saveMessage = account.id
      ? "Update Account completed."
      : "Save new Account completed.";

    return toast.promise(accountApi.saveAccount(account), {
      pending: "Saving Account. Please wait.",
      success: {
        render(result) {
          dispatch(saveAccountSuccess(result.data));
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
  };
}

export function deleteAccount(account) {
  //eslint-disable-next-line no-unused-vars
  return function (dispatch, getState) {
    dispatch(beginApiCall());

    return toast.promise(accountApi.deleteAccount(account.id), {
      pending: "Deleting account. Please wait.",
      success: {
        render() {
          dispatch(deleteAccountSuccess(account));
          return "Delete account completed.";
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
