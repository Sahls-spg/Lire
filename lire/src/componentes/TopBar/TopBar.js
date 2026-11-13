import style from "./TopBar.module.css";
import Logo from "../../assets/img/Logo L.png";
import { HiLogout } from "react-icons/hi";
import { PiHouseBold } from "react-icons/pi";
import { IoLibraryOutline } from "react-icons/io5";
import { MdOutlineAutoStories } from "react-icons/md";
import { PiShootingStarBold } from "react-icons/pi";
import { Link } from "react-router-dom";

export function TopBar({ children }) {
    function deslogar() 
    {
        localStorage.removeItem("token");
    }

    return (
        <div>
            <div className={style.topbar_conteudo}>
                <img src={Logo} alt="Logo Lire" className={style.logo}/>
                <div className={style.botoes_menu}>
                    <Link to="/home">
                        <PiHouseBold />
                        <h3>Home</h3>
                    </Link>

                    <Link to="/biblioteca">
                        <IoLibraryOutline />
                        <h3>Biblioteca</h3>
                    </Link>

                    <Link to="/planosdeleitura">
                        <MdOutlineAutoStories />
                        <h3>Planos de Leitura</h3>
                    </Link>

                    <Link to="/recomendacoes">
                        <PiShootingStarBold />
                        <h3>Recomendações</h3>
                    </Link>
                </div>
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