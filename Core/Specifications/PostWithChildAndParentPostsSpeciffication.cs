using Core.Documents;

namespace Core.Specifications;

public class PostWithChildAndParentPostsSpeciffication : BaseSpecification<PostDocument>

{
    public PostWithChildAndParentPostsSpeciffication() { }

    public PostWithChildAndParentPostsSpeciffication(string parentId) : base(x => x.ParentId == parentId)
    {
        AddInclude(x => x.Author);
        AddInclude(x => x.Board);
        AddInclude(x => x.Children);
    }
}
