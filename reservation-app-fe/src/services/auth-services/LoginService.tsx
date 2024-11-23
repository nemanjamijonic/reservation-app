import axios from "axios";
import { handleError } from "../../helpers/ErrorHandler";
import { AuthResponseModel } from "../../models/AuthResponseModel";

const url = process.env.REACT_APP_BACKEND_URL_AUTH_API;

export const loginAPI = async (
    username: string,
    password: string
): Promise<AuthResponseModel | undefined> => {
    try {
        console.log(url)
        const response = await axios.post<AuthResponseModel>(
            `${url}/login`,
            { username, password }
        );
        return response.data;
    } catch (error) {
        handleError(error);
    }
};