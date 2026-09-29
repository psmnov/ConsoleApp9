using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal interface IDrawable
    {
        public void Draw(Graphics g);
    }
    internal abstract class VisualCurve: ICurve, IDrawable
    {
        protected readonly ICurve curve;
        public VisualCurve(ICurve curve)
        {
            this.curve = curve;
        }
        public abstract void Draw(Graphics g);
        public IPoint GetPoint(double t, out IPoint point) {
            return curve.GetPoint(t, out point);
        }
       
    }
    internal class VisualLine : VisualCurve
    {
       
        public VisualLine(IPoint a, IPoint b) : base(new Line(a, b))
        {    
        }
        public override void Draw(Graphics g)
        {
            curve.GetPoint(0, out IPoint start);
            curve.GetPoint(1, out IPoint end);
            
            g.DrawLine(Pens.Black, (float)start.X, (float)start.Y, (float)end.X, (float)end.Y);
        }

    }
    internal class VisualBezier : VisualCurve
    {
       
        public VisualBezier(IPoint a, IPoint b, IPoint c, IPoint d) : base(new Bezier(a, b, c, d))
        {
            
        }
        public override void Draw(Graphics g)
        {
            curve.GetPoint(0, out IPoint a);
            curve.GetPoint(1, out IPoint b);
            curve.GetPoint(0.33, out IPoint c);
            curve.GetPoint(0.66, out IPoint d);

            g.DrawBezier(Pens.Black, (float)a.X, (float)a.Y, (float)c.X, (float)c.Y, (float)d.X, (float)d.Y, (float)b.X, (float)b.Y);
        }
       
    }
}
