using System.Text.RegularExpressions;

namespace NaimouzaHighSchool.Models.Utility
{
    public class ExcelColumnPositionStaff : BaseModel
    {
        public ExcelColumnPositionStaff(string name)
            : base()
        {
            ColName = name;
        }

        public ExcelColumnPositionStaff(string name, string pos)
        {
            this.ColName = name;
            this.ColPosition = pos;
        }

        public string ColName { get; set; }

        private string _colPosition;
        public string ColPosition
        {
            get => _colPosition;
            set
            {
                Regex rgx = new Regex(@"(^[a-zA-Z]{1}$)|(^[aAbBcC][a-zA-Z]{1}$)");
                if (rgx.IsMatch(value))
                {
                    _colPosition = value.ToUpper();

                }
                else
                {
                    _colPosition = "";
                }
                OnPropertyChanged("ColPosition");
            }
        }
    }
}
