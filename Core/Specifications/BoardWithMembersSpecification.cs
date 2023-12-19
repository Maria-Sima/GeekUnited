using Core.Documents;

namespace Core.Specifications;

public class BoardWithMembersSpecification : BaseSpecification<BoardDocument>
{
    public BoardWithMembersSpecification(string id)
        : base(x => x.Id == id)
    {
        AddInclude(x => x.CreatedBy);
        AddInclude(x => x.Members.Select(memberId => new UserWithInfoSpecification(memberId)));
    }

    public BoardWithMembersSpecification(GeneralSpecParams boardParams) : base(x =>
        (string.IsNullOrEmpty(boardParams.Search) || x.BoardName.ToLower().Contains(boardParams.Search))
        && (string.IsNullOrEmpty(boardParams.UserId) || x.Members.Any(m => m == boardParams.UserId)))
    {
        AddInclude(x => x.Members.Select(memberId => new UserWithInfoSpecification(memberId)));
        AddOrderBy(x => x.BoardName);
        ApplyPaging(boardParams.PageSize * (boardParams.PageIndex - 1), boardParams.PageSize);
    }
}
