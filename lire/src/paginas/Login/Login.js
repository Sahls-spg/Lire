import { useState } from "react";
import Logo from "../../assets/Logo.png"
import LoginAPI from "../../services/loginAPI";
import { FormControl, FormGroup, FormLabel, Form } from "react-bootstrap";
import { IoIosEye, IoIosEyeOff } from "react-icons/io";
import style from './Login.module.css'
import { useNavigate } from "react-router-dom"
import { Link } from "react-router-dom";

export function Login() {
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [verSenha, setVerSenha] = useState('password');

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

    async function handleLogin(e) {
        e.preventDefault();

        if (!validarEmail()) {
            alert("Insira um e-mail válido!");
            return;
        }

        if (!validarSenha()) {
            alert("A senha deve conter no mínimo 6 caracteres!");
            return;
        };

        try {
            const response = await LoginAPI.loginAsync(email, senha);

            if (response?.status === 200) {
                localStorage.setItem("token", response.data.token);
                navigate("/home");
            };
        }
        catch (error) {
            const mensagem = error.response?.data;

            if (mensagem != null) {
                alert(mensagem);
                setEmail("");
                setSenha("");
            }
            else {
                alert("Ocorreu um erro ao fazer login, tente novamente.");
            }
        }
    }

    return (
        <div className={style.pagina_login}>
            <div className={style.login_conteudo}>
                <img src={Logo} alt="Logo-Lire" className={style.logo} />

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
                        <div className={style.campo_senha}>
                            <FormControl
                                type={verSenha}
                                placeholder="Digite sua senha"
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
                <p>Ainda não tem conta? {" "}
                    <Link to="/cadastro" className={style.link_cadastro}>Cadastre-se</Link>
                </p>
            </div>
        </div>
    )
}