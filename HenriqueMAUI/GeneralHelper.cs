﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueMAUI
{
    public static class GeneralHelper
    {
        public static bool HasSpecialChars(string str)
        {
            return str.Any(ch => !char.IsLetterOrDigit(ch));
        }

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static bool isEntryAZero(string str)
        {
            if (int.Parse(str) == 0)
                return true;

            return false;
        }

        public static async Task InvalidInputAlert()
        {
            await Shell.Current.CurrentPage.DisplayAlert(
                "Erro",
                "Você inseriu algum caractere inválido. Lembre-se que as entradas só aceitam números.",
                "OK");
        }

        public static async Task InputIsZeroAlert()
        {
            await Shell.Current.CurrentPage.DisplayAlert(
                "Erro",
                "Os campos 'Preço Inicial' e 'Tempo' não podem ser iguais a zero.",
                "OK");
        }

        public static float CheckBiggestPrice(double[] prices)
        {
            double biggestPrice = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] > biggestPrice)
                    biggestPrice = prices[i];
            }

            return float.Parse(biggestPrice.ToString("0.00"));
        }

        public static float CheckSmallestPrice(double[] prices)
        {
            double smallestPrice = 10000000;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < smallestPrice)
                    smallestPrice = prices[i];
            }

            return float.Parse(smallestPrice.ToString("0.00"));
        }
    }
}

