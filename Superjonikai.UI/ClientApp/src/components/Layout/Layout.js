import React from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export default class Layout extends React.Component {
  render() {
    return (
      <div>
        <NavMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
