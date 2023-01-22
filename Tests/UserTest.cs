using APIUserRegisterSystem.DB;
using APIUserRegisterSystem.Entities;
using APIUserRegisterSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UserRegistrationSystemTests
{
    public class Tests
    {
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=DESKTOP-1AEJFBE\\SQLEXPRESS01;Database=API_UserRegisterDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true")
                .Options;
       //AppDbContext context = new(options);
        UserRepository userRep = new();
        LoginRepository loginRep = new();
        //AddressRepository addressRep = new(context);


        [Test]
        public void CreateNewAddressAndCheckIfAddressByIDMatchesDb()
        {
            var context = new AppDbContext(options);
            AddressRepository addressRep = new(context);

            var address = new Address { City = "Kaunas", Street = "Baltu pr.", HouseNumber = 25, FlatNumber = 56 };
            context.Addresses.Add(address);
            context.SaveChanges();

            var addressId = address.Id;
            var actual = addressRep.Get(addressId);

            Assert.AreEqual(actual.Id, addressId);
        }
        [Test]
        public void CreateNewUserAndUpdateHisName()
        {
            var context = new AppDbContext(options);
            UserRepository userRep = new(context);

            var user = new User 
            { 
                Name="algis", 
                SurName="padalgis",
                IdNumber=123,
                Mail="as@test.lt", 
                Phone=862548795, 
                Photo="test",
                AddressId = 10,
                LoginId = 3
            };
            context.Users.Add(user);
            context.SaveChanges();

            var user2 = new UserNameDTO { Name = "darius" };
            var actual = userRep.UpdateName(user.Id, user2);

            Assert.AreEqual(actual.Name, "darius");
        }
        [Test]
        public void CreateNewLoginsWhenDeleteAndCheckIfItIsDeleted()
        {
            var context = new AppDbContext(options);
            LoginRepository loginRep = new(context);

            var login = new Login { UserName = "test1", Password = "test1" };
            context.Logins.Add(login);
            context.SaveChanges();

            var loginId = login.Id;
            loginRep.Delete(loginId);

            Assert.Null(context.Logins.Find(login.Id));
        }
    }
}