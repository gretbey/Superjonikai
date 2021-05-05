import React from 'react';
import { connect } from 'react-redux';
import { post } from '../helpers/request';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import * as currentUserActions from '../redux/actions/currentUserActions';
import Layout from '../components/Layout/Layout';
import LoginPage from '../components/Login/LoginPage';
import HomePage from '../components/Home/HomePage';
import FlowersCatalogPage from '../components/FlowersCatalog/FlowersCatalogPage'
import BouquetsCatalogPage from '../components/BouquetsCatalog/BouquetsCatalogPage';
import ShoppingCartPage from '../components/ShoppingCart/ShoppingCartPage';
import OrdersManagementPage from '../components/OrdersManagement/OrdersManagementPage';

const FlowersPageWraped = () =>
    <Layout>
        <FlowersCatalogPage />
    </Layout>;

class Routes extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            components: [
                { component: HomePage, path: "/home" },
                { component: LoginPage, path: "/login" },
                { component: FlowersCatalogPage, path: "/catalog" },
                { component: BouquetsCatalogPage, path: "/bouquetsCatalog" },
                { component: ShoppingCartPage, path: "/cart" },
                { component: OrdersManagementPage, path: "/ordersManagement" },
            ]
        }
    }

   

    render(){
        return (
            <BrowserRouter basename={ 'tmp' }>
                <Switch>
                    {   
                        this.state.components.map((comp, i) => {
                            let wrappedComponent = () =>
                                <Layout>
                                    <comp.component/>
                                </Layout>;
                            
                            return (
                                <Route component={wrappedComponent} path={comp.path} key={`route_key_${i}`}/>
                            )
                        })
                    }
                    <Route component={FlowersPageWraped} />    
                </Switch>
            </BrowserRouter>
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
        login: (currentUser) => dispatch(currentUserActions.loginSuccess(currentUser))
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Routes);
