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
                                <NavLink tag={Link} className="text-dark">SHOPPING CART</NavLink>
                                <NavLink tag={Link} className="text-dark">SIGN OUT</NavLink>
                                <NavLink tag={Link} className="text-dark" to="/login">ACCOUNT</NavLink> 
                            </div>
                        </Container>
                    </Navbar>
                </header>
                <Navbar>
                    <Container>
                        <div class="sidenav">
                            <NavLink tag={Link} className="text-dark" to="/catalog">Flowers</NavLink>
                            <NavLink tag={Link} className="text-dark" to="/bouquetsCatalog">Bouquets</NavLink>
                            <NavLink tag={Link} className="text-dark">About</NavLink>
                            <NavLink tag={Link} className="text-dark">Contacts</NavLink>
                        </div>
                    </Container>
                </Navbar>
            </div>
        );
    }
}
