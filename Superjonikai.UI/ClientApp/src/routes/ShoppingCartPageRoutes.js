import React from 'react';
import { connect } from 'react-redux';
import { post } from '../helpers/request';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import * as currentUserActions from '../redux/actions/currentUserActions';
import ShoppingCartPageLayout from '../components/ShoppingCart/ShoppingCartPageLayout';
import CheckoutPage from '../components/Checkout/CheckoutPage';
import ShoppingCartPage from '../components/ShoppingCart/ShoppingCartPage';
import DeliveryInfoPage from '../components/DeliveryInfo/DeliveryInfoPage';
import PaymentInfoPage from '../components/PaymentInfo/PaymentInfoPage';

const ShoppingCartPageWraped = () =>
    <ShoppingCartPageLayout>
        <ShoppingCartPage />
    </ShoppingCartPageLayout>;

class ShoppingCartPageRoutes extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            components: [
                { component: CheckoutPage, path: "/checkout" },
                { component: DeliveryInfoPage, path: "/delivery" },
                { component: PaymentInfoPage, path: "/payment" }
            ]
        }
    }



    render() {
        return (
            <BrowserRouter basename={'tmp'}>
                <Switch>
                    {
                        this.state.components.map((comp, i) => {
                            let wrappedComponent = () =>
                                <ShoppingCartPageLayout>
                                    <comp.component />
                                </ShoppingCartPageLayout>;

                            return (
                                <Route component={wrappedComponent} path={comp.path} key={`route_key_${i}`} />
                            )
                        })
                    }
                    <Route component={ShoppingCartPageWraped} />
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
)(ShoppingCartPageRoutes);
