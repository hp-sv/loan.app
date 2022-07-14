const intialState = {
  /* Client */
  clientState: {
    results: [],
    currentPage: 0,
    pageCount: 0,
    pageSize: 15,
    rowCount: 0,
    firstRowOnPage: 0,
    lastRowOnPage: 0,
    filterBy: "",
  },

  /* Account*/
  accounts: {},

  /*Page*/
  page: {
    title: "Home Page",
    user: "Unknow User",
  },

  /*filters*/
  filters: {
    clientFilterBy: "",
    accountFilterBy: "",
  },

  /**/
  lookupSet: {
    transactionType: { lookups: [] },
    durationType: { lookups: [] },
    repaymentSchedule: { lookups: [] },
    recordStatus: { lookups: [] },
    seedConstantType: { lookups: [] },
    changeOperations: { lookups: [] },
    accountStatus: { lookups: [] },
  },

  /*Api Counter*/
  apiCallsInProgress: 0,
};

export default intialState;
