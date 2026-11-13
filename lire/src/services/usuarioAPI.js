import { HTTPClient } from "./client";

const UsuarioAPI = {
    async criarAsync(nome, sobrenome, email, senha, quantidadeLivrosLidos, dataNascimento, genero, generoLiterarioFavorito, diasDisponiveis, tempoDiario) {
        try {
            const usuarioCriar = {
                Nome: nome,
                Sobrenome: sobrenome,
                Email: email,
                Senha: senha,
                QuantidadeDeLivrosLidos: Number(quantidadeLivrosLidos),
                DataNascimento: dataNascimento,
                Genero: genero,
                GenerosLiterariosFavorito: generoLiterarioFavorito,
                DiasDisponiveisParaLer: Number(diasDisponiveis),
                TempoDiarioPraLer: `${tempoDiario}:00`
            };
            const response = await HTTPClient.post(`/Usuario/Criar`, usuarioCriar);
            return response;
        }
        catch (error) {
            console.error("Erro ao criar usuário", error);
            throw error;
        }
    },

    async atualizarAsync(id, nome, sobrenome, email, dataNascimento) {
        try {
            const usuarioAtualizar = {
                Id: id,
                Nome: nome,
                Sobrenome: sobrenome,
                Email: email,
                DataNascimento: dataNascimento
            };
            const response = await HTTPClient.put(`/Usuario/Atualizar`, usuarioAtualizar);
            return response;
        }
        catch (error) {
            console.error("Erro ao atualizar usuário", error);
            throw error;
        }
    },

    async deletarAsync(usuarioId) {
        try {
            const response = await HTTPClient.delete(`/Usuario/Deletar/${usuarioId}`);
            return response;
        }
        catch (error) {
            console.error("Erro ao deletar usuário", error);
            throw error;
        }
    },

    async obterPeloIdAsync(usuarioId) {
        try {
            const response = await HTTPClient.get(`/Usuario/ObterPeloId/${usuarioId}`);
            return response.data;
        }
        catch (error) {
            console.error("Erro ao obter usuário pelo Id", error);
            throw error;
        }
    },

    async obterPeloEmail(email) {
        try {
            const response = await HTTPClient.get(`/Usuario/ObterPeloEmail/${email}`)
            return response;
        }
        catch (error) {
            console.error("Erro ao obter usuário pelo e-mail", error);
            throw error;
        }
    },

    async listarAsync() {
        try {
            const response = await HTTPClient.get(`/Usuario/Listar`)
            return response;
        }
        catch (error) {
            console.error("Erro ao listar usuários", error);
            throw error;
        }
    },

    async listarGenero() {
        try {
            const response = await HTTPClient.get(`/Usuario/ListarGeneros`)
            return response.data;
        }
        catch (error) {
            console.error("Erro ao listar gêneros", error);
            throw error;
        }
    },

    async listarGeneroLiterario() {
        try {
            const response = await HTTPClient.get(`/Usuario/ListarGenerosLiterarios`)
            return response.data;
        }
        catch (error) {
            console.error("Erro ao listar gêneros literários", error);
            throw error;
        }
    }
}

export default UsuarioAPI;