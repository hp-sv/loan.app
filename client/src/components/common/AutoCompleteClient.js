import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import { AutoComplete } from "antd";
import * as clientApi from "../../api/clientApi";
import Disabled from "./Disabled";
import intialState from "../../store/reducers/initialState";
import {
  EditOutlined
} from '@ant-design/icons';

const Option = AutoComplete.Option;

function AutoCompleteClient({
  name,
  label,
  selected,
  onSelect,
  filterOption,
  error,
  disable = false,
}) {
  const [clientState, setClientState] = useState(intialState.clientState);
  const [inputValue, setInputValue] = useState("");
  
  const {page, pageSize} = {page:1, pageSize: 50};

  useEffect(() => {
    if (clientState.results.length === 0 && selected && selected !== "") {
      clientApi.searchClients(selected, page, pageSize).then((searchResult) => {
        setClientState(searchResult);
      });
    }

    setInputValue(selected);
  }, [selected]);

  const handleSearch = (value) => {
    if (value && value.length > 0) {
      clientApi.searchClients(value, page, pageSize).then((searchResult) => {
        setClientState(searchResult);
      });
    }
  };

  const handleChange = (value, label) => {
    setInputValue(value);
  };

  const handleSelect = (value, option) => {
    const selectedClient = clientState.results.find(
      (client) => client.id === parseInt(option.id)
    );
    onSelect(selectedClient);
  };

  const clientOptions = clientState.results
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
      <Disabled disabled={disable}>
      <div className="field">        
          <AutoComplete
            value={inputValue}
            style={{ width: "90%" }}
            onSearch={handleSearch}
            onChange={handleChange}
            onSelect={handleSelect}
            placeholder="Search client here"
          >
            {clientOptions}
          </AutoComplete>
          <EditOutlined className="grid_inline_icon" />
        
        {error && (
          <div
            className="alert alert-danger alert-sm"
            style={{ padding: 0, height: 30 }}
          >
            {error}
          </div>
        )}
      </div>
      </Disabled>
    </div>
  );
}

AutoCompleteClient.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onSelect: PropTypes.func.isRequired,
  filterOption: PropTypes.func.isRequired,
  disable: PropTypes.bool.isRequired,
  selected: PropTypes.string,
  error: PropTypes.string,
};

export default AutoCompleteClient;
