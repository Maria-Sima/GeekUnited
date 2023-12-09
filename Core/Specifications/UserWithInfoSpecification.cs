using Core.Entities;

namespace Core.Specifications;

public class UserWithInfoSpecification : BaseSpecification<AppUser>
{
    public UserWithInfoSpecification(string userId) : base(x => x.Id == userId)
    {
        AddInclude(user => user.Name);
        AddInclude(user => user.Username);
        AddInclude(user => user.ProfilePhoto);
        AddInclude(user => user.Id);
    }
}
