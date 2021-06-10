using AuthoritySystem.Model.Entity;

namespace AuthoritySystem.Model.Dto.Response
{
    public class UserResponseDto : BaseResponseDto<UserDto>
    {
    }

    public class UserDto:TB_User
    {
        public string RoleName { get; set; }

        public string DepartmentName { get; set; }
    }
}
