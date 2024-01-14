using System.Threading.Tasks;

namespace HiringSonda.Infra.Data
{
    public interface IUnitOfWork
    {
        ContextDatabase Context { get; }
        Task CommitAsync();
        Task CommitWithIdentityInsertAsync(string table);
    }
}
