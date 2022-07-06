import apiUrl from "./apiUrl";
import { handleResponse, handleError } from "./apiUtils";

const baseUrl = apiUrl.baseUrl + "lookup/";

export function saveLookup(lookup) {
  return fetch(baseUrl + (lookup.id || ""), {
    method: lookup.id ? "PUT" : "POST", // POST for create, PUT to update when id already exists.
    headers: { "content-type": "application/json" },
    body: JSON.stringify(lookup),
  })
    .then(handleResponse)
    .catch(handleError);
}

export function deleteLookup(lookupId) {
  return fetch(baseUrl + lookupId, { method: "DELETE" })
    .then(handleResponse)
    .catch(handleError);
}

export function getLookupBySetId(id) {
  return fetch(baseUrl + id, { method: "GET" })
    .then(handleResponse)
    .catch(handleError);
}
