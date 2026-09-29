// See https://aka.ms/new-console-template for more information
using ConsoleApp9;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Point = ConsoleApp9.Point;



Bitmap bitmap = new Bitmap(400, 400);
IDrawable visualLine = new VisualLine(new Point(150, 150), new Point(350, 350));

IDrawable visualBezier = new VisualBezier(
    new Point(100, 350),
    new Point(150, 50),
    new Point(350, 50),
    new Point(350, 350));

Graphics g = Graphics.FromImage(bitmap);


g.Clear(Color.White);
visualBezier.Draw(g);
visualLine.Draw(g);
g.Dispose();
string path = Path.GetFullPath("result.png");
bitmap.Save(path, ImageFormat.Png);
bitmap.Dispose();
Console.WriteLine("Сохранено: " + path);
Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });