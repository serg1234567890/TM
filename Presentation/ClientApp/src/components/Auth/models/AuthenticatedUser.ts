export interface AuthenticatedUser {
    id: string;
    name: string;
    token: string;
    role: string;
}