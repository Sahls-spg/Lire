using ProjetoLire.Repositorio.Contexto;

public abstract class BaseRepositorio
{
    protected readonly ProjetoLireContexto _contexto;

    protected BaseRepositorio(ProjetoLireContexto contexto)
    {
        _contexto = contexto;
    }
}