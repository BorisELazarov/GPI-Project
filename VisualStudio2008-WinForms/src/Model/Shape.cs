using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows;

namespace Draw
{
	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
	[Serializable]
	public class Shape
	{
        #region Constructors

        public Shape()
		{ }

        public Shape(RectangleF rect)
		{
			rectangle = rect;
            center = new PointF(
                rect.X + Width / 2,
                rect.Y + Height / 2
                );
        }

        public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;
			this.FillColor =  shape.FillColor;
			this.strokeColor = shape.strokeColor;
			this.isGradient = shape.isGradient;
			this.gradientFillColor = shape.gradientFillColor;
			this.fillColorOpacity = shape.fillColorOpacity;
			this.Angle = shape.angle;
			this.center = shape.center;
			this.lineThickness = shape.lineThickness;
		}

		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		protected RectangleF rectangle;		
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { 
				rectangle = value;
			}
		}
		
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width {
			get { return rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height {
			get { return rectangle.Height; }
			set { rectangle.Height = value; }
		}
		
		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location {
			get { return rectangle.Location; }
			set { 
				rectangle.Location = value;
				center = new PointF(
					rectangle.Location.X + rectangle.Width/2,
					rectangle.Location.Y + rectangle.Height/2
					);
			}
		}
		
		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		protected Color fillColor;		
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

		//Цвят на контура
		protected Color strokeColor;
        public virtual Color StrokeColor
        {
            get { return strokeColor; }
            set { strokeColor = value; }
        }

		/// <summary>
		/// Втори цвят на градиента
		/// </summary>
		protected Color gradientFillColor=Color.White;
		public virtual Color GradientFillColor
		{
			get { return gradientFillColor; }
			set { gradientFillColor = value; }
		}

		//Процент колкоо е пълна (обратното на прозрачно) формата
		protected int fillColorOpacity;
        public virtual int FillColorOpacity
        {
            get { return fillColorOpacity; }
            set { fillColorOpacity = value; }
        }

        //Градиента чрез който правим формата на градиент
        protected bool isGradient=false;
        public virtual bool IsGradient
        {
            get { return isGradient; }
            set { isGradient = value; }
        }

		//Матрицатa чрез която ще завъртаме формите
		protected float angle=0;
		public virtual float Angle
		{ 
		    get { return angle; }
			set { angle = value; }
		}

		//Центъра на завъртане
		protected PointF center;
		public virtual PointF Center
		{
			get { return center; }
			set { center = value; }
		}

		//Дебелина на контура
		protected float lineThickness;
		public virtual float LineThickness
		{
			get { return lineThickness; }
			set { lineThickness = value/15; }
		}

		#endregion

		protected PointF RotatedPoint(PointF point)
		{
            double cos = Math.Cos(-angle * (Math.PI / 180));
            double sin = Math.Sin(-angle * (Math.PI / 180));
            Vector rotationVector = new Vector(
                cos * (point.X - center.X)
                -
                sin * (point.Y - center.Y),
                sin * (point.X - center.X)
                +
                cos * (point.Y - center.Y)
                );
            rotationVector.X = rotationVector.X + center.X;
            rotationVector.Y = rotationVector.Y + center.Y;
            point.X = (float)rotationVector.X;
            point.Y = (float)rotationVector.Y;
			return point;
        }

		/// <summary>
		/// Проверка дали точка point принадлежи на елемента.
		/// </summary>
		/// <param name="point">Точка</param>
		/// <returns>Връща true, ако точката принадлежи на елемента и
		/// false, ако не пренадлежи</returns>
		public virtual bool Contains(PointF point)
		{
            return rectangle.Contains(RotatedPoint(point));
            
        }
		
		/// <summary>
		/// Визуализира елемента.
		/// </summary>
		/// <param name="grfx">Къде да бъде визуализиран елемента.</param>
		public virtual void DrawSelf(Graphics grfx)
		{
		}

        /// <summary>
        /// Изпълнява цъщата функция като DrawSelf метода с разлиакта, че
        /// завърта формата около центъра на групата и след това около самия си център
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="groupCenter"></param>
        /// <param name="groupAngle"></param>
        public virtual void DrawByGroup(Graphics grfx, PointF groupCenter, float groupAngle)
		{	
		}

		/// <summary>
		/// A method that resizes the current shape by
		/// multiplying it with the parameter
		/// </summary>
		/// <param name="size"></param>
        public virtual void ReSize(float size)
        {
            Width = size*Width;
            Height = size * Height;
			rectangle.Width = Width;
			rectangle.Height= Height;

        }
    }
}
