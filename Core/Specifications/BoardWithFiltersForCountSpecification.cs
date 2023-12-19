using Core.Documents;

namespace Core.Specifications;

public class BoardWithFiltersForCountSpecification : BaseSpecification<BoardDocument>
{
    public BoardWithFiltersForCountSpecification() { }

    public BoardWithFiltersForCountSpecification(GeneralSpecParams specParams) : base(
        x =>
            string.IsNullOrEmpty(specParams.Search)
            || x.Bio.ToLower().Contains(specParams.Search)
            || string.IsNullOrEmpty(specParams.BoardId)
            || x.CreatedBy == specParams.UserId
    ) { }
}
