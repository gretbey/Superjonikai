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
                { component: RegistrationPage, path: "/registration" }
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
                    console.error('POST login?token=true failed:');
                    console.error(error);
                })
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
