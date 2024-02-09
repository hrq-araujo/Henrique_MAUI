﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        string volatilidade = "";

        [ObservableProperty]
        string retorno = "";

        [ObservableProperty]
        string precoInicial = "";

        [ObservableProperty]
        string tempo = "";

        public void StartViewModel()
        {
        }

        [RelayCommand]
        private void SearchClicked()
        {
            Console.WriteLine("preco inicial:" + precoInicial);
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
    }

}
