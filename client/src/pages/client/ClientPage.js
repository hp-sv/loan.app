import React, { useState } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Drawer } from "antd";
import { newClient } from "../../store/dataInitialiser";

import ClientList from "./ClientList";
import ClientForm from "./ClientForm";
import SearchForm from "../../components/common/SearchForm";
import {
  searchClients,
  setClientFilter,
} from "../../store/actions/clientActions";
import * as constants from "../../constants/Common";

function ClientPage({ clientState, searchClients, setClientFilter }) {
  const [drawerState, setDrawerState] = useState({
    visible: false,
    recordMode: constants.RECORD_NONE,
    selectedClient: newClient,
    title: "",
  });

  function handleValueChange(event) {
    const { value } = event.target;
    setClientFilter(value);
  }

  const handleSearch = (event) => {
    event.preventDefault();
    searchClients(clientState.filterBy, 1, clientState.pageSize);
  };

  function handleEditClient(client) {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_EDIT,
      selectedClient: client,
      title: "Edit client",
    });
  }

  function handleAddClient() {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_ADD,
      selectedClient: newClient,
      title: "Add new client",
    });
  }

  function handleDeleteClient(client) {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_DELETE,
      selectedClient: client,
      title: "Delete client",
    });
  }

  function handleDrawerClose() {
    setDrawerState({
      visible: false,
      recordMode: constants.RECORD_NONE,
      selectedClient: newClient,
      title: "",
    });
  }

  function handlePageChange(page, pageSize) {
    searchClients(
      clientState.filterBy,
      page > 0 ? page : clientState.currentPage,
      clientState.pageSize !== pageSize ? pageSize : clientState.pageSize
    );
  }

  function render() {
    return (
      <>
        {drawerState.visible && (
          <Drawer
            title={drawerState.title}
            placement={"right"}
            closable={true}
            maskClosable={false}
            onClose={handleDrawerClose}
            visible={drawerState.visible}
            key={"createUpdateClient"}
            size={"small"}
          >
            <ClientForm
              selectedClient={drawerState.selectedClient}
              onSubmitSuccess={handleDrawerClose}
              onCancel={handleDrawerClose}
              mode={drawerState.recordMode}
            />
          </Drawer>
        )}
        <div className="container">
          <div className="row">
            <div className="col input-group">
              <SearchForm
                placeHolder="Search client"
                onChange={handleValueChange}
                onSearch={handleSearch}
                value={clientState.filterBy}
              />
              <button
                className="btn btn-outline-secondary bi-person-plus btn-sm"
                onClick={() => handleAddClient()}
              ></button>
            </div>
          </div>
        </div>
        <ClientList
          clientState={clientState}
          onEdit={handleEditClient}
          onDelete={handleDeleteClient}
          onPageChange={handlePageChange}
        />
      </>
    );
  }

  return (
    <>
      <h4>Manage Client</h4>
      {render()}
    </>
  );
}

function mapStateToProps(state) {
  const { clientState } = state;
  return {
    clientState,
    loading: state.apiCallsInProgress > 0,
  };
}

const mapDispatchToProps = {
  searchClients,
  setClientFilter,
};

ClientPage.propTypes = {
  clientState: PropTypes.object.isRequired,
  searchClients: PropTypes.func.isRequired,
  loading: PropTypes.bool.isRequired,
  mode: PropTypes.number.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientPage);
