import React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { logoutAccount} from '../store/actions/AccountActions'
import { Link } from 'react-router-dom';
import { connect } from "react-redux"
import {
  infoNotification,
  successfulNotification,
  errorNotification
} from '../store/actions/NotificationActions'
import '../styles/NavMenuStyles.css';

class NavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }

  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }

  logoutUser() {
    let userToken = {
      userId: localStorage.getItem("userId"),
      token: localStorage.getItem("token")
    }
    this.props.logoutAccount(userToken)
            .then(response => {
              console.log(response)
                if (response.status === 200) {
                    localStorage.clear()
                    this.props.successfulNotification("Loged out!")
                    window.location.reload(false);
                } else {
                    this.props.errorNotification("Connection problem! Please try again")
                }
            })
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light >
          <Container>
            <NavbarBrand tag={Link} to="/"><img className="navbarLogo" src={require("../content/logo/bar-logo.png")} /></NavbarBrand>
            <NavbarToggler onClick={this.toggle} className="mr-2" />
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                  <ul className="navbar-nav flex-grow">
                    <NavItem>
                      <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                    </NavItem>
                    <NavItem><NavLink></NavLink></NavItem>
                    <NavItem><NavLink></NavLink></NavItem>
                    <NavItem><NavLink></NavLink></NavItem>
                    <NavItem className="cursorPointer">
                      <NavLink className="text-dark">Hello {localStorage.getItem("userName")}!</NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink className="logoutBtn" onClick={this.logoutUser.bind(this)}>LogOut</NavLink>
                    </NavItem>
                  </ul>
                </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}

const mapDispatchToProps = dispatch => {
  return {
      logoutAccount: (userToken) => dispatch(logoutAccount(userToken)),

      // Notifications
      infoNotification: (message) => dispatch(infoNotification(message)),
      successfulNotification: (message) => dispatch(successfulNotification(message)),
      errorNotification: (message) => dispatch(errorNotification(message))
  }
}

export default connect(null, mapDispatchToProps)(NavMenu)
