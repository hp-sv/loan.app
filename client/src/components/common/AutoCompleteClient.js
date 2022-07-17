import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import { AutoComplete, Drawer } from "antd";
import * as clientApi from "../../api/clientApi";
import Disabled from "./Disabled";
import intialState from "../../store/reducers/initialState";
import { EditOutlined } from "@ant-design/icons";
import * as constants from "../../constants/Common";
import ClientForm from "../../pages/client/ClientForm";

const Option = AutoComplete.Option;

function AutoCompleteClient({
  name,
  label,
  selected,
  onSelect,
  filterOption,
  showEdit,
  disable,
  error,
}) {
  const [selectedState, setSelectedState] = useState({
    client: { id: -1 },
    mode: constants.RECORD_NONE,
    visible: false,
  });

  const [clientState, setClientState] = useState(intialState.clientState);
  const [inputValue, setInputValue] = useState("");

  const { page, pageSize } = { page: 1, pageSize: 50 };

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
    setSelectedState({ ...selectedState, client: selectedClient });

    onSelect(selectedClient);
  };

  const handleEditClient = () => {
    setSelectedState({
      ...selectedState,
      mode: constants.RECORD_EDIT,
      visible: true,
    });
  };

  const handleCloseEdit = () => {
    setSelectedState({ ...selectedState, visible: false });
  };

  const handleCloseDrawer = () => {
    setSelectedState({ ...selectedState, visible: false });
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

  const style = {
    width: showEdit && selectedState.client.id > 0 ? "90%" : "100%",
  };

  return (
    <div className={wrapperClass}>
      <label htmlFor={name}>{label}</label>
      <div className="field">
        <Disabled disabled={disable}>
          <AutoComplete
            value={inputValue}
            style={style}
            onSearch={handleSearch}
            onChange={handleChange}
            onSelect={handleSelect}
            placeholder="Search client here"
          >
            {clientOptions}
          </AutoComplete>
        </Disabled>
        {showEdit && selectedState.client.id > 0 && (
          <EditOutlined
            className="grid_inline_icon"
            onClick={handleEditClient}
          />
        )}
        {error && (
          <div
            className="alert alert-danger alert-sm"
            style={{ padding: 0, height: 30 }}
          >
            {error}
          </div>
        )}
      </div>
      <Drawer
        title="Edit client"
        placement={"right"}
        closable={true}
        maskClosable={false}
        visible={selectedState.visible}
        key={"updateClientFromAutoComplete"}
        onClose={handleCloseEdit}
        size={"small"}
      >
        <ClientForm
          selectedClient={selectedState.client}
          onSubmitSuccess={handleCloseDrawer}
          onCancel={handleCloseDrawer}
          mode={constants.RECORD_EDIT}
        />
      </Drawer>
    </div>
  );
}

AutoCompleteClient.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onSelect: PropTypes.func.isRequired,
  filterOption: PropTypes.func.isRequired,
  showEdit: PropTypes.bool.isRequired,
  disable: PropTypes.bool.isRequired,
  selected: PropTypes.string,
  error: PropTypes.string,
};

export default AutoCompleteClient;
