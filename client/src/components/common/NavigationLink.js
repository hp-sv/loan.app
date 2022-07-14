import React from "react";
import { NavLink } from "react-router-dom";
import {
  AccountBookOutlined ,
  TeamOutlined,
  InfoCircleOutlined,
  HomeOutlined,
  SettingOutlined
} from '@ant-design/icons';

function NavigationLink() {
  return (
    <>
      <div className="col-md-1">
        <NavLink to="/" className="text-muted" style={{verticalAlign:"middle"}}>
          <HomeOutlined/>Home
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink to="/clients" className="text-muted">
          <TeamOutlined/>Clients
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink to="/accounts" className="text-muted">
          <AccountBookOutlined/>Accounts
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink to="/admin" className="text-muted">
          <SettingOutlined/>Admin
        </NavLink>
      </div>
      <div className="col-md-1">
        <NavLink to="/about" className="text-muted">
          <InfoCircleOutlined />About
        </NavLink>
      </div>
    </>
  );
}

export default NavigationLink;
