import style from "./TopBar.module.css";
import Logo from "../../assets/Logo L.png";
import { HiLogout } from "react-icons/hi";

export function TopBar({ children }) {
    function deslogar() 
    {
        localStorage.removeItem("token");
    }

    return (
        <div>
            <div className={style.topbar_conteudo}>
                <img src={Logo} alt="Logo Lire" className={style.logo}/>
                <Link to="/" className={style.botao_deslogar} onClick={deslogar}>
                    <HiLogout />
                </Link>
            </div>
            <div className={style.pagina_conteudo}>
                {children}
            </div>
        </div>
    );
}