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

export function searchAccounts(filter, page, pageSize) {
  if (filter.length > 0) {
    return fetch(
      `${baseUrl}search?filter=${filter}&pg=${page}&pgsize=${pageSize}`,
      { method: "GET" }
    )
      .then(handleResponse)
      .catch(handleError);
  } else {
    return fetch(`${baseUrl}?pg=${page}&pgsize=${pageSize}`, { method: "GET" })
      .then(handleResponse)
      .catch(handleError);
  }
}

export function approveAccount(account) {
  return fetch(`${baseUrl}${account.id}/approve`, {
    method: "PUT",
    headers: { "content-type": "application/json" },
    body: JSON.stringify(account),
  })
    .then(handleResponse)
    .catch(handleError);
}

export function cancelAccount(account) {
  return fetch(`${baseUrl}${account.id}/cancel`, {
    method: "PUT",
    headers: { "content-type": "application/json" },
    body: JSON.stringify(account),
  })
    .then(handleResponse)
    .catch(handleError);
}

export function declineAccount(account) {
  return fetch(`${baseUrl}${account.id}/decline`, {
    method: "PUT",
    headers: { "content-type": "application/json" },
    body: JSON.stringify(account),
  })
    .then(handleResponse)
    .catch(handleError);
}
