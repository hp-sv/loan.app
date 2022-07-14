import apiUrl from "./apiUrl";
import { handleResponse, handleError } from "./apiUtils";
const baseUrl = apiUrl.baseUrl + "client/";

export function saveClient(client) {
  return fetch(baseUrl + (client.id || ""), {
    method: client.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(client),
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteClient(clientId) {
  return fetch(baseUrl + clientId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}

export function getClientById(id) {
  return fetch(baseUrl + id, { method: "GET" })
    .then(handleResponse)
    .catch(handleError);
}

export function searchClients(filter, page, pageSize) {
  if (filter.length > 0) {
    return fetch(
      `${baseUrl}search?filter=${filter}&pg=${page}&pgsize=${pageSize}`,
      {
        method: "GET",
      }
    )
      .then(handleResponse)
      .catch(handleError);
  } else {
    return fetch(`${baseUrl}?pg=${page}&pgsize=${pageSize}`, {
      method: "GET",
    })
      .then(handleResponse)
      .catch(handleError);
  }
}
