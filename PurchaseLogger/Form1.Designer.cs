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
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
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
            this.CategoryTextBox.Location = new System.Drawing.Point(82, 14);
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.Size = new System.Drawing.Size(100, 20);
            this.CategoryTextBox.TabIndex = 3;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(82, 44);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.ValueTextBox.TabIndex = 4;
            // 
            // DateTextBox
            // 
            this.DateTextBox.Location = new System.Drawing.Point(82, 74);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.Size = new System.Drawing.Size(100, 20);
            this.DateTextBox.TabIndex = 5;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(82, 101);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 6;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // PurchaseLoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 153);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.DateTextBox);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.CategoryTextBox);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.CategoryLabel);
            this.Name = "PurchaseLoggerForm";
            this.Text = "Purchase Logger 2.0";
            //this.Load += new System.EventHandler(this.PurchaseLoggerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.TextBox CategoryTextBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.TextBox DateTextBox;
        private System.Windows.Forms.Button SubmitButton;
    }
}

