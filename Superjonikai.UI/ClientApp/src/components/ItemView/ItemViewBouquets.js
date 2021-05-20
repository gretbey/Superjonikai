import React from 'react';
import { connect } from 'react-redux';
import { Link } from "react-router-dom";
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './ItemViewStyle.css';

class ItemViewBouquets extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            bouquet: { id: '', name: '-', price: '0.00', color: '' }
        };
    }


    render() {
        const { id, name, price, color } = this.state;
        return (
            <div className='page-wrapper'>
                <h1>BOUQUETS DETAILS </h1>
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
                        <br />
                        <div className='row'>
                            <button type="addToCart" className="btnToCart">Add To Cart</button>
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