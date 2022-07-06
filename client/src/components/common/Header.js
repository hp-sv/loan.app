import NavigationLink from "./NavigationLink";
import * as Icon from "react-bootstrap-icons";

function Header() {  
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
      <div className="row">
        <div className="col">&nbsp;
        </div>
      </div>
    </div>
  );
}

export default Header;
