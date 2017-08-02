using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Sdk;

namespace OnionArchitecture.Repository.Tests.UnitTests
{
    public class GenericRepositoryTest
    {

        /// <summary>
        /// This method is used to setup a dummy repository where the db context has been injected with an in-memory provider.
        /// </summary>
        /// <returns></returns>
        public DummyRepository CreateDummyRepository()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create new options instance setting context to use in memory service provider
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase()
                .UseInternalServiceProvider(serviceProvider);

            var context = new DummyContext(builder.Options);
            return new DummyRepository(context);
        }

        #region Asynchronous CRUD operation tests 

        [Fact(DisplayName = "CreateAsync returns id of entity")]
        public async Task Test_CreateAsync_Returns_Id()
        {
            using (var repo = CreateDummyRepository())
            {
                // Arrange
                var dummy = new Dummy {DummyVariable = 42};

                // Act 
                var result = await repo.CreateAsync(dummy);

                // Assert
                Assert.Equal(1, result);
            }
        }

        [Fact(DisplayName = "CreateAsync throws exception if context is dispoed")]
        public async Task Test_CreateAsync_ThrowsException_IfContextDisposed()
        {
            // Arrange
            using (var repo = CreateDummyRepository())
            {
                // Act 
                repo.Dispose();

                // Assert 
                await Assert.ThrowsAsync<ObjectDisposedException>(async () => 
                    await repo.CreateAsync(new Dummy {DummyVariable = 42}));
            }
        }

        #endregion

        #region Asynchronous Delete Operation

        
           
        [Fact(DisplayName = "DeleteAsync removes the correct item")]
        public async Task Test_DeleteAsync_RemovesCorrectItem()
        {
            // Arrange
            using (var repo = CreateDummyRepository())
            {
                var ids = new List<int>();
                ids.Add(await repo.CreateAsync(new Dummy { DummyVariable = 2 }));
                ids.Add(await repo.CreateAsync(new Dummy { DummyVariable = 2 }));
                ids.Add(await repo.CreateAsync(new Dummy { DummyVariable = 2 }));
                int toRemove = ids[1];
                // Act
                var result = await repo.DeleteAsync(toRemove);
                // Assert
                Assert.True(result);
                Assert.Equal(1, (await repo.FindAsync(ids[0])).Id);
                Assert.Equal(3, (await repo.FindAsync(ids[2])).Id);
            }
        }

        [Fact(DisplayName = "DeleteAsync throws exception if item not found")]
        public async Task Test_DeleteAsync_ThrowsException_IfItemNotFound()
        {
            // Arrange
            using (var repo = CreateDummyRepository())
            {
                await repo.CreateAsync(new Dummy { DummyVariable = 2048 });
                // Act+Assert
                await Assert.ThrowsAsync<InvalidOperationException>(
                    async () => await repo.DeleteAsync(10));
            }
        }

        [Fact(DisplayName = "DeleteAsync throws exception if context is disposed")]
        public async Task Test_Delete_ThrowsException_IfContextDisposed()
        {
            // Arrange
            using (var repo = CreateDummyRepository())
            {
                repo.Dispose();
                // Act+Assert
                await Assert.ThrowsAsync<ObjectDisposedException>(
                    async () => await repo.DeleteAsync(2));
            }
        }

        #endregion

        #region Test FindAsync asynchronous operation

        [Fact(DisplayName = "FindAsync throws exception if context is disposed")]
        public async Task Test_FindAsync_ThrowsException_IfContextDisposed()
        {
            // Arrange
            using (var repo = CreateDummyRepository())
            {
                // Act
                repo.Dispose();
                // Act+Assert
                await Assert.ThrowsAsync<ObjectDisposedException>(async () =>
                await repo.FindAsync(2));
            }
        }

        [Fact(DisplayName = "FindAsync returns entity if id found")]
        public async Task Test_FindAsync_ReturnsEntity_IfIdExist()
        {
            // Arrange
            using (var repo = CreateDummyRepository())
            {
                int id = await repo.CreateAsync(new Dummy { DummyVariable = 42 });
                // Act
                var result = await repo.FindAsync(id);
                // Assert
                Assert.IsType<Dummy>(result);
                Assert.Equal(id, result.Id);
            }
        }
        [Fact(DisplayName = "FindAsync throws exception if entity not found.")]
        public async Task Test_FindAsync_ThrowsException_IfEntityNotFound()
        {
            // Arrange 
            using (var repo = CreateDummyRepository())
            {
                // Act and Assert 
                await Assert.ThrowsAsync<InvalidOperationException>(async () => await repo.FindAsync(4234));
            }
        }

        #endregion

        #region UpdateAsync-Tests
        [Fact(DisplayName = "UpdateAsync throws exception if item not found.")]
        public async Task Test_UpdateAsync_ThrowsInvalidOperationException_IfItemNotFound()
        {
            using (var repo = CreateDummyRepository())
            {
                var oldDummy = new Dummy { DummyVariable = 1 };
                await repo.CreateAsync(oldDummy);
                var newDummy = new Dummy { Id = 2, DummyVariable = 42 };
                await Assert.ThrowsAsync<DbUpdateConcurrencyException>(async () => await repo.UpdateAsync(newDummy));
            }
        }

        [Fact(DisplayName = "UpdateAsync updates item if found.")]
        public async Task Test_UpdateAsync_Updates_IfItemFound()
        {
            using (var repo = CreateDummyRepository())
            {
                var oldDummy = new Dummy { DummyVariable = 1 };
                oldDummy.Id = await repo.CreateAsync(oldDummy);
                oldDummy.DummyVariable = 42;
                var result = await repo.UpdateAsync(oldDummy);
                Assert.True(result);
                Assert.Equal(42, (await repo.FindAsync(1)).DummyVariable);
            }
        }


        #endregion


    }
}
