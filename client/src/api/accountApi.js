import apiUrl from "./apiUrl";
import { handleResponse, handleError } from "./apiUtils";

const baseUrl = apiUrl.baseUrl + "account/";

export function saveAccount(account) {
  return fetch(baseUrl + (account.id || ""), {
    method: account.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(account),
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteAccount(accountId) {
  return fetch(baseUrl + accountId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}

export function getAccountById(id) {
  return fetch(baseUrl + id, { method: "GET" })
    .then(handleResponse)
    .catch(handleError);
}

export function searchAccounts(filter) {
  return fetch(baseUrl + "search?filter=" + filter, { method: "GET" })
    .then(handleResponse)
    .catch(handleError);
}
