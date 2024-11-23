import React, { useState } from "react";
import { toast } from "react-toastify";
import { loginAPI } from "../../services/auth-service/LoginService";
import { AuthResponseModel } from "../../models/AuthResponseModel";
import "./Login.css";

const Login: React.FC = () => {
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [loading, setLoading] = useState<boolean>(false);

    const handleLogin = async () => {
        if (!username || !password) {
            toast.warning("Please fill in both fields.");
            return;
        }

        setLoading(true);

        try {
            const response: AuthResponseModel | undefined = await loginAPI(username, password);
            if (response) {
                toast.success("Login successful!");
                localStorage.setItem("jwtToken", response.token);
                localStorage.setItem("userId", response.userId);
                localStorage.setItem("username", response.username);
                // Redirect or update UI as needed
                console.log("Login Response:", response);
            } else {
                toast.error("Failed to login. Please try again.");
            }
        } catch (error) {
            toast.error("An unexpected error occurred.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="login-container">
            <h2>Login</h2>
            <div className="input-container">
                <input
                    type="text"
                    placeholder="Username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    className="input"
                    disabled={loading}
                />
                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    className="input"
                    disabled={loading}
                />
            </div>
            <button onClick={handleLogin} className="button" disabled={loading}>
                {loading ? "Logging in..." : "Login"}
            </button>
        </div>
    );
};

export default Login;