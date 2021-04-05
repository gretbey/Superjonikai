import {
    LOGIN_SUCCESS,
} from '../constants';

const initialState = {
    email: null,
    firstName: null,
    lastName: null,
}

export default (state = initialState, action) => {
    switch(action.type){
        case LOGIN_SUCCESS:{
            state.email = action.login;
            state.firstName = action.firstName;
            state.lastName = action.lastName;
            return { ...state };
        }
        default:
            return state;
    }
}