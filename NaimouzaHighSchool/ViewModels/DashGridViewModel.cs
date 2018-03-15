using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaimouzaHighSchool.Models.Database;
using NaimouzaHighSchool.ViewModels.Commands;

namespace NaimouzaHighSchool.ViewModels
{
    public class DashGridViewModel : BaseViewModel
    {
        public DashGridViewModel()
            : base()
        {
            StartUpInitializer();
        }

        private float _transScaleX;
        public float TransScaleX
        {
            get { return _transScaleX; }
            set
            {
                _transScaleX = value;
                OnPropertyChanged("TransScaleX");
            }
        }

        private float _transScaleY;
        public float TransScaleY
        {
            get { return _transScaleY; }
            set { _transScaleY = value; OnPropertyChanged("TransScaleY"); }
        }


        private float _transCenterX;
        public float TransCenterX
        {
            get { return _transCenterX; }
            set
            {
                _transCenterX = value;
                OnPropertyChanged("TransCenterX");
            }
        }

        private float _transCenterY;
        public float TransCenterY
        {
            get { return _transCenterY; }
            set { _transCenterY = value; OnPropertyChanged("TransCenterY"); }
        }

        public RelayCommand ZoomInCommand { get; set; }
        public RelayCommand ZoomOutCommand { get; set; }

        private void StartUpInitializer()
        {
            TransScaleX = 1f;
            TransScaleY = 1f;
            TransCenterX = 1f;
            TransCenterY = 1f;

            ZoomInCommand = new RelayCommand(ZoomIn, CanZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut, CanZoomOut);
        }

        private void ZoomIn()
        {
            TransScaleX = TransScaleX + 0.1f;
            TransScaleY = TransScaleY + 0.1f;
            TransCenterX = TransCenterX + 0.1f;
            TransCenterY = TransCenterY + 0.1f;
        }
        private bool CanZoomIn()
        {
            return true;
        }

        private void ZoomOut()
        {
            TransScaleX = TransScaleX - 0.1f;
            TransScaleY = TransScaleY - 0.1f;
            TransCenterX = TransCenterX - 0.1f;
            TransCenterY = TransCenterY - 0.1f;

        }
        private bool CanZoomOut()
        {
            return true;
        }
    }
}
