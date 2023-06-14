using OpenTK.Graphics.ES11;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace RadarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Radar launch...");
            
            using (Windows window = new Windows(500, 500, "Radar App"))
            {
                window.Load += delegate
                {
                    Console.WriteLine("Loaded app...");
                };

                window.RenderFrame += delegate(FrameEventArgs e)
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit);
                };

                window.UpdateFrame += delegate(FrameEventArgs e)
                {

                };


                window.Run();
            }
        }
    }
}