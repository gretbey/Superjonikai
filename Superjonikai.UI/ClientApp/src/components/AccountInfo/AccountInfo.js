import React from 'react';
import { connect } from 'react-redux';
import { Link } from "react-router-dom";
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './AccountInfo.css';
import Swal from 'sweetalert2';

class AccountInfo extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            current_pass: null,
            new_pass: null,
            confrm_pass: null
        };

        this.handleKeyPress = this.handleKeyPress.bind(this);
    }

    componentDidMount() {
        window.addEventListener("keypress", this.handleKeyPress);
    }

    componentWillUnmount() {
        window.removeEventListener("keypress", this.handleKeyPress);
    }

    handleKeyPress(e) {
        if (e.key === "Enter")
            this.login();

    }


    comparePasswords() {
        const {
            current_pass,
            new_pass,
            confrm_pass
        } = this.state;

        if (new_pass == confrm_pass && (new_pass > 0 && confrm_pass > 0)) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Your work has been saved',
                showConfirmButton: false,
                timer: 1500
            })
            return window.location.href = "/catalog";
        }
        else {
            Swal.fire({
                title: 'Error!',
                text: 'Passwords do not match, please try again.',
                icon: 'error',
                confirmButtonText: 'Continue'
            })
        }
    }

    render() {
        return (
            <div className='page-wrapper'>
                <br/>
                <div className='item-holder'>
                    <h1>Account Information </h1>
                    <br />
                    <div className='user-info'>
                        <div>
                            <label className="firstName">First Name:</label>
                        </div>
                        <div>
                            <label className="lastName">Last Name:</label>
                        </div>
                        <div>
                            <label className="email">Email:</label>
                        </div>
                    </div>

                    <div>
                        <br />
                        <label className="change-label">Change Password:</label>
                    </div>
                    <div className='change-pass'>
                        <div className='row'>
                            <br />
                            <label>current password:</label>
                            <input type='password' onChange={e => this.setState({ current_pass: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                        </div>
                        <div className='row'>
                            <label>new password:</label>
                            <input type='password' onChange={e => this.setState({ new_pass: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                        </div>
                        <div className='row'>
                            <label>confirm password:</label>
                            <input type='password' onChange={e => this.setState({ confrm_pass: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                        </div>
                        <div>
                            <br />
                            <br />
                            <button type="button" className="btnChangePass" onClick={() => this.comparePasswords()}>Change Password</button>
                        </div>
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
)(AccountInfo); 