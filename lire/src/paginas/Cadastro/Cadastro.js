import style from "./Cadastro.module.css";
import { useState } from "react";
import { TopBarCadastro } from "../../componentes/TopBarCadastro/TopBarCadastro"
import { useNavigate } from "react-router-dom";
import { FormControl, FormGroup, FormLabel, Form } from "react-bootstrap";
import { IoIosEye, IoIosEyeOff } from "react-icons/io";
import { useEffect } from "react";
import UsuarioAPI from "../../services/usuarioAPI";

export function Cadastro() {
    const [nome, setNome] = useState("");
    const [sobrenome, setSobrenome] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [verSenha, setVerSenha] = useState('password');
    const [quantidadeLivrosLidos, setQuantidadeLivrosLidos] = useState("");
    const [dataNascimento, setDataNascimento] = useState("");
    const [genero, setGenero] = useState([]);
    const [generosLiterarios, setGenerosLiterarios] = useState([]);
    const [generosLiterariosSelecionado, setGenerosLiterariosSelecionado] = useState([]);
    const [generoSelecionado, setGeneroSelecionado] = useState("");

    const navigate = useNavigate();

    const validarEmail = () => {
        return email.length >= 10
    };

    const validarSenha = () => {
        return senha.length >= 6
    };

    useEffect(() => {
        async function carregarGeneros() {
            try {
                const generos = await UsuarioAPI.listarGenero();
                const generosLiterarios = await UsuarioAPI.listarGeneroLiterario();

                setGenero(generos);
                setGenerosLiterarios(generosLiterarios);
            }
            catch (error) {
                alert("Não foi possível carregar os gêneros.");
            }
        }

        carregarGeneros();
    }, []);

    function selecionarGeneroLiterario(genero) {
        if (generosLiterariosSelecionado.includes(genero)) {
            setGenerosLiterariosSelecionado(
                generosLiterariosSelecionado.filter(generoLiterario => generoLiterario !== genero)
            );
        } else {
            setGenerosLiterariosSelecionado([
                ...generosLiterariosSelecionado,
                genero
            ]);
        }
    }

    async function handleSenha() {
        verSenha === 'password' ? setVerSenha('text') : setVerSenha('password')
    }

    async function handleCadastro(e) {
        e.preventDefault();

        if (!validarEmail()) {
            alert("Insira um e-mail válido!");
            return;
        }

        if (!validarSenha()) {
            alert("A senha cadastrada deve conter no mínimo 6 caracteres!");
            return;
        };

        try {
            const response = await UsuarioAPI.criarAsync(nome, sobrenome, email, senha, quantidadeLivrosLidos, dataNascimento, generoSelecionado, generosLiterariosSelecionado);

            if (response?.status === 200) {
                alert("Usuário cadastrado com sucesso!")
                navigate("/home");
            };
        }
        catch (error) {
            const mensagem = error.response?.data;

            if (mensagem != null) {
                alert(mensagem);
            }
            else {
                alert("Ocorreu um erro ao fazer cadastro, tente novamente.");
            }
        }
    }

    return (
        <TopBarCadastro>
            <div className={style.pagina_cadastro}>
                <div className={style.pagina_cabecalho}>
                    <h2>Bem-vindo(a) ao Lire!</h2>
                    <h4>Preencha as informações abaixo para iniciar sua jornada literária</h4>
                </div>
                <div className={style.pagina_conteudo}>
                    <Form onSubmit={handleCadastro}>
                        <div className={style.linha_formulario}>
                            <FormGroup controlId="formNome" className="mb-3">
                                <FormLabel>Nome</FormLabel>
                                <FormControl
                                    type="text"
                                    placeholder="Digite seu nome"
                                    name="nome"
                                    value={nome}
                                    onChange={(e) => setNome(e.target.value)}
                                    required
                                    minLenght={1}
                                    maxLenght={15}
                                />
                            </FormGroup>
                            <FormGroup controlId="formSobrenome" className="mb-3">
                                <FormLabel>Sobrenome</FormLabel>
                                <FormControl
                                    type="text"
                                    placeholder="Digite seu sobrenome"
                                    name="sobrenome"
                                    value={sobrenome}
                                    onChange={(e) => setSobrenome(e.target.value)}
                                    required
                                    minLenght={2}
                                    maxLenght={50}
                                />
                            </FormGroup>
                        </div>
                        <div className={style.linha_formulario}>
                            <FormGroup controlId="formEmail" className="mb-3">
                                <FormLabel>E-mail</FormLabel>
                                <FormControl
                                    type="email"
                                    placeholder="Digite seu e-mail"
                                    name="email"
                                    value={email}
                                    onChange={(e) => setEmail(e.target.value)}
                                    required
                                    minLenght={10}
                                    maxLenght={40}
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
                                        minLenght={6}
                                        maxLenght={15}
                                    />
                                    <button type={"button"} onClick={handleSenha} className={style.botao_verSenha}>
                                        {verSenha === 'password' ? <IoIosEyeOff /> : <IoIosEye />}
                                    </button>
                                </div>
                            </FormGroup>
                        </div>
                        <div className={style.linha_formulario}>
                            <FormGroup controlId="formDataNascimento" className="mb-3">
                                <FormLabel>Data de Nascimento</FormLabel>
                                <FormControl
                                    type="date"
                                    name="dataNascimento"
                                    value={dataNascimento}
                                    onChange={(e) => setDataNascimento(e.target.value)}
                                    required
                                />
                            </FormGroup>
                            <FormGroup controlId="formQuantidadeLivros" className="mb-3">
                                <FormLabel>Quantos livros você já leu até hoje?</FormLabel>
                                <FormControl
                                    type="number"
                                    min="0"
                                    step="1"
                                    value={quantidadeLivrosLidos}
                                    onChange={(e) => setQuantidadeLivrosLidos(e.target.value)}
                                    required
                                />
                            </FormGroup>
                        </div>
                        <FormGroup controlId="formGenero" className="mb-3">
                            <FormLabel>Gênero</FormLabel>
                            <div className={style.botoes}>
                                {genero.map((genero) => (
                                    <button
                                        key={genero}
                                        type="button"
                                        onClick={() => setGeneroSelecionado(genero)}
                                        className={
                                            generoSelecionado === genero
                                                ? style.selecionado
                                                : ""
                                        }
                                    >
                                        {genero}
                                    </button>
                                ))}
                            </div>
                        </FormGroup>
                        <FormGroup controlId="formGenerosLiterarios" className="mb-3">
                            <FormLabel>Gêneros literários favoritos</FormLabel>
                            <div className={style.botoes}>
                                {generosLiterarios.map((genero) => (
                                    <button
                                        key={genero}
                                        type="button"
                                        onClick={() => selecionarGeneroLiterario(genero)}
                                        className={
                                            generosLiterariosSelecionado.includes(genero)
                                                ? style.selecionado
                                                : ""
                                        }
                                    >
                                        {genero}
                                    </button>
                                ))}
                            </div>
                        </FormGroup>
                        <button type="submit" className={style.botao_cadastro}>Criar conta</button>
                    </Form>
                </div>
            </div>
        </TopBarCadastro>
    );
}