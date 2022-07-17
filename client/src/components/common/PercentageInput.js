import React from "react";
import PropTypes from "prop-types";
import { InputNumber } from "antd";

const PercentageInput = ({
  name,
  label,
  onChange,
  placeholder,
  value,
  error,
  min,
  max,
  readOnly = false,
}) => {
  let wrapperClass = "form-group form-group-sm";
  if (error && error.length > 0) {
    wrapperClass += " has-error";
  }

  const handleOnChange = (value) => {
    onChange({ target: { name, value } });
  };

  return (
    <div className={wrapperClass}>
      <label htmlFor={name}>{label}</label>
      <div className="field">
        <InputNumber
          name={name}
          className="form-control"
          placeholder={placeholder}
          value={value}
          onChange={handleOnChange}
          min={min}
          max={max}
          formatter={(value) => `${value}%`}
          parser={(value) => value.replace("%", "")}
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

PercentageInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  min: PropTypes.number.isRequired,
  max: PropTypes.number.isRequired,
  placeholder: PropTypes.string,
  value: PropTypes.number,
  error: PropTypes.string,
  readOnly: PropTypes.bool,
};

export default PercentageInput;
