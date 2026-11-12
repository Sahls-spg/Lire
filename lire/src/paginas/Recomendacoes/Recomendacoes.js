import style from "./Recomendacoes.module.css";
import { useEffect, useState } from 'react';
import { TopBar } from "../../componentes/TopBar/TopBar";

export function Recomendacoes() {
    return (
        <TopBar>
            <div className={style.pagina_conteudo}>
                <div>
                    <h1> Recomendações para você</h1>
                    <h4>Escolhidas pela IA com base nos seus interesses</h4>
                </div>
            </div>
        </TopBar>
    );
}