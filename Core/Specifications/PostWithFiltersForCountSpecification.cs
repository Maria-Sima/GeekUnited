using Core.Entities;

namespace Core.Specifications;

public class PostWithFiltersForCountSpecification:BaseSpecification<Post>
{
    public PostWithFiltersForCountSpecification(PostSpecParams postSpecParams) : base(
        x=>
            (string.IsNullOrEmpty(postSpecParams.Search) || x.Title.ToLower().Contains(postSpecParams.Search)) ||
            (!postSpecParams.BoardId.HasValue || x.BoardId == postSpecParams.BoardId) && 
            (!postSpecParams.UserId.HasValue ||x.UserId==postSpecParams.UserId)
    )
    {
        
    }
}