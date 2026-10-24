import { useState } from "react";
import Logo from "../../assets/LogoLire.png"
import LoginAPI from "../../services/loginAPI";
import { FormControl, FormGroup, FormLabel } from "react-bootstrap";
import { IoIosEye, IoIosEyeOff } from "react-icons/io";

export function Login() {
    const [ email, setEmail ] = useState('');
    const [ senha, setSenha ] = useState('');
    const [ verSenha, setVerSenha] = useState('password');

    const navigate = useNavigate();

    const validarEmail = () => {
        return email.length >= 10
    };

    const validarSenha = () => {
        return senha.length >= 6
    };

    async function handleSenha() {
        verSenha === 'password' ? setVerSenha('text') : setVerSenha('password')
    }

    async function handleLogin(e)
    {
        e.preventDefault();

        if(!validarEmail())
        {
            alert("Insira um e-mail válido!");
            return;
        }

        if(!validarSenha())
        {
            alert("A senha deve conter no mínimo 6 caracteres!");
            return;
        };

        try
        {
            const response = await LoginAPI.loginAsync(email, senha);

            if(response?.status === 200)
            {
                navigate("/home");
            };
        }
        catch(error)
        {
            if(error.response?.status === 400)
            {
                alert("Usuário não encontrado, faça seu cadastro!");
                setEmail("");
                setSenha("");
            }
            else if(error.response?.status === 401)
            {
                alert("Senha incorreta, porfavor digite sua senha novamente.");
                setSenha("");
            }
            else
            {
                alert("Erro ao fazer login.");
            }
        }
    }

    return (
        <div className={style.login_conteudo}>
            <img src={Logo} alt="Logo-Lire" className={style.logo}/>

            <Form onSubmit={handleLogin}>
                <FormGroup controlId="formEmail" className="mb-3">
                    <Form.Label>E-mail</Form.Label>
                    <FormControl
                        type="email"
                        placeholder="Digite seu e-mail"
                        name="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </FormGroup>
                <FormGroup controlId="formSenha" className="mb-3">
                    <FormLabel>Senha</FormLabel>
                    <div>
                        <FormControl
                            type={verSenha}
                            placeholder="********"
                            name="senha"
                            value={senha}
                            onChange={(e) => setSenha(e.target.value)}
                            required
                    />
                        <button type={"button"} onClick={handleSenha} className={style.botao_verSenha}>
                            {verSenha === 'password' ? <IoIosEyeOff /> : <IoIosEye />}
                        </button>
                    </div>
                </FormGroup>
                <button type="submit" className={style.botao_entrar}>Entrar</button>
            </Form>
            <button type={"button"} className={style.botao_cadastrar}>Ainda não tem conta? Cadastre-se</button>
        </div>
    )
}