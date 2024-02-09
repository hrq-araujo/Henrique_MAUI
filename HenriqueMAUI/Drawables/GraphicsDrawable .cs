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
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Drawing code goes here
            canvas.StrokeColor = Color.FromArgb("#FF7B68EE");
            canvas.DrawRectangle(0,0,200,100);


            PathF path = new PathF();
            path.MoveTo(0, 500);
            path.LineTo(10, 430);

            canvas.DrawPath(path);

            //left -> right, top -> bottom
            //canvas.DrawLine(0,500,10,430);

            //DrawNewLine(canvas, 10, 430);
        }

        public void DrawNewLine(ICanvas canvas, float xOrigin, float yOrigin)
        {

            canvas.DrawLine(xOrigin, yOrigin, 20, 350);
        }
    }
}
