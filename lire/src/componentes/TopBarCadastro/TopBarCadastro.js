import style from "./TopBarCadastro.module.css";
import Logo from "../../assets/Logo L.png"

export function TopBarCadastro({ children }) {
    return (
        <div>
            <div className={style.topbar_conteudo}>
                <img src={Logo} alt="Logo Lire" className={style.logo}/>
            </div>
            <div className={style.pagina_conteudo}>
                {children}
            </div>
        </div>
    );
}