const intialState = {
  /* Client */
  clients: [],

  /* Account*/
  accounts: [],

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
  lookupSet:{
    transactionType: {lookups:[]},
    durationType:{lookups:[]},
    repaymentSchedule:{lookups:[]},
    recordStatus:{lookups:[]},
    seedConstantType:{lookups:[]},
    changeOperations:{lookups:[]},
    accountStatus:{lookups:[]},
  },

  /*Api Counter*/
  apiCallsInProgress: 0,
};

export default intialState;
