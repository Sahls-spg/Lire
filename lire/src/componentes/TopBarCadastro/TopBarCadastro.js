import style from "./TopBarCadastro.module.css";
import { Link } from "react-router-dom";

export function TopBarCadastro({ children, childrenTopo })
{
    return (
        <div>
            <div className={style.topbar_conteudo}>
                <div className={style.area_topo}>
                    {childrenTopo}
                </div>
            </div>
            <div className={style.pagina_conteudo}>
                {children}
            </div>
        </div>
    );
}