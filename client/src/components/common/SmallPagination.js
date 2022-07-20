import React from "react";
import PropTypes from "prop-types";
import { Pagination } from "antd";
import { PaginationProps } from "antd";

const showTotal: PaginationProps["showTotal"] = (total) =>
  `Total ${total} items`;

const SmallPagination = ({ total, pageSize, onChange }) => {
  return (
    <Pagination
      size="small"
      total={total}
      pageSize={pageSize}
      showSizeChanger={false}
      showTotal={showTotal}
      onChange={onChange}
    />
  );
};

SmallPagination.propTypes = {
  total: PropTypes.number.isRequired,
  pageSize: PropTypes.number.isRequired,
  onChange: PropTypes.func.isRequired,
};

export default SmallPagination;
