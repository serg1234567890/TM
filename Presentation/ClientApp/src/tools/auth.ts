import { AuthenticatedUser } from "../components/Auth/models/AuthenticatedUser";

export const AUTHENTICATED_USER = "AUTHENTICATED_USER";

export const setAuthenticatedUser = (authenticatedUser: AuthenticatedUser) => {
    localStorage.setItem(AUTHENTICATED_USER, JSON.stringify(authenticatedUser));
};

export const removeAuthenticatedUser = () => {
    localStorage.removeItem(AUTHENTICATED_USER);
};

export const getAuthenticatedUser = (): AuthenticatedUser | undefined => {
	const item = localStorage.getItem(AUTHENTICATED_USER);
	return item ? JSON.parse(item) : undefined;
};

export const isAuthenticated = () => {
	const token = getToken();
	if (token == null) {
		return false;
	}
	return true;
};

export const getToken = () => {
	const authenticatedUser = getAuthenticatedUser();
	return authenticatedUser ? authenticatedUser.token : undefined;
};
