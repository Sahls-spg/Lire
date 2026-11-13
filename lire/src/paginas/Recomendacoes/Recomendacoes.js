import style from "./Recomendacoes.module.css";
import { useEffect, useState } from "react";
import { TopBar } from "../../componentes/TopBar/TopBar";
import { jwtDecode } from "jwt-decode";
import RecomendacaoIAAPI from "../../services/recomendacaoIAAPI";

export function Recomendacoes() {
    const [livros, setLivros] = useState([]);
    const [livroSelecionado, setLivroSelecionado] = useState(null);
    const [carregando, setCarregando] = useState(false);

    useEffect(() => {
        const token = localStorage.getItem("token");

        if (token == null) {
            return;
        }

        const usuarioId = jwtDecode(token).sub;
        const recomendacoesAnteriores = localStorage.getItem(`recomendacoes${usuarioId}`);

        if (recomendacoesAnteriores != null) {
            setLivros(JSON.parse(recomendacoesAnteriores));
        }
    }, []);

    async function buscarRecomendacoes() {

        const token = localStorage.getItem("token");

        if (token == null) {
            return;
        }

        const usuarioId = jwtDecode(token).sub;

        try {
            setCarregando(true);

            const novasRecomendacoes = await RecomendacaoIAAPI.gerarRecomendacoes(usuarioId);

            const todosLivrosRecomendados = novasRecomendacoes.concat(livros);

            setLivros(todosLivrosRecomendados);

            localStorage.setItem(`recomendacoes${usuarioId}`, JSON.stringify(todosLivrosRecomendados));
        }
        catch (error) {
            console.error("Erro ao buscar recomendações:", error);
        }
        finally {
            setCarregando(false);
        }
    }

    function exibirCapa(livro) {
        if (livro.imagemCapa != null) {
            return <img src={livro.imagemCapa} alt={livro.titulo} className={style.capa} />;
        }
        else {
            return <div className={style.capa_padrao}>{livro.titulo}</div>;
        }
    }

    return (
        <TopBar>
            <div className={style.pagina_conteudo}>
                <h1>Recomendações para você</h1>

                <div className={style.gerar_recomendacoes}>
                    <h2>Sua próxima leitura começa aqui</h2>
                    <p>Descubra novas leituras que combinam com seu perfil.</p>

                    <button onClick={buscarRecomendacoes} disabled={carregando}>
                        {carregando ? "Buscando livros..." : "Descobrir novos livros"}
                    </button>
                </div>

                <h2>Suas recomendações</h2>

                <div className={style.lista_livros}>
                    {livros.map((livro) => (
                        <div className={style.card_livro} key={livro.id}>

                            {exibirCapa(livro)}

                            <div className={style.informacoes}>
                                <h2>{livro.titulo}</h2>
                                <p>{livro.autor}</p>
                                <p>{livro.quantidadeDePaginas} páginas</p>
                            </div>

                            <button onClick={() => setLivroSelecionado(livro)}>
                                Ver livro
                            </button>
                        </div>
                    ))}
                </div>

                {livroSelecionado && (
                    <div className={style.fundo_modal}>
                        <div className={style.modal}>
                            <h2>{livroSelecionado.titulo}</h2>

                            {exibirCapa(livroSelecionado)}

                            <p>{livroSelecionado.autor}</p>
                            <p>{livroSelecionado.quantidadeDePaginas} páginas</p>

                            <h3>Sinopse</h3>
                            <p>{livroSelecionado.sinopse}</p>

                            <button onClick={() => setLivroSelecionado(null)}>
                                Fechar
                            </button>
                        </div>
                    </div>
                )}
            </div>
        </TopBar>
    );
}
