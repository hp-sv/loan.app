import NavigationLink from "./NavigationLink";
import {
  BlockOutlined 
} from '@ant-design/icons';

function Header() {
  return (
    <div className="container bg-light">
      <div className="row">
        <div className="col-md-1">
          <BlockOutlined style={{fontSize: "80px", color: "black"}}/>
        </div>
        <div className="col">
          <h1>Retail Loan Service</h1>
        </div>
      </div>
      <div className="row">
        <NavigationLink />
      </div>
      <div className="row">
        <div className="col">&nbsp;</div>
      </div>
    </div>
  );
}

export default Header;
