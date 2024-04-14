using HiringSonda.Domain.UserAggregate;

namespace HiringSonda.Application.Person.Models.Response
{
    public record UserResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public static explicit operator UserResponse(UserDomain user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FullName = user.FullName
            };
        }
    }
}
