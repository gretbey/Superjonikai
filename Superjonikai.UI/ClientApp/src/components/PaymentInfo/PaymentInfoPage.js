import React from 'react';
import { connect } from 'react-redux';
import { post } from '../../helpers/request'
import * as currentUserActions from '../../redux/actions/currentUserActions';
import 'bootstrap/dist/css/bootstrap.css';
import './PaymentInfoPage.css';

class PaymentInfoPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            banks: [
                { id: 0, name: 'Swedbank'},
                { id: 1, name: 'Seb'},
                { id: 2, name: 'Luminor' },
                { id: 3, name: 'Citadele' },
                { id: 4, name: 'Revolut' },
                { id: 5, name: 'Danske' }
            ]
        };
    }

    renderTableData() {
        return this.state.banks.map((bank, index) => {
            const { id, name, price, color } = bank
            return (
                <div class="bank_card">
                    <img class="img" src="https://www.lb.lt/uploads/news/images/595x396_ratio/f_3ee5b219ff095232972333012c069007_23856_a0bbc2553dfbf593a63c4405d5ff5e9c.jpg" />
                    <br />
                    <div class="bank_info">
                        <label>{name}</label>
                    </div>
                </div>
            )
        })
    };

    render() {
        return (
            <section id="payment_section">
                <div>
                    <tbody>
                        <div className='banking_wrapper'>
                            <div>
                                <h2>Electornic banking</h2>
                            </div>
                            <hr/>
                            <div class="banks">
                                {this.renderTableData()}
                            </div>
                        </div>
                    </tbody>
                    </div>
            </section>
        )
    };
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
)(PaymentInfoPage);

