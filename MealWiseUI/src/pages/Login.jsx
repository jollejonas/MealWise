import LoginForm from '../components/User/LoginForm';
import { Container } from 'react-bootstrap';

function Login() {
    return(
        <Container className="w-50">
            <LoginForm />
        </Container>
    );
}
   
export default Login;