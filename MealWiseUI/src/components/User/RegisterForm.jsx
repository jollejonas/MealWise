import { useState } from 'react';
import { register } from '../../services/authService';

const RegisterForm = ({ onSuccess }) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [email, setEmail] = useState("");
    const [error, setError] = useState(null);

    const handleRegister = async (event) => {
        event.preventDefault();
        setError(null);
        try {
            await register(username, email, password);
            onSuccess();
        } catch (error) {
            setError("Registrering fejlede. Prøv igen.");
        }
    };

    return(
        <div>
            <h2>Opret bruger</h2>
            {error && <p style = {{ color: 'red' }}>{error}</p>}
            <form onSubmit={handleRegister}>
                <input 
                type="text" 
                placeholder="Brugernavn"
                value={username} 
                onChange={(event) => setUsername(event.target.value)} 
                required
                />
                <input
                type="email"
                placeholder="Email"
                value={email}
                onChange={(event) => setEmail(event.target.value)}
                required
                /> 
                <input type="password" 
                placeholder="Adgangskode"
                value={password} 
                onChange={(event) => setPassword(event.target.value)} 
                required
                />
                <button type="submit">Opret bruger</button>
            </form>
        </div>
    );
};

export default RegisterForm;