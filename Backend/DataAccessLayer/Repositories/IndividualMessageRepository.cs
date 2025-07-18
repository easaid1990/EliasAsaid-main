using Medfar.Interview.Types;
using Microsoft.EntityFrameworkCore;

namespace Medfar.Interview.DAL.Repositories;

public class IndividualMessageRepository(MedfarDbContext context) : IIndividualMessageRepository
{
    private readonly MedfarDbContext _context = context;

    public async Task<List<IndividualMessage>> GetAllAsync()
    {
        return await _context.IndividualMessages.ToListAsync();
    }

    public async Task<List<IndividualMessage>> SearchAsync(
        string? searchString = null,
        DateTime? fromDate = null,
        DateTime? toDate = null
    )
    {
        // Predicate builder using Expression
        var predicate = PredicateBuilder.True<IndividualMessage>();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            var param = searchString.Trim();
            predicate = predicate.And(m =>
                EF.Functions.Like(m.Subject, $"%{param}%")
                || EF.Functions.Like(m.Body, $"%{param}%")
            );
        }
        if (fromDate.HasValue)
        {
            var from = fromDate.Value;
            predicate = predicate.And(m => m.SendDate >= from);
        }
        if (toDate.HasValue)
        {
            var to = toDate.Value;
            predicate = predicate.And(m => m.SendDate <= to);
        }

        return await _context.IndividualMessages.Where(predicate).ToListAsync();
    }

}
