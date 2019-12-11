namespace Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxSource = new System.Windows.Forms.PictureBox();
            this.pictureBoxContour = new System.Windows.Forms.PictureBox();
            this.contourLabel = new System.Windows.Forms.Label();
            this.centersLabel = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.xInput = new System.Windows.Forms.TextBox();
            this.yInput = new System.Windows.Forms.TextBox();
            this.returnedPointLbl = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.lockStateToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContour)).BeginInit();
            this.lockStateToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxSource
            // 
            this.pictureBoxSource.Location = new System.Drawing.Point(27, 37);
            this.pictureBoxSource.Name = "pictureBoxSource";
            this.pictureBoxSource.Size = new System.Drawing.Size(369, 246);
            this.pictureBoxSource.TabIndex = 0;
            this.pictureBoxSource.TabStop = false;
            // 
            // pictureBoxContour
            // 
            this.pictureBoxContour.Location = new System.Drawing.Point(465, 37);
            this.pictureBoxContour.Name = "pictureBoxContour";
            this.pictureBoxContour.Size = new System.Drawing.Size(385, 245);
            this.pictureBoxContour.TabIndex = 1;
            this.pictureBoxContour.TabStop = false;
            // 
            // contourLabel
            // 
            this.contourLabel.AutoSize = true;
            this.contourLabel.Location = new System.Drawing.Point(63, 320);
            this.contourLabel.Name = "contourLabel";
            this.contourLabel.Size = new System.Drawing.Size(56, 17);
            this.contourLabel.TabIndex = 2;
            this.contourLabel.Text = "contour";
            // 
            // centersLabel
            // 
            this.centersLabel.AutoSize = true;
            this.centersLabel.Location = new System.Drawing.Point(587, 320);
            this.centersLabel.Name = "centersLabel";
            this.centersLabel.Size = new System.Drawing.Size(48, 17);
            this.centersLabel.TabIndex = 3;
            this.centersLabel.Text = "center";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Location = new System.Drawing.Point(123, 395);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(21, 17);
            this.X.TabIndex = 4;
            this.X.Text = "X:";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Location = new System.Drawing.Point(123, 438);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(21, 17);
            this.Y.TabIndex = 5;
            this.Y.Text = "Y:";
            // 
            // xInput
            // 
            this.xInput.Location = new System.Drawing.Point(150, 392);
            this.xInput.Name = "xInput";
            this.xInput.Size = new System.Drawing.Size(100, 22);
            this.xInput.TabIndex = 6;
            // 
            // yInput
            // 
            this.yInput.Location = new System.Drawing.Point(150, 435);
            this.yInput.Name = "yInput";
            this.yInput.Size = new System.Drawing.Size(100, 22);
            this.yInput.TabIndex = 7;
            // 
            // returnedPointLbl
            // 
            this.returnedPointLbl.AutoSize = true;
            this.returnedPointLbl.Location = new System.Drawing.Point(402, 435);
            this.returnedPointLbl.Name = "returnedPointLbl";
            this.returnedPointLbl.Size = new System.Drawing.Size(62, 17);
            this.returnedPointLbl.TabIndex = 8;
            this.returnedPointLbl.Text = "returned";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(101, 483);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(162, 27);
            this.sendBtn.TabIndex = 9;
            this.sendBtn.Text = "Send Coordinates";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // lockStateToolStrip
            // 
            this.lockStateToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lockStateToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.lockStateToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.lockStateToolStrip.Location = new System.Drawing.Point(0, 528);
            this.lockStateToolStrip.Name = "lockStateToolStrip";
            this.lockStateToolStrip.Size = new System.Drawing.Size(1157, 25);
            this.lockStateToolStrip.TabIndex = 10;
            this.lockStateToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1157, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 553);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lockStateToolStrip);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.returnedPointLbl);
            this.Controls.Add(this.yInput);
            this.Controls.Add(this.xInput);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.X);
            this.Controls.Add(this.centersLabel);
            this.Controls.Add(this.contourLabel);
            this.Controls.Add(this.pictureBoxContour);
            this.Controls.Add(this.pictureBoxSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContour)).EndInit();
            this.lockStateToolStrip.ResumeLayout(false);
            this.lockStateToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSource;
        private System.Windows.Forms.PictureBox pictureBoxContour;
        private System.Windows.Forms.Label contourLabel;
        private System.Windows.Forms.Label centersLabel;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.TextBox xInput;
        private System.Windows.Forms.TextBox yInput;
        private System.Windows.Forms.Label returnedPointLbl;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.ToolStrip lockStateToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}

