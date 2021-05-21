import React from 'react';
import { connect } from 'react-redux';
import { Link } from "react-router-dom";
import { get, post } from '../../helpers/request'
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