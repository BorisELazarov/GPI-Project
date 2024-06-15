using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using Draw;
using Draw.src.Model;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
		}

        #endregion

        #region Properties

        ///<summary>
        /// 
        /// </summary>
        private GroupShape copyBin;
        public GroupShape CopyBin {
            get { return copyBin; }
            set {  copyBin = value; }
        }
		
		/// <summary>
		/// Избран елемент.
		/// </summary>
		private List<Shape> selection=new List<Shape>();
		public List<Shape> Selection {
			get { return selection; }
			set { selection = value; }
		}
		
		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}

		/// <summary>
		/// Дали в момента се чертае полигон
		/// </summary>
		private bool isCustomPolygon=false;
		public bool IsCustomPolygon {
			get { return isCustomPolygon; }
			set { isCustomPolygon = value; }
		}

		/// <summary>
		/// Лист с точките с които ще чертаем полигона
		/// </summary>
		private List<PointF> polygonPoints= new List<PointF>();
		public List<PointF> PolygonPoints {
			get { return polygonPoints; } 
			set { polygonPoints = value; }
		}
		
		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}
		
		private Shape storedPrimitive;
		public Shape StoredPrimitive
		{
		get { return storedPrimitive; }
		set { storedPrimitive = value; }
		}
		#endregion
		
		/// <summary>
		/// място върху клиентската област.
		/// </summary>
		public void AddRandomRectangle(int opacity, int degrees, int lineThickness)
		{
			Random rnd = new Random();
			int x = rnd.Next(0,1000);
			int y = rnd.Next(100,600);
			
			RectangleShape rect = new RectangleShape(new RectangleF(x,y,100,200));
			rect.FillColor = Color.White;
			rect.StrokeColor = Color.Black;
			rect.FillColorOpacity= opacity;
			rect.Angle=degrees;
            rect.LineThickness=lineThickness;

            ShapeList.Add(rect);
		}

        //Добавя произволна елипса
        public void AddRandomElipse(int opacity, int degrees, float lineThickness)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            ElipseShape elipse = new ElipseShape(new RectangleF(x, y, 100, 200));
            elipse.FillColor = Color.Gray;
            elipse.StrokeColor = Color.Black;
			elipse.FillColorOpacity= opacity;
            elipse.Angle = degrees;
            elipse.LineThickness = lineThickness;

            ShapeList.Add(elipse);
        }

        //Добавяне на произволна линия
        public void AddRandomLine(int degrees, float lineThickness)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            LineShape line = new LineShape(new RectangleF(x, y, 100, 200));
            line.FillColor = Color.Gray;
            line.StrokeColor = Color.Black;
            line.Angle = degrees;
            line.LineThickness= lineThickness;

            ShapeList.Add(line);
        }

        //Добавя произволна крива на брезиер
        public void AddRandomBrezier(int degrees, int lineThickness)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            BrezierShape brez = new BrezierShape(new RectangleF(x, y, 100, 200));
            brez.FillColor = Color.Gray;
            brez.StrokeColor = Color.Black;
            brez.Angle = degrees;
            brez.LineThickness=lineThickness;

            ShapeList.Add(brez);
        }

        //Добавя произволен хексагон
        public void AddRandomHexagon(int opacity, int degrees, float lineThickness)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            HexagonShape hexagon = new HexagonShape(new RectangleF(x, y, 150, 150));
            hexagon.FillColor = Color.Gray;
            hexagon.StrokeColor = Color.Black;
            hexagon.FillColorOpacity = opacity;
            hexagon.Angle = degrees;
            hexagon.LineThickness = lineThickness;

            ShapeList.Add(hexagon);
        }

        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
		{
			for(int i = ShapeList.Count - 1; i >= 0; i--)
			{
				if (ShapeList[i].Contains(point))
				{
					return ShapeList[i];
				}
			}
			return null;

		}

        /// <summary>
        /// Проверява се дали една точка се състои в някоя фигура от selection листа
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Дали точката се съдържа в някоя от избраните фигури</returns>
        public bool SelectContainsPoint(PointF point)
        {
            for (int i = selection.Count - 1; i >= 0; i--)
            {
                if (selection[i].Contains(point))
                {
                    ///ShapeList[i].FillColor = Color.Red;

                    return true;
                }
            }
            return false;
        }


		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			if (Selection.Count > 0) {
				foreach (Shape shape in Selection)
				{
                    shape.Location = new PointF
                        (shape.Location.X + p.X - lastLocation.X,
                        shape.Location.Y + p.Y - lastLocation.Y);
                }
					lastLocation = p;
            }
		}

        public void AddRandomStar(int opacity, float degrees, float lineThickness)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            StarShape star = new StarShape(new RectangleF(x, y, 175, 175));
            star.FillColor = Color.Gray;
            star.StrokeColor = Color.Black;
            star.FillColorOpacity = opacity;
            star.Angle = degrees;
            star.LineThickness= lineThickness;

            ShapeList.Add(star);
        }

        public void AddCustomPolygon(int opacity, float degrees, float lineThickness)
        {
            PointF[] points = new PointF[polygonPoints.Count];
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                points[i] = polygonPoints[i];
            }

            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            for (int i=0; i<points.Length; i++)
			{
				if (minX > points[i].X)
					minX =Convert.ToInt32(points[i].X);
                if (minY > points[i].Y)
                    minY = Convert.ToInt32(points[i].Y);
                if (maxX < points[i].X)
                    maxX = Convert.ToInt32(points[i].X);
                if (maxY < points[i].Y)
                    maxY = Convert.ToInt32(points[i].Y);
            }
			
			PolygonShape polygon = new PolygonShape(new RectangleF(minX, minY, maxX - minX, maxY - minY));
            polygon.Points= points;
			List<CustomLineShape> drawingLines=new List<CustomLineShape>();
			foreach (CustomLineShape line in ShapeList.Where(x=> x is CustomLineShape))
			{
				if (polygonPoints.Contains(line.End1) && polygonPoints.Contains(line.End2))
				{
					drawingLines.Add(line);
				}
			}
			ShapeList.RemoveAll(x => drawingLines.Contains(x));
			polygonPoints.Clear();
			polygon.FillColor = Color.White;
			polygon.StrokeColor= Color.Black;
			polygon.FillColorOpacity = opacity;
			polygon.Angle= degrees;
            polygon.LineThickness= lineThickness;

			ShapeList.Add(polygon);
        }

        public void DrawCustomLine(float lineThickness)
        {
			CustomLineShape line = new CustomLineShape(
				polygonPoints[polygonPoints.Count()-2],
				polygonPoints.Last()
				);

            line.StrokeColor = Color.Black;
            line.Angle = 0;
            line.LineThickness= lineThickness;

			ShapeList.Add(line);
        }

        public void GroupSelection()
        {
            if (Selection.Count < 2) return;
            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;
            foreach (Shape shape in selection)
            {
                if (shape.Location.X < minX)
                    minX = shape.Location.X;
                if (shape.Location.Y < minY)
                    minY = shape.Location.Y;
                if (shape.Location.X + shape.Width > maxX)
                    maxX = shape.Location.X + shape.Width;
                if (shape.Location.Y + shape.Height > maxY)
                    maxY = shape.Location.Y + shape.Height;
            }
            RectangleF rect = new RectangleF(minX, minY, maxX - minX, maxY - minY);
            GroupShape group = new GroupShape(rect);
            group.StrokeColor = Color.Black;
            group.FillColor = Color.White;
            group.FillColorOpacity = 100;

            foreach (Shape shape in ShapeList)
            {
                if (selection.Contains(shape))
                {
                    group.SubShapes.Add(shape);
                }
            }

            ShapeList.RemoveAll(x => selection.Contains(x));

            Selection.Clear();
            Selection.Add(group);
            ShapeList.Add(group);

        }

        public void UngroupSelection()
        {
            List <Shape> shapes = new List<Shape>();
			foreach (GroupShape group in selection.Where(x => x is GroupShape))
			{
                foreach (Shape shape in group.SubShapes)
                {
					shapes.Add(shape);
                }
				ShapeList.Remove(group);
            }
            selection.RemoveAll(x => x is GroupShape);
            selection.AddRange(shapes);
            ShapeList.AddRange(shapes);
        }

        public void AddCustomRectangle(int opacity, int degrees, float lineThickness, float x, float y)
        {
            RectangleShape rect = new RectangleShape(new RectangleF(x, y, 100, 200));
            rect.FillColor = Color.White;
            rect.StrokeColor = Color.Black;
            rect.FillColorOpacity = opacity;
            rect.Angle = degrees;
            rect.LineThickness = lineThickness;

            ShapeList.Add(rect);
        }

        public void AddCustomElipse(int opacity, int degrees, float lineThickness, float x, float y)
        {
            ElipseShape elipse = new ElipseShape(new RectangleF(x, y, 100, 200));
            elipse.FillColor = Color.White;
            elipse.StrokeColor = Color.Black;
            elipse.FillColorOpacity = opacity;
            elipse.Angle = degrees;
            elipse.LineThickness = lineThickness;

            ShapeList.Add(elipse);
        }

        public void AddCustomBrezier(int degrees, float lineThickness, float x, float y)
        {
            BrezierShape brez = new BrezierShape(new RectangleF(x, y, 100, 200));
            brez.StrokeColor = Color.Black;
            brez.Angle = degrees;
            brez.LineThickness = lineThickness;

            ShapeList.Add(brez);
        }

        public void AddCustomHexagon(int opacity, int degrees, float lineThickness, float x, float y)
        {
            HexagonShape hexagon = new HexagonShape(new RectangleF(x, y, 100, 200));
            hexagon.FillColor = Color.White;
            hexagon.StrokeColor = Color.Black;
            hexagon.FillColorOpacity = opacity;
            hexagon.Angle = degrees;
            hexagon.LineThickness = lineThickness;

            ShapeList.Add(hexagon);
        }

        public void AddCustomLine(int degrees, float lineThickness, float x, float y)
        {
            LineShape line = new LineShape(new RectangleF(x, y, 100, 200));
            line.StrokeColor = Color.Black;
            line.Angle = degrees;
            line.LineThickness = lineThickness;

            ShapeList.Add(line);
        }

        public void AddCustomStar(int opacity, int degrees, float lineThickness, float x, float y)
        {
            StarShape star = new StarShape(new RectangleF(x, y, 175, 175));
            star.FillColor = Color.White;
            star.StrokeColor = Color.Black;
            star.FillColorOpacity = opacity;
            star.Angle = degrees;
            star.LineThickness = lineThickness;

            ShapeList.Add(star);
        }

        public void Copy()
        {
            if(selection.Count<=0)
                return;
            float minX=float.MaxValue, minY=float.MaxValue,
                maxX=float.MinValue, maxY=float.MinValue;
            foreach (Shape shape in selection)
            {
                if (shape.Location.X<minX)
                    minX = shape.Location.X;
                if (shape.Location.Y<minY)
                    minY = shape.Location.Y;
                if(shape.Location.X+shape.Width>maxX)
                    maxX=shape.Location.X+shape.Width;
                if (shape.Location.Y + shape.Height > maxY)
                    maxY = shape.Location.Y + shape.Height;
            }
            copyBin = new GroupShape(new RectangleF(minX+10, minY+10, maxX - minX, maxY - minY));
            foreach (Shape shape in selection)
            {
                Shape copy=new Shape();
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
                copyBin.SubShapes.Add(copy);
            }
        }

        public void Paste(float x, float y)
        {
            copyBin.Location = new PointF(x, y);
            copyBin.Rectangle = new RectangleF(x, y, copyBin.Rectangle.Width, copyBin.Rectangle.Height);
            foreach (Shape shape in copyBin.SubShapes) 
            {
                Shape paste = new Shape();
                if (shape is RectangleShape)
                    paste = new RectangleShape((RectangleShape)shape);
                if (shape is ElipseShape)
                    paste = new ElipseShape((ElipseShape)shape);
                if (shape is LineShape)
                    paste = new LineShape((LineShape)shape);
                if (shape is StarShape)
                    paste = new StarShape((StarShape)shape);
                if (shape is HexagonShape)
                    paste = new HexagonShape((HexagonShape)shape);
                if (shape is PolygonShape)
                {
                    paste = new PolygonShape((PolygonShape)shape);
                }
                if (shape is BrezierShape)
                    paste = new BrezierShape((BrezierShape)shape);
                if (shape is GroupShape)
                    paste = new GroupShape((GroupShape)shape);
                ShapeList.Add(paste);
            }
        }
    }
}
