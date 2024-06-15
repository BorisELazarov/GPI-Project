namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawElipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawLineSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawBrezierSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawHexagonSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawStarSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.customPolygonButton = new System.Windows.Forms.ToolStripButton();
            this.groupShape = new System.Windows.Forms.ToolStripButton();
            this.ungroupShape = new System.Windows.Forms.ToolStripButton();
            this.colorStokeButton = new System.Windows.Forms.ToolStripButton();
            this.gradientButton = new System.Windows.Forms.ToolStripButton();
            this.isGradientButton = new System.Windows.Forms.ToolStripButton();
            this.strokeColorButton = new System.Windows.Forms.ToolStripButton();
            this.deleteSelectedButton = new System.Windows.Forms.ToolStripButton();
            this.resizeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.opacityTrackBar = new System.Windows.Forms.TrackBar();
            this.opacityLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lineThicknessTrackBar = new System.Windows.Forms.TrackBar();
            this.lineThicknessLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.primitivesNameListBox = new System.Windows.Forms.ListBox();
            this.primitiveNamesLabel = new System.Windows.Forms.Label();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.rotationTrackBar = new System.Windows.Forms.TrackBar();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotate90DegreesCounterClockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastPickedColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.elipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brezierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexagonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCtrlVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1175, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.openImageToolStripMenuItem,
            this.saveFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openImageToolStripMenuItem.Text = "Open file...";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.saveFileToolStripMenuItem.Text = "Save...";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 651);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1175, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickUpSpeedButton,
            this.drawRectangleSpeedButton,
            this.drawElipseSpeedButton,
            this.drawLineSpeedButton,
            this.drawBrezierSpeedButton,
            this.drawHexagonSpeedButton,
            this.drawStarSpeedButton,
            this.customPolygonButton,
            this.groupShape,
            this.ungroupShape,
            this.colorStokeButton,
            this.gradientButton,
            this.isGradientButton,
            this.strokeColorButton,
            this.deleteSelectedButton,
            this.resizeToolStripButton});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(1175, 25);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.pickUpSpeedButton.Text = "mouse";
            this.pickUpSpeedButton.Click += new System.EventHandler(this.pickUpSpeedButton_Click);
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawRectangleSpeedButton.Text = "Rectangle";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // drawElipseSpeedButton
            // 
            this.drawElipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawElipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawElipseSpeedButton.Image")));
            this.drawElipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawElipseSpeedButton.Name = "drawElipseSpeedButton";
            this.drawElipseSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawElipseSpeedButton.Text = "Elipse";
            this.drawElipseSpeedButton.Click += new System.EventHandler(this.drawElipseButton_Click);
            // 
            // drawLineSpeedButton
            // 
            this.drawLineSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawLineSpeedButton.Image = global::Draw.Properties.Resources.line;
            this.drawLineSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawLineSpeedButton.Name = "drawLineSpeedButton";
            this.drawLineSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawLineSpeedButton.Text = "Line";
            this.drawLineSpeedButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // drawBrezierSpeedButton
            // 
            this.drawBrezierSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawBrezierSpeedButton.Image = global::Draw.Properties.Resources.bezier;
            this.drawBrezierSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawBrezierSpeedButton.Name = "drawBrezierSpeedButton";
            this.drawBrezierSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawBrezierSpeedButton.Text = "Brezier";
            this.drawBrezierSpeedButton.ToolTipText = "Brezier";
            this.drawBrezierSpeedButton.Click += new System.EventHandler(this.drawBrezierButton_Click_);
            // 
            // drawHexagonSpeedButton
            // 
            this.drawHexagonSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawHexagonSpeedButton.Image = global::Draw.Properties.Resources.hexagon;
            this.drawHexagonSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawHexagonSpeedButton.Name = "drawHexagonSpeedButton";
            this.drawHexagonSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawHexagonSpeedButton.Text = "Hexagon";
            this.drawHexagonSpeedButton.Click += new System.EventHandler(this.drawHexagonButton_Click);
            // 
            // drawStarSpeedButton
            // 
            this.drawStarSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawStarSpeedButton.Image = global::Draw.Properties.Resources.star;
            this.drawStarSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawStarSpeedButton.Name = "drawStarSpeedButton";
            this.drawStarSpeedButton.Size = new System.Drawing.Size(23, 22);
            this.drawStarSpeedButton.Text = "Star";
            this.drawStarSpeedButton.Click += new System.EventHandler(this.drawStarSpeedButton_Click);
            // 
            // customPolygonButton
            // 
            this.customPolygonButton.CheckOnClick = true;
            this.customPolygonButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.customPolygonButton.Image = global::Draw.Properties.Resources.polygon2;
            this.customPolygonButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.customPolygonButton.Name = "customPolygonButton";
            this.customPolygonButton.Size = new System.Drawing.Size(23, 22);
            this.customPolygonButton.Text = "Custom Polygon";
            this.customPolygonButton.Click += new System.EventHandler(this.customPolygonButton_Click);
            // 
            // groupShape
            // 
            this.groupShape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.groupShape.Image = global::Draw.Properties.Resources.groupShape;
            this.groupShape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.groupShape.Name = "groupShape";
            this.groupShape.Size = new System.Drawing.Size(23, 22);
            this.groupShape.Text = "Group";
            this.groupShape.Click += new System.EventHandler(this.groupShape_Click);
            // 
            // ungroupShape
            // 
            this.ungroupShape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ungroupShape.Image = global::Draw.Properties.Resources.groupShape;
            this.ungroupShape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ungroupShape.Name = "ungroupShape";
            this.ungroupShape.Size = new System.Drawing.Size(23, 22);
            this.ungroupShape.Text = "Ungroup";
            this.ungroupShape.Click += new System.EventHandler(this.ungroupShape_Click);
            // 
            // colorStokeButton
            // 
            this.colorStokeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorStokeButton.Image = ((System.Drawing.Image)(resources.GetObject("colorStokeButton.Image")));
            this.colorStokeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorStokeButton.Name = "colorStokeButton";
            this.colorStokeButton.Size = new System.Drawing.Size(23, 22);
            this.colorStokeButton.Text = "Choose Color";
            this.colorStokeButton.Click += new System.EventHandler(this.colorStokeButton_Click);
            // 
            // gradientButton
            // 
            this.gradientButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gradientButton.Image = ((System.Drawing.Image)(resources.GetObject("gradientButton.Image")));
            this.gradientButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gradientButton.Name = "gradientButton";
            this.gradientButton.Size = new System.Drawing.Size(23, 22);
            this.gradientButton.Text = "Gradient Color";
            this.gradientButton.Click += new System.EventHandler(this.gradientButton_Click);
            // 
            // isGradientButton
            // 
            this.isGradientButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.isGradientButton.Image = global::Draw.Properties.Resources.Gradient_Switch;
            this.isGradientButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.isGradientButton.Name = "isGradientButton";
            this.isGradientButton.Size = new System.Drawing.Size(23, 22);
            this.isGradientButton.Text = "Gradient On/off";
            this.isGradientButton.ToolTipText = "Gradient On/off";
            this.isGradientButton.Click += new System.EventHandler(this.isGradientButton_Click_1);
            // 
            // strokeColorButton
            // 
            this.strokeColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.strokeColorButton.Image = global::Draw.Properties.Resources.coloredFrame;
            this.strokeColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strokeColorButton.Name = "strokeColorButton";
            this.strokeColorButton.Size = new System.Drawing.Size(23, 22);
            this.strokeColorButton.Text = "Change frame color";
            this.strokeColorButton.Click += new System.EventHandler(this.strokeColorButton_Click);
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteSelectedButton.Image = global::Draw.Properties.Resources.deleteSelected;
            this.deleteSelectedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(23, 22);
            this.deleteSelectedButton.Text = "Изтрий избраните форми";
            this.deleteSelectedButton.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // resizeToolStripButton
            // 
            this.resizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resizeToolStripButton.Image = global::Draw.Properties.Resources.resize;
            this.resizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resizeToolStripButton.Name = "resizeToolStripButton";
            this.resizeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.resizeToolStripButton.Text = "Resize";
            this.resizeToolStripButton.Click += new System.EventHandler(this.resizeToolStripButton_Click);
            // 
            // opacityTrackBar
            // 
            this.opacityTrackBar.Location = new System.Drawing.Point(3, 34);
            this.opacityTrackBar.Maximum = 100;
            this.opacityTrackBar.Name = "opacityTrackBar";
            this.opacityTrackBar.Size = new System.Drawing.Size(164, 45);
            this.opacityTrackBar.TabIndex = 5;
            this.opacityTrackBar.Value = 100;
            this.opacityTrackBar.ValueChanged += new System.EventHandler(this.opacityTrackBar_ValueChanged);
            // 
            // opacityLabel
            // 
            this.opacityLabel.AutoSize = true;
            this.opacityLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.opacityLabel.Location = new System.Drawing.Point(58, 18);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(33, 13);
            this.opacityLabel.TabIndex = 6;
            this.opacityLabel.Text = "100%";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sizeTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lineThicknessTrackBar);
            this.panel1.Controls.Add(this.lineThicknessLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.primitivesNameListBox);
            this.panel1.Controls.Add(this.primitiveNamesLabel);
            this.panel1.Controls.Add(this.yTextBox);
            this.panel1.Controls.Add(this.xTextBox);
            this.panel1.Controls.Add(this.yLabel);
            this.panel1.Controls.Add(this.xLabel);
            this.panel1.Controls.Add(this.rotationTrackBar);
            this.panel1.Controls.Add(this.rotationLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.opacityTrackBar);
            this.panel1.Controls.Add(this.opacityLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1005, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 602);
            this.panel1.TabIndex = 7;
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(9, 303);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.sizeTextBox.TabIndex = 23;
            this.sizeTextBox.TextChanged += new System.EventHandler(this.sizeTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Size multiplier:";
            // 
            // lineThicknessTrackBar
            // 
            this.lineThicknessTrackBar.Location = new System.Drawing.Point(9, 162);
            this.lineThicknessTrackBar.Maximum = 100;
            this.lineThicknessTrackBar.Name = "lineThicknessTrackBar";
            this.lineThicknessTrackBar.Size = new System.Drawing.Size(158, 45);
            this.lineThicknessTrackBar.TabIndex = 20;
            this.lineThicknessTrackBar.TabStop = false;
            this.lineThicknessTrackBar.Value = 50;
            this.lineThicknessTrackBar.ValueChanged += new System.EventHandler(this.lineThicknessTrackBar_ValueChanged);
            // 
            // lineThicknessLabel
            // 
            this.lineThicknessLabel.AutoSize = true;
            this.lineThicknessLabel.Location = new System.Drawing.Point(117, 146);
            this.lineThicknessLabel.Name = "lineThicknessLabel";
            this.lineThicknessLabel.Size = new System.Drawing.Size(13, 13);
            this.lineThicknessLabel.TabIndex = 19;
            this.lineThicknessLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Thickness of lines:";
            // 
            // primitivesNameListBox
            // 
            this.primitivesNameListBox.FormattingEnabled = true;
            this.primitivesNameListBox.Location = new System.Drawing.Point(9, 395);
            this.primitivesNameListBox.Name = "primitivesNameListBox";
            this.primitivesNameListBox.Size = new System.Drawing.Size(120, 108);
            this.primitivesNameListBox.TabIndex = 17;
            this.primitivesNameListBox.DoubleClick += new System.EventHandler(this.primitivesNameListBox_DoubleClick);
            // 
            // primitiveNamesLabel
            // 
            this.primitiveNamesLabel.AutoSize = true;
            this.primitiveNamesLabel.Location = new System.Drawing.Point(6, 379);
            this.primitiveNamesLabel.Name = "primitiveNamesLabel";
            this.primitiveNamesLabel.Size = new System.Drawing.Size(101, 13);
            this.primitiveNamesLabel.TabIndex = 15;
            this.primitiveNamesLabel.Text = "Names of primitives:";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(9, 264);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.ReadOnly = true;
            this.yTextBox.Size = new System.Drawing.Size(100, 20);
            this.yTextBox.TabIndex = 14;
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(9, 225);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.ReadOnly = true;
            this.xTextBox.Size = new System.Drawing.Size(100, 20);
            this.xTextBox.TabIndex = 13;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(6, 248);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(65, 13);
            this.yLabel.TabIndex = 12;
            this.yLabel.Text = "Y of current:";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(6, 207);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(65, 13);
            this.xLabel.TabIndex = 11;
            this.xLabel.Text = "X of current:";
            // 
            // rotationTrackBar
            // 
            this.rotationTrackBar.Location = new System.Drawing.Point(9, 98);
            this.rotationTrackBar.Maximum = 360;
            this.rotationTrackBar.Name = "rotationTrackBar";
            this.rotationTrackBar.Size = new System.Drawing.Size(158, 45);
            this.rotationTrackBar.TabIndex = 10;
            this.rotationTrackBar.TabStop = false;
            this.rotationTrackBar.Value = 360;
            this.rotationTrackBar.ValueChanged += new System.EventHandler(this.rotationTrackBar_ValueChanged);
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(59, 82);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(17, 13);
            this.rotationLabel.TabIndex = 9;
            this.rotationLabel.Text = "0°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rotation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Opacity:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateToolStripMenuItem,
            this.rotate90DegreesCounterClockwiseToolStripMenuItem,
            this.lastPickedColorToolStripMenuItem,
            this.addFigureToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteCtrlVToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(270, 158);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.rotateToolStripMenuItem.Text = "rotate 90° clockwise (Ctr+.)";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotate90DegreesClockwiseToolStripMenuItem_Click);
            // 
            // rotate90DegreesCounterClockwiseToolStripMenuItem
            // 
            this.rotate90DegreesCounterClockwiseToolStripMenuItem.Name = "rotate90DegreesCounterClockwiseToolStripMenuItem";
            this.rotate90DegreesCounterClockwiseToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.rotate90DegreesCounterClockwiseToolStripMenuItem.Text = "Rotate 90° counter-clockwise (Ctrl+,)";
            this.rotate90DegreesCounterClockwiseToolStripMenuItem.Click += new System.EventHandler(this.rotate90DegreesCounterClockwiseToolStripMenuItem_Click);
            // 
            // lastPickedColorToolStripMenuItem
            // 
            this.lastPickedColorToolStripMenuItem.Name = "lastPickedColorToolStripMenuItem";
            this.lastPickedColorToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.lastPickedColorToolStripMenuItem.Text = "Last picked color";
            this.lastPickedColorToolStripMenuItem.Click += new System.EventHandler(this.lastPickedColorToolStripMenuItem_Click);
            // 
            // addFigureToolStripMenuItem
            // 
            this.addFigureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem1,
            this.elipseToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.brezierToolStripMenuItem,
            this.hexagonToolStripMenuItem,
            this.starToolStripMenuItem});
            this.addFigureToolStripMenuItem.Name = "addFigureToolStripMenuItem";
            this.addFigureToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.addFigureToolStripMenuItem.Text = "Add figure...";
            // 
            // rectangleToolStripMenuItem1
            // 
            this.rectangleToolStripMenuItem1.Name = "rectangleToolStripMenuItem1";
            this.rectangleToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.rectangleToolStripMenuItem1.Text = "Rectangle";
            this.rectangleToolStripMenuItem1.Click += new System.EventHandler(this.rectangleToolStripMenuItem1_Click);
            // 
            // elipseToolStripMenuItem
            // 
            this.elipseToolStripMenuItem.Name = "elipseToolStripMenuItem";
            this.elipseToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.elipseToolStripMenuItem.Text = "Elipse";
            this.elipseToolStripMenuItem.Click += new System.EventHandler(this.elipseToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // brezierToolStripMenuItem
            // 
            this.brezierToolStripMenuItem.Name = "brezierToolStripMenuItem";
            this.brezierToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.brezierToolStripMenuItem.Text = "Brezier";
            this.brezierToolStripMenuItem.Click += new System.EventHandler(this.brezierToolStripMenuItem_Click);
            // 
            // hexagonToolStripMenuItem
            // 
            this.hexagonToolStripMenuItem.Name = "hexagonToolStripMenuItem";
            this.hexagonToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.hexagonToolStripMenuItem.Text = "Hexagon";
            this.hexagonToolStripMenuItem.Click += new System.EventHandler(this.hexagonToolStripMenuItem_Click);
            // 
            // starToolStripMenuItem
            // 
            this.starToolStripMenuItem.Name = "starToolStripMenuItem";
            this.starToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.starToolStripMenuItem.Text = "Star";
            this.starToolStripMenuItem.Click += new System.EventHandler(this.starToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.selectAllToolStripMenuItem.Text = "Select all (Ctrl+A)";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.copyToolStripMenuItem.Text = "Copy (Ctrl+C)";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteCtrlVToolStripMenuItem
            // 
            this.pasteCtrlVToolStripMenuItem.Name = "pasteCtrlVToolStripMenuItem";
            this.pasteCtrlVToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.pasteCtrlVToolStripMenuItem.Text = "Paste (Ctrl+V)";
            this.pasteCtrlVToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text File|*.txt|Binary file|*.bin";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text File|*.txt|Binary file|*.bin";
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 49);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(1175, 602);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.viewPort_MouseDoubleClick);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton drawElipseSpeedButton;
        private System.Windows.Forms.ToolStripButton drawBrezierSpeedButton;
        private System.Windows.Forms.ToolStripButton drawHexagonSpeedButton;
        private System.Windows.Forms.ToolStripButton colorStokeButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TrackBar opacityTrackBar;
        private System.Windows.Forms.Label opacityLabel;
        private System.Windows.Forms.ToolStripButton gradientButton;
        private System.Windows.Forms.ToolStripButton drawLineSpeedButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar rotationTrackBar;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton groupShape;
        private System.Windows.Forms.ToolStripButton drawStarSpeedButton;
        private System.Windows.Forms.ToolStripButton isGradientButton;
        private System.Windows.Forms.ToolStripButton customPolygonButton;
        private System.Windows.Forms.ToolStripButton deleteSelectedButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastPickedColorToolStripMenuItem;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label primitiveNamesLabel;
        private System.Windows.Forms.ListBox primitivesNameListBox;
        private System.Windows.Forms.ToolStripMenuItem rotate90DegreesCounterClockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton ungroupShape;
        private System.Windows.Forms.TrackBar lineThicknessTrackBar;
        private System.Windows.Forms.Label lineThicknessLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton strokeColorButton;
        private System.Windows.Forms.ToolStripMenuItem addFigureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem elipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brezierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexagonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteCtrlVToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton resizeToolStripButton;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.Label label5;
    }
}
