using HEB.NetGiphyA.Business.Interfaces;
using HEB.NetGiphyA.Data;
using HEB.NetGiphyA.Data.Objects;
using System.Linq;

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


        /// <summary>
        /// Method implementation to verify if a user has registered to the app previously
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool IUserService.VerifyRegisteredUser(string userEmail)
        {
            var objUser = _userContext.Users.Where(u => u.UserEmail == userEmail).FirstOrDefault();
            return (objUser != null);           // Return true if the user is already registered       
        }
    }
}
