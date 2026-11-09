import style from "./TopBar.module.css";
import Logo from "../../assets/Logo L.png";
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
                <Link className={style.botoes_menu}>
                    <PiHouseBold />
                    <h3>Home</h3>
                    <IoLibraryOutline />
                    <h3>Biblioteca</h3>
                    <MdOutlineAutoStories />
                    <h3>Planos de Leitura</h3>
                    <PiShootingStarBold />
                    <h3>Recomendações</h3>
                </Link>
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