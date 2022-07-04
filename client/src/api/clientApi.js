import { handleResponse, handleError } from "./apiUtils";
const baseUrl = "https://localhost:7219/api/client/";

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

export function searchClients(filter) {
  return fetch(baseUrl + "search?filter=" + filter, { method: "GET" })
    .then(handleResponse)
    .catch(handleError);
}
