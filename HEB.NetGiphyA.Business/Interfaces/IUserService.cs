using HEB.NetGiphyA.Data.Objects;

namespace HEB.NetGiphyA.Business.Interfaces
{
    public interface IUserService
    {

        /// <summary>
        /// Method definition to Add a User to the application
        /// </summary>
        /// <param name="user"></param>
        void AddUserRegistration(User user);
    }
}
