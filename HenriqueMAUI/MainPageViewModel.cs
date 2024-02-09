using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HenriqueMAUI.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HenriqueMAUI
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string volatilidadeTxt = "";

        [ObservableProperty]
        string retornoTxt = "";

        [ObservableProperty]
        string precoInicialTxt = "";

        [ObservableProperty]
        string tempoTxt = "";

        double volatilidade = 0;

        double retorno = 0;

        double precoInicial = 0;

        int tempo = 0;


        public void StartViewModel()
        {
        }

        [RelayCommand]
        private void SearchClicked()
        {
            CorrectInsertedValues(volatilidadeTxt, retornoTxt, precoInicialTxt, tempoTxt);

            var prices = GenerateBrownianMotion(volatilidade, retorno, precoInicial, tempo);

            GraphicsDrawable graphics = new GraphicsDrawable();
        }
        public static double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays)
        {
            Random rand = new();
            double[] prices = new double[numDays];
            prices[0] = initialPrice;

            for (int i = 1; i < numDays; i++)
            {
                double u1 = 1.0 - rand.NextDouble();
                double u2 = 1.0 - rand.NextDouble();
                double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                double retornoDiario = mean + sigma * z;

                prices[i] = prices[i - 1] * Math.Exp(retornoDiario);
            }

            return prices;
        }

        private void CorrectInsertedValues(string volatilidadeTxt, string retornoTxt, string precoInicialTxt, string tempoTxt)
        {
            volatilidade = double.Parse(volatilidadeTxt)/100;
            retorno = double.Parse(retornoTxt)/100;
            precoInicial = double.Parse(precoInicialTxt);
            tempo = int.Parse(tempoTxt);
        }
    }

}
