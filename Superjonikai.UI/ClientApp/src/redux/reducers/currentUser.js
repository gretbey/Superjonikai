import {
    LOGIN_SUCCESS,
    LOGIN_FAILURE,
    LOGOUT
} from '../constants';

const initialState = {/*now hardcoded, later change to current user*/
    email: "titasgg@gmail.com",
    firstName: "Titas",
    lastName: "Grigaitis",
    token: "adjhwu1321"
}

export default (state = initialState, action) => {
    switch(action.type){
        case LOGIN_SUCCESS:{
            state.email = action.login;
            state.firstName = action.firstName;
            state.lastName = action.lastName;
            state.token = action.token;
            state.expiredAt = action.expiredAt;

            return { ...state };
        }
        case LOGOUT: {
            state.login = null;
            state.name = null;
            state.token = null;
            return { ...state };
        }
        case LOGIN_FAILURE: {
            state.login = null;
            state.name = null;
            state.token = null;
            return { ...state };
        }
        default:
            return state;
    }
}