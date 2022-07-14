import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Drawer } from "antd";
import { newClient } from "../../store/dataInitialiser";

import ClientList from "./ClientList";
import ClientForm from "./ClientForm";
import SearchForm from "../../components/common/SearchForm";
import {
  searchClients,
  saveClient,
  deleteClient,
  setClientFilter,
} from "../../store/actions/clientActions";
import * as constants from "../../constants/Common";

function ClientPage({
  clientState,
  searchClients,
  setClientFilter,
  saveClient,
  deleteClient,
  mode,
}) {
  const [pageMode, setPageMode] = useState(mode);

  const [drawerState, setDrawerState] = useState({
    visible: false,
    recordMode: constants.RECORD_NONE,
    selectedClient: newClient,
    title: "",
    submitting: false,
    error: {},
  });

  useEffect(() => {
    setPageMode(mode);
  }, []);

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
      submitting: false,
      error: {},
    });
  }

  function handleAddClient() {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_ADD,
      selectedClient: newClient,
      title: "Add new client",
      submitting: false,
      error: {},
    });
  }

  function handleDeleteClient(client) {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_DELETE,
      selectedClient: client,
      title: "Delete client",
      submitting: false,
      error: {},
    });
  }

  function onDrawerClose() {
    setDrawerState({
      visible: false,
      recordMode: constants.RECORD_NONE,
      selectedClient: newClient,
      title: "",
      submitting: false,
      error: {},
    });
  }

  function handleSubmitForm(event) {
    event.preventDefault();
    if (drawerState.recordMode === constants.RECORD_DELETE) {
      deleteClient(drawerState.selectedClient)
        .then(() => {
          onDrawerClose();
        })
        .catch((ex) => {
          catchError(ex);
        });
    } else {
      //RECORD_ADD, RECORD_EDIT
      saveClient(drawerState.selectedClient)
        .then(() => {
          onDrawerClose();
        })
        .catch((ex) => {
          catchError(ex);
        });
    }
  }

  function catchError(ex) {
    const validationErrors = {
      onSave: ex.message,
      ...ex.error.errors,
      validationErrors: ex.error.validationErrors,
    };

    setDrawerState((state) => ({
      ...state,
      error: validationErrors,
    }));
  }

  function handleCancelForm() {
    setDrawerState({
      visible: false,
      recordMode: constants.RECORD_NONE,
      selectedClient: newClient,
      title: "",
      submitting: false,
      error: {},
    });
  }

  function handleEmergencyContactSelected(client) {
    setDrawerState((prevState) => ({
      ...prevState,
      ...{
        selectedClient: {
          ...prevState.selectedClient,
          emergencyContact: client,
          emergencyContactId: client.id,
        },
      },
    }));
  }

  function handleChange(event) {
    const { name, value } = event.target;
    setDrawerState((prevState) => ({
      ...prevState,
      ...{
        selectedClient: {
          ...prevState.selectedClient,
          [name]: name === "id" ? parseInt(value, 0) : value,
        },
      },
    }));
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
            closable={false}
            onClose={onDrawerClose}
            visible={drawerState.visible}
            key={"createUpdateClient"}
            size={"small"}
          >
            <ClientForm
              client={drawerState.selectedClient}
              onSubmitForm={handleSubmitForm}
              onCancelForm={handleCancelForm}
              onChange={handleChange}
              onEmergencyContactSelected={handleEmergencyContactSelected}
              mode={drawerState.recordMode}
              submitting={drawerState.submitting}
              errors={drawerState.error}
            />
          </Drawer>
        )}
        <div className="row">
          <div className="input-group">
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
      {pageMode === constants.PAGE_MANAGE && <h4>Manage Client</h4>}
      {pageMode === constants.PAGE_SELECT && <h4>Select Client</h4>}
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
  saveClient,
  deleteClient,
};

ClientPage.propTypes = {
  clientState: PropTypes.object.isRequired,
  searchClients: PropTypes.func.isRequired,
  saveClient: PropTypes.func.isRequired,
  deleteClient: PropTypes.func.isRequired,
  updateClientState: PropTypes.func.isRequired,
  loading: PropTypes.bool.isRequired,
  mode: PropTypes.number.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientPage);
