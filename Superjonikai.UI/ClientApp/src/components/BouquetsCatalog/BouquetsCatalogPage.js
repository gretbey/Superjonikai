import React from 'react';
import { get } from '../../helpers/request'
import { connect } from 'react-redux';
import { Link } from "react-router-dom";
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './BouquetsCatalogPage.css';

class BouquetsCatalogPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            bouquets: [
                { id: this.id, name: this.name, price: this.price, image_path: this.image_path }],
            value: 'sort',
            sortedBouquets: this.bouquets,
            priceLowRange: 0,
            priceHighRange: 200
        };
    }

    componentDidMount() {

        get('/allBouquets')
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    this.setState({ bouquets: res.data, loading: false });
                }
            })
            .catch(error => {
                alert(error);
                console.error('GET bouquets failed:')
                console.error(error);
            })
    }

    renderTableData() {
        return this.state.bouquets.filter(item => item.price <= this.state.priceHighRange && item.price >= this.state.priceLowRange).map((bouquet, index) => {
            const { id, name, price, color, image_path } = bouquet
            return (
                <div class="product-card">
                    <Link to={{ pathname: `itemViewBouquets/${bouquet.name}`, state: { bouquet }, search: `?id=${id}` }}>
                        <img class="img" src={image_path} />
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
                this.sortedBouquets = sortByPriceAsc(this.state.bouquets);
                break;
            case 'sortByPriceDes':
                this.sortedBouquets = sortByPriceDes(this.state.bouquets);
                break;
            case 'sortByNameAsc':
                this.sortedBouquets = sortByNameAsc(this.state.bouquets);
                break;
            case 'sortByNameDes':
                this.sortedBouquets = sortByNameDes(this.state.bouquets);
                break;
            default:
                this.sortedFlowers = this.state.flowers;
                break;
        }
        this.render();
    };

    priceLowRangeChanged = (event) => {
        this.setState({ priceLowRange: event.target.value }, () => {
            console.log(this.state.priceLowRange, 'priceLowRange');
            this.render();
        });
    };

    priceHighRangeChanged = (event) => {
        this.setState({ priceHighRange: event.target.value }, () => {
            console.log(this.state.priceHighRange, 'priceHighRange');
            this.render();
        });
    };

    render() {
        return (
            <div>
                <tbody>
                    <div className="top">
                        <h2>Bouquets</h2>
                        <br />
                        <div>
                            <h3 className="inline" id="PriceRange">Price range</h3>
                            <input className="inline" id="InputText" type="text" placeholder="0" onKeyPress={this.priceLowRangeChanged} onKeyUp={this.priceLowRangeChanged} />
                            <h3 className="inline">  -  </h3>
                            <input className="inline" id="InputText" type="text" placeholder="200" onKeyPress={this.priceHighRangeChanged} onKeyUp={this.priceHighRangeChanged} />
                            <select className="inline" id="sort" onChange={this.handleChange} value={this.value}>
                                <option value="-"></option>
                                <option value="sortByPriceAsc">Sort By Price Asc</option>
                                <option value="sortByPriceDes">Sort By Price Des</option>
                                <option value="sortByNameAsc">Sort By Name Asc</option>
                                <option value="sortByNameDes">Sort By Name Des</option>
                            </select>
                        </div>
                    </div>
                    <div className="products">
                        {this.renderTableData()}
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
)(BouquetsCatalogPage);

