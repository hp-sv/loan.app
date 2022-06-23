import React from "react";
import { NavLink } from "react-router-dom";

function NavigationLink() {
  
  const activeStyle = { color: "blue" };

  return (
    <>
      <div className="col-md-1">
        <NavLink exact to="/" activeStyle={activeStyle} className="bi bi-house">
          Home
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink
          exact
          to="/clients"
          activeStyle={activeStyle}
          className="bi bi-person"
        >
          Clients
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink
          exact
          to="/accounts"
          activeStyle={activeStyle}
          className="bi bi-credit-card"
        >
          Accounts
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink
          exact
          to="/admin"
          activeStyle={activeStyle}
          className="bi bi-gear"
        >
          Admin
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink
          exact
          to="/about"
          activeStyle={activeStyle}
          className="bi bi-info-circle"
        >
          About
        </NavLink>
      </div>
      <div className="col-md-7"></div>
    </>
  );
}

export default NavigationLink;
