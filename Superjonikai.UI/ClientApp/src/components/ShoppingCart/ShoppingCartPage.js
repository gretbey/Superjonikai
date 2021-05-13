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
                            <div className="topnav" id="shopping_cart_nav">
                                <NavLink tag={Link} className="text-dark" id="payment_button" to="/payment">Payment</NavLink>
                                <NavLink tag={Link} className="text-dark" id="delivery_button" to="/delivery">Delivery</NavLink>
                                <NavLink tag={Link} className="text-dark" id="checkout_button" to="/checkout">Shopping Cart</NavLink>
                            </div>
                        </Container>
                    </Navbar>
                </header>
                <hr/>
                <div class="summary">
                    {this.renderSummaryData()}
                </div>
            </div>
        );
    }

    renderSummaryData() {
        return (
            <section id="order_summary">
                <div>
                    <h2>Summary</h2>
                </div>
                <hr/>
                <div>
                    <label className="summary_label">SUBTOTAL</label>
                    <label className="summary_amount">0.00 €</label>
                </div>
                <div>
                    <label className="summary_label">DELIVERY</label>
                    <label className="summary_amount">0.00 €</label>
                </div>
                <hr/>
                <div>
                    <label className="summary_label">TOTAL</label>
                    <label className="summary_amount">0.00 €</label>
                </div>
                <div className='payment_button'>
                    <button type="button" className="btnLogin" onClick={() => this.login()}>Pay Now</button>
                </div>
            </section>
            )
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
