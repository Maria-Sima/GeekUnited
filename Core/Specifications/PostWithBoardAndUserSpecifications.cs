using Core.Entities;

namespace Core.Specifications;

public class PostWithBoardAndUserSpecifications:BaseSpecification<Post>
{
    public PostWithBoardAndUserSpecifications(PostSpecParams postParams) : base(x=>
        (string.IsNullOrEmpty(postParams.Search) || x.Title.ToLower().Contains(postParams.Search)) &&
        (!postParams.BoardId.HasValue || x.BoardId==postParams.BoardId==postParams.BoardId.HasValue) && 
        (!postParams.UserId.HasValue || x.UserId==postParams.UserId)
        )
    {
        AddInclude(x => x.Board);
        AddInclude(x => x.AppUser);
        AddOrderBy(x => x.Title);
        ApplyPaging(postParams.PageSize * (postParams.PageIndex - 1), postParams.PageSize);
    }

    public PostWithBoardAndUserSpecifications(int id) : base(x=>x.Id==id)
    {
        AddInclude(x=>x.Board);
        AddInclude(x=>x.AppUser);
    }
}