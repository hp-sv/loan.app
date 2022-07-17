import React from "react";
import PropTypes from "prop-types";
import { InputNumber } from "antd";

const MoneyInput = ({
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
          defaultValue={1000}
          formatter={(value) =>
            `$ ${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ",")
          }
          parser={(value) => value.replace(/\$\s?|(,*)/g, "")}
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

MoneyInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  value: PropTypes.number,
  error: PropTypes.string,
  readOnly: PropTypes.bool,
};

export default MoneyInput;
