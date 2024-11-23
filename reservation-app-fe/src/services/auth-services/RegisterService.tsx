import axios from "axios";
import { handleError } from "../../helpers/ErrorHandler";
import { AuthResponseModel } from "../../models/AuthResponseModel";

const url = process.env.REACT_APP_BACKEND_URL_AUTH_API;

export const registerAPI = async (
    registerData: {
        username: string;
        password: string;
        firstName: string;
        lastName: string;
        email: string;
        role: number;
        gender: number;
        dateOfBirth: string;
    }
): Promise<AuthResponseModel | undefined> => {
    try {
        const response = await axios.post<AuthResponseModel>(
            `${url}/register`,
            { registerDto: registerData }
        );
        return response.data;
    } catch (error) {
        handleError(error);
    }
};
