import React from 'react';
import { post } from '../../helpers/request'
import 'bootstrap/dist/css/bootstrap.css';
import './RegistrationPage.css';
import Swal from 'sweetalert2';

class RegistrationPage extends React.Component{
    constructor(){
        super();

        this.state = {
            firstName: null,
            lastName: null,
            phoneNumber: null,
            email: null,
            password: null,
            confirmPassword: null,
            token: null
        };
        this.onSubmit = this.registration.bind(this);
    }

    handleKeyPress(e){
        if (e.key === "Enter")
            this.registration(e);
    }
    
    registration(e) {
        e.preventDefault();
        const {
            firstName,
            lastName,
            phoneNumber,
            email,
            password,
            confirmPassword,
            token
        } = this.state;

        
        if (password !== confirmPassword) {
            Swal.fire({
                title: 'Error!',
                text: 'Passwords do not match, please try again.',
                icon: 'error',
                confirmButtonText: 'Continue'
            })
            return;
        }

        post('registration/registration', {
            firstName: firstName,
            lastName: lastName,
            phoneNumber: phoneNumber,
            email: email,
            password: password,
            token: token,

        })
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Your work has been saved',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    return window.location.href = "/login";
                }
                else
                {
                    alert("Registration failed.");
                }
            })
            .catch(error => {
                console.log(error);
            })
    }

    render(){
        return (
            <form className='registrationContainer' onSubmit={this.onSubmit} >
                <div className='form-holder'>
                    <div>
                        <label className="registrationLabel">REGISTRATION</label>
                    </div>
                    <div className='row'>
                        <label>Fist name:</label>
                        <input type='text' onChange={e => this.setState({ firstName: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='row'>
                        <label>Last name:</label>
                        <input type='text' onChange={e => this.setState({ lastName: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='row'>
                        <label>Phone number:</label>
                        <input type='text' onChange={e => this.setState({ phone: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='row'>
                        <label>Email:</label>
                        <input type='text' onChange={e => this.setState({ email: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='row'>
                        <label>Password:</label>
                        <input type='password' onChange={e => this.setState({ password: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='row'>
                        <label>Confirm password:</label>
                        <input type='password' onChange={e => this.setState({ confirmPassword: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='row'>
                        <button type="submit" className="btnRegistration">Submit</button>
                    </div>

                </div>
            </form>
        )
    }
}
export default RegistrationPage;