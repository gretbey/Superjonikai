import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './AboutPageStyle.css';

class AboutPage extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <br/>
                <div className='aboutContainer'>
                    <h1>ABOUT PAGE</h1>
                    <h2>Flower shop </h2>
                    <div className='textContainer' >
                        <p>Welcome to our flower shop website:</p>
                        <ul>
                            <li> We offer all kinds of flowers for purchase to our customers</li>
                            <li> If you can't decide how to make your own bouque, you can shop for already premade ones in the "Bouquets" section</li>
                            <li> All our products are gathered from eco-friendly sources</li>
                            <li> <strong>We offer 100% customer satisfaction guarantee</strong></li>
                        </ul>
                        <p>If you have any questions you may contact us online or via our e-mail and phone, and we will immediately consult you or offer the best floral design that would match your expectations. You may start ordering flowers online.</p>
                    </div>
                </div>
            </div>
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

    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AboutPage); 