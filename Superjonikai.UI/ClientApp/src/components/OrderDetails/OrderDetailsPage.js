import React from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { put, get, post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './OrderDetailsPage.css';

class OrderDetailsPage extends React.Component {
    constructor(props) {
        super(props);
        const query = new URLSearchParams(window.location.search);
        this.state = {
            order: null,
            status: null,
            deliveryDate: null,
            clientName: null,
            orderId: query.get("id"),
            items: [
                { id: 123456, name: 'Toulip Bouquet', itemType: 'Bouquet', size: 'Medium', price: 20.00 },
            ]
        }
    }

    componentDidMount() {
        get(`orders/${this.state.orderId}`)
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    this.setState({
                        order: res.data,
                        status: res.data.status,
                        deliveryDate: res.data.deliveryDate,
                        clientName: res.data.clientName,
                        orderId: res.data.id,
                    })
                }
                else {
                    console.warn(`Cannot get order:`);
                    console.warn(res.message);
                }
            })
            .catch(error => {
                console.error(`GET orders/${this.state.orderId} failed:`);
                console.error(error);
            });
    }


    render() {
        return (
            <div className="page-wrapper">
                <section class="parrent">
                    <section class="left">
                        <div>
                            <h2><b>Order id: </b>{this.state.orderId}</h2>
                        </div>
                        <h2> Items </h2>
                        <hr/>
                        <div className='cartItems'>
                            <div class="orders_list_header">
                                <ul>
                                <li class='item'>
                                    <table>
                                        <tr>
                                            <td><p> {this.state.items.name} </p></td>
                                            <td><p> {this.state.items.size} </p></td>
                                            <td><p> {this.state.items.price}€ </p></td>
                                            <td><p> Status: {this.state.status}</p></td>
                                        </tr>
                                    </table>
                                </li>
                                </ul>
                            </div>
                            <div id="gift_card">
                                <div class="card">
                                    <div>
                                        <p> <b>Gift Card</b></p>
                                    </div>
                                    <div id="gift_card_input">
                                        <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                                    </div>
                                </div>
                            </div> 
                        </div>
                    </section>
                    <section class="middle">
                    </section>
                    <section class="right">
                        <h2> Details: </h2>
                        <hr/>
                        <div className='details'>
                            <p><b>Client: </b>{this.state.clientName}</p>
                            <p><b>Delivery date: </b>{this.state.deliveryDate}</p>
                            <p><b>Delivery address: </b>{this.state.deliveryDate}</p>
                            <p><b>Phone number: </b>{this.state.deliveryDate}</p>
                            <p><b>Price: </b>{this.state.deliveryDate}</p>
                        </div>
                        <br/>
                        <h3>Update status of order</h3>
                        <input
                        className="input"
                        type="text"
                        defaultValue={this.state.status}
                        onChange={e => this.setState({ status: e.target.value })}
                        required />
                        <button type="button" onClick={() => this.update()}>Update</button>
                    </section>
                 </section>
            </div>
        )
    };

    update() {
        const {
            order,
            status,
            clientName,
            deliveryDate,
            orderId
        } = this.state;

        put('/UpdateOrder', {
            id: orderId,
            clientName: clientName,
            deliveryDate: deliveryDate,
            status: status,
            rowVersion: order.rowVersion
        })
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    alert("Updated!");
                }
                else {
                    alert("Value updated by another user. Try again.")
                    this.setState({
                        order: res.data,
                        clientName: res.data.clientName,
                        deliveryDate: res.data.deliveryDate,
                        status: res.data.status,
                    });
                }
            })
            .catch(error => {
                alert(error)
                console.error(`PUT orders/${orderId} failed:`)
                console.error(error)
            });
    }

    //need to fix
    renderListData() {
        return (
            <ul class="items_list">
                {this.state.items.map(function (d, idx) {
                    return (
                        <li class="item" key={idx}>
                            <table>
                                <tr>
                                    <td><p> {d.name} </p></td>
                                    <td><p> {d.size} </p></td>
                                    <td><p> {d.price}€ </p></td>
                                    <td><p> Status: {this.state.status}</p></td>
                                </tr>
                            </table>
                        </li>)
                })}
            </ul>
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
)(OrderDetailsPage);