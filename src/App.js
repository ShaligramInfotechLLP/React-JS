import React from "react";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import AdminUserListComponent from './adminuser/AdminUserListComponent';
import AdminUserComponent from './adminuser/AdminUserComponent';

class App extends React.Component {
  render() {
    return (
      <Router>
        <div>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/AdminUsers">AdminUsers</Link>
            </li>
          </ul>

          <hr />

          <Route exact path="/" component={Home} />
          <Route path="/AdminUsers" component={AdminUserListComponent} />
          <Route path="/AdminUser" component={AdminUserComponent} />
          
        </div>
      </Router>
    );
  }
}

export default App;

const Home = () => (
  <div>
    <h2>Home</h2>
  </div>
);

const About = () => (
  <div>
    <h2>About Us</h2>
  </div>
);
const Contact = () => (
  <div>
    <h2>Contact Us</h2>
  </div>
);

