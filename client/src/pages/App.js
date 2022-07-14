import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.css";

import HomePage from "./home/HomePage";
import AccountPage from "./account/AccountPage";
import AboutPage from "./about/AboutPage";
import Header from "../components/common/Header";
import PageNotFound from "./PageNotFound";
import ClientPage from "./client/ClientPage";
import * as constants from "../constants/Common";

function App() {
  return (
    <div className="container">
      <Router>
        <Header title="Home" />
        <Routes>
          <Route exact path="/" element={<HomePage />} />
          <Route path="/about" element={<AboutPage />} />
          <Route
            exact
            path="/clients"
            element={<ClientPage mode={constants.PAGE_MANAGE} />}
          />
          <Route
            exact
            path="/accounts"
            element={<AccountPage />}
          />
          <Route element={PageNotFound} />
        </Routes>
      </Router>      
    </div>
  );
}

export default App;
