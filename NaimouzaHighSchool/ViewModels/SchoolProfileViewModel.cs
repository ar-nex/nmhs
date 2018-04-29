using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Database;

namespace NaimouzaHighSchool.ViewModels
{
    class SchoolProfileViewModel : BaseViewModel
    {
        public SchoolProfileViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private int _startYear;
        public int StartYear
        {
            get { return _startYear; }
            set
            {
                _startYear = (value > 2016 && value < DateTime.Today.Year+2) ? value : DateTime.Today.Year;
                OnPropertyChanged("StartYear");
                if (StartYear > 2016 && EndYear > 2016)
                {
                    UpdateSchoolProfile();
                }
            }
        }

        private int _endYear;
        public int EndYear
        {
            get { return _endYear; }
            set
            {
                _endYear = (value > 2016 && value < DateTime.Today.Year + 2) ? value : DateTime.Today.Year;
                OnPropertyChanged("EndYear");
                if (StartYear > 2016 && EndYear > 2016)
                {
                    UpdateSchoolProfile();
                }
            }
        }

        private int _startYearCl;
        public int StartYearCl
        {
            get { return _startYearCl; }
            set
            {
                _startYearCl = (value > 2016 && value < DateTime.Today.Year + 2) ? value : DateTime.Today.Year;
                OnPropertyChanged("StartYearCl");
                if (SchoolClassIndex > 0 && StartYearCl > 2016 && EndYearCl > 2016)
                {
                    UpdateClassProfile();
                }
            }
        }

        private int _endYearCl;
        public int EndYearCl
        {
            get { return _endYearCl; }
            set
            {
                _endYearCl = (value > 2016 && value < DateTime.Today.Year + 2) ? value : DateTime.Today.Year;
                OnPropertyChanged("EndYearCl");
                if (SchoolClassIndex > 0 && StartYearCl > 2016 && EndYearCl > 2016)
                {
                    UpdateClassProfile();
                }
            }

        }

        private int _startYearStrm;
        public int StartYearStrm
        {
            get { return _startYearStrm; }
            set
            {
                _startYearStrm = (value > 2016 && value < DateTime.Today.Year + 2) ? value : DateTime.Today.Year;
                OnPropertyChanged("StartYearStrm");
                UpdateStreamProfile();
            }
        }

        private int _endYearStrm;
        public int EndYearStrm
        {
            get { return _endYearStrm; }
            set
            {
                _endYearStrm = (value > 2016 && value < DateTime.Today.Year + 2) ? value : DateTime.Today.Year;
                OnPropertyChanged("EndYearStrm");
                UpdateStreamProfile();
            }
        }


        private string[] _schoolClass;
        public string[] SchoolClass
        {
            get { return _schoolClass; }
            set { _schoolClass = value; OnPropertyChanged("SchoolClass"); }
        }

        private int _schoolClassIndex;
        public int SchoolClassIndex
        {
            get { return _schoolClassIndex; }
            set
            {
                _schoolClassIndex = (value > -1 && value < SchoolClass.Length) ? value : -1;
                OnPropertyChanged("SchoolClassIndex");
                if (SchoolClassIndex > 0 && StartYearCl > 2016 && EndYearCl > 2016)
                {
                    UpdateClassProfile();
                }
            }
        }

        private string[] _schoolClassStrm;
        public string[] SchoolClassStrm
        {
            get { return _schoolClassStrm; }
            set { _schoolClassStrm = value; OnPropertyChanged("SchoolClassStrm"); }
        }

        private int _schoolClassStrmIndex;
        public int SchoolClassStrmIndex
        {
            get { return _schoolClassStrmIndex; }
            set
            {
                _schoolClassStrmIndex = (value > -1 && value < SchoolClassStrm.Length) ? value : -1;
                OnPropertyChanged("SchoolClassStrmIndex");
                UpdateStreamProfile();
            }
        }

        private string _selClass;
        public string SelClass
        {
            get { return _selClass; }
            set { _selClass = value; OnPropertyChanged("SelClass"); }
        }

        private string _selClassStream;
        public string SelClassStream
        {
            get { return _selClassStream; }
            set { _selClassStream = value; OnPropertyChanged("SelClassStream"); }
        }


        private int _grandTotal;
        public int GrandTotal
        {
            get { return _grandTotal; }
            set { _grandTotal = value; OnPropertyChanged("GrandTotal"); }
        }


        private int _countCls;
        public int CountCls
        {
            get { return _countCls; }
            set { _countCls = value; OnPropertyChanged("CountCls"); }
        }

        private int _countClsStream;
        public int CountClsStream
        {
            get { return _countClsStream; }
            set { _countClsStream = value; OnPropertyChanged("CountClsStream"); }
        }


        private int _count5;
        public int Count5
        {
            get { return _count5; }
            set { _count5 = value; OnPropertyChanged("Count5"); }
        }

        private int _count6;
        public int Count6
        {
            get { return _count6; }
            set { _count6 = value; OnPropertyChanged("Count6"); }
        }

        private int _count7;
        public int Count7
        {
            get { return _count7; }
            set { _count7 = value; OnPropertyChanged("Count7"); }
        }

        private int _count8;
        public int Count8
        {
            get { return _count8; }
            set { _count8 = value; OnPropertyChanged("Count8"); }
        }

        private int _count9;
        public int Count9
        {
            get { return _count9; }
            set { _count9 = value; OnPropertyChanged("Count9"); }
        }

        private int _count10;
        public int Count10
        {
            get { return _count10; }
            set { _count10 = value; OnPropertyChanged("Count10"); }
        }

        private int _count11;
        public int Count11
        {
            get { return _count11; }
            set { _count11 = value; OnPropertyChanged("Count11"); }
        }

        private int _count12;
        public int Count12
        {
            get { return _count12; }
            set { _count12 = value; OnPropertyChanged("Count12"); }
        }

        private int _countMale;
        public int CountMale
        {
            get { return _countMale; }
            set { _countMale = value; OnPropertyChanged("CountMale"); }
        }

        private int _countFemale;
        public int CountFemale
        {
            get { return _countFemale; }
            set { _countFemale = value; OnPropertyChanged("CountFemale"); }
        }

        private int _countGenNull;
        public int CountGenNull
        {
            get { return _countGenNull; }
            set { _countGenNull = value; OnPropertyChanged("CountGenNull"); }
        }

        private int _countGen;
        public int CountGen
        {
            get { return _countGen; }
            set { _countGen = value; OnPropertyChanged("CountGen"); }
        }

        private int _countSC;
        public int CountSC
        {
            get { return _countSC; }
            set { _countSC = value; OnPropertyChanged("CountSC"); }
        }

        private int _countST;
        public int CountST
        {
            get { return _countST; }
            set { _countST = value; OnPropertyChanged("CountST"); }
        }

        private int _countOBC;
        public int CountOBC
        {
            get { return _countOBC; }
            set { _countOBC = value; OnPropertyChanged("CountOBC"); }
        }

        private int _countOBC_A;
        public int CountOBC_A
        {
            get { return _countOBC_A; }
            set { _countOBC_A = value; OnPropertyChanged("CountOBC_A"); }
        }

        private int _countOBC_B;
        public int CountOBC_B
        {
            get { return _countOBC_B; }
            set { _countOBC_B = value; OnPropertyChanged("CountOBC_B"); }
        }


        private int _countSocCatNull;
        public int CountSocCatNull
        {
            get { return _countSocCatNull; }
            set { _countSocCatNull = value; OnPropertyChanged("CountSocCatNull"); }
        }

        private int _countApl;
        public int CountApl
        {
            get { return _countApl; }
            set { _countApl = value; OnPropertyChanged("CountApl"); }
        }

        private int _countBpl;
        public int CountBpl
        {
            get { return _countBpl; }
            set { _countBpl = value; OnPropertyChanged("CountBpl"); }
        }


        private int _countClA;
        public int CountClA
        {
            get { return _countClA; }
            set { _countClA = value; OnPropertyChanged("CountClA"); }
        }

        private int _countClB;
        public int CountClB
        {
            get { return _countClB; }
            set { _countClB = value; OnPropertyChanged("CountClB"); }
        }

        private int _countClC;
        public int CountClC
        {
            get { return _countClC; }
            set { _countClC = value; OnPropertyChanged("CountClC"); }
        }

        private int _countClD;
        public int CountClD
        {
            get { return _countClD; }
            set { _countClD = value; OnPropertyChanged("CountClD"); }
        }

        private int _countClE;
        public int CountClE
        {
            get { return _countClE; }
            set { _countClE = value; OnPropertyChanged("CountClE"); }
        }

        private int _countClNullSec;
        public int CountClNullSec
        {
            get { return _countClNullSec; }
            set { _countClNullSec = value; OnPropertyChanged("CountClNullSec"); }
        }

        private int _countClMale;
        public int CountClMale
        {
            get { return _countClMale; }
            set { _countClMale = value; OnPropertyChanged("CountClMale"); }
        }

        private int _countClFemale;
        public int CountClFemale
        {
            get { return _countClFemale; }
            set { _countClFemale = value; OnPropertyChanged("CountClFemale"); }
        }

        private int _countClGenNull;
        public int CountClGenNull
        {
            get { return _countClGenNull; }
            set { _countClGenNull = value; OnPropertyChanged("CountClGenNull"); }
        }

        private int _countClGen;
        public int CountClGen
        {
            get { return _countClGen; }
            set { _countClGen = value; OnPropertyChanged("CountClGen"); }
        }

        private int _countClSC;
        public int CountClSC
        {
            get { return _countClSC; }
            set { _countClSC = value; OnPropertyChanged("CountClSC"); }
        }


        private int _countClST;
        public int CountClST
        {
            get { return _countClST; }
            set { _countClST = value; OnPropertyChanged("CountClST"); }
        }

        private int _countClOBC;
        public int CountClOBC
        {
            get { return _countClOBC; }
            set { _countClOBC = value; OnPropertyChanged("CountClOBC"); }
        }

        private int _countClOBC_A;
        public int CountClOBC_A
        {
            get { return _countClOBC_A; }
            set { _countClOBC_A = value; OnPropertyChanged("CountClOBC_A"); }
        }

        private int _countClOBC_B;
        public int CountClOBC_B
        {
            get { return _countClOBC_B; }
            set { _countClOBC_B = value; OnPropertyChanged("CountClOBC_B"); }
        }


        private int _countClSocCatNull;
        public int CountClSocCatNull
        {
            get { return _countClSocCatNull; }
            set { _countClSocCatNull = value; OnPropertyChanged("CountClSocCatNull"); }
        }

        private int _countClApl;
        public int CountClApl
        {
            get { return _countClApl; }
            set { _countClApl = value; OnPropertyChanged("CountClApl"); }
        }

        private int _countClBpl;
        public int CountClBpl
        {
            get { return _countClBpl; }
            set { _countClBpl = value; OnPropertyChanged("CountClBpl"); }
        }

        private int _countArts;
        public int CountArts
        {
            get { return _countArts; }
            set { _countArts = value; OnPropertyChanged("CountArts"); }
        }

        private int _countScience;
        public int CountScience
        {
            get { return _countScience; }
            set { _countScience = value; OnPropertyChanged("CountScience"); }
        }

        private int _countStreamNull;
        public int CountStreamNull
        {
            get { return _countStreamNull; }
            set { _countStreamNull = value; OnPropertyChanged("CountStreamNull"); }
        }


        private int _countArb;
        public int CountArb
        {
            get { return _countArb; }
            set { _countArb = value; OnPropertyChanged("CountArb"); }
        }

        private int _countEco;
        public int CountEco
        {
            get { return _countEco; }
            set { _countEco = value; OnPropertyChanged("CountEco"); }
        }

        private int _countEdu;
        public int CountEdu
        {
            get { return _countEdu; }
            set { _countEdu = value; OnPropertyChanged("CountEdu"); }
        }

        private int _countGeo;
        public int CountGeo
        {
            get { return _countGeo; }
            set { _countGeo = value; OnPropertyChanged("CountGeo"); }
        }

        private int _countHis;
        public int CountHis
        {
            get { return _countHis; }
            set { _countHis = value; OnPropertyChanged("CountHis"); }
        }

        private int _countPhi;
        public int CountPhi
        {
            get { return _countPhi; }
            set { _countPhi = value; OnPropertyChanged("CountPhi"); }
        }

        private int _countPol;
        public int CountPol
        {
            get { return _countPol; }
            set { _countPol = value; OnPropertyChanged("CountPol"); }
        }

        private int _countSoc;
        public int CountSoc
        {
            get { return _countSoc; }
            set { _countSoc = value; OnPropertyChanged("CountSoc"); }
        }

        private int _countPhy;
        public int CountPhy
        {
            get { return _countPhy; }
            set { _countPhy = value; OnPropertyChanged("CountPhy"); }
        }

        private int _countChm;
        public int CountChm
        {
            get { return _countChm; }
            set { _countChm = value; OnPropertyChanged("CountChm"); }
        }

        private int _countMth;
        public int CountMth
        {
            get { return _countMth; }
            set { _countMth = value; OnPropertyChanged("CountMth"); }
        }

        private int _countBio;
        public int CountBio
        {
            get { return _countBio; }
            set { _countBio = value; OnPropertyChanged("CountBio"); }
        }

        private void StartUpInitializer()
        {
            SchoolClass = new string[] { "-select-", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII"};
            SchoolClassStrm = new string[] { "XI", "XII"};
            StartYear = DateTime.Today.Year;
            EndYear = DateTime.Today.Year;
            StartYearCl = DateTime.Today.Year;
            EndYearCl = DateTime.Today.Year;
            StartYearStrm = DateTime.Today.Year;
            EndYearStrm = DateTime.Today.Year;
        }

        private void UpdateSchoolProfile()
        {
            SchoolProfileDb db = new SchoolProfileDb();
            var tpl = db.GetProfile(StartYear, EndYear);
            GrandTotal = tpl.Item1;
            Count5 = tpl.Item2;
            Count6 = tpl.Item3;
            Count7 = tpl.Item4;
            Count8 = tpl.Item5;
            Count9 = tpl.Item6;
            Count10 = tpl.Item7;
            Count11 = tpl.Item8;
            Count12 = tpl.Item9;

            CountMale = tpl.Item10;
            CountFemale = tpl.Item11;
            CountGenNull = tpl.Item12;

            CountGen = tpl.Item13;
            CountSC = tpl.Item14;
            CountST = tpl.Item15;
            CountOBC = tpl.Item16;
            CountOBC_A = tpl.Item17;
            CountOBC_B = tpl.Item18;
            CountSocCatNull = tpl.Item19;

            CountApl = tpl.Item20;
            CountBpl = tpl.Item21;
        }

        private void UpdateClassProfile()
        {
            SchoolProfileDb db = new SchoolProfileDb();
            var tpl = db.GetProfile(StartYearCl, EndYearCl, SchoolClass[SchoolClassIndex]);
            CountCls = tpl.Item1;
            CountClA = tpl.Item2;
            CountClB = tpl.Item3;
            CountClC = tpl.Item4;
            CountClD = tpl.Item5;
            CountClE = tpl.Item6;
            CountClNullSec = tpl.Item7;

            CountClMale = tpl.Item8;
            CountClFemale = tpl.Item9;
            CountClGenNull = tpl.Item10;

            CountClGen = tpl.Item11;
            CountClSC = tpl.Item12;
            CountClST = tpl.Item13;
            CountClOBC = tpl.Item14;
            CountClOBC_A = tpl.Item15;
            CountClOBC_B = tpl.Item16;
            CountClSocCatNull = tpl.Item17;

            CountClApl = tpl.Item18;
            CountClBpl = tpl.Item19;
        }

        private void UpdateStreamProfile()
        {
            if (StartYearStrm < 2017 || EndYearStrm < 2017 || SchoolClassStrmIndex == -1)
            {
                
                CountArts = CountScience = 0;
                CountArb = CountEco = CountEdu = CountGeo = CountHis = CountPhi = CountPhi = CountPol = CountSoc = 0;
                CountPhy = CountChm = CountMth = CountBio = 0;
            }
            else
            {
                SchoolProfileDb db = new SchoolProfileDb();
                var tpl = db.GetProfileOfStream(StartYearStrm, EndYearStrm, SchoolClassStrm[SchoolClassStrmIndex]);
                SelClassStream = SchoolClassStrm[SchoolClassStrmIndex];
                CountClsStream = tpl.Item1;
                CountArts = tpl.Item2;
                CountScience = tpl.Item3;
                CountStreamNull = tpl.Item4;

                CountArb = tpl.Item5;
                CountEco = tpl.Item6;
                CountEdu = tpl.Item7;
                CountGeo = tpl.Item8;
                CountHis = tpl.Item9;
                CountPhi = tpl.Item10;
                CountPol = tpl.Item11;
                CountSoc = tpl.Item12;

                CountPhy = tpl.Item13;
                CountChm = tpl.Item14;
                CountMth = tpl.Item15;
                CountBio = tpl.Item16;
            }
        }
    }
}
