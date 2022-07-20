import React, { useState } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import CommentInput from "../../components/common/CommentInput";
import { saveAccountComment } from "../../store/actions/accountActions";
import catchActionError from "../../module/catchActionError";

const AccountCommentForm = ({
  account,
  saveAccountComment,
  onSubmitSuccess,
}) => {
  const [selectedAccount, setSelectedAccount] = useState({
    account,
    accountComment: "",
    errors: {},
    submitting: false,
  });

  const setDefaultState = () => {
    setSelectedAccount({
      account,
      accountComment: "",
      errors: {},
      submitting: false,
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    event.stopPropagation();

    const { account, accountComment } = selectedAccount;
    const newComment = {
      accountId: account.id,
      comment: accountComment,
      statusId: account.statusId,
    };

    saveAccountComment(newComment)
      .then((savedAccount) => {
        setDefaultState();
        onSubmitSuccess(savedAccount);
      })
      .catch((ex) => {
        catchActionError(ex, setSelectedAccount);
      });
  };

  const handleChange = (event) => {
    const { value } = event.target;
    setSelectedAccount((prevState) => ({
      ...prevState,
      accountComment: value,
    }));
  };

  const { errors, accountComment, submitting } = selectedAccount;

  return (
    <form onSubmit={handleSubmit}>
      {errors.onSave && (
        <div className="alert alert-danger" role="alert sm">
          {errors.onSave}
          <br />
          {errors.validationErrors &&
            errors.validationErrors.map((error) => {
              return (
                <li
                  key={`__validationError${error.code}`}
                >{`[Code]: ${error.code}: [Message]: ${error.message}`}</li>
              );
            })}
        </div>
      )}
      <CommentInput
        name="Comment"
        label="Comment"
        value={accountComment}
        onChange={handleChange}
        error={
          errors["comment"] && errors["comment"].length > 0
            ? errors["comment"][0]
            : ""
        }
      />
      <button
        type="submit"
        disabled={submitting}
        className="btn btn-outline-secondary bi-save btn-sm m-1"
      >
        {submitting ? "Saving new comment..." : "Save"}
      </button>
    </form>
  );
};

AccountCommentForm.propTypes = {
  account: PropTypes.object.isRequired,
  saveAccountComment: PropTypes.func.isRequired,
  onSubmitSuccess: PropTypes.func.isRequired,
};

const mapDispatchToProps = {
  saveAccountComment,
};

export default connect(() => {
  return {};
}, mapDispatchToProps)(AccountCommentForm);
