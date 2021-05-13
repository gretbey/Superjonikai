import React from 'react';
import { Container } from 'reactstrap';
import { ShoppingCartPage } from './ShoppingCartPage';

export default class ShoppingCartPageLayout extends React.Component {
    render() {
        return (
            <div>
                <ShoppingCartPage />
                <Container>
                    {this.props.children}
                </Container>
            </div>
        );
    }
}
