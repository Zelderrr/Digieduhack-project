namespace MyGameBackend.Services
{
    public interface IUserService
    {
        User Register(string email, string password);
        User Login(string email, string password);
        void CompleteDailyQuestion(User user);
        void UpgradeCharacter(User user);
        User GetUserProfile();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(string email, string password)
        {
            var user = new User { Email = email, Password = password };
            _userRepository.Save(user);
            return user;
        }

        public User Login(string email, string password)
        {
            var user = _userRepository.FindByEmail(email);
            return user != null && user.Password == password ? user : null;
        }

        public void CompleteDailyQuestion(User user)
        {
            user.Coins += 50;
            _userRepository.Save(user);
        }

        public void UpgradeCharacter(User user)
        {
            if (user.Coins >= 100)
            {
                user.Coins -= 100;
                user.CharacterPower += 50;
                _userRepository.Save(user);
            }
        }

        public User GetUserProfile()
        {
            // Implement session management to retrieve the logged-in user
            return new User(); // Dummy return
        }
    }
}