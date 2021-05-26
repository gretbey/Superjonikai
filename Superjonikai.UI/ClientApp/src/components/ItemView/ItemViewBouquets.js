import React from 'react';
import { connect } from 'react-redux';
import { Link } from "react-router-dom";
import { get, post, post2 } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './ItemViewStyle.css';

class ItemViewBouquets extends React.Component {
    constructor(props) {
        super(props);
        const query = new URLSearchParams(window.location.search);
        this.state = {
            bouquet: null,
            price: null,
            name: null,
            color: null,
            bouquetId: query.get("id"),
        }
    }

    componentDidMount() {
        get(`bouquets/${this.state.bouquetId}`)
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    this.setState({
                        bouquet: res.data,
                        price: res.data.price,
                        name: res.data.name,
                        color: res.data.color,
                        bouquetId: res.data.id,
                    })
                }
                else {
                    console.warn(`Cannot get bouquet:`);
                    console.warn(res.message);
                }
            })
            .catch(error => {
                console.error(`GET bouquets/${this.state.bouquetId} failed:`);
                console.error(error);
            });
    }


    render() {
        const { id, name, price, color } = this.state;
        return (
            <div className='page-wrapper'>
                <h1>BOUQUETS DETAILS </h1>
                <hr />
                <br />
                <div class="row" >
                    <div class="column">
                        <img class="img" src="https://www.realflowers.co.uk/pub/media/catalog/product/cache/70584c3f10463a2342ffe93acb98e4d0/s/i/simply_gorgeous_bouquet.jpg" />
                    </div>
                    <div class="column">
                        <h2>Name: {name} </h2>
                        <h2> From: {price}€ </h2>
                        <br />
                        <div className='row'>
                            <label for="size">Size:</label>
                            <select name="size" id="size">
                                <option value="small">Small</option>
                                <option value="medium">Medium</option>
                                <option value="large">Large</option>
                            </select>
                        </div>
                        <hr />
                        <br />
                        <div className='row'>
                            <button type="addToCart" className="btnToCart" onClick={() => this.addToCart()}>Add To Cart</button>
                        </div>
                        <div className='row'>
                            <Link to={{ pathname: `/bouquetsCatalog` }}>
                                Back to Bouquets
                            </Link>
                        </div>
                    </div>
                </div>
            </div>
        )
    };

    addToCart() {
        const {
            bouquet,
            price,
            name,
            color,
            bouquetId
        } = this.state;

        post2('/add/{bouquet}', {
            id: bouquetId,
            price: price,
            name: name,
            color: color,
            bouquetId: bouquetId,
            size: "small"
        })
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    alert("Succesfully added to cart!");
                }
                else {
                    alert("You already added this item to cart")
                }
            })
            .catch(error => {
                alert(error)
                console.error(`POST api/add/${bouquet} failed:`)
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
)(ItemViewBouquets);