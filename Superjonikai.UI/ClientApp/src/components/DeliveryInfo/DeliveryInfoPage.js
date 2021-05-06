import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';

class DeliveryInfoPage extends React.Component {
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
                        <label className="delivery_label">Deliver to:</label>
                    </div>
                    <hr/>
                    <div className='first_name'>
                        <input type='text' placeholder='First Name'/>
                    </div>
                    <br />
                    <div className='last_name'>
                        <input type='text' placeholder='Last Name'/>
                    </div>
                    <div className='address'>
                        <input type='text' placeholder='Address'/>
                    </div>
                    <div className='country'>
                        <input type='text' placeholder='Country'/>
                    </div>
                    <div className='city'>
                        <input type='text' placeholder='City'/>
                    </div>
                    <div className='phone_number'>
                        <input type='tel' placeholder='Phone Number'/>
                    </div>
                    <div className='delivery_date'>
                        <label>Delivery Date: </label>
                        <input type='date' />
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <div>
                        <label className="summary_label">Summary</label>
                    </div>
                    <hr />
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
)(DeliveryInfoPage);