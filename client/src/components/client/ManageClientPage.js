import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import ClientForm from "./ClientForm";
import { newClient } from "../../store/dataInitialiser";

function ManageClientPage({ client }) {
  return (
    <div className="col-md-6">
      <ClientForm client={client} />
    </div>
  );
}

function mapStateToProps(state) {
  return {
    client: newClient,
  };
}

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(ManageClientPage);
