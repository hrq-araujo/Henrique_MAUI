using Microsoft.UI.Composition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriqueMAUI.Drawables
{
    public class GraphicsDrawable : IDrawable
    {
        public double xOrigin = 0;
        public double yOrigin = 0;
        public double xDestination = 0;
        public double yDestination = 0;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Color.FromArgb("#FF7B68EE");


            PathF path = new PathF();
            path.MoveTo(0, 500);
            path.LineTo(10, 430);
            Console.WriteLine(xDestination);

            canvas.DrawPath(path);

            //left -> right, top -> bottom
            //canvas.DrawLine(0,500,10,430);

            //DrawNewLine(canvas, 10, 430);

            //500 por 500.
        }

        public void DrawNewLine(ICanvas canvas, float xOrigin, float yOrigin)
        {
            
            canvas.DrawLine(xOrigin, yOrigin, 500, 350);
        }
    }
}
