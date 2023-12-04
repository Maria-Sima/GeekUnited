using Core.Entities;

namespace Core.Specifications;

public class PostWithFiltersForCountSpecification : BaseSpecification<Post>
{
    public PostWithFiltersForCountSpecification(PostSpecParams postSpecParams)
        : base(
            x =>
                string.IsNullOrEmpty(postSpecParams.Search)
                || x.Text.ToLower().Contains(postSpecParams.Search)
                || (
                    (string.IsNullOrEmpty(postSpecParams.BoardId) || x.Board == postSpecParams.BoardId)
                    && (string.IsNullOrEmpty(postSpecParams.Search) || x.Author == postSpecParams.UserId)
                )
        ) { }
}
