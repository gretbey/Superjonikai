import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './ShoppingCartPage.css';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';

export class ShoppingCartPage extends Component {
    static displayName = ShoppingCartPage.name;

    constructor(props) {
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
                            <div className="topnav">
                                <NavLink tag={Link} className="text-dark" to="/payment">Payment</NavLink>
                                <NavLink tag={Link} className="text-dark" to="/delivery">Delivery</NavLink>
                                <NavLink tag={Link} className="text-dark" to="/checkout">Shopping Cart</NavLink>
                            </div>
                        </Container>
                    </Navbar>
                </header>
            </div>
        );
    }
}

const mapStateToProps = (state, ownProps) => {
    return {
        currentUser: state.currentUser
    }
}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {

    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(ShoppingCartPage);
