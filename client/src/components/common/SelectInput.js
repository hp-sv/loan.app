import React from "react";
import PropTypes from "prop-types";
import { Select } from "antd";

const { Option } = Select;

const SelectInput = ({
  name,
  label,
  onChange,
  defaultOption,
  value,
  error,
  options,
  readOnly = false,
}) => {
  const handleOnChange = (value) => {
    onChange({ target: { name, value } });
  };

  return (
    <div className="form-group">
      <label htmlFor={name}>{label}</label>
      <div className="field">
        {/* Note, value is set here rather than on the option - docs: https://facebook.github.io/react/docs/forms.html */}
        <Select
          name={name}
          value={value}
          onChange={!readOnly && handleOnChange}
          className="form-control"
        >
          <Option value="">{defaultOption}</Option>
          {options.map((option) => {
            return (
              <Option key={`${name}_option_${option.id}`} value={option.id}>
                {option.name}
              </Option>
            );
          })}
        </Select>
        {error && <div className="alert alert-danger">{error}</div>}
      </div>
    </div>
  );
};

SelectInput.propTypes = {
  name: PropTypes.string.isRequired,
  label: PropTypes.string.isRequired,
  onChange: PropTypes.func.isRequired,
  defaultOption: PropTypes.string,
  value: PropTypes.oneOfType([PropTypes.string, PropTypes.number]),
  error: PropTypes.string,
  options: PropTypes.arrayOf(PropTypes.object),
  readOnly: PropTypes.bool,
};

export default SelectInput;
