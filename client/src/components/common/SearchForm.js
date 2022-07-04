import React from "react";
import PropTypes from "prop-types";

function SearchForm({ onChange, onSearch, value, placeHolder }) {
  return (
    <form className="form-inline" onSubmit={onSearch}>
      <div className="input-group input-group-sm">
        <input
          type="text"
          name="filter"
          className="form-control"
          placeholder={placeHolder}
          value={value}
          onChange={onChange}
        />
        <div className="input-group-btn">
          <button
            type="submit"
            className="btn btn-outline-secondary bi bi-search btn-sm"
          ></button>
        </div>
      </div>
    </form>
  );
}

SearchForm.propTypes = {
  value: PropTypes.string,
  onChange: PropTypes.func.isRequired,
  onSearch: PropTypes.func.isRequired,
  placeHolder: PropTypes.string.isRequired,
};

export default SearchForm;
