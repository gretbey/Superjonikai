import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './FlowersCatalogPage.css';
import './FlowersCatalogPage.css';

class FlowersCatalogPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            flowers: [
                { id: 0, name: 'tulpes', price: 0.7, color: 'geltona' },
                { id: 1, name: 'tulpes', price: 0.7, color: 'raudona' },
                { id: 2, name: 'rozes', price: 0.7, color: 'raudona' },
                { id: 0, name: 'bijunai', price: 0.7, color: 'geltona' },
                { id: 1, name: 'lelijos', price: 0.7, color: 'balta' },
                { id: 2, name: 'rozes', price: 0.7, color: 'raudona' }
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
                        <label>{name} {price}Eur</label>
                        <br/>
                        <label>{color}</label>
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
                        <div class="products">
                            {this.renderTableData()}
                        </div>
                    </div>
                </tbody>
                <div>
                    <button class="add-new-item" onClick={() => this.openPopUpWindow()}>+</button>
                </div>
            </div>
        )
    }

    openPopUpWindow() {
        let newWin = window.open("about:blank", "hello", "width=300,height=300");

        newWin.document.write("Form to submit new flower type");
        newWin.moveTo(200, 200);
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

