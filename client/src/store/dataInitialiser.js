const newClient = {
  id: null,
  firstName: "",
  middleName: "",
  lastName: "",
  dob: "1900-01-01",
  emailAddress: "",
  mobileNumber: "",
  addressLine1: "",
  addressLine2: "",
  addressLine3: "",
};

const newAccount = {
  id: null,
  clientId: null,
  rate: 1.0,
  principal: 0.0,
  duration: 6,
  durationTypeId: 10005,
  repaymentTypeId: 10011,
  statusId: 10027,
  accountComments: [],
  accountTransactions: [],
};

module.exports = {
  newClient,
  newAccount,
};
