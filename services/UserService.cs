using TheEnchiridion.context;
using TheEnchiridion.models;
using TheEnchiridion.models.requests;

namespace TheEnchiridion.services
{
    public interface IUserService
    {
        void createUser(LoginRequest loginRequest);
        bool loginUser(LoginRequest loginRequest);
        bool userExists(string userName);
    }

    public class UserService: IUserService
    {
        public UserService() { }

        public void createUser(LoginRequest loginRequest)
        {
            using (var context = new DataContext())
            {
                var user = new User()
                {
                    username = loginRequest.Username,
                    password = loginRequest.Password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            //TODO: Add exception throwing for why it failed.
        }

        public bool loginUser(LoginRequest loginRequest)
        {
            using (var context = new DataContext())
            {
                bool loginSuccess = context.Users.Any(
                    x => x.username == loginRequest.Username && 
                    x.password == loginRequest.Password
                );
                return loginSuccess;
            }
        }

        public bool userExists(string userName)
        {
            using (var context = new DataContext())
            {
                return context.Users.Any(x => x.username == userName);
            }
        }
    }
}
