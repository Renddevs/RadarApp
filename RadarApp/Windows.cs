using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RadarApp
{
    internal class Windows : GameWindow
    {
        #region Initialize VBO & VAO variable
        private int _circle1BufferObject;
        private int _lineBufferObject;
        private int _circle2BufferObject;
        private int _circle3BufferObject;
        private int _target1BufferObject;
        private int _circle1ArrayObject;
        private int _lineArrayObject;
        private int _circle2ArrayObject;
        private int _circle3ArrayObject;
        private int _target1ArrayObject;
        #endregion

        public List<float> _circle1Vertice = new List<float>();

        public List<float> _circle2Vertice = new List<float>();

        public List<float> _circle3Vertice = new List<float>();

        public List<float> _target1Vertice = new List<float>();

        public Windows(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnLoad()
        {
            base.OnLoad();

            _circle1Vertice = CircleVertices(0, 0, 1);
            _circle2Vertice = CircleVertices(0, 0, 1.4f);
            _circle3Vertice = CircleVertices(0, 0, 2.2f);
            _target1Vertice = CircleVertices(20.6f, 35.5f, 55);

            List<float> _lineVertices = new List<float>();

            #region line x & y
            //horizontal lines
            _lineVertices.AddRange(new List<float>() {
                -1f, 0.0f, 0.0f,
                1f,  0.0f, 0.0f
            });
            //vertikal lines
            _lineVertices.AddRange(new List<float>() {
                0.0f, -1f, 0.0f,
                0.0f,  1f, 0.0f
            });
            #endregion


            #region Create Buffer Object
            _circle1BufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _circle1BufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _circle1Vertice.Count * sizeof(float), _circle1Vertice.ToArray(), BufferUsageHint.StaticDraw);
            _circle1ArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_circle1ArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            _lineBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _lineBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _lineVertices.Count * sizeof(float), _lineVertices.ToArray(), BufferUsageHint.StaticDraw);
            _lineArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_lineArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            _circle2BufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _circle2BufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _circle2Vertice.Count * sizeof(float), _circle2Vertice.ToArray(), BufferUsageHint.StaticDraw);
            _circle2ArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_circle2ArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            _circle3BufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _circle3BufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _circle3Vertice.Count * sizeof(float), _circle3Vertice.ToArray(), BufferUsageHint.StaticDraw);
            _circle3ArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_circle3ArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            _target1BufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _target1BufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _target1Vertice.Count * sizeof(float), _target1Vertice.ToArray(), BufferUsageHint.StaticDraw);
            _target1ArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_target1ArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(0);

            #endregion
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.BindVertexArray(_circle1ArrayObject);
            GL.DrawArrays(PrimitiveType.Points, 0, _circle1Vertice.Count);

            GL.BindVertexArray(_lineArrayObject);
            GL.DrawArrays(PrimitiveType.Lines, 0, 2);
            GL.DrawArrays(PrimitiveType.Lines, 2, 2);

            GL.BindVertexArray(_circle2ArrayObject);
            GL.DrawArrays(PrimitiveType.Points, 0, _circle2Vertice.Count);

            GL.BindVertexArray(_circle3ArrayObject);
            GL.DrawArrays(PrimitiveType.Points, 0, _circle3Vertice.Count);

            GL.BindVertexArray(_target1ArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, _target1Vertice.Count);

            SwapBuffers();
        }


        public List<float> CircleVertices(float position_x, float position_y, float sizeConf)
        {
            List<float> _circleVertices = new List<float>();
            float x = position_x;
            float y = position_y;

            for (int i = 0; i < 360; i++)
            {
                _circleVertices.Add((float)(x + Math.Cos(i))/sizeConf);
                _circleVertices.Add((float)(y + Math.Sin(i))/sizeConf);
                _circleVertices.Add(0);
            }

            return _circleVertices;
        }
    
    }
}
