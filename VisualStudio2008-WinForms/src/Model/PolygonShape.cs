using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class PolygonShape : Shape
	{
		#region Constructor
		
		public PolygonShape(RectangleF rect) : base(rect)
		{
		}
		
		public PolygonShape(PolygonShape polygon) : base(polygon)
		{
            this.points=new PointF[polygon.points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = polygon.points[i];
            }
		}

        #endregion

        #region Properties
        private PointF[] points;
        public PointF[] Points
        {
            get { return points; }
            set { points = value; }
        }
        public override PointF Location 
        { 
            get => base.Location;
            set 
            {
                if (points!=null)
                for (int i = 0; i < points.Length; i++)
                {
                    points[i].X += value.X-Location.X;
                    points[i].Y += value.Y - Location.Y;
                }
                base.Location = value;
            }
        }
        #endregion


        ///<summary>
        ///Overriding the resize method
        ///</summary>
        public override void ReSize(float size)
        {
            base.ReSize(size);
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = (points[i].X-Location.X) * size+Location.X;
                points[i].Y = (points[i].Y - Location.Y) * size + Location.Y;
            }
        }

        /// <summary>
        /// Проверка за принадлежност на точка point към многоъгълника,
        /// като се спуска хоризонтална линия и се брои броя на пресичане.
        /// </summary>
        public override bool Contains(PointF point)
        {
            point = RotatedPoint(point);
            int intersecCount = 0;
            for (int i = 0; i < points.Length; i++)
            {
                int next = (i + 1) % points.Length;
                if (
                     (
                       (points[i].Y <= point.Y && point.Y < points[next].Y)
                       ||
                       (points[next].Y <= point.Y && point.Y < points[i].Y)
                     )
                     &&
                     (
                       point.X < (points[next].X - points[i].X) * (point.Y - points[i].Y)
                       /
                       (points[next].Y - points[i].Y) + points[i].X
                     )
                    )
                {
                    intersecCount++;
                }
            }
            return intersecCount % 2 == 1;
        }
		
		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
            ///<summary>
            ///Запазва се състоянието на графиката и след това се трансформира чрез матрица в default състояние,
			///която сме създали и завъртяли около центъра на Rectangle-a на angle градуса по часовниковата стрелка
			///</summary>
            GraphicsState state = grfx.Save();
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, center);
            grfx.Transform = matrix;

            ///<summary>
			///Задава се нормалния цвят, цвета на градиента
			///и прозрачността на формата и след това се
			///проверява дали своеството isGradient e вярно
            ///и ако е формата се боядисва в градиента чрез LinearGradientBrush
			///</summary>
            Color color = Color.FromArgb(255 * FillColorOpacity / 100, FillColor);

            if (IsGradient)
            {
                Color gradient = Color.FromArgb(255 * FillColorOpacity / 100, GradientFillColor);
                grfx.FillPolygon(new LinearGradientBrush(Rectangle, color, gradient, 45), points);
            }
            else
				grfx.FillPolygon(new SolidBrush(color), points);

            grfx.DrawPolygon(new Pen(StrokeColor, lineThickness), points);

            //Възстановява се състоянието на графиката чрез запазеното сътояние state
            grfx.Restore(state);
        }

        /// <summary>
        /// Изпълнява цъщата функция като DrawSelf метода с разлиакта, че
        /// завърта формата около центъра на групата и след това около самия си център
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="groupCenter"></param>
        /// <param name="groupAngle"></param>
        public override void DrawByGroup(Graphics grfx,
            PointF groupCenter, float groupAngle)
        {
            ///<summary>
            ///Запазва се състоянието на графиката и след това се трансформира чрез матрица в default състояние,
			///която сме създали и завъртяли около центъра на Rectangle-a на angle градуса по часовниковата стрелка
			///</summary>
            GraphicsState state = grfx.Save();
            Matrix matrix = new Matrix();
            matrix.RotateAt(groupAngle, groupCenter);
            matrix.RotateAt(angle, center);
            grfx.Transform = matrix;

            ///<summary>
			///Задава се нормалния цвят, цвета на градиента
			///и прозрачността на формата и след това се
			///проверява дали своеството isGradient e вярно
            ///и ако е формата се боядисва в градиента чрез LinearGradientBrush
			///</summary>
            Color color = Color.FromArgb(255 * FillColorOpacity / 100, FillColor);

            if (IsGradient)
            {
                Color gradient = Color.FromArgb(255 * FillColorOpacity / 100, GradientFillColor);
                grfx.FillPolygon(new LinearGradientBrush(Rectangle, color, gradient, 45), points);
            }
            else
                grfx.FillPolygon(new SolidBrush(color), points);

            grfx.DrawPolygon(new Pen(StrokeColor, lineThickness), points);

            //Възстановява се състоянието на графиката чрез запазеното сътояние state
            grfx.Restore(state);
        }
    }
}
