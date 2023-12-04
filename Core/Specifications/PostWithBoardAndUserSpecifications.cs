using Core.Entities;

namespace Core.Specifications;

public class PostWithBoardAndUserSpecifications : BaseSpecification<Post>
{
    public PostWithBoardAndUserSpecifications(PostSpecParams postParams)
        : base(
            x =>
                (string.IsNullOrEmpty(postParams.Search) || x.Text.ToLower().Contains(postParams.Search))
                && (string.IsNullOrEmpty(postParams.UserId)|| x.Board == postParams.BoardId)
                && (string.IsNullOrEmpty(postParams.UserId) || x.Author == postParams.UserId)
        )
    {
        AddInclude(x => x.Board);
        AddInclude(x => x.Author);
        AddOrderBy(x => x.CreatedAt);
        ApplyPaging(postParams.PageSize * (postParams.PageIndex - 1), postParams.PageSize);
    }

    public PostWithBoardAndUserSpecifications(string id)
        : base(x => x.Id == id)
    {
        AddInclude(x => x.Board);
        AddInclude(x => x.Author);
    }
}
