import style from "./Biblioteca.module.css";
import { useEffect, useState } from 'react';
import { TopBar } from "../../componentes/TopBar/TopBar";

export function Biblioteca()
{
    return (
            <TopBar>
                <div className={style.pagina_conteudo}>
                    <h1> Minha Biblioteca</h1>  
                </div>
            </TopBar>
        );
}