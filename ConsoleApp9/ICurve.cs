using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal interface ICurve
    {
        IPoint GetPoint(double t, out IPoint point);
    }
    internal abstract class ACurve : ICurve
    {
        protected  IPoint a { get; }
        protected  IPoint b { get; }
        public ACurve(IPoint a, IPoint b)
        {
            this.a = a;
            this.b = b;
        }
        public abstract IPoint GetPoint(double t, out IPoint p);
       
    }
    internal class Line : ACurve
    {

        public Line(IPoint a, IPoint b) : base(a, b) { }
        public override IPoint GetPoint(double t, out IPoint p)
        {
            double y = (1-t)*a.Y + t*b.Y;
            double x = (1-t)*a.X + t*b.X;
            return p = new Point(x, y);
        }
    }
    internal class Bezier : ACurve
    {
        private readonly IPoint c;
        private readonly IPoint d;
        public Bezier(IPoint a, IPoint b, IPoint c, IPoint d): base(a, b)
        {
            this.c = c;
            this.d = d;
        }
        public override IPoint GetPoint(double t, out IPoint p)
        {
            double x = (1 - t)* (1 - t)* (1 - t)*a.X + 3*t*(1-t)*(1-t)*c.X + 3*t*t*(1-t)*d.X + t*t*t*b.X;
            double y = (1 - t)* (1 - t)* (1 - t)*a.Y + 3*t*(1-t)*(1-t)*c.Y + 3*t*t*(1-t)*d.Y + t*t*t*b.Y;
            return p = new Point(x, y);
        }
    }
}
