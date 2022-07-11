import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import Disabled from "../../components/common/Disabled";
import ClientList from "./ClientList";
import SearchForm from "../../components/common/SearchForm";
import { searchClients } from "../../store/actions/clientActions";
import { setClientFilterBy } from "../../store/actions/filterAction";
import ManageClient from "./ManageClient";
import * as constants from "../../constants/Common";

function ClientPage({
  clients,
  searchClients,
  setClientFilterBy,
  clientFilterBy,
  onAfterClientSelect,
  mode,
  loading,
}) {
  const [pageMode, setPageMode] = useState(mode);
  const [recordMode, setRecordMode] = useState(constants.RECORD_NONE);
  const [selectedClientId, setSelectedClientId] = useState(0);

  useEffect(() => {
    setPageMode(mode);
  }, []);

  function handleValueChange(event) {
    const { value } = event.target;
    setClientFilterBy(value);
  }

  function handleSearch(event) {
    event.preventDefault();
    searchClients(clientFilterBy);
  }

  function handleEditClient(id) {
    setRecordMode(constants.RECORD_EDIT);
    setSelectedClientId(id);
  }

  function handleAddClient() {
    setSelectedClientId(null);
    setRecordMode(constants.RECORD_ADD);
  }

  function handleDeleteClient(id) {
    setRecordMode(constants.RECORD_DELETE);
    setSelectedClientId(id);
  }

  function handleAfterClientSaveAndCancel() {
    setRecordMode(constants.RECORD_NONE);
  }

  function render() {
    switch (recordMode) {
      case constants.RECORD_ADD:
      case constants.RECORD_EDIT:
      case constants.RECORD_DELETE:
        return (
          <ManageClient
            id={selectedClientId}
            mode={recordMode}
            afterClientSave={handleAfterClientSaveAndCancel}
            handleCancelForm={handleAfterClientSaveAndCancel}
          />
        );
      default:
        return (
          <Disabled disabled={loading}>
            <div className="row">
              <div className="input-group">
                <SearchForm
                  placeHolder="Search client"
                  onChange={handleValueChange}
                  onSearch={handleSearch}
                  value={clientFilterBy}
                />
                <button
                  className="btn btn-outline-secondary bi-person-plus btn-sm"
                  onClick={() => handleAddClient()}
                ></button>
              </div>
            </div>
            <ClientList
              clients={clients}
              onSelect={onAfterClientSelect}
              onEdit={handleEditClient}
              onDelete={handleDeleteClient}
            />
          </Disabled>
        );
    }
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
  const { clients, filters } = state;
  return {
    clients: clients.length === 0 ? [] : clients,
    loading: state.apiCallsInProgress > 0,
    clientFilterBy: filters.clientFilterBy,
  };
}

const mapDispatchToProps = {
  searchClients,
  setClientFilterBy,
};

ClientPage.propTypes = {
  clients: PropTypes.array.isRequired,
  searchClients: PropTypes.func.isRequired,
  setClientFilterBy: PropTypes.func.isRequired,
  loading: PropTypes.bool.isRequired,
  clientFilterBy: PropTypes.string,
  mode: PropTypes.number.isRequired,
  onAfterClientSelect: PropTypes.func,
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientPage);
