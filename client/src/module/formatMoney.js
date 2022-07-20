const formatMoney = (money) => {
  return money.toLocaleString(undefined, { maximumFractionDigits: 2 });
};

export default formatMoney;
