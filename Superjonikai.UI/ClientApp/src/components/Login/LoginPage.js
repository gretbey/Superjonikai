import React from 'react';
import { post } from '../../helpers/request'
import { connect } from 'react-redux';
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './LoginPage.css';
import { Link } from 'react-router-dom';

class LoginPage extends React.Component{
    constructor(props){
        super(props);

        this.state = {
            email: null,
            password: null,
        };

        this.handleKeyPress = this.handleKeyPress.bind(this);
    }

    componentDidMount(){
        window.addEventListener("keypress", this.handleKeyPress);
    }

    componentWillUnmount(){
        window.removeEventListener("keypress", this.handleKeyPress);
    }

    handleKeyPress(e){
        if (e.key === "Enter")
            this.login();
    }

    login(){
        const {
            email,
            password
        } = this.state;

        if (!email || !password)
            return;

        post('login/login', {
            email: email,
            password: password,
        })
            .then(res => res.json())
            .then(res => {
                if (res.success) {
                    alert("Successfully connected");
                    this.props.history.push('/catalog');
                    this.props.login(res.data);                    
                }
                else
                {
                    alert("Bad credentials");
                }
            })
            .catch(error => {
                console.log(error);
            })
    }

    render(){
        return(
            <div className='loginContainer'>
                <div className='form-holder'>
                    <div>
                        <label className="login-label">LOGIN</label>
                    </div>
                    <div className='row'>
                        <label>Email:</label>
                        <input type='text' onChange={e => this.setState({ email: e.target.value })} onKeyPress={e => this.handleKeyPress(e)}/>
                    </div>
                    <div className='row'>
                        <label>Password:</label>
                        <input type='password' onChange={e => this.setState({ password: e.target.value })} onKeyPress={e => this.handleKeyPress(e)}/>
                    </div>
                    <div className='row'>
                        <button type="button" className="btnLogin" onClick={() => this.login()}>Login</button>
                    </div>
                    <div>
                        <label>Need an account?</label><Link className="sign-up" to="/registration">  Sign up</Link>
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
        login: (currentUser) => dispatch(currentUserActions.loginSuccess(currentUser))
    }
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(LoginPage);