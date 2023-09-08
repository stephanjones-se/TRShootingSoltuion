namespace WinFormsApp2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            aim = new NumericUpDown();
            rot = new NumericUpDown();
            outer = new NumericUpDown();
            magpie = new NumericUpDown();
            inner = new NumericUpDown();
            bull = new NumericUpDown();
            vbull = new NumericUpDown();
            definedTargets = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            targetDiagram = new PictureBox();
            btnCreatePDF = new Button();
            plottingDiagram = new Panel();
            roty = new NumericUpDown();
            zoomValue = new NumericUpDown();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aim).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)outer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)magpie).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inner).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bull).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vbull).BeginInit();
            ((System.ComponentModel.ISupportInitialize)targetDiagram).BeginInit();
            plottingDiagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zoomValue).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(21, 304);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // aim
            // 
            aim.Location = new Point(104, 79);
            aim.Maximum = new decimal(new int[] { 2600, 0, 0, 0 });
            aim.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            aim.Name = "aim";
            aim.Size = new Size(120, 23);
            aim.TabIndex = 3;
            aim.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // rot
            // 
            rot.Location = new Point(104, 50);
            rot.Maximum = new decimal(new int[] { 2600, 0, 0, 0 });
            rot.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            rot.Name = "rot";
            rot.Size = new Size(58, 23);
            rot.TabIndex = 4;
            rot.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // outer
            // 
            outer.Location = new Point(104, 108);
            outer.Maximum = new decimal(new int[] { 2600, 0, 0, 0 });
            outer.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            outer.Name = "outer";
            outer.Size = new Size(120, 23);
            outer.TabIndex = 5;
            outer.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // magpie
            // 
            magpie.Location = new Point(104, 137);
            magpie.Maximum = new decimal(new int[] { 2600, 0, 0, 0 });
            magpie.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            magpie.Name = "magpie";
            magpie.Size = new Size(120, 23);
            magpie.TabIndex = 6;
            magpie.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // inner
            // 
            inner.Location = new Point(104, 166);
            inner.Maximum = new decimal(new int[] { 2600, 0, 0, 0 });
            inner.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            inner.Name = "inner";
            inner.Size = new Size(120, 23);
            inner.TabIndex = 7;
            inner.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // bull
            // 
            bull.Location = new Point(104, 195);
            bull.Maximum = new decimal(new int[] { 2600, 0, 0, 0 });
            bull.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            bull.Name = "bull";
            bull.Size = new Size(120, 23);
            bull.TabIndex = 8;
            bull.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // vbull
            // 
            vbull.Location = new Point(104, 224);
            vbull.Maximum = new decimal(new int[] { 1500, 0, 0, 0 });
            vbull.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            vbull.Name = "vbull";
            vbull.Size = new Size(120, 23);
            vbull.TabIndex = 9;
            vbull.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // definedTargets
            // 
            definedTargets.FormattingEnabled = true;
            definedTargets.Location = new Point(104, 19);
            definedTargets.Name = "definedTargets";
            definedTargets.Size = new Size(121, 23);
            definedTargets.TabIndex = 10;
            definedTargets.SelectedIndexChanged += definedTargets_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 52);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 11;
            label1.Text = "Frame Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 81);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 12;
            label2.Text = "Aiming Mark";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 110);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 13;
            label3.Text = "Outer";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 139);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 14;
            label4.Text = "Magpie";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(61, 168);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 15;
            label5.Text = "Inner";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(68, 197);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 16;
            label6.Text = "Bull";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(58, 226);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 17;
            label7.Text = "V Bull";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 22);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 18;
            label8.Text = "Target Name";
            // 
            // targetDiagram
            // 
            targetDiagram.BackColor = Color.White;
            targetDiagram.BorderStyle = BorderStyle.FixedSingle;
            targetDiagram.Location = new Point(90, 40);
            targetDiagram.Name = "targetDiagram";
            targetDiagram.Size = new Size(680, 500);
            targetDiagram.TabIndex = 19;
            targetDiagram.TabStop = false;
            // 
            // btnCreatePDF
            // 
            btnCreatePDF.Location = new Point(246, 629);
            btnCreatePDF.Name = "btnCreatePDF";
            btnCreatePDF.Size = new Size(75, 23);
            btnCreatePDF.TabIndex = 20;
            btnCreatePDF.Text = "Create PDF";
            btnCreatePDF.UseVisualStyleBackColor = true;
            btnCreatePDF.Click += btnCreatePDF_Click;
            // 
            // plottingDiagram
            // 
            plottingDiagram.BackColor = Color.White;
            plottingDiagram.Controls.Add(targetDiagram);
            plottingDiagram.Location = new Point(361, 19);
            plottingDiagram.Name = "plottingDiagram";
            plottingDiagram.Size = new Size(1200, 780);
            plottingDiagram.TabIndex = 21;
            plottingDiagram.Paint += DrawPanel;
            // 
            // roty
            // 
            roty.Location = new Point(167, 50);
            roty.Maximum = new decimal(new int[] { 2600, 0, 0, 0 });
            roty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            roty.Name = "roty";
            roty.Size = new Size(56, 23);
            roty.TabIndex = 22;
            roty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // zoomValue
            // 
            zoomValue.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            zoomValue.Location = new Point(103, 253);
            zoomValue.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            zoomValue.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            zoomValue.Name = "zoomValue";
            zoomValue.Size = new Size(120, 23);
            zoomValue.TabIndex = 24;
            zoomValue.Value = new decimal(new int[] { 100, 0, 0, 0 });
            zoomValue.ValueChanged += zoomValue_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(56, 255);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 25;
            label9.Text = "Zoom";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 815);
            Controls.Add(label9);
            Controls.Add(zoomValue);
            Controls.Add(roty);
            Controls.Add(plottingDiagram);
            Controls.Add(btnCreatePDF);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(definedTargets);
            Controls.Add(vbull);
            Controls.Add(bull);
            Controls.Add(inner);
            Controls.Add(magpie);
            Controls.Add(outer);
            Controls.Add(rot);
            Controls.Add(aim);
            Controls.Add(pictureBox1);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)aim).EndInit();
            ((System.ComponentModel.ISupportInitialize)rot).EndInit();
            ((System.ComponentModel.ISupportInitialize)outer).EndInit();
            ((System.ComponentModel.ISupportInitialize)magpie).EndInit();
            ((System.ComponentModel.ISupportInitialize)inner).EndInit();
            ((System.ComponentModel.ISupportInitialize)bull).EndInit();
            ((System.ComponentModel.ISupportInitialize)vbull).EndInit();
            ((System.ComponentModel.ISupportInitialize)targetDiagram).EndInit();
            plottingDiagram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)roty).EndInit();
            ((System.ComponentModel.ISupportInitialize)zoomValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private NumericUpDown aim;
        private NumericUpDown rot;
        private NumericUpDown outer;
        private NumericUpDown magpie;
        private NumericUpDown inner;
        private NumericUpDown bull;
        private NumericUpDown vbull;
        private ComboBox definedTargets;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnCreatePDF;
        private Panel panel1;
        private PictureBox targetDiagram;
        private Panel plottingDiagram;
        private NumericUpDown roty;
        private NumericUpDown zoomValue;
        private Label label9;
    }


}