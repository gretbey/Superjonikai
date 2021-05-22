import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './ShoppingCartPage.css';
import { connect } from 'react-redux';
import { get, post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';

export class ShoppingCartPage extends Component {
    static displayName = ShoppingCartPage.name;

    constructor(props) {
        super(props);

        this.state = {
            collapsed: true,
            clientName: "TitasGrigaitis" /* now hardcoded, later will be changed*/,
            items: [],
            subTotal: 0,
            total: 0,
            deliveryPrice: 2

        };
    }

    componentDidMount() {
        get(`clientOrders/${this.state.clientName}`)
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    this.setState({
                        items: res.data,
                        loading: false
                    })
                }
                else {
                    console.warn(`Cannot get orders:`);
                    console.warn(res.message);
                }
            })
            .catch(error => {
                console.error(`GET orders/${this.state.clientName} failed:`);
                console.error(error);
            });
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
        this.state.items.map(item => {
            this.state.subTotal += item.totalPrice
            return
        })
        this.state.total = this.state.subTotal + this.state.deliveryPrice
        return (
            <section id="order_summary">
                <div>
                    <h2>Summary</h2>
                </div>
                <hr/>
                <div>
                    <label className="summary_label">SUBTOTAL</label>
                    <label className="summary_amount">{this.state.subTotal} €</label>
                </div>
                <div>
                    <label className="summary_label">DELIVERY</label>
                    <label className="summary_amount">{this.state.deliveryPrice} €</label>
                </div>
                <hr/>
                <div>
                    <label className="summary_label">TOTAL</label>
                    <label className="summary_amount">{this.state.total} €</label>
                </div>
                <div className='payment_button'>
                    <button type="button" className="btnLogin" >Continue</button>
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
