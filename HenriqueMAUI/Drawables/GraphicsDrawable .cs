using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueMAUI.Drawables
{
    public class GraphicsDrawable : IDrawable
    {
        public double[] prices;
        public int tempo;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Color.FromArgb("#FF7B68EE");

            PathF path = new PathF();

            if(prices != null && prices.Length > 0)
            {
                float biggestPriceForScale = float.Parse(CheckBiggestPrice(prices).ToString("0.0000"));

                float pixelsToSkipOnX = 500 / (float)tempo;
                float xDestination = 0;
                float yDestination = 0;

                for(int i = 0; i < prices.Length; i++)
                {
                    if(i == 0)
                    {
                        yDestination = GetGraphicHeight(biggestPriceForScale, prices[i]);
                        xDestination =  pixelsToSkipOnX;

                        path.MoveTo(0, 500);
                        path.LineTo(xDestination, yDestination);
                    }
                    else
                    {
                        yDestination = GetGraphicHeight(biggestPriceForScale, prices[i]);
                        xDestination = xDestination + pixelsToSkipOnX;

                        path.LineTo(xDestination, yDestination);
                    }
                    
                }
            }
            canvas.DrawPath(path);
        }

        private float GetGraphicHeight(float biggestPriceForScale, double iterationPrice)
        {
            float price = float.Parse(iterationPrice.ToString("0.0000"));

            if (biggestPriceForScale == price)
                Console.WriteLine("aqui");

            double result = (iterationPrice * 500) / biggestPriceForScale;

            float height = float.Parse(result.ToString("0.0000"));
            Console.WriteLine(500 - height);

            return 500-height;
        }

        private double CheckBiggestPrice(double[] prices)
        {
            double biggestPrice = 0;
            for (int i = 0;i < prices.Length;i++)
            {
                if (prices[i] > biggestPrice)
                    biggestPrice = prices[i];
            }
            return biggestPrice;
        }
    }
}
