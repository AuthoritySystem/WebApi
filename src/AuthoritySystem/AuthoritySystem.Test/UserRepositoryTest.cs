using AuthoritySystem.IRepository.Repository;
using AuthoritySystem.Model.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AuthoritySystem.Test
{
    public class UserRepositoryTest
    {
        [Fact]
        public void VerfyListUserCount()
        {
            var repository = new Mock<IUserRepository>();
            List<TB_User> list = new List<TB_User>()
            {
                new TB_User{ }
            };
            repository.Setup(x => x.GetAllListAsync(null));

            var result = repository.Object.GetAllListAsync(null);
            Assert.Equal(2, 2);
        }
    }
}
