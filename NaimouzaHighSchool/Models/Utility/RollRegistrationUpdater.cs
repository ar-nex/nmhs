namespace NaimouzaHighSchool.Models.Utility
{
    public class RollRegistrationUpdater : RollUpdater
    {
        public RollRegistrationUpdater()
            : base()
        {

        }

        private string _registrationNo;
        public string RegistrationNo
        {
            get => _registrationNo;
            set
            {
                _registrationNo = value;
                OnPropertyChanged("RegistrationNo");
            }
        }
    }
}
