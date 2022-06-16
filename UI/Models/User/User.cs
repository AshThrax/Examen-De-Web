
namespace UI.Models.User
{
    public class User 
    {
        public string UserId { get; set; }
        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public string ContactEmail { get; set; }

        public string UserState { get; set; }

        public string UserNameComplete => string.Format("{0} {1}",UserFirstName,UserLastName);

    }
}
