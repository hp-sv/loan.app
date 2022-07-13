import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import { AutoComplete } from "antd";
import * as clientApi from "../../api/clientApi";

const Option = AutoComplete.Option;

function AutoCompleteClient({
  name,
  label,
  selected,
  onSelect,
  filterOption,
  error,
}) {
  const [clients, setClients] = useState([]);
  const [inputValue, setInputValue] = useState("");

  useEffect(() => {
    if (clients.length === 0 && selected && selected !== "") {
      clientApi.searchClients(selected).then((searchResult) => {
        setClients(searchResult);
      });
    }

    setInputValue(selected);
  }, [selected]);

  const handleSearch = (value) => {
    if (value && value.length >= 2) {
      clientApi.searchClients(value).then((searchResult) => {
        setClients(searchResult);
      });
    }
  };

  const handleChange = (value, label) => {
    setInputValue(value);
  };

  const handleSelect = (value, option) => {
    const selectedClient = clients.find(
      (client) => client.id === parseInt(option.id)
    );
    onSelect(selectedClient);
  };

  const clientOptions = clients
    .filter((client) => {
      return filterOption ? filterOption(client) : true;
    })
    .map((client) => {
      return (
        <Option key={client.fullName} id={client.id}>
          {client.fullName}
        </Option>
      );
    });

  let wrapperClass = "form-group form-group-sm";
  if (error && error.length > 0) {
    wrapperClass += " has-error";
  }

  return (
    <div className={wrapperClass}>
      <label htmlFor={name}>{label}</label>
      <div className="field">
        <AutoComplete
          style={{ width: 200 }}
          value={inputValue}
          onSearch={handleSearch}
          onChange={handleChange}
          onSelect={handleSelect}
          placeholder="Search client here"
        >
          {clientOptions}
        </AutoComplete>
        {error && (
          <div
            className="alert alert-danger alert-sm"
            style={{ padding: 0, height: 30 }}
          >
            {error}
          </div>
        )}
      </div>
    </div>
  );
}

AutoCompleteClient.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onSelect: PropTypes.func.isRequired,
  filterOption: PropTypes.func.isRequired,
  selected: PropTypes.string,
  error: PropTypes.string,
};

export default AutoCompleteClient;
