import { TopBar } from "../../componentes/TopBar/TopBar";
import style from "./Home.module.css";
import { useEffect, useState } from 'react';
import { jwtDecode } from 'jwt-decode';
import UsuarioAPI from '../../services/usuarioAPI';

export function Home()
{
    const [usuario, setUsuario] = useState(null);

    useEffect(() => {
        async function carregarUsuario() {
            const token = localStorage.getItem("token");
            const dadosToken = jwtDecode(token);

            const usuarioDominio = await UsuarioAPI.obterPeloIdAsync(dadosToken.sub);

            setUsuario(usuarioDominio);

            console.log("Usuário retornado:", usuarioDominio);
        }

        carregarUsuario();
    }, []);

    return (
        <TopBar>
            <div className={style.pagina_conteudo}>
                <h1> Olá, {usuario?.nome}!</h1>  
                
            </div>
        </TopBar>
    );
}