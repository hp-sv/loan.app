import React from "react";
import { NavLink } from "react-router-dom";

function NavigationLink() {
  return (
    <>
      <div className="col-md-1">
        <NavLink to="/" className="bi bi-house text-muted">
          Home
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink to="/clients" className="bi bi-people text-muted">
          Clients
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink to="/accounts" className="bi bi-journal text-muted">
          Accounts
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink to="/admin" className="bi bi-gear text-muted">
          Admin
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink to="/about" className="bi bi-info-circle text-muted">
          About
        </NavLink>
      </div>
    </>
  );
}

export default NavigationLink;
