import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';

class ShoppingCartPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            flowers: [
                { id: 0, name: 'tulpes', price: 0.7, color: 'geltona' },
                { id: 2, name: 'rozes', price: 0.7, color: 'raudona' },
                { id: 0, name: 'bijunai', price: 0.7, color: 'geltona' }
            ]
        };
    }



    render() {
        return (
            <div className='cart-wrapper'>
                <div className='cart-holder'>
                    <div>
                        <label className="delivery_label">Delivery</label>
                    </div>
                    <div className='first_name'>
                        <input type='text' placeholder='First Name' onChange={e => this.setState({ email: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <br />
                    <div className='last_name'>
                        <input type='text' placeholder='Last Name' onChange={e => this.setState({ password: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='address'>
                        <input type='text' placeholder='Address' onChange={e => this.setState({ password: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='country'>
                        <input type='text' placeholder='Country' onChange={e => this.setState({ password: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='city'>
                        <input type='text' placeholder='City' onChange={e => this.setState({ password: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='phone_number'>
                        <input type='tel' placeholder='Phone Number' pattern="[0-9]{3}-[0-9]{2}-[0-9]{3}" onChange={e => this.setState({ password: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <div className='delivery_date'>
                        <input type='date' onChange={e => this.setState({ password: e.target.value })} onKeyPress={e => this.handleKeyPress(e)} />
                    </div>
                    <br/>
                    <div>
                        <label className="summary_label">Summary</label>
                    </div>
                    <div>
                        <label className="subtotal">SUBTOTAL</label>
                    </div>
                    <div>
                        <label className="delivery">DELIVERY</label>
                    </div>
                    <div>
                        <label className="delivery">TOTAL</label>
                    </div>
                    <div className='payment_button'>
                        <button type="button" className="btnLogin" onClick={() => this.login()}>Pay Now</button>
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
)(ShoppingCartPage);