import { useSelector } from "react-redux";
import { selectPageTitle } from "../../store/selector/pageTitleSelector";
import NavigationLink from "./NavigationLink";
import * as Icon from "react-bootstrap-icons";

function Header() {
  const currentPageTitle = useSelector(selectPageTitle);

  return (
    <div className="container bg-light">
      <div className="row">
        <div className="col-md-1">
          <Icon.DashCircleDotted size={80} />
        </div>
        <div className="col">
          <h1>Retail Loan Service</h1>
        </div>
      </div>
      <div className="row">
        <div className="col">
          <NavigationLink />
        </div>
      </div>
      <br />
      <div className="row">
        <div className="col">
          <h4>{currentPageTitle}</h4>
        </div>
      </div>
    </div>
  );
}

export default Header;
