namespace StockViewer
{
    partial class FormAddMovingAverage
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
            this.movingAverageLabel = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxInstruction = new System.Windows.Forms.TextBox();
            this.labelNumDays = new System.Windows.Forms.Label();
            this.textMA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // movingAverageLabel
            // 
            this.movingAverageLabel.AutoSize = true;
            this.movingAverageLabel.Enabled = false;
            this.movingAverageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movingAverageLabel.Location = new System.Drawing.Point(98, 24);
            this.movingAverageLabel.Name = "movingAverageLabel";
            this.movingAverageLabel.Size = new System.Drawing.Size(204, 20);
            this.movingAverageLabel.TabIndex = 6;
            this.movingAverageLabel.Text = "Simple Moving Averages";
            this.movingAverageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(63, 155);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(101, 36);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(226, 158);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(107, 33);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxInstruction
            // 
            this.textBoxInstruction.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInstruction.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxInstruction.Enabled = false;
            this.textBoxInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInstruction.Location = new System.Drawing.Point(47, 54);
            this.textBoxInstruction.Multiline = true;
            this.textBoxInstruction.Name = "textBoxInstruction";
            this.textBoxInstruction.ReadOnly = true;
            this.textBoxInstruction.Size = new System.Drawing.Size(314, 38);
            this.textBoxInstruction.TabIndex = 4;
            this.textBoxInstruction.TabStop = false;
            this.textBoxInstruction.Text = "Enter the Time Frame for Moving Average to add to the chart.  Use Time Frames fro" +
    "m 1 to 600 days.";
            this.textBoxInstruction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNumDays
            // 
            this.labelNumDays.AutoSize = true;
            this.labelNumDays.Enabled = false;
            this.labelNumDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumDays.Location = new System.Drawing.Point(84, 101);
            this.labelNumDays.Name = "labelNumDays";
            this.labelNumDays.Size = new System.Drawing.Size(126, 17);
            this.labelNumDays.TabIndex = 5;
            this.labelNumDays.Text = "Number of Days = ";
            this.labelNumDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textMA
            // 
            this.textMA.Location = new System.Drawing.Point(216, 101);
            this.textMA.Name = "textMA";
            this.textMA.Size = new System.Drawing.Size(38, 20);
            this.textMA.TabIndex = 0;
            this.textMA.Text = "0";
            this.textMA.TextChanged += new System.EventHandler(this.textMA_TextChanged);
            // 
            // FormAddMovingAverage
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(412, 240);
            this.Controls.Add(this.labelNumDays);
            this.Controls.Add(this.textBoxInstruction);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.movingAverageLabel);
            this.Controls.Add(this.textMA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormAddMovingAverage";
            this.Text = "Adding Moving Averages";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddMovingAverage_FormClosing);
            this.Load += new System.EventHandler(this.FormAddMovingAverage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label movingAverageLabel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxInstruction;
        private System.Windows.Forms.Label labelNumDays;
        private System.Windows.Forms.TextBox textMA;
    }
}