using Core.Documents;

namespace Core.Specifications;

public class PostWithBoardAndUserSpecifications : BaseSpecification<PostDocument>
{
    public PostWithBoardAndUserSpecifications(GeneralSpecParams generalParams)
        : base(
            x =>
                (string.IsNullOrEmpty(generalParams.Search) || x.Text.ToLower().Contains(generalParams.Search))
                && (string.IsNullOrEmpty(generalParams.UserId) || x.Board == generalParams.BoardId)
                && (string.IsNullOrEmpty(generalParams.UserId) || x.Author == generalParams.UserId)
        )
    {
        AddInclude(x => x.Board);
        AddInclude(x => x.Author);
        AddOrderBy(x => x.CreatedAt);
        ApplyPaging(generalParams.PageSize * (generalParams.PageIndex - 1), generalParams.PageSize);
    }

    public PostWithBoardAndUserSpecifications(string id)
        : base(x => x.Id == id)
    {
        AddInclude(x => x.Board);
        AddInclude(x => x.Author);
    }
}
