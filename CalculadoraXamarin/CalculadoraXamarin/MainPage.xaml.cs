using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraXamarin
{
    public partial class MainPage : ContentPage
    {
        int estadoActual = 1;
        string mioperador;
        double primernumero, segundonumero;
        public MainPage()
        {
            InitializeComponent();
            Limpiar(this, null);
        }

        void NumeroSeleccionado(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            
            if(this.resulText.Text=="0"|| estadoActual < 0)
            {
                this.resulText.Text = ""; // aquí el cero que se muestra en la pantalla de la calculadora se eliminará (saldrá 5 en vez de 05)
                
                if(estadoActual < 0)
                {
                    estadoActual *= -1; // si el estado actual es menor de 0 se multiplica por -1 para hacerlo positivo
                }
            }
            this.resulText.Text += pressed;
            double number; 
            if(double.TryParse(this.resulText.Text, out number))
            {
               // this.resulText.Text = number.ToString("No");
                if(estadoActual == 1)
                {
                    primernumero = number; // el "estado actual" al principio será 1 por lo que se le asignará el primer numero introducido a la variable firstNumber
                }
                else
                {
                    segundonumero = number;
                }
            }


        }
        void OperadorSeleccionado(Object sender, EventArgs e)
        {
            estadoActual = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mioperador = pressed;
        }
        void Limpiar(object sender, EventArgs e)
        {
            primernumero = 0;
            segundonumero = 0;
            estadoActual = 1;
            this.resulText.Text = "0";
        }
        void PorcentajeSeleccionado(object sender,EventArgs e)
        {
            if((estadoActual == -1) || (estadoActual == 1))
            {
                var result = primernumero / 100;
                this.resulText.Text = result.ToString();
                primernumero = result;
                estadoActual = -1;

            }
        }
        void Calcular(object sender, EventArgs e)
        {
            if (estadoActual == 2)
            {
                var result = AyudaCalcular(primernumero, segundonumero, mioperador);
                this.resulText.Text = result.ToString();
                primernumero = result;
                estadoActual = -1;

            }
        }
        double AyudaCalcular(double valor1, double valor2 , string mioperador)
        {
            double result = 0;
            switch (mioperador)
            {
                case "+":
                    result = valor1 + valor2;
                    break;
                case "x":
                    result = valor1 * valor2;
                    break;
                case "/":
                    result = valor1 / valor2;
                    break;
                case "-":
                    result = valor1 - valor2;
                    break;
            }
            return result;
        }
        private void RaizSeleccionado(object sender, EventArgs e) // solo podemos llamar a este metodo cuando tengamos un numero incial o un resultado
        {
            if ((estadoActual == 1) || (estadoActual == -1))
            {
                var result = Math.Sqrt(primernumero);
                this.resulText.Text = result.ToString();
                primernumero = result;
                estadoActual = -1;
            }
        }
    }
}
