import { HTTPClient } from "./client";

const RecomendacaoIAAPI = {
    async gerarRecomendacoes(usuarioId, token) {
        try 
        {
            const response = await HTTPClient.post(`/RecomendacaoIA/RecomendacaoLivro/${usuarioId}`);
            return response.data;
        }
        catch (error) 
        {
            console.error("Erro ao gerar recomendação", error);
            throw error;
        }
    }
}
export default RecomendacaoIAAPI;