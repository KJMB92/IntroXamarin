using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntroXamarin.App.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculoIMC : ContentPage
    {
        public CalculoIMC()
        {
            InitializeComponent();
        }

        public void CalcularBTN (object sender, EventArgs e)
        {
            double peso = double.Parse(EntryPeso.Text);
            double altura = (double.Parse(EntryAltura.Text))/100;

            double total  =peso/(altura*altura);

            this.LabelParaVerIMC.Text = (total).ToString();


            if (total < 18.5)//Peso inferior al normal Menos de 18.5, Tienes bajo peso
            {
                var message = $"Tu peso es muy bajo";
                DisplayAlert("Notify", message, "Cancel");
            }
            if (total >= 18.5 && total <= 24.9)//Normal 18.5 –24.9, Tu peso es normal
            {
                var message = $"Tu peso es normal";
                DisplayAlert("Notify", message, "Cancel");
            }
            if (total >= 25.0 && total <= 29.9)//Peso superior al normal 25.0 –29.9, Tienes sobrepeso
            {
                var message = $"Tienes sobre peso";
                DisplayAlert("Notify", message, "Cancel");
            }
            if (total > 30.0 )//•Obesidad Más de 30.0, Tienes obesidad, ¡Cuídate!
            {
                var message = $"Tienes obesidad,  Cuidate";
                DisplayAlert("Notify", message, "Cancel");
            }
        }
    }
}