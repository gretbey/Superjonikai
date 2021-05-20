import React from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { get } from '../../helpers/request'
import { post } from '../../helpers/request';
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './OrdersManagementPage.css';
class OrdersManagementPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            orders: [
                { id: 123456, clientName: 'Tom Jenkins', deliveryDate: '2021-05-02', status: 'Completed' },
            ]
        };
    }

    componentDidMount() {

        get('/allOrders')
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    this.setState({ orders: res.data, loading: false });
                }
            })
            .catch(error => {
                alert(error);
                console.error('GET orders failed:')
                console.error(error);
            })
    }

    render() {
        return (
            <div id="orders_list">
                <h2 class="title">Orders</h2>
                <br/>
                
                <div class="orders_list_header">
                    <table>
                        <tr>
                            <td><h4> ID </h4></td>
                            <td><h4> Name </h4></td>
                            <td><h4> Delivery date </h4></td>
                            <td><h4> Status </h4></td>
                        </tr>
                    </table>
                </div>
                <hr/>
                <div class="orders">
                    {this.renderListData()}
                </div>
            </div>
        )
    }

    renderListData() {
        return (
            <ul class="orders_list">
                {this.state.orders.map(function (d, idx) {
                    return (
                        <li class="order" key={idx}>
                            <table>
                                <tr>
                                    <td><p class="order_detail" > #{d.id} </p></td>
                                    <td><p class="order_detail" > {d.clientName} </p></td>
                                    <td><p class="order_detail" > {d.deliveryDate} </p></td>
                                    <td><p class="order_detail" > {d.status} </p></td>
                                    <td><Link id="details_link" class="order_detail" to={{ pathname: "/ordersDetailPage", search: `?id=${d.id}` }} >details</Link></td>
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
)(OrdersManagementPage);