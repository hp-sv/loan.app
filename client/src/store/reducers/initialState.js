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

  /*Api Counter*/
  apiCallsInProgress: 0,
};

export default intialState;
