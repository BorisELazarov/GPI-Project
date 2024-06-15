using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    [Serializable]
    public class RectangleShape : Shape
	{
		#region Constructor
		
		public RectangleShape(RectangleF rect) : base(rect)
		{
		}
		
		public RectangleShape(RectangleShape rectangle) : base(rectangle)
		{
		}
		
		#endregion

		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
            // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
            // В случая на правоъгълник - директно връщаме true
            //return base.Contains(point);
			return base.Contains(point);
		}

        //public override bool Intersects(PointF point)
        //{
        //    return base.Intersects(point);
        //}

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

            ///<summary>
            ///Запазва се състоянието на графиката и след това се трансформира чрез матрица в default състояние,
			///която сме създали и завъртяли около центъра на Rectangle-a на angle градуса по часовниковата стрелка
			///</summary>
            GraphicsState state = grfx.Save();
            Matrix matrix = new Matrix();
            matrix.RotateAt(Angle,center);
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
                grfx.FillRectangle(new LinearGradientBrush(Rectangle, color, gradient, 45),
					Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
			}
			else
				grfx.FillRectangle(new SolidBrush(color), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            grfx.DrawRectangle(new Pen(strokeColor,lineThickness), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
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
            base.DrawSelf(grfx);

            ///<summary>
            ///Запазва се състоянието на графиката и след това се трансформира чрез матрица в default състояние,
			///която сме създали и завъртяли около центъра на Rectangle-a на angle градуса по часовниковата стрелка
			///</summary>
            GraphicsState state = grfx.Save();
            Matrix matrix = new Matrix();
            matrix.RotateAt(groupAngle,groupCenter);
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
                grfx.FillRectangle(new LinearGradientBrush(Rectangle, color, gradient, 45),
                    Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
            else
                grfx.FillRectangle(new SolidBrush(color), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            grfx.DrawRectangle(new Pen(strokeColor, lineThickness), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            //Възстановява се състоянието на графиката чрез запазеното сътояние state
            grfx.Restore(state);
        }
    }
}
