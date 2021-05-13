import React from 'react';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { post } from '../../helpers/request';
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './CheckoutPage.css';

class CheckoutPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            items: [
                { id: 123456, name:'Spring Boquet', itemType: 'Boquet', price: 41.50, size: 'Medium' },
                { id: 123456, name: 'Spring Boquet', itemType: 'Boquet', price: 41.50, size: 'Medium' },
                { id: 123456, name: 'Spring Boquet', itemType: 'Boquet', price: 41.50, size: 'Medium' },
                { id: 123456, name: 'Spring Boquet', itemType: 'Boquet', price: 41.50, size: 'Medium' }
            ]
        };
    }

    render() {
        return (
            <section id="checkout_section">
                <div id="checkout_items">
                    <div class="items">
                        {this.renderListData()}
                    </div>
                </div>
                <div id="gift_card">
                    <div class="card">
                        <div>
                            <button type="button" className="add_gift_card" >Add Gift Card</button>
                        </div>
                        <div id="gift_card_input">
                            <input type='text' placeholder='Message...' />
                        </div>
                        <div id="confirmation_buttons">
                            <button type="button" id="gift_card_cancel_btn" >Cancel</button>
                            <button type="button" id="gift_card_add_btn" >Add</button>
                        </div>
                    </div>
                </div>
            </section>
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
                                    <td><p class="order_detail" > {d.name} </p></td>
                                    <td><p class="order_detail" > Size: {d.size} </p></td>
                                    <td><p class="order_detail" > {d.price} €</p></td>
                                    <button type="button" className="remove_item_btn" >X</button>
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
)(CheckoutPage);