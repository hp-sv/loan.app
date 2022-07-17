import React from "react";
import PropTypes from "prop-types";
import { Input } from "antd";

const TextInput = ({
  name,
  label,
  onChange,
  placeholder,
  value,
  error,
  readOnly = false,
}) => {
  let wrapperClass = "form-group form-group-sm";
  if (error && error.length > 0) {
    wrapperClass += " has-error";
  }

  return (
    <div className={wrapperClass}>
      <label htmlFor={name}>{label}</label>
      <div className="field">
        <Input
          type="text"
          name={name}
          className="form-control"
          placeholder={placeholder}
          value={value}
          onChange={onChange}
          readOnly={readOnly}
        />
        {error && (
          <div
            className="alert alert-danger alert-sm"
            style={{ padding: 0, height: 30 }}
          >
            {error}
          </div>
        )}
      </div>
    </div>
  );
};

TextInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  readOnly: PropTypes.bool,
  value: PropTypes.string,
  error: PropTypes.string,
};

export default TextInput;
