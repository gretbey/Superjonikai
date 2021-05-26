import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.state = {
      collapsed: true
    };
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
                            <NavLink tag={Link} className="text-dark" to="/adminStockPage">Stock</NavLink>
                        </div>
                    </Container>
                </Navbar>
            </div>
        );
    }
}
