using Core.Entities;

namespace Core.Specifications;

public class PostWithChildAndParentPostsSpeciffication : BaseSpecification<Post>

{
    public PostWithChildAndParentPostsSpeciffication() { }

    public PostWithChildAndParentPostsSpeciffication(string parentId) : base(x => x.ParentId == parentId)
    {
        AddInclude(x => x.Author);
        AddInclude(x => x.Board);
        AddInclude(x => x.Children);
    }
}
