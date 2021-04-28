import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './FlowersCatalogPage.css';

class FlowersCatalogPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            flowers: [
                { id: 0, name: 'Tulips', price: 0.7, color: 'yellow' },
                { id: 1, name: 'Tulips', price: 0.4, color: 'red' },
                { id: 2, name: 'Roses', price: 0.35, color: 'red' },
                { id: 0, name: 'Tulips', price: 1.3, color: 'yellow' },
                { id: 1, name: 'Lilies', price: 1.2, color: 'white' },
                { id: 2, name: 'Roses', price: 0.5, color: 'red' },
                { id: 0, name: 'Tulips', price: 0.6, color: 'yellow' },
                { id: 1, name: 'Tulips', price: 0.3, color: 'red' },
                { id: 2, name: 'Roses', price: 0.5, color: 'red' },
                { id: 0, name: 'Tulips', price: 0.8, color: 'yellow' },
                { id: 1, name: 'Lilies', price: 0.6, color: 'white' },
                { id: 2, name: 'Roses', price: 0.9, color: 'red' },
                { id: 0, name: 'Tulips', price: 0.3, color: 'yellow' },
                { id: 1, name: 'Tulips', price: 0.5, color: 'red' },
                { id: 2, name: 'Roses', price: 0.6, color: 'red' },
                { id: 0, name: 'Tulips', price: 0.9, color: 'yellow' },
                { id: 1, name: 'Lilies', price: 0.4, color: 'white' },
                { id: 2, name: 'Roses', price: 0.3, color: 'red' },
                { id: 0, name: 'Tulips', price: 1.5, color: 'yellow' },
                { id: 1, name: 'Tulips', price: 1.3, color: 'red' },
                { id: 2, name: 'Roses', price: 1.1, color: 'red' },
                { id: 0, name: 'Tulips', price: 0.7, color: 'yellow' },
                { id: 1, name: 'Lilies', price: 1.7, color: 'white' },
                { id: 2, name: 'Roses', price: 0.7, color: 'red' }
            ]
        };
    }

    renderTableData() {
        return this.state.flowers.map((flower, index) => {
            const { id, name, price, color } = flower
            return (
                <div class="product-card">
                        <img class="img" src="https://www.floristikosnamai.lt/image/cache/catalog/geles/RAUDONOS-TULPES-1000x1000.jpg"/>
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
                        <h2 className="title">Flowers</h2>
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
)(FlowersCatalogPage);

