import React from 'react';
import { connect } from 'react-redux';
import { post, get, getCookie, removeCookie } from '../helpers/request';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import * as currentUserActions from '../redux/actions/currentUserActions';
import Layout from '../components/Layout/Layout';
import LoginPage from '../components/Login/LoginPage';
import HomePage from '../components/Home/HomePage';
import FlowersCatalogPage from '../components/FlowersCatalog/FlowersCatalogPage'
import BouquetsCatalogPage from '../components/BouquetsCatalog/BouquetsCatalogPage';
import RegistrationPage from '../components/Registration/RegistrationPage';
import AboutPage from '../components/About/AboutPage';
import ContactsPage from '../components/Contacts/ContactsPage';
import AccountInfo from '../components/AccountInfo/AccountInfo';
import ItemViewBouquets from '../components/ItemView/ItemViewBouquets';
import ItemViewFlowers from '../components/ItemView/ItemViewFlowers';

import ShoppingCartPageRoutes from '../routes/ShoppingCartPageRoutes';
import OrdersManagementPage from '../components/OrdersManagement/OrdersManagementPage';
import OrdersDetailsPage from '../components/OrderDetails/OrderDetailsPage';

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
                { component: RegistrationPage, path: "/registration" },
                { component: ShoppingCartPageRoutes, path: "/cart" },
                { component: OrdersManagementPage, path: "/ordersManagement" },
                { component: OrdersDetailsPage, path: "/ordersDetailPage" },
                { component: AboutPage, path: "/about" },
                { component: ContactsPage, path: "/contacts" },
                { component: AccountInfo, path: "/accountInfo" },
                { component: ItemViewBouquets, path: "/itemViewBouquets" },
                { component: ItemViewFlowers, path: "/itemViewFlowers" }
            ]
        }
    }
    componentDidMount() {
        const token = getCookie('AuthToken');
        if (token) {
            post('login?token=true', { token })
                .then(res => res.json())
                .then(res => {
                    if (res.success) {
                        this.props.login(res.data);
                        this.setState({ loading: false });
                    }
                    else {
                        removeCookie('AuthToken');
                        window.location.reload();
                    }
                })
                .catch(error => {
                    console.error(error);
                })
        }
    }
   

    render() {
        const { currentUser } = this.props;
        if (!currentUser || !currentUser.token)
            return (
                <BrowserRouter basename={'tmp'}>
                    <Switch>
                        <Route path='/catalog' exact component={FlowersCatalogPage} />
                        <Route path='/registration' component={RegistrationPage} />
                    </Switch>
                </BrowserRouter>
            )
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
        login: (currentUser) => dispatch(currentUserActions.loginSuccess(currentUser)),
        logout: () => dispatch(currentUserActions.logout())

    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Routes);
