using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    [Serializable]
    public class StarShape:Shape
    {
        #region Constructor

        public StarShape(RectangleF rect) : base(rect)
        {
        }

        public StarShape(StarShape star) : base(star)
        {
        }

        #endregion

        /// <summary>
		/// Проверка за принадлежност на точка point към многоъгълника,
		/// като се спуска хоризонтална линия и се брои броя на пресичане.
		/// </summary>
		private PointF[] points = new PointF[10];
        public override bool Contains(PointF point)
        {
            point=RotatedPoint(point);
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
            points[0] = new PointF(Location.X + (Width / 2), Location.Y);
            points[2] = new PointF(Location.X, Location.Y + Height * 0.4f);
            points[4] = new PointF(Location.X + (Width / 4), Location.Y + Height);
            points[6] = new PointF(Location.X + Width * 0.80f, Location.Y + Height);
            points[8] = new PointF(Location.X + Width, Location.Y + (Height * 0.4f));

            PointF center = new PointF(
                (points[0].X + points[2].X + points[4].X + points[6].X + points[8].X)/5,
                (points[0].Y + points[2].Y + points[4].Y + points[6].Y + points[8].Y)/5
                );

            for (int i = 1; i < points.Length; i += 2)
            {
                points[i] = new PointF(
                    (points[(i - 1) % 10].X + points[(i + 1) % 10].X + 3*center.X) / 5,
                    (points[(i - 1) % 10].Y + points[(i + 1) % 10].Y + 3*center.Y) / 5
                    );
            }

            ///<summary>
            ///Запазва се състоянието на графиката и след това се трансформира чрез матрица в default състояние,
			///която сме създали и завъртяли около центъра на Rectangle-a на angle градуса по часовниковата стрелка
			///</summary>
            GraphicsState state = grfx.Save();
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle,center);
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
            points[0] = new PointF(Location.X + (Width / 2), Location.Y);
            points[2] = new PointF(Location.X, Location.Y + Height * 0.4f);
            points[4] = new PointF(Location.X + (Width / 4), Location.Y + Height);
            points[6] = new PointF(Location.X + Width * 0.80f, Location.Y + Height);
            points[8] = new PointF(Location.X + Width, Location.Y + (Height * 0.4f));

            PointF center = new PointF(
                (points[0].X + points[2].X + points[4].X + points[6].X + points[8].X) / 5,
                (points[0].Y + points[2].Y + points[4].Y + points[6].Y + points[8].Y) / 5
                );

            for (int i = 1; i < points.Length; i += 2)
            {
                points[i] = new PointF(
                    (points[(i - 1) % 10].X + points[(i + 1) % 10].X + 3 * center.X) / 5,
                    (points[(i - 1) % 10].Y + points[(i + 1) % 10].Y + 3 * center.Y) / 5
                    );
            }

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
