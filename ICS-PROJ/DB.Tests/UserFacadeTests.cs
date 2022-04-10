using BL.Facades;
using BL.Models;
using DB.Tests.Seeds;
using DB.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DB.Tests
{
    public class UserFacadeTests : Bases.BaseMapperTests<UserFacade>
    {
        public UserFacadeTests()
        {
            var unitOfWorkFactory = new UnitOfWorkFactory(DbFactory);
            SUT = new UserFacade(unitOfWorkFactory, Mapper);
        }

        [Fact]
        public async Task Create_WithNonExistingItem_DoesNotThrow()
        {
            var _ = await SUT.SaveAsync(ModelSeeds.UserDetailModel);
        }

        [Fact]
        public async Task GetAll_Single_User1()
        {
            var users = await SUT.GetAsync();
            var user = users.Single(i => i.ID == UserSeeds.User1.ID);

            DeepAssert.Equal(Mapper.Map<UserListModel>(UserSeeds.User1), user);
        }

        [Fact]
        public async Task GetById_User1()
        {
            var user = await SUT.GetAsync(UserSeeds.User1.ID);

            DeepAssert.Equal(Mapper.Map<UserDetailModel>(UserSeeds.User1), user);
        }
    }
}
