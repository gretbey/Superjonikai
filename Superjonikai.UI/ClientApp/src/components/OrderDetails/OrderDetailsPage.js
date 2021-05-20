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
            <div>
                <tbody>
                    <div className='catalog-wrapper'>
                        <p><b>Order id: </b>{this.state.orderId}</p>
                        <p><b>Client: </b>{this.state.clientName}</p>
                        <p><b>Delivery date: </b>{this.state.deliveryDate}</p>
                        <br/>
                        <p>Update status of order</p>
                        <input
                            className="input"
                            type="text"
                            defaultValue={this.state.status}
                            onChange={e => this.setState({ status: e.target.value })}
                            required />
                        <button type="button" onClick={() => this.update()}>Update</button>
                    </div>
                </tbody>
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

        alert(status)
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