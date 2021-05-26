import React from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { put, get, post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './AdminStockPage.css';

class AdminStockPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            items: [
                { id: 123456, name: 'Tulips', itemType: 'Flower', quantity: 250},
            ],
            bouquets: [
                { id: 123456, name: 'Bouquet', itemType: 'Bouquet', quantity: 3},
            ],
            clientName: this.props.currentUser.firstName.concat(this.props.currentUser.lastName),
        };
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
                    <section class="flower">
                        <h2> Flower Stock </h2>
                        <hr />
                        <div className="flowerStock">
                            <div class="items">
                                {this.renderListData()}
                            </div>
                        </div>
                    </section>
                    <section class="middle"/>
                    <section class="bouquet">
                        <h2> Bouquet Stock </h2>
                        <hr/>
                        <div className="bouquetStock">
                            <div class="items">
                                {this.renderListBouquets()}
                            </div>
                        </div>
                    </section>
                </section>
            </div>
        )
    }

    renderListData() {
        return (
            <ul class="items_list">
                {this.state.items.map(function (d, idx) {
                    return (
                        <li class="item" key={idx}>
                            <table>
                                <tr>
                                    <td><img class="item_img" src="https://www.floristikosnamai.lt/image/cache/catalog/geles/RAUDONOS-TULPES-1000x1000.jpg" /></td>
                                    <td><p class="flower_detail" > Name: {d.name} </p></td>
                                    <td><p class="flower_detail" > Quantity: {d.quantity} </p></td>
                                    <button type="button" id="editButton" >Edit</button>
                                    <button type="button" id="saveButton" >Save</button>
                                </tr>
                            </table>
                        </li>)
                })}
            </ul>
        )
    }

    renderListBouquets() {
        return (
            <ul class="items_list">
                {this.state.bouquets.map(function (d, idx) {
                    return (
                        <li class="item" key={idx}>
                            <table>
                                <tr>
                                    <td><img class="item_img" src="https://www.realflowers.co.uk/pub/media/catalog/product/cache/70584c3f10463a2342ffe93acb98e4d0/s/i/simply_gorgeous_bouquet.jpg" /></td>
                                    <td><p class="bouq_detail" > Name: {d.name} </p></td>
                                    <td><p class="bouq_detail" > Quantity: {d.quantity} </p></td>
                                    <button type="button" id="editButton" >Edit</button>
                                    <button type="button" id="saveButton" >Save</button>
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
)(AdminStockPage);