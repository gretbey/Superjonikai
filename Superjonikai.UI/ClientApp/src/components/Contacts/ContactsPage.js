import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './ContactsPageStyle.css';

class ContactsPage extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <br />
                <div className='contactsContainer'>
                    <h1>CONTACTS PAGE</h1>
                    <h2>Flower shop </h2>
                    <div className='textContainer'>
                        <p>If you have any issues with our products you can contact us at:</p>
                        <ul>
                            <li> <strong>flowershop@mail.com</strong></li>
                        </ul>
                        <p>This webapp project was created by PS3 students group - SuperjonikAI </p>
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
)(ContactsPage); 