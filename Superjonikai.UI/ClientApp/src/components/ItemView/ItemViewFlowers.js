import React from 'react';
import { connect } from 'react-redux';
import { Link } from "react-router-dom";
import { get, post, post2 } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './ItemViewStyle.css';
import Swal from 'sweetalert2';

class ItemViewFlowers extends React.Component {
    constructor(props) {
        super(props);
        const query = new URLSearchParams(window.location.search);
        this.state = {
            flower: null,
            price: null,
            name: null,
            color: null,
            image_path: null,
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
                        image_path: res.data.image_path,
                        flowerId: res.data.id,
                    })
                }
                else {
                    console.warn(`Cannot get flower:`);
                    console.warn(res.message);
                }
            })
            .catch(error => {
                console.error(`GET flowers/${this.state.flowerId} failed:`);
                console.error(error);
            });
    }


    render() {
        const { id, name, price, color, image_path } = this.state;
        return (
            <div className='boundary'>
                <div className='page-wrapper'>
                    <h1>FLOWER DETAILS </h1>
                    <hr />
                    <br />
                    <div class="row" >
                        <div class="column left">
                            <img class="img" src={image_path} />
                        </div>
                        <div class="column right">
                            <h2>Name: {this.state.name} </h2>
                            <h2> 1 pc. price {this.state.price}€ </h2>
                            <h2> Available </h2>
                        </div>
                    </div>
                    <hr />
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    <br />
                    <div class='row'>
                        <div class="column">
                            <label for="pc."></label>
                            <select name="size" id="size" onChange={this.handleChange}>
                                <option value="3">3</option>
                                <option value="6">6</option>
                                <option value="9">9</option>
                            </select>
                        </div>
                        /*<div class="column">
                            <p>Pc.  0.00€ </p>
                        </div>*/
                    </div>
                    <br />
                    <div>
                        <button type="addToCart" className="btnToCart" onClick={() => this.addToCart()}>Add To Cart</button>
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

    handleChange = (event) => {
        this.setState({ quantity: event.target.value });
    };

    addToCart() {
        const {
            flower,
            price,
            name,
            color,
            image_path,
            flowerId,
        } = this.state;

        post2('/add/{flower}', {
            id: flowerId,
            price: price,
            name: name,
            color: color,
            image_path: image_path,
            flowerId: flowerId,
            quantity: 3
        })
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: "Succesfully added to cart!",
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
                else {
                    Swal.fire({
                        title: 'Error!',
                        text: 'You already added this item to cart',
                        icon: 'error',
                        confirmButtonText: 'Continue'
                    })
                }
            })
            .catch(error => {
                alert(error)
                console.error(`POST api/add/${flower} failed:`)
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
)(ItemViewFlowers);