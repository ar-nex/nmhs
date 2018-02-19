namespace NaimouzaHighSchool.Models.Utility
{
    public class Teacher : BaseModel
    {
        public Teacher()
            : base()
        {

        }
        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _subject;
        public string Subject
        {
            get => _subject;
            set
            {
                _subject = value;
                OnPropertyChanged("Subject");
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private string _passwordHash;
        public string PasswordHash
        {
            get { return _passwordHash; }
            set { _passwordHash = value; }
        }
    }
}
