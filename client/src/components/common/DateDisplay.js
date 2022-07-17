import React from "react";
import PropTypes from "prop-types";
import parseJSON from "date-fns/parseJSON";
import { format } from "date-fns";

const DateDisplay = (date) => {
  const theDate = new Date(date);
  return <>{format(theDate, "dd/MM/yyyy")}</>;
};

DateDisplay.propTypes = {
  date: PropTypes.string.isRequired,
};

export default DateDisplay;
