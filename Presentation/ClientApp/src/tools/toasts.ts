import { toast, ToastOptions } from 'react-toastify';

export const getErrorMessage = (error: Error) => {
    return error ? error.message : "";
};


export const successOptions: ToastOptions = { autoClose: 2000, position: 'bottom-left' };
export const warningOptions: ToastOptions = { autoClose: 8000, position: 'bottom-left' };
export const errorOptions: ToastOptions = { autoClose: false, position: 'bottom-left' };

export const successToast = (message: string): void => {
    toast.success(message, successOptions);
};
export const warnToast = (message: string): void => {
    toast.warn(message, warningOptions);
};
export const errorToast = (e: Error, message?: string): void => {
    toast.error((message + " " + getErrorMessage(e)).trim(), errorOptions);
};

export const loadingErrorToast = (e: Error): void => {
    errorToast(e, "Loading error.");
};

export const loginErrorToast = (e: Error): void => {
    errorToast(e, "Login error.");
};
