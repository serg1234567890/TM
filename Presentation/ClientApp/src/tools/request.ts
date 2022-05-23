import { getToken } from "./auth";

export function request(cmd = '', body = '', method = 'GET') {

    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    //headers.append('Accept', 'application/json');

    const token = getToken();
    headers.append('Authorization', `Bearer ${token}`);

    console.log(token);
    const requestInit: RequestInit = method === 'GET' ? {
        method: method, // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, cors, *same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'include', // include, *same-origin, omit
        headers: headers
    } : {
        method: method, // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, cors, *same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: headers,
        body: body
    };
    const fetchdata = async () => {
        return await (await fetch(cmd, requestInit).then((response) => {
            if (response.ok) {
                return response.json();
            } else {
                return "failed";
            }
        }));
    }
    return fetchdata();
}

export enum Method {
    GET = 'GET',
    POST = 'POST'
}