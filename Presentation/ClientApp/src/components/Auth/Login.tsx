import * as React from "react";
import { useState } from "react";
import { API } from "../../tools/api";
import { removeAuthenticatedUser, setAuthenticatedUser } from "../../tools/auth";
import { Method, request } from "../../tools/request";
import { AuthenticatingUser } from "./models/AuthenticatingUser";

const Login: React.FunctionComponent = () => {
    const [name, setName] = useState<string>('');
    const [password, setPassword] = useState<string>('');

    const submitForm = (event: React.FormEvent<HTMLFormElement>) => {
        // Preventing the page from reloading
        event.preventDefault();
        removeAuthenticatedUser();

        (async () => {
            const authenticatingUser: AuthenticatingUser = {
                name: name,
                password: password
            }
            const content = await request(API.LOGIN, JSON.stringify(authenticatingUser), Method.POST);

            if (content !== 'failed') {
                setAuthenticatedUser(content);
                window.location.assign("/");
            }
        })();
    }

    return <>
        <div className='d-flex align-items-center justify-content-center' style={{ height: "100vh" }}>
            <div className="bg-white p-3 border" style={{ width: "400px" }}>
                <div className="container">
                    <form onSubmit={submitForm}>
                        <input
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            type="text"
                            placeholder="Enter a name"
                            className="input"
                        />
                        <input
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            type="password"
                            placeholder="Enter a password"
                            className="input"
                        />
                        <button type="submit" className="btn">Submit</button>
                    </form>
                </div>
            </div>
        </div>
    </>
};

export default Login;