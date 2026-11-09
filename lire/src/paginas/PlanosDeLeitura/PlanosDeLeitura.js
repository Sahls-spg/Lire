import style from "./PlanosDeLeitura.module.css";
import { useEffect, useState } from 'react';
import { TopBar } from "../../componentes/TopBar/TopBar";

export function PlanosDeLeitura()
{
    return (
            <TopBar>
                <div className={style.pagina_conteudo}>
                    <h1> Meus Planos de Leitura</h1>  
                </div>
            </TopBar>
        );
}