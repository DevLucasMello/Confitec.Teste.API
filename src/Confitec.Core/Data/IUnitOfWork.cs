using System.Threading.Tasks;

namespace Confitec.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
