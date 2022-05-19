using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IntroXamarin.App.ViewModels.Forms
{
    internal class RegisterPatternViewModel : BaseViewModel
    {
        #region privateProp Attributes
        private String _firstName;
        private String _lastName;
        private long _telephone;
        private String _email;
        private DateTime _enrollmentDate;
        #endregion

        #region publicProp getter, setter
        public String FirstName
        {
            get { return _firstName; }
            set { this.SetValue(ref _firstName, value); }
        }

        public String LastName
        {
            get { return _lastName; }
            set { this.SetValue(ref _lastName, value); }
        }

        public long Telephone
        {
            get { return _telephone; }
            set { this.SetValue(ref _telephone, value); }
        }

        public string Email
        {
            get { return _email; }
            set { this.SetValue(ref _email, value); }
        }

        public DateTime EnrollmentDate
        {
            get { return _enrollmentDate; }
            set { this.SetValue(ref _enrollmentDate, value); }
        }
        #endregion

        public RegisterPatternViewModel()
        {
            this.RegisterCommand = new Command(Register);
        }

        #region Commands
        public Command RegisterCommand { get; set; }
        #endregion

        #region Methods
        private async void Register()
        {
            bool required = false;
            if (String.IsNullOrEmpty(this.FirstName))
                required = true;

            if (required)
            {
                await Application.Current.MainPage.DisplayAlert("Notify", "Fields required", "Cancel");
                return;
            }


            var firstName = this.FirstName;
            var lastName = this.LastName;
            var email = this.Email;
            var telephone = this.Telephone;
            var enrollmentDate = EnrollmentDate.Date;


            var message = $"Register Successful {firstName}{lastName}.";
            await Application.Current.MainPage.DisplayAlert("Notify", message, "Cancel");
        } 
        #endregion

    }
}      
