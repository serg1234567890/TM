import { Navigate, useLocation } from "react-router";
import { isAuthenticated } from "../../tools/auth";

const PrivateRoute = (props: { children: React.ReactNode }) => {
    const { children } = props;
    const location = useLocation();
    return <>
        {isAuthenticated() ?
            <>{children}</>
            : <Navigate
                replace={true}
                to="/login"
                state={{ from: `${location.pathname}${location.search}` }}
            />
        }</>
};

export default PrivateRoute;

