import React from 'react';
import { get } from '../../helpers/request'
import { connect } from 'react-redux';
import { Link } from "react-router-dom";
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './FlowersCatalogPage.css';

class FlowersCatalogPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            flowers: [
                { id: 0, name: 'Tulips', price: 0.7, color: 'yellow' }],
            value: 'sort',
            sortedFlowers: this.flowers,
            priceLowRange: 0,
            priceHighRange: 50
        };  
    };

    componentDidMount() {

        get('/allFlowers')
                .then(res => res.json())
                .then(res => {
                    if (res.success) {
                        this.setState({ flowers: res.data, loading: false });
                    }
                })
                .catch(error => {
                    alert(error);
                    console.error('GET flowers failed:')
                    console.error(error);
                })
    }

    renderTableData() {
        return this.state.flowers.filter(item => item.price <= this.state.priceHighRange && item.price >= this.state.priceLowRange).map((flower, index) => {
            const { id, name, price, color } = flower
            return (
                <div class="product-card">
                    <Link to={{ pathname: `itemViewFlowers/${flower.name}`, state: { flower }, search: `?id=${id}` }}>
                    <img class="img" src="https://www.floristikosnamai.lt/image/cache/catalog/geles/RAUDONOS-TULPES-1000x1000.jpg" />
                        <br />
                    </Link>
                    <div class="product-info">
                        <label>{name}</label>
                        <br />
                        <label>{price}Eur</label>
                    </div>
                </div>

            )
        })
    };

    handleChange = (event) => {

        this.setState({ value: event.target.value });
        switch (event.target.value) {
            case 'sortByPriceAsc':
                this.sortedFlowers = sortByPriceAsc(this.state.flowers);
                break;
            case 'sortByPriceDes':
                this.sortedFlowers = sortByPriceDes(this.state.flowers);
                break;
            case 'sortByNameAsc':
                this.sortedFlowers = sortByNameAsc(this.state.flowers);
                break;
            case 'sortByNameDes':
                this.sortedFlowers = sortByNameDes(this.state.flowers);
                break;
            default:
                this.sortedFlowers = this.state.flowers;
                break;
        }
        this.render();
    };

    priceLowRangeChanged = (event) => {
        this.setState({ priceLowRange: event.target.value }, () => {
            this.render();
        });
    };

    priceHighRangeChanged = (event) => {
        this.setState({ priceHighRange: event.target.value }, () => {
            this.render();
        });
    };

    render() {
        return (
            <div>
                <tbody>
                    <div className='catalog-wrapper'>
                        <h2 className="title">Flowers</h2>
                        <br/>
                        <div className="sorting">
                            <h3 className="inline" id="PriceRange">Price range</h3>
                            <input className="inline" id="InputText" type="text" placeholder="0" onKeyPress={this.priceLowRangeChanged} onKeyUp={this.priceLowRangeChanged}/>
                            <h3 className="inline">  -  </h3>
                            <input className="inline" id="InputText" type="text" placeholder="50" onKeyPress={this.priceHighRangeChanged} onKeyUp={this.priceHighRangeChanged}/>
                            <select className="inline" id="sort" onChange={this.handleChange} value={this.value}>
                                <option value="-"></option>
                                <option value="sortByPriceAsc">Sort By Price Asc</option>
                                <option value="sortByPriceDes">Sort By Price Des</option>
                                <option value="sortByNameAsc">Sort By Name Asc</option>
                                <option value="sortByNameDes">Sort By Name Des</option>
                            </select>
                        </div>
                        <div class="products">
                            {this.renderTableData()}
                        </div>
                    </div>
                </tbody>
            </div>
        )
    };
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

const sortByPriceAsc = (array) => {
    return array.sort((a, b) => Number(a.price) - Number(b.price));
}

const sortByPriceDes = (array) => {
    return array.sort((a, b) => Number(b.price) - Number(a.price));
}

const sortByNameAsc = (array) => {
    return array.sort((a, b) => a.name !== b.name ? a.name < b.name ? -1 : 1 : 0);
}

const sortByNameDes = (array) => {
    return array.sort((a, b) => a.name !== b.name ? a.name > b.name ? -1 : 1 : 0)
}


export default connect(
    mapStateToProps,
    mapDispatchToProps
)(FlowersCatalogPage);

