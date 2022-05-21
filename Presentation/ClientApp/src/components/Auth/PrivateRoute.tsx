import { Route, Redirect } from "react-router";
import { isAuthenticated } from "../../tools/auth";

//@ts-ignore
const PrivateRoute = ({ component: Component, ...rest }) => {

    return <Route {...rest} render={props => (
        isAuthenticated() ?
            <Component {...props} />
        : <Redirect to={{ pathname: "/login", state: { from: rest.location } }} />
    )} />;
};

export default PrivateRoute;

