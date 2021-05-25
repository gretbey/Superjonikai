import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavItem, NavLink } from 'reactstrap';
import * as currentUserActions from '../../redux/actions/currentUserActions';
import { removeCookie, post } from '../../helpers/request';
import { Link, withRouter } from 'react-router-dom';
import './NavMenu.css';
import { connect } from 'react-redux';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
      super(props);
      this.logout = this.logout.bind(this);
      this.state = {
        collapsed: true
       };
    }

    logout() {
        post("login/logout");
        this.props.logout();
        removeCookie('AuthToken');
        this.props.history.push('/');
    }


    render() {
        return (
            <div>
                <header>
                    <Navbar>
                        <Container>
                            <div>
                                <NavLink tag={Link} className="text-dark"></NavLink>
                            </div>
                            <div className="topnav">

                                <NavLink tag={Link} className="text-dark" to="/cart">SHOPPING CART</NavLink>
                                <NavLink tag={Link} className="text-dark" to="/registration">SIGN UP</NavLink>
                                <NavLink tag={Link} className="text-dark" to="/login">SIGN IN</NavLink> 
                                <NavLink tag={Link} className="text-dark" to="/accountInfo">Account Information</NavLink> 
                                <button type="button" className="btnLogout" onClick={() => this.logout()}>Logout</button>
                            </div>
                        </Container>
                    </Navbar>
                </header>
                <Navbar>
                    <Container>
                        <div class="sidenav">
                            <NavLink tag={Link} className="text-dark" to="/catalog">Flowers</NavLink>
                            <NavLink tag={Link} className="text-dark" to="/bouquetsCatalog">Bouquets</NavLink>
                            <NavLink tag={Link} className="text-dark" to="/about">About</NavLink>
                            <NavLink tag={Link} className="text-dark" to="/contacts">Contacts</NavLink>
                            <NavLink tag={Link} className="text-dark" to="/ordersManagement">Orders</NavLink>
                        </div>
                    </Container>
                </Navbar>
            </div>
        );
    }
}
const mapStateToProps = (state, ownProps) => {
    return {

    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        logout: () => dispatch(currentUserActions.logout())
    }
}

export default withRouter(connect(
    mapStateToProps,
    mapDispatchToProps
)(NavMenu));
