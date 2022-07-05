import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import { searchClients } from "../../store/actions/clientActions";
import { setCurrentPageTitle } from "../../store/actions/pageAction";
import PropTypes from "prop-types";
import ClientList from "./ClientList";
import SearchForm from "../common/SearchForm";
import { Navigate } from "react-router-dom";
import { setClientFilterBy } from "../../store/actions/filterAction";
import Disabled from "../common/Disabled";

function ClientPage({
  clients,
  searchClients,
  setCurrentPageTitle,
  setClientFilterBy,
  clientFilterBy,
  loading,
}) {
  useEffect(() => {
    setCurrentPageTitle("Clients");
    setFilterBy(clientFilterBy);
  }, []);

  const [filterBy, setFilterBy] = useState("");

  function handleValueChange(event) {
    const { value } = event.target;
    setFilterBy(value);
  }

  function handleSearch(event) {
    event.preventDefault();    
    setClientFilterBy(filterBy);
    searchClients(filterBy);
  }

  const [redirectToAddClient, setRedirectToAddClient] = useState(false);

  return ( 
    <>   
      {redirectToAddClient && <Navigate to="/client" />}
      <Disabled disabled={loading}>
      <div className="row">
          <div className="input-group">
            <button
                className="btn btn-outline-secondary bi-person btn-sm"
                onClick={() => setRedirectToAddClient(true)}
              >
                Add Client
              </button>
            <SearchForm
              placeHolder="Search client"
              onChange={handleValueChange}
              onSearch={handleSearch}
              value={filterBy}
            />
          </div>
      </div>
      <ClientList clients={clients} />
      </Disabled>
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
  setCurrentPageTitle,
  setClientFilterBy,
};

ClientPage.propTypes = {
  clients: PropTypes.array.isRequired,
  searchClients: PropTypes.func.isRequired,
  setCurrentPageTitle: PropTypes.func.isRequired,
  loading: PropTypes.bool.isRequired,
  clientFilterBy: PropTypes.string,
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientPage);
