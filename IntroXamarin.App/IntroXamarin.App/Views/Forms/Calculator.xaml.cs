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
    public partial class Calculator : ContentPage
    {
        public Calculator()
        {
            InitializeComponent();
        }

        public double cifra = 0;
        public double numero1 = 0;
        public double numero2 = 0;
        public string operando;
        public int estado = 1;

        #region captura lo tecleado en numeros

        private void tecladoNumero(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string presionado = button.Text;

            if(this.labelNumeroFormula1.Text == "0" || estado < 0)
            {
                this.labelNumeroFormula1.Text = "";

                if (estado < 0)
                {
                    estado *= -1;
                }
            }

            this.labelNumeroFormula1.Text += presionado;

            double numero;
            if (double.TryParse(this.labelNumeroFormula1.Text, out numero))
            {
                if (estado == 1)
                {
                    numero1 = numero;
                }
                else
                {
                    numero2 = numero;
                }
            }
        }


        #endregion

        #region Captura la operacion tecleada
        public void operacion(object sender, EventArgs e)
        {
            estado = -2;
            Button button = (Button)sender;
            string presionado = button.Text;
            operando = presionado;
        }
        #endregion

        #region captura la tecla limpiar

        void limpiar(object sender, EventArgs e)
        {
            numero1 = 0;
            numero2 = 0;
            estado = 1;
            this.labelNumeroFormula1.Text = "0";
        }

        #endregion

        #region captura la tecla porcentaje

        void porcentaje(object sender, EventArgs e)
        {

            if ((estado == -1) || (estado == 1))
            {
                var resultado = numero1 / 100;
                this.labelNumeroFormula1.Text = resultado.ToString();
                numero1 = resultado;
                estado = -1;
            }
        }
        #endregion

        #region captura la tecla igual
        void igual(object sender, EventArgs e)
        {
            if (estado == 2)
            {
                var resultado = calculos(numero1, numero2, operando);

                this.labelNumeroFormula1.Text = resultado.ToString();
                numero1 = resultado;
                estado = -1;
            }
        }
        #endregion

        #region realiza los calculos

        double calculos(double num1, double num2, string operando)
        {
            double resultado = 0;
            switch (operando)
            {
                case "÷":
                    resultado = num1 / num2;
                    break;
                case "x":
                    resultado = num1 * num2;
                    break;
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "(²)":
                    resultado = Math.Pow(num1, num1);
                    break;
            }
            return resultado;

        }

        #endregion




    }
}