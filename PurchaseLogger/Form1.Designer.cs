namespace PurchaseLogger
{
    partial class PurchaseLoggerForm
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
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.CategoryTextBox = new System.Windows.Forms.TextBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.DateTextBoxM = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.DateTextBoxD = new System.Windows.Forms.TextBox();
            this.DateTextBoxY = new System.Windows.Forms.TextBox();
            this.TodayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(13, 22);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(49, 13);
            this.CategoryLabel.TabIndex = 0;
            this.CategoryLabel.Text = "Category";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(13, 51);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(34, 13);
            this.ValueLabel.TabIndex = 1;
            this.ValueLabel.Text = "Value";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(13, 81);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(30, 13);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "Date";
            // 
            // CategoryTextBox
            // 
            this.CategoryTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CategoryTextBox.Location = new System.Drawing.Point(82, 14);
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.Size = new System.Drawing.Size(116, 20);
            this.CategoryTextBox.TabIndex = 4;
            this.CategoryTextBox.Text = "e.g. Food, Furniture...";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ValueTextBox.Location = new System.Drawing.Point(82, 44);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(116, 20);
            this.ValueTextBox.TabIndex = 5;
            this.ValueTextBox.Text = "e.g. 3.99, 8, 750.00...";
            // 
            // DateTextBoxM
            // 
            this.DateTextBoxM.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DateTextBoxM.Location = new System.Drawing.Point(82, 74);
            this.DateTextBoxM.Name = "DateTextBoxM";
            this.DateTextBoxM.Size = new System.Drawing.Size(22, 20);
            this.DateTextBoxM.TabIndex = 6;
            this.DateTextBoxM.Text = "mm";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(82, 101);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 3;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // DateTextBoxD
            // 
            this.DateTextBoxD.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DateTextBoxD.Location = new System.Drawing.Point(110, 74);
            this.DateTextBoxD.Name = "DateTextBoxD";
            this.DateTextBoxD.Size = new System.Drawing.Size(26, 20);
            this.DateTextBoxD.TabIndex = 7;
            this.DateTextBoxD.Text = "dd";
            // 
            // DateTextBoxY
            // 
            this.DateTextBoxY.ForeColor = System.Drawing.SystemColors.GrayText;
            this.DateTextBoxY.Location = new System.Drawing.Point(142, 74);
            this.DateTextBoxY.Name = "DateTextBoxY";
            this.DateTextBoxY.Size = new System.Drawing.Size(40, 20);
            this.DateTextBoxY.TabIndex = 8;
            this.DateTextBoxY.Text = "yyyy";
            // 
            // TodayButton
            // 
            this.TodayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.TodayButton.Location = new System.Drawing.Point(189, 74);
            this.TodayButton.Name = "TodayButton";
            this.TodayButton.Size = new System.Drawing.Size(58, 19);
            this.TodayButton.TabIndex = 9;
            this.TodayButton.Text = "Today";
            this.TodayButton.UseVisualStyleBackColor = true;
            this.TodayButton.Click += new System.EventHandler(this.TodayButton_Click);
            // 
            // PurchaseLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 145);
            this.Controls.Add(this.TodayButton);
            this.Controls.Add(this.DateTextBoxY);
            this.Controls.Add(this.DateTextBoxD);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.DateTextBoxM);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.CategoryTextBox);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.CategoryLabel);
            this.Name = "PurchaseLoggerForm";
            this.Text = "Purchase Logger 2.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.TextBox CategoryTextBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.TextBox DateTextBoxM;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.TextBox DateTextBoxD;
        private System.Windows.Forms.TextBox DateTextBoxY;
        private System.Windows.Forms.Button TodayButton;
    }
}

