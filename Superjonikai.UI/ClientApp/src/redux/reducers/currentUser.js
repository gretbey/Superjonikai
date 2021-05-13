import {
    LOGIN_SUCCESS,
    LOGIN_FAILURE,
    LOGOUT
} from '../constants';

const initialState = {
    email: null,
    firstName: null,
    lastName: null,
    token: null
}

export default (state = initialState, action) => {
    switch(action.type){
        case LOGIN_SUCCESS:{
            state.email = action.login;
            state.firstName = action.firstName;
            state.lastName = action.lastName;
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