using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle(opacityTrackBar.Value,rotationTrackBar.Value,lineThicknessTrackBar.Value);
			
            string name = "правоъгълник";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
		}

        private void viewPort_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (pickUpSpeedButton.Checked)
            {
                if (!dialogProcessor.IsCustomPolygon)
                {
                    Shape temp = dialogProcessor.ContainsPoint(e.Location);

                    if (temp != null)
                    {
                        if (dialogProcessor.Selection.Contains(temp))
                            dialogProcessor.Selection.Remove(temp);
                        else
                            dialogProcessor.Selection.Add(temp);
                        if (dialogProcessor.Selection.Count > 0)
                        {
                            if (dialogProcessor.Selection.Count() == 1
                                && !(temp is GroupShape))
                            {
                                opacityTrackBar.Value = temp.FillColorOpacity;
                                rotationTrackBar.Value = Convert.ToInt32(temp.Angle);
                            }
                            statusBar.Items[0].Text = "Последно действие: Селекция на примитив";

                            viewPort.Invalidate();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
        /// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
        /// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
        /// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
        /// </summary>
        void ViewPortMouseDown(object sender, MouseEventArgs e)
		{
            if (e.Button == MouseButtons.Right)
			{
			contextMenuStrip1.Show(e.X, e.Y);
			}
			else
			if (pickUpSpeedButton.Checked)
            {
                xTextBox.Text = e.X.ToString();
                yTextBox.Text = e.Y.ToString();
                if (dialogProcessor.IsCustomPolygon)
				{
					dialogProcessor.PolygonPoints.Add(e.Location);
					if (dialogProcessor.PolygonPoints.Count>1)
					{
						dialogProcessor.DrawCustomLine(lineThicknessTrackBar.Value);
						viewPort.Invalidate();
					}
				}
				else
				{

					if (dialogProcessor.SelectContainsPoint(e.Location))
					{
						if (dialogProcessor.Selection.Count>0)
						{
                            dialogProcessor.IsDragging = true;
                            dialogProcessor.LastLocation = e.Location;

                            viewPort.Invalidate();
                        }
					}

					
                }
			}
		}
		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режим на "влачене", то избрания елемент се транслира.
		/// Също с всяко местене градиент се пренарисува наново
		/// </summary>
		void ViewPortMouseMove(object sender, MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging)
			{
				if (dialogProcessor.Selection.Count() > 0)
				{
                    statusBar.Items[0].Text = "Последно действие: Влачене";
                    dialogProcessor.TranslateTo(e.Location);
                    viewPort.Invalidate();
                }
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}


		//Добавя произволна елипса
        private void drawElipseButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomElipse(opacityTrackBar.Value, rotationTrackBar.Value, lineThicknessTrackBar.Value);

            string name = "елипса";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

		//Добавя произволна крива на брезиер
        private void drawBrezierButton_Click_(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomBrezier(rotationTrackBar.Value,lineThicknessTrackBar.Value);
			string name = "линия на Брезиер";
            statusBar.Items[0].Text = "Последно действие: Рисуване на "+name;
			primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

		//Добавя произволен хексагон
        private void drawHexagonButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomHexagon(opacityTrackBar.Value, rotationTrackBar.Value, lineThicknessTrackBar.Value);

            string name = "хексагон";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

		//Променя цвета на избраните форми
        private void colorStokeButton_Click(object sender, EventArgs e)
        {
			if(colorDialog.ShowDialog()==DialogResult.OK
				&& dialogProcessor.Selection.Count>0)
			{
			    Color pickedColor=colorDialog.Color;
				foreach (Shape shape in dialogProcessor.Selection)
				{
					shape.FillColor = pickedColor;
                }
                viewPort.Invalidate();
            }
        }

        //Променя цвета на градиента избраните форми
        private void gradientButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog()==DialogResult.OK
                && dialogProcessor.Selection.Count() > 0)
            {
                foreach (Shape shape in dialogProcessor.Selection)
                {
						shape.GradientFillColor = colorDialog.Color;
                }
                viewPort.Invalidate();
            }

        }

        //Превръща селектираните форме в градиент или ги премахва от градиент
        private void isGradientButton_Click_1(object sender, EventArgs e)
        {
            if (dialogProcessor.Selection.Count() > 0)
            {
                foreach (Shape shape in dialogProcessor.Selection)
                {
                    shape.IsGradient = !shape.IsGradient;
                }
                viewPort.Invalidate();
            }
        }

        //При промяна на стойноста на тракбара се променя прозрачността на избраната форма
        //ако има такава
        private void opacityTrackBar_ValueChanged(object sender, EventArgs e)
        {
			opacityLabel.Text=opacityTrackBar.Value.ToString()+"%";
			if (dialogProcessor.Selection.Count()>0)
			{
				foreach (Shape shape in dialogProcessor.Selection)
				{
				shape.FillColorOpacity = opacityTrackBar.Value;
                }

				viewPort.Invalidate();
			}
        }

		//Добавяне на произволна линия
        private void lineButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomLine(rotationTrackBar.Value, lineThicknessTrackBar.Value);

            statusBar.Items[0].Text = "Последно действие: Рисуване на линия";

            string name = "линия";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


		//Променя ъгъла на завъртане на избраните форми
        private void rotationTrackBar_ValueChanged(object sender, EventArgs e)
        {
			rotationLabel.Text = rotationTrackBar.Value.ToString() + "°";
			if (dialogProcessor.Selection.Count>0)
			{
				foreach (Shape shape in dialogProcessor.Selection)
				{
					shape.Angle = rotationTrackBar.Value;
				}
				viewPort.Invalidate();
			} 
		}

		//Променя дебелината на контура на избраните форми
        private void lineThicknessTrackBar_ValueChanged(object sender, EventArgs e)
        {
            lineThicknessLabel.Text = lineThicknessTrackBar.Value.ToString()+"%";
            if (dialogProcessor.Selection.Count > 0)
            {
                foreach (Shape shape in dialogProcessor.Selection)
                {
                    shape.LineThickness = lineThicknessTrackBar.Value;
                }
                viewPort.Invalidate();
            }
        }

        private void groupShape_Click(object sender, EventArgs e)
        {
			dialogProcessor.GroupSelection();
            RenewListBox();
			viewPort.Invalidate();
        }

        private void pickUpSpeedButton_Click(object sender, EventArgs e)
        {

        }

		//Добавя произволна звезда
        private void drawStarSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomStar(opacityTrackBar.Value, rotationTrackBar.Value, lineThicknessTrackBar.Value);

            string name = "звезда";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

        private void customPolygonButton_Click(object sender, EventArgs e)
        {
			if (dialogProcessor.IsCustomPolygon)
			{
				if (dialogProcessor.PolygonPoints.Count > 2)
                {
                    dialogProcessor.AddCustomPolygon(opacityTrackBar.Value, rotationTrackBar.Value, lineThicknessTrackBar.Value);

                    string name = "полигон";
                    statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
                    primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

                    viewPort.Invalidate();
                }
				else
					MessageBox.Show("Polygon must have atleast 3 points");
            }
            dialogProcessor.IsCustomPolygon = !dialogProcessor.IsCustomPolygon;
        }

        /// <summary>
        /// Изтрива селектираните форми или по-точно изпразва dialogProccesor.Selection
        /// като изтрива всички форми от списъка от dialogProccesor.ShapeList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
			DialogResult dialogResult 
				= MessageBox.Show("Сигурни ли сте, че искате да изтриете избранните форми?",
				"Изтриване на избраните форми",MessageBoxButtons.YesNo);

			if (dialogResult==DialogResult.Yes)
			{
				dialogProcessor.ShapeList.RemoveAll(x => dialogProcessor.Selection.Contains(x));
				dialogProcessor.Selection.Clear();
                RenewListBox();
				viewPort.Invalidate();
			}
        }

        private void RenewListBox()
        {
            primitivesNameListBox.Items.Clear();
            foreach (Shape shape in dialogProcessor.ShapeList)
            {
                string name = "";
                if (shape is PolygonShape)
                {
                    name = "полигон";
                }
                else
                if (shape is StarShape)
                {
                    name = "звезда";
                }
                else
                if (shape is RectangleShape)
                {
                    name = "правоъгълник";
                }
                else
                if (shape is LineShape)
                {
                    name = "линия";
                }
                else
                if (shape is BrezierShape)
                {
                    name = "линия на брезиер";
                }
                else
                if (shape is HexagonShape)
                {
                    name = "хексагон";
                }
                else
                if (shape is GroupShape)
                {
                    name = "група";
                }
                else
                if (shape is ElipseShape)
                {
                    name = "елипса";
                }
                primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.IndexOf(shape)+1).ToString() + "#" + name);
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
			if (e.Control)
			{
                if (e.KeyCode==Keys.C)
                {
                    copyToolStripMenuItem_Click(sender, e);
                }
                else
                if (e.KeyCode == Keys.V)
                {
                    pasteToolStripMenuItem_Click(sender, e);
                }
                else
                if (e.KeyCode == Keys.R)
				{
					dialogProcessor.AddRandomRectangle(opacityTrackBar.Value, rotationTrackBar.Value, lineThicknessTrackBar.Value);
					string name = "правоъгълник";
					statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
					primitivesNameListBox.Items.Add(name);
				}
				else
				if (e.KeyCode == Keys.A)
				{
					selectAllToolStripMenuItem_Click(sender, e);
                }
                else
                if (e.Shift)
                {
                    if (e.KeyCode == Keys.G)
                    {
                        dialogProcessor.UngroupSelection();
                        statusBar.Items[0].Text = "Probe";
                    }
                    else
                    if (e.KeyCode == Keys.A)
                    {
                        dialogProcessor.Selection = new List<Shape>();
                    }
                }
                else
				if (e.KeyCode == Keys.G)
                {
                    groupShape_Click(sender, e);
				}
				else
				if (e.KeyCode==Keys.Delete || e.KeyCode==Keys.Back)
				{
					deleteSelectedButton_Click(sender,e);
				}
				else
				if (e.KeyCode == Keys.Oemcomma)
				{
					rotate90DegreesCounterClockwiseToolStripMenuItem_Click(sender, e);
				}
				else
				if (e.KeyCode == Keys.OemPeriod)
                {
					rotate90DegreesClockwiseToolStripMenuItem_Click(sender, e);
                }
            }
			viewPort.Invalidate();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void rotate90DegreesClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
			foreach (Shape shape in dialogProcessor.Selection)
			{
				shape.Angle = (shape.Angle + 90) % 360;
			}
			viewPort.Invalidate();
        }

        private void rotate90DegreesCounterClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Shape shape in dialogProcessor.Selection)
            {
                shape.Angle = Math.Abs(shape.Angle - 90) % 360;
            }
            viewPort.Invalidate();

        }

        private void lastPickedColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Shape shape in dialogProcessor.Selection)
            {
				shape.FillColor = colorDialog.Color;
            }
            viewPort.Invalidate();
        }


        private void ungroupShape_Click(object sender, EventArgs e)
        {
			dialogProcessor.UngroupSelection();
            viewPort.Invalidate();
            RenewListBox();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.ShapeList.Count>0)
            {
                DialogResult result = MessageBox.Show("Do you want to save this file?", "Warning", MessageBoxButtons.YesNoCancel);
                if (result==DialogResult.Yes)
                    saveFileToolStripMenuItem_Click(sender, e);
                if (result == DialogResult.Cancel)
                    return;
            }
            //openFileDialog1.FileName
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
				FileStream stream = new FileStream(openFileDialog1.FileName,FileMode.Open);
				BinaryFormatter binaryFormatter= new BinaryFormatter();
				dialogProcessor.ShapeList= (List<Shape>)binaryFormatter.Deserialize(stream);
				stream.Close();
				viewPort.Invalidate();
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
				BinaryFormatter binaryFormatter= new BinaryFormatter();
				FileStream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create);
				binaryFormatter.Serialize(stream, dialogProcessor.ShapeList);
				stream.Close();
			}
		}

        private void primitivesNameListBox_DoubleClick(object sender, EventArgs e)
        {
			Shape shape= dialogProcessor.ShapeList.ElementAt(primitivesNameListBox.SelectedIndex);
			if (dialogProcessor.Selection.Contains(shape))
			{
				dialogProcessor.Selection.Remove(shape);
			}
			else
            {
                dialogProcessor.Selection.Add(shape);
            }
				

        }

        private void strokeColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK
                && dialogProcessor.Selection.Count > 0)
            {
                Color pickedColor = colorDialog.Color;
                foreach (Shape shape in dialogProcessor.Selection)
                {
                    shape.StrokeColor = pickedColor;
                }
                viewPort.Invalidate();
            }
        }

        private void rectangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(xTextBox.Text) || string.IsNullOrEmpty(yTextBox.Text))
                return;
            dialogProcessor.AddCustomRectangle(opacityTrackBar.Value, rotationTrackBar.Value,
                lineThicknessTrackBar.Value, (float)Convert.ToDouble(xTextBox.Text),
                (float)Convert.ToDouble(yTextBox.Text));

            string name = "правоъгълник";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

        private void elipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(xTextBox.Text) || string.IsNullOrEmpty(yTextBox.Text))
                return;
            dialogProcessor.AddCustomElipse(opacityTrackBar.Value, rotationTrackBar.Value,
                lineThicknessTrackBar.Value, (float)Convert.ToDouble(xTextBox.Text),
                (float)Convert.ToDouble(yTextBox.Text));

            string name = "елипса";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(xTextBox.Text) || string.IsNullOrEmpty(yTextBox.Text))
                return;
            dialogProcessor.AddCustomLine(rotationTrackBar.Value,
                lineThicknessTrackBar.Value, (float)Convert.ToDouble(xTextBox.Text),
                (float)Convert.ToDouble(yTextBox.Text));

            string name = "линия";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

        private void brezierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(xTextBox.Text) || string.IsNullOrEmpty(yTextBox.Text))
                return;
            dialogProcessor.AddCustomBrezier(rotationTrackBar.Value,
                lineThicknessTrackBar.Value, (float)Convert.ToDouble(xTextBox.Text),
                (float)Convert.ToDouble(yTextBox.Text));

            string name = "линия на Брезиер";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

        private void hexagonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(xTextBox.Text) || string.IsNullOrEmpty(yTextBox.Text))
                return;
            dialogProcessor.AddCustomHexagon(opacityTrackBar.Value, rotationTrackBar.Value,
                lineThicknessTrackBar.Value, (float)Convert.ToDouble(xTextBox.Text),
                (float)Convert.ToDouble(yTextBox.Text));

            string name = "хексагон";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

        private void starToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(xTextBox.Text) || string.IsNullOrEmpty(yTextBox.Text))
                return;
            dialogProcessor.AddCustomStar(opacityTrackBar.Value, rotationTrackBar.Value,
                lineThicknessTrackBar.Value, (float)Convert.ToDouble(xTextBox.Text),
                (float)Convert.ToDouble(yTextBox.Text));

            string name = "звезда";
            statusBar.Items[0].Text = "Последно действие: Рисуване на " + name;
            primitivesNameListBox.Items.Add((dialogProcessor.ShapeList.Count).ToString() + "#" + name);

            viewPort.Invalidate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dialogProcessor.ShapeList.Count>0)
            {
                DialogResult result = MessageBox.Show("Do you want to save this file!", "Warning", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    saveFileToolStripMenuItem_Click(sender, e);
                if (result == DialogResult.Cancel)
                    e.Cancel= true;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Shape shape in dialogProcessor.ShapeList.Where(x => !dialogProcessor.Selection.Contains(x)))
            {
                dialogProcessor.Selection.Add(shape);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.CopyBin == null)
                return;
            dialogProcessor.Paste((float)double.Parse(xTextBox.Text),(float)double.Parse(yTextBox.Text));
            viewPort.Invalidate();
            RenewListBox();
        }

        private void resizeToolStripButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sizeTextBox.Text))
            {
                foreach (Shape shape in dialogProcessor.Selection)
                {
                    shape.ReSize((float)double.Parse(sizeTextBox.Text));
                }
                viewPort.Invalidate();
            }
        }

        private void sizeTextBox_TextChanged(object sender, EventArgs e)
        {
            float a= 2;
            if (!float.TryParse(sizeTextBox.Text, out a))
                sizeTextBox.Text = "";
        }
    }
}

