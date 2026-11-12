
import React, { createContext, useContext, useRef, useState } from 'react';
import { Alert } from './Alert';

const AlertContext = createContext(null);

export function AlertProvider({ children }) {
    const [alerta, setAlerta] = useState({
        visivel: false,
        mensagem: '',
        tipo: 'success',
        aoConfirmar: null
    });

    const timerRef = useRef(null);

    const mostrarAlerta = (mensagem, tipo = 'success', aoConfirmar = null) => {
        if (timerRef.current) {
            clearTimeout(timerRef.current);
        }

        setAlerta({
            visivel: true,
            mensagem,
            tipo,
            aoConfirmar
        });

        timerRef.current = setTimeout(() => {
            setAlerta(alertaAtual => {
                if (alertaAtual.aoConfirmar) {
                    alertaAtual.aoConfirmar();
                }

                return {
                    visivel: false,
                    mensagem: '',
                    tipo: 'success',
                    aoConfirmar: null
                };
            });

            timerRef.current = null;
        }, 2000);
    };

    const fecharAlerta = () => {
        if (timerRef.current) {
            clearTimeout(timerRef.current);
            timerRef.current = null;
        }

        const acao = alerta.aoConfirmar;

        setAlerta({
            visivel: false,
            mensagem: '',
            tipo: 'success',
            aoConfirmar: null
        });

        if (acao) {
            acao();
        }
    };

    return (
        <AlertContext.Provider value={{ mostrarAlerta }}>
            {children}

            <Alert
                visivel={alerta.visivel}
                mensagem={alerta.mensagem}
                tipo={alerta.tipo}
                onFechar={fecharAlerta}
            />
        </AlertContext.Provider>
    );
}

export function useAlert() 
{
    const contexto = useContext(AlertContext);

    if (!contexto) {
        throw new Error('useAlert precisa ser utilizado dentro de AlertProvider.');
    }

    return contexto;
}
