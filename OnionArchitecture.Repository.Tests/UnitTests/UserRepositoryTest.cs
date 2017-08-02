using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Repository.Models;
using OnionArchitecture.Repository.Repositories;
using Xunit;

namespace OnionArchitecture.Repository.Tests.UnitTests
{
    public class UserRepositoryTest
    {
        [Fact(DisplayName = "CreateAsync Given Valid input Returns Id")]
        public async Task Test_CreateAsync_Returns_Id()
        {
            //Arrange
            var options = TestUtility.CreateNewContextOptions();
            var context = new Context(options);
            var repository = new UserRepository(context);

            using (repository)
            {
                var user = new User()
                {
                    Name = "Test"
                };
                //Act
                var id = await repository.CreateAsync(user);
                //Assert
                Assert.Equal(1, id);
            }
        }
        public class TestDbSet<T> : DbSet<T> where T : class
        {

        }

        [Fact(DisplayName = "CreateAsync given null input throws ArgumentNullException")]
        public async Task Test_CreateAsync_Given_Null_Throws_ArgumentNullException()
        {
            //Arrange
            var options = TestUtility.CreateNewContextOptions();
            var context = new Context(options);
            var repository = new UserRepository(context);

            using (repository)
            {
                //Act + Assert
                await Assert.ThrowsAsync<ArgumentNullException>(() => repository.CreateAsync(null));
            }
        }

    }

}
