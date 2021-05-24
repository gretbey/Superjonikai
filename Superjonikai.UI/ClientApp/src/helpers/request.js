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
    .then(res => handleErrors(res))
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
    .then(res => handleErrors(res))
}

export function put(url, params = {}) {
    return fetch(url, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
        },
        body: JSON.stringify(params)
    })
    .then(res => handleErrors(res))
}


function handleErrors(response) {
    if (response.status === 401) {
        window.location.reload();
        return Promise.reject()
    }
    return response;
}

export function post2(url, params = {}) {
    return fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Token ' + getCookie('AuthToken')
        },
        body: JSON.stringify(params)
    })
    .then(res => handleErrors(res))
}