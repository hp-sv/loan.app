import React from "react";
import PropTypes from "prop-types";

function Disabled({ disabled, children }) {
  if (disabled) {
    return (
      <div style={{ pointerEvents: "none" }} disabled>
        {children}
      </div>
    );
  }

  return <React.Fragment>{children}</React.Fragment>;
}

Disabled.propTypes = {
  disabled: PropTypes.bool.isRequired,
};

export default Disabled;
