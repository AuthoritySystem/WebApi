using AuthoritySystem.Model.Entity;

namespace AuthoritySystem.Model.Dto.Request
{
    public class UserRequestDto : PagingRequest
    {
        /// <summary>
        /// 是否分页，默认为true
        /// </summary>
        public bool IsPaging { get; set; } = true;
    }
}
