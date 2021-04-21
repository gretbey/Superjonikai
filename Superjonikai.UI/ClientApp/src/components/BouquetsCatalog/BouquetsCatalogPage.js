import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './BouquetsCatalogPage.css';

class BouquetsCatalogPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            bouquets: [
                { id: 0, name: 'Simply gorgeous bouquet', price: 60.30},
                { id: 1, name: 'Summer flowers bouquet', price: 40.3},
                { id: 2, name: 'Mixed flowers', price: 16.4},
                { id: 0, name: 'Bright flower bouquet', price: 10 },
                { id: 1, name: 'Roses box', price: 12 }
            ]
        };
    }

    renderTableData() {
        return this.state.bouquets.map((bouquet, index) => {
            const { id, name, price } = bouquet
            return (
                <div class="product-card">
                        <img class="img" src="https://www.realflowers.co.uk/pub/media/catalog/product/cache/70584c3f10463a2342ffe93acb98e4d0/s/i/simply_gorgeous_bouquet.jpg"/>
                        <br/>
                        <div class="product-info">
                        <label>{name}</label>
                        <br/>
                        <label>{price}Eur</label>
                        </div>
                </div>
               
            )
        })
    }

    render() {
        return (
            <div>
                <tbody>
                    <div className='catalog-wrapper'>
                        <h2 className="title">Bouquets</h2>
                        <div class="products">
                            {this.renderTableData()}
                        </div>
                    </div>
                </tbody>
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
)(BouquetsCatalogPage);

