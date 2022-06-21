import { useSelector } from "react-redux";
import { selectPageTitle } from "../../store/selector/pageTitleSelector";
import { selectPageUser } from "../../store/selector/pageUserSelector";
import logo from "./loan-logo.svg";

function Header() {
  const currentPageTitle = useSelector(selectPageTitle);
  const currentPageUser = useSelector(selectPageUser);

  return (
    <header>
      <div className="row">
        <div className="col-md-2">
          <img src={logo} height="75" width="75" className="logo" alt="logo" />
        </div>
        <div className="col-md-10 mt-5 subtitle">
          <h1>Retail Loan Service</h1>
        </div>
      </div>
      <div className="row">
        <div className="col-md-6">
          <h5>{currentPageTitle}</h5>
        </div>
        <div className="col-md-6">{currentPageUser}</div>
      </div>
    </header>
  );
}

export default Header;
