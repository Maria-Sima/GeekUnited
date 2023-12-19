using Core.Documents;

namespace Core.Specifications;

public class PostWithFiltersForCountSpecification : BaseSpecification<PostDocument>
{
    public PostWithFiltersForCountSpecification(GeneralSpecParams generalSpecParams)
        : base(
            x =>
                string.IsNullOrEmpty(generalSpecParams.Search)
                || x.Text.ToLower().Contains(generalSpecParams.Search)
                || (string.IsNullOrEmpty(generalSpecParams.BoardId) || x.Board == generalSpecParams.BoardId)
                && (string.IsNullOrEmpty(generalSpecParams.Search) || x.Author == generalSpecParams.UserId)
        ) { }
}
