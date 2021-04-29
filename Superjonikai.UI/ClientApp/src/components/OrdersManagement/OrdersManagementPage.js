import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './OrdersManagementPage.css';

class OrdersManagementPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            orders: [
                { id: 0, name: 'Tom Jenkins', price: 41.00, status: 'Completed' },
                { id: 2, name: 'Lalaila Smith', price: 36.00, status: 'Paid' },
                { id: 1, name: 'Thomas Miller', price: 24.00, status: 'Processing' }
            ]
        };
    }

    render() {
        return (
            <div>
                {this.state.orders.map(function (d, idx) {
                    return (<li key={idx}>{d.name}</li>)
                })}
            </div>
        );
    }


}