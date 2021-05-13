import Cookies from 'universal-cookie';
const cookies = new Cookies();

export function getCookie(name) {
    return cookies.get(name);
}

export function setCookie(value, expirationDate) {
    cookies.set('AuthToken', value, {
        path: '/',
        expires: new Date(expirationDate),
    });
}

export function removeCookie(name) {
    cookies.remove(name, {
        path: '/',
    });
}
export function post(url, params = {}) {
    return fetch('./api/' + url, {
        method: 'post',
        headers: { 
            'Content-Type': 'application/json',
            'Authorization': 'Token ' + getCookie('AuthToken')
        },
        body: JSON.stringify(params)
    })
}


export function get(url, params = {}) {
    return fetch(url, {
        method: 'get',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Token ' + getCookie('AuthToken'),
        }
    })
}