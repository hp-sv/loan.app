import React from "react";
import PropTypes from "prop-types";
import { Input } from "antd";
const { TextArea } = Input;

const CommentInput = ({ name, label, onChange, placeholder, value, error }) => {
  let wrapperClass = "form-group form-group-sm";
  if (error && error.length > 0) {
    wrapperClass += " has-error";
  }

  return (
    <div className={wrapperClass}>
      <label htmlFor={name}>{label}</label>
      <div className="field">
        <TextArea
          name={name}
          className="form-control"
          placeholder={placeholder}
          value={value}
          onChange={onChange}
          rows={4}
          maxLength={500}
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

CommentInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  readOnly: PropTypes.bool,
  value: PropTypes.string,
  error: PropTypes.string,
};

export default CommentInput;
