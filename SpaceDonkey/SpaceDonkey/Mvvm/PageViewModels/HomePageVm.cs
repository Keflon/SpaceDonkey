using FunctionZero.CommandZero;
using SpaceDonkey.Models.Apod;
using SpaceDonkey.Mvvm.ViewModels;
using SpaceDonkey.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceDonkey.Mvvm.PageViewModels
{
    public class HomePageVm : SpaceDonkeyBaseVm
    {
        private ApodResponse _apodData;
        private DateTime _pictureDate;
        private readonly ApodService _apodService;
        private readonly OmdbService _omdbService;

        public ICommand TestCommand { get; }

        //private ICommand _testCommand;
        //public ICommand TestCommand
        //{
        //    get
        //    {
        //        return _testCommand;
        //    }
        //    set
        //    {
        //        _testCommand = value;
        //    }
        //}





        public ApodResponse ApodData
        {
            get => _apodData;
            set => SetProperty(ref _apodData, value);
        }

        public DateTime PictureDate
        {
            get => _pictureDate;
            set => SetProperty(ref _pictureDate, value);
        }

        public HomePageVm(ApodService apodService, OmdbService omdbService)
        {
            _apodService = apodService;
            _omdbService = omdbService;
            PictureDate = DateTime.Now;



            TestCommand = new CommandBuilder().SetExecute(TestCommandExecute).Build();
        }

        private async void TestCommandExecute()
        {
            Models.Omdb.MovieCollectionModel result = await _omdbService.GetMoviesAsync("Conan");

            if (result.Movies != null)
            {
                foreach (var item in result.Movies)
                {
                    Debug.WriteLine(item.Name);
                }
            }
        }

        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(PictureDate))
            {
                var result = await _apodService.GetApodAsync(PictureDate);

                if (result.status == Services.Rest.ResultStatus.Success)
                {
                    ApodData = result.payload.FirstOrDefault();
                }
                else
                {
                    ApodData = null;
                }
            }
        }
    }
}
