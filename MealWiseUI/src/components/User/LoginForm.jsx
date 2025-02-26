import { useState } from 'react';
import { login } from '../../services/authService';

const LoginForm = ({ onSuccess }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState(null);

    const handleLogin = async (event) => {
        event.preventDefault();
        setError(null);

        try {
            const response = await login(username, password);

            if (response?.token) {
                onSuccess(); // Luk modalen ved succesfuldt login
            } else {
                setError("Login fejlede. Tjek dine oplysninger.");
            }
        } catch (error) {
            setError("Login fejlede. Tjek dine oplysninger.");
        }
    };

    return(
        <div>
            <h2>Login</h2>
            {error && <p style = {{ color: 'red' }}>{error}</p>}
            <form onSubmit={handleLogin}>
                <input 
                type="text" 
                placeholder="Brugernavn"
                value={username} 
                onChange={(event) => setUsername(event.target.value)} 
                required
                />
                <input type="password" 
                placeholder="Adgangskode"
                value={password} 
                onChange={(event) => setPassword(event.target.value)} 
                required
                />
                <button type="submit">Login</button>
            </form>
        </div>
    );
};

export default LoginForm;