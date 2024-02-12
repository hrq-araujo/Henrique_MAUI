using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HenriqueMAUI.Drawables;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace HenriqueMAUI
{
    public partial class MainPageViewModel : ObservableObject
    {
        public GraphicsView _drawableGraphic;

        [ObservableProperty]
        string precoInicialTxt = "";

        [ObservableProperty]
        string tempoTxt = "";

        [ObservableProperty]
        public float volatilidadeValue = 0;

        [ObservableProperty]
        public float retornoValue = 0;

        [ObservableProperty]
        private string buttonTxt = "Gerar simulação";

        [ObservableProperty]
        public bool isButtonEnabled = true;

        double volatilidade = 0;

        double retorno = 0;

        double precoInicial = 0;

        int tempo = 0;

        [ObservableProperty]
        public float biggestPriceFound;

        [ObservableProperty]
        public float smallestPriceFound;

        [ObservableProperty]
        public bool isPriceInfoVisible = false;

        [RelayCommand]
        private void SimulationClicked()
        {
            LocksSimulationButton();

            bool isDataCorrect = CorrectInsertedValues(volatilidadeValue, retornoValue, precoInicialTxt, tempoTxt);

            if (isDataCorrect)
            {
                var prices = GenerateBrownianMotion(volatilidade, retorno, precoInicial, tempo);

                BiggestPriceFound = GeneralHelper.CheckBiggestPrice(prices);
                SmallestPriceFound = GeneralHelper.CheckSmallestPrice(prices);
                IsPriceInfoVisible = true;

                GenerateGraphic(prices, tempo);
            }
            UnlocksSimulationButton();
        }

        #region BUTTON CONTROL
        private void UnlocksSimulationButton()
        {
            ButtonTxt = "Gerar outra simulação";
            IsButtonEnabled = true;
        }

        private void LocksSimulationButton()
        {
            ButtonTxt = "Carregando...";
            IsButtonEnabled = false;
        }
        #endregion

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



        private bool CorrectInsertedValues(float volatilidadeValue, float retornoValue, string precoInicialTxt, string tempoTxt)
        {
            if(GeneralHelper.HasSpecialChars(precoInicialTxt) || GeneralHelper.HasSpecialChars(tempoTxt))
            {
                GeneralHelper.InvalidInputAlert();
                return false;
            }

            if(!GeneralHelper.IsDigitsOnly(precoInicialTxt) || !GeneralHelper.IsDigitsOnly(tempoTxt))
            {
                GeneralHelper.InvalidInputAlert();
                return false;
            }

            if (GeneralHelper.isEntryAZero(precoInicialTxt) || GeneralHelper.isEntryAZero(tempoTxt))
            {
                GeneralHelper.InputIsZeroAlert();
                return false;
            }

            volatilidade = volatilidadeValue / 100;
            retorno = retornoValue / 100;
            precoInicial = double.Parse(precoInicialTxt);
            tempo = int.Parse(tempoTxt);
            return true;
        }

        private void GenerateGraphic(double[] prices, int tempo)
        {
            GraphicsDrawable graphics = new GraphicsDrawable();

            graphics.prices = prices;
            graphics.tempo = tempo;


            _drawableGraphic.Drawable = graphics;
            _drawableGraphic.Invalidate();
        }
    }

}
