import style from "./Recomendacoes.module.css";
import { useEffect, useState } from 'react';
import { TopBar } from "../../componentes/TopBar/TopBar";

export function Recomendacoes()
{
    return (
            <TopBar>
                <div className={style.pagina_conteudo}>
                    <h1> Recomendações para você</h1>  
                </div>
            </TopBar>
        );
}