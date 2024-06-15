using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace Draw
{
    [Serializable]
    public class ElipseShape : Shape
	{
		#region Constructor
		
		public ElipseShape(RectangleF rect) : base(rect)
		{
		}

		public ElipseShape(ElipseShape elipse) : base(elipse)
		{
		}

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към елипсата.
        /// В случая на елипсата този метод може да не бъде пренаписван, защото
        /// Порерява се по теоремата за дали една точка е в елипса:
        /// ((X-Xc)^2)/(a^2) - ((Y-Yc)^2)/(b^2) <=1 където Х и Yc са координатите
		/// на точката за която проверяваме дали е в елипсата, Хс и Yc са
		/// координатите на центъра на елипсата и а и b са съответно половината на
		/// широчината и дължината на елипсата
        /// </summary>
        public override bool Contains(PointF point)
		{
            point=RotatedPoint(point);
			return (Math.Pow(point.X - center.X, 2)/Math.Pow(Width / 2, 2))
				+
				(Math.Pow(point.Y - center.Y, 2)/Math.Pow(Height / 2, 2))
				<= 1 ;
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
			grfx.Transform=matrix;

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
                grfx.FillEllipse(new LinearGradientBrush(Rectangle, color, gradient, 45),
                    Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
            else
            grfx.FillEllipse(new SolidBrush(color), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            grfx.DrawEllipse(new Pen(StrokeColor, lineThickness), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

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
                grfx.FillEllipse(new LinearGradientBrush(Rectangle, color, gradient, 45),
                    Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
            else
                grfx.FillEllipse(new SolidBrush(color), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            grfx.DrawEllipse(new Pen(StrokeColor, lineThickness), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            //Възстановява се състоянието на графиката чрез запазеното сътояние state
            grfx.Restore(state);
        }
    }

}
