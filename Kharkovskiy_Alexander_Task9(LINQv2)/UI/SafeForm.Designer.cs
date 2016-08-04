namespace UI
{
    partial class SafeForm
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
            this.SafeToXML = new System.Windows.Forms.GroupBox();
            this.PathXmlTB = new System.Windows.Forms.TextBox();
            this.SafeFileXmlButton = new System.Windows.Forms.Button();
            this.SafeToTxt = new System.Windows.Forms.GroupBox();
            this.PathTxtTB = new System.Windows.Forms.TextBox();
            this.SafeFileTxtButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SafeToXML.SuspendLayout();
            this.SafeToTxt.SuspendLayout();
            this.SuspendLayout();
            // 
            // SafeToXML
            // 
            this.SafeToXML.Controls.Add(this.PathXmlTB);
            this.SafeToXML.Controls.Add(this.SafeFileXmlButton);
            this.SafeToXML.Location = new System.Drawing.Point(14, 12);
            this.SafeToXML.Name = "SafeToXML";
            this.SafeToXML.Size = new System.Drawing.Size(258, 68);
            this.SafeToXML.TabIndex = 12;
            this.SafeToXML.TabStop = false;
            this.SafeToXML.Text = "Сохранить в XML";
            // 
            // PathXmlTB
            // 
            this.PathXmlTB.Location = new System.Drawing.Point(12, 33);
            this.PathXmlTB.Name = "PathXmlTB";
            this.PathXmlTB.Size = new System.Drawing.Size(156, 20);
            this.PathXmlTB.TabIndex = 1;
            this.PathXmlTB.Enter += new System.EventHandler(this.PathXmlTB_Enter);
            // 
            // SafeFileXmlButton
            // 
            this.SafeFileXmlButton.Location = new System.Drawing.Point(174, 33);
            this.SafeFileXmlButton.Name = "SafeFileXmlButton";
            this.SafeFileXmlButton.Size = new System.Drawing.Size(78, 23);
            this.SafeFileXmlButton.TabIndex = 0;
            this.SafeFileXmlButton.Text = "Сохранить";
            this.SafeFileXmlButton.UseVisualStyleBackColor = true;
            this.SafeFileXmlButton.Click += new System.EventHandler(this.SafeFileXmlButton_Click);
            // 
            // SafeToTxt
            // 
            this.SafeToTxt.Controls.Add(this.PathTxtTB);
            this.SafeToTxt.Controls.Add(this.SafeFileTxtButton);
            this.SafeToTxt.Location = new System.Drawing.Point(14, 86);
            this.SafeToTxt.Name = "SafeToTxt";
            this.SafeToTxt.Size = new System.Drawing.Size(258, 68);
            this.SafeToTxt.TabIndex = 12;
            this.SafeToTxt.TabStop = false;
            this.SafeToTxt.Text = "Сохранить в текстовый файл";
            // 
            // PathTxtTB
            // 
            this.PathTxtTB.Location = new System.Drawing.Point(12, 33);
            this.PathTxtTB.Name = "PathTxtTB";
            this.PathTxtTB.Size = new System.Drawing.Size(156, 20);
            this.PathTxtTB.TabIndex = 1;
            this.PathTxtTB.Enter += new System.EventHandler(this.PathTxtTB_Enter);
            // 
            // SafeFileTxtButton
            // 
            this.SafeFileTxtButton.Location = new System.Drawing.Point(174, 33);
            this.SafeFileTxtButton.Name = "SafeFileTxtButton";
            this.SafeFileTxtButton.Size = new System.Drawing.Size(78, 23);
            this.SafeFileTxtButton.TabIndex = 0;
            this.SafeFileTxtButton.Text = "Сохранить";
            this.SafeFileTxtButton.UseVisualStyleBackColor = true;
            this.SafeFileTxtButton.Click += new System.EventHandler(this.SafeFileTxtButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(197, 166);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 13;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SafeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 201);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SafeToTxt);
            this.Controls.Add(this.SafeToXML);
            this.Name = "SafeForm";
            this.Text = "SafeForm";
            this.SafeToXML.ResumeLayout(false);
            this.SafeToXML.PerformLayout();
            this.SafeToTxt.ResumeLayout(false);
            this.SafeToTxt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SafeToXML;
        private System.Windows.Forms.TextBox PathXmlTB;
        private System.Windows.Forms.Button SafeFileXmlButton;
        private System.Windows.Forms.GroupBox SafeToTxt;
        private System.Windows.Forms.TextBox PathTxtTB;
        private System.Windows.Forms.Button SafeFileTxtButton;
        private System.Windows.Forms.Button CloseButton;
    }
}