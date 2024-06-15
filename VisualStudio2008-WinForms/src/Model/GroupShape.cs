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
    public class GroupShape: Shape
    {
        #region Constructor

        public GroupShape(RectangleF rect) : base(rect)
        {
        }

        public GroupShape(GroupShape groupShape) : base(groupShape)
        {
            foreach (Shape shape in groupShape.subShapes)
            {
                Shape copy = new Shape();
                if (shape is RectangleShape)
                    copy = new RectangleShape((RectangleShape)shape);
                if (shape is ElipseShape)
                    copy = new ElipseShape((ElipseShape)shape);
                if (shape is LineShape)
                    copy = new LineShape((LineShape)shape);
                if (shape is StarShape)
                    copy = new StarShape((StarShape)shape);
                if (shape is HexagonShape)
                    copy = new HexagonShape((HexagonShape)shape);
                if (shape is PolygonShape)
                {
                    copy = new PolygonShape((PolygonShape)shape);
                }
                if (shape is BrezierShape)
                    copy = new BrezierShape((BrezierShape)shape);
                if (shape is GroupShape)
                    copy = new GroupShape((GroupShape)shape);
                subShapes.Add(copy);
            }
        }

        #endregion

        #region Properties
        private List<Shape> subShapes=new List<Shape>();
        public List<Shape> SubShapes
        {
            get { return subShapes; }
            set { subShapes = value; }
        }
        public override PointF Location 
        { 
            get => base.Location;
            set {
                
                foreach (Shape shape in subShapes)
                {
                    shape.Location = new PointF(
                        shape.Location.X + value.X - Location.X,
                        shape.Location.Y + value.Y - Location.Y
                        );
                }
                base.Location =new PointF(value.X,value.Y);
                Center=new PointF(
                    value.X+Width/2,
                    value.Y+Height/2
                    );
            }
        }
        /// <summary>
		/// Цвят на елемента.
		/// </summary>
        public override Color FillColor
        {
            get => base.fillColor;
            set
            {
                fillColor = value;
                foreach (Shape shape in subShapes)
                {
                    shape.FillColor = this.fillColor;
                }
            }
        }

        //Цвят на контура
        public override Color StrokeColor
        {
            get => base.strokeColor;
            set
            {
                strokeColor = value;
                foreach (Shape shape in subShapes)
                {
                    shape.StrokeColor = this.strokeColor;
                }
            }
        }

        /// <summary>
        /// Втори цвят на градиента
        /// </summary>
        public override Color GradientFillColor
        {
            get => base.gradientFillColor; 
            set
            {
                gradientFillColor = value;
                foreach (Shape shape in subShapes)
                {
                    shape.GradientFillColor = this.gradientFillColor;
                }
            }
        }

        //Процент колкоо е пълна (обратното на прозрачно) формата
        public override int FillColorOpacity
        {
            get => base.fillColorOpacity;
            set
            {
                fillColorOpacity = value;
                foreach (Shape shape in subShapes)
                {
                    shape.FillColorOpacity = this.fillColorOpacity;
                }
            }
        }

        //Градиента чрез който правим формата на градиент
        public override bool IsGradient
        {
            get => base.isGradient;
            set
            {
                isGradient = value;
                foreach (Shape shape in subShapes)
                {
                    shape.IsGradient = this.isGradient;
                }
            }
        }

        //Дебелина на контура
        public override float LineThickness
        {
            get => base.lineThickness;
            set { 
                lineThickness = value / 15;
                foreach (Shape shape in subShapes)
                {
                    shape.LineThickness = value;
                }
            }
        }
        #endregion

        public override void ReSize(float size)
        {
            base.ReSize(size);
            foreach (Shape shape in subShapes)
            {
                shape.ReSize(size);
            }
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
            if (rectangle.Contains(point))
            foreach (Shape shape in subShapes)
            {
                if(shape.Contains(point)) return true;
            }
            return false;
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            ///<summary>
			///Всяка форма от листа subShapes се рисува
			///</summary>
            foreach (Shape shape in subShapes)
            {
                shape.DrawByGroup(grfx, center, angle);
            }
        }
        public override void DrawByGroup(Graphics grfx, PointF groupCenter, float groupAngle)
        {
            foreach (Shape shape in subShapes)
            {
                shape.DrawByGroup(grfx, groupCenter, groupAngle);
            }
        }
    }
}
