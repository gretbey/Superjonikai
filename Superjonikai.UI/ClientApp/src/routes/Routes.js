import React from 'react';
import { connect } from 'react-redux';
import { post } from '../helpers/request';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import * as currentUserActions from '../redux/actions/currentUserActions';
import Layout from '../components/Layout/Layout';
import LoginPage from '../components/Login/LoginPage';
import HomePage from '../components/Home/HomePage';
import NotFoundPage from '../components/NotFound/NotFoundPage';

const NotFoundPageWraped = () =>
    <Layout>
        <NotFoundPage/>
    </Layout>;

class Routes extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            components: [
                { component: HomePage, path: "/home" },
            ]
        }
    }

    render(){
        const { currentUser } = this.props;

        if ((currentUser != null) && (currentUser.firstName == null))
            return (
                <BrowserRouter basename={ 'tmp' }>
                    <Switch>
                        <Route path='/' exact component={LoginPage}/>
                        <Route component={NotFoundPage}/>
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
                    <Route component={NotFoundPageWraped}/>
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
