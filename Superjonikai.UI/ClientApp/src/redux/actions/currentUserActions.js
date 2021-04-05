import {
    LOGIN_SUCCESS
} from '../constants';

export function loginSuccess(currentUser){
    return {
        type: LOGIN_SUCCESS,
        email: currentUser.email,
        firstName: currentUser.firstName,
        lastName: currentUser.lastName,
    }
}