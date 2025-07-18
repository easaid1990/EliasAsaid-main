using Medfar.Interview.Types;

namespace Medfar.Interview.DAL.Repositories
{
    public interface IIndividualMessageRepository
    {
        Task<List<IndividualMessage>> GetAllAsync();
        Task<List<IndividualMessage>> SearchAsync(
            string searchString,
            DateTime? fromDate,
            DateTime? toDate
        );
    }
}
