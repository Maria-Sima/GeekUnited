using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class BoardWithFiltersForCountSpecification:BaseSpecification<Board>
{
    public BoardWithFiltersForCountSpecification() { }
    public BoardWithFiltersForCountSpecification(GeneralSpecParams specParams) : base(
        x =>
            string.IsNullOrEmpty(specParams.Search)
            || x.Bio.ToLower().Contains(specParams.Search)
            || (string.IsNullOrEmpty(specParams.BoardId) || x.CreatedBy == specParams.UserId)

    ) { }
}
