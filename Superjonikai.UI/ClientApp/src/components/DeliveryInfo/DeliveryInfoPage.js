import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './DeliveryInfoPage.css';

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
            <section id="delivery_section">
                <div className='delivery_wrapper'>
                    <div className='delivery_holder'>
                        <div>
                            <h2>Deliver to:</h2>
                        </div>
                        <hr/>
                        <div class="delivery_info_input" id='first_name'>
                            <input type='text' placeholder='First Name'/>
                        </div>
                        <div class="delivery_info_input" id='last_name'>
                            <input type='text' placeholder='Last Name'/>
                        </div>
                        <div class="delivery_info_input" id='address'>
                            <input type='text' placeholder='Address'/>
                        </div>
                        <div class="delivery_info_input" id='country'>
                            <input type='text' placeholder='Country'/>
                        </div>
                        <div class="delivery_info_input" id='city'>
                            <input type='text' placeholder='City'/>
                        </div>
                        <div class="delivery_info_input" id='phone_number'>
                            <input type='tel' placeholder='Phone Number'/>
                        </div>
                        <div class="delivery_info_input" id='delivery_date'>
                            <label id="delivery_date_label">Delivery Date: </label>
                            <input id="delivery_date_input" type='date' />
                        </div>
                    </div>
                </div >
            </section>
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