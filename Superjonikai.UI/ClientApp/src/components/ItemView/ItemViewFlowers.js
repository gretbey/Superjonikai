import React from 'react';
import { connect } from 'react-redux';
import { Link } from "react-router-dom";
import { get, post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './ItemViewStyle.css';

class ItemViewFlowers extends React.Component {
    constructor(props) {
        super(props);
        const query = new URLSearchParams(window.location.search);
        this.state = {
            flower: null,
            price: null,
            name: null,
            color: null,
            flowerId: query.get("id"),
        }
    }

    componentDidMount() {
        get(`flowers/${this.state.flowerId}`)
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    this.setState({
                        flower: res.data,
                        price: res.data.price,
                        name: res.data.name,
                        color: res.data.color,
                        flowerId: res.data.id,
                    })
                }
                else {
                    console.warn(`Cannot get flower:`);
                    console.warn(res.message);
                }
            })
            .catch(error => {
                console.error(`GET flowers/${this.state.orderId} failed:`);
                console.error(error);
            });
    }


    render() {
        const { id, name, price, color } = this.state;
        return (
            <div className='boundary'>
                <div className='page-wrapper'>
                    <h1>FLOWER DETAILS </h1>
                    <br />
                    <div class="row" >
                        <div class="column left">
                            <img class="img" src="https://www.floristikosnamai.lt/image/cache/catalog/geles/RAUDONOS-TULPES-1000x1000.jpg" />
                        </div>
                        <div class="column right">
                            <h2>Name: {this.state.name} </h2>
                            <h2> 1 pc. price {this.state.price}€ </h2>
                            <h2> Available </h2>
                        </div>
                    </div>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    <br />
                    <div class='row'>
                        <div class="column">
                            <label for="pc."></label>
                            <select name="size" id="size">
                                <option value="three">3</option>
                                <option value="six">6</option>
                                <option value="nine">9</option>
                            </select>
                        </div>
                        <div class="column">
                            <p>Pc.  0.00€ </p>
                        </div>
                    </div>
                    <br />
                    <div>
                        <button type="addToCart" className="btnToCart">Add To Cart</button>
                    </div>
                    <br />
                    <div>
                        <Link to={{ pathname: `/flowersCatalog` }}>
                            Back to Flowers
                        </Link>
                    </div>
                </div>
            </div>
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
)(ItemViewFlowers);