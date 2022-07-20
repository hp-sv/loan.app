const catchActionError = (ex, setStateError) => {
  const validationErrors = {
    onSave: ex.message,
    ...ex.error.errors,
    validationErrors: ex.error.validationErrors,
  };
  setStateError((prevState) => ({
    ...prevState,
    errors: validationErrors,
  }));
};

export default catchActionError;
