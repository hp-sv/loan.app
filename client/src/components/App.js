import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-icons/font/bootstrap-icons.css";
import HomePage from "./home/HomePage";
import AboutPage from "./about/AboutPage";
import Header from "./common/Header";
import PageNotFound from "./PageNotFound";
import ClientPage from "./client/ClientPage";
import ManageClientPage from "./client/ManageClientPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function App() {
  return (
    <div className="container">
      <Router>
        <Header title="Home" />
        <Routes>
          <Route exact path="/" element={<HomePage />} />
          <Route path="/about" element={<AboutPage />} />
          <Route path="/clients" element={<ClientPage />} />
          <Route path="/client/:id" element={<ManageClientPage />} />
          <Route path="/client" element={<ManageClientPage />} />
          <Route element={PageNotFound} />
        </Routes>
      </Router>
      <ToastContainer autoClose={1000} />
    </div>
  );
}

export default App;
