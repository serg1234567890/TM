import { getToken } from "./auth";

export function request(cmd = '', body = '', method = 'GET') {

    const headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');

    const token = getToken();
    if (token != null) {
        headers.append('Authorization', `Bearer ${token}`);
    }

    const requestInit: RequestInit = {
        method: method, // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, cors, *same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: headers,
        redirect: 'follow', // manual, *follow, error
        referrer: 'no-referrer', // no-referrer, *client
        body: body // body data type MUST !!! match "Content-Type" header
    };
    const fetchdata = async () => {
        return await (await fetch(cmd, requestInit)).json();
    }
    return fetchdata();
}

export enum Method {
    GET = 'GET',
    POST = 'POST'
}