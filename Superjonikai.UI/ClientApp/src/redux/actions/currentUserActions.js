import {
    LOGIN_SUCCESS,
    LOGIN_FAILURE,
    LOGOUT
} from '../constants';

export function loginSuccess(currentUser){
    return {
        type: LOGIN_SUCCESS,
        email: currentUser.email,
        firstName: currentUser.firstName,
        lastName: currentUser.lastName,
        token: currentUser.token,
        expiredAt: currentUser.expiredAt
    }
}
export function loginFailure() {
    return {
        type: LOGIN_FAILURE
    }
}
export function logout() {
    return {
        type: LOGOUT
    }
}