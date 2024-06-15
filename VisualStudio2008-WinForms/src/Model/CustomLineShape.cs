using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    [Serializable]
    public class CustomLineShape:Shape
    {
        #region Constructor

        public CustomLineShape(PointF end1, PointF end2)
        {
            this.end1 = end1;
            this.end2 = end2;
            Location= new PointF(
                Math.Min(end1.X, end2.X),
                Math.Min(end1.Y, end2.Y)
                );
            Width =Math.Max(end1.X, end2.X) - Location.X;
            Height=Math.Max(end1.Y, end2.Y) - Location.Y;
        }

        #endregion

        //Единия край на линията
        private PointF end1;
        public PointF End1
        {
            get { return end1; }
            set { end1 = value; }
        }

        //Другия край на линията
        private PointF end2;
        public PointF End2
        {
            get { return end2; }
            set { end2 = value; }
        }

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
            return base.Contains(point);
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
            matrix.RotateAt(angle,center);
            grfx.Transform = matrix;

            grfx.DrawLine(new Pen(StrokeColor, lineThickness), end1.X,end1.Y,end2.X,end2.Y);

            //Възстановява се състоянието на графиката чрез запазеното сътояние state
            grfx.Restore(state);
        }
    }
}
