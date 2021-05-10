export function post(url, params = {}){
    return fetch('./api/' + url, {
        method: 'post',
        headers: { 
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(params)
    })
}

export function get(url, params = {}) {
    return fetch(url, {
        method: 'get',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    })
}