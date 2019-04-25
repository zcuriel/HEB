using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Data;
using HEB.NetGiphyA.Data.Objects;

namespace HEB.NetGiphyA.Business.Handlers
{
    public class UserService : IUserService
    {
        private NetGiphyADbContext _userContext;

        public UserService(NetGiphyADbContext userContext)
        {
            _userContext = userContext;
        }

        /// <summary>
        /// Method implementation to Register to the Database
        /// </summary>
        /// <param name="user"></param>
        public void AddUserRegistration(User user)
        {
            _userContext.Add(user);
            _userContext.SaveChanges();
        }
    }
}
