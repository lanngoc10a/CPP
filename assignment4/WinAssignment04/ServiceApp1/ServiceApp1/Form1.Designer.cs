namespace ServiceApp1
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
            this.checkBoxCleaning = new System.Windows.Forms.CheckBox();
            this.checkBoxService = new System.Windows.Forms.CheckBox();
            this.checkBoxMaintenance = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.AddTextButton = new System.Windows.Forms.Button();
            this.roomNumbText = new System.Windows.Forms.TextBox();
            this.RoomNumbLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxCleaning
            // 
            this.checkBoxCleaning.AutoSize = true;
            this.checkBoxCleaning.Location = new System.Drawing.Point(12, 12);
            this.checkBoxCleaning.Name = "checkBoxCleaning";
            this.checkBoxCleaning.Size = new System.Drawing.Size(67, 17);
            this.checkBoxCleaning.TabIndex = 0;
            this.checkBoxCleaning.Text = "Cleaning";
            this.checkBoxCleaning.UseVisualStyleBackColor = true;
            this.checkBoxCleaning.Click += new System.EventHandler(this.checkBoxCleaning_Clicked);
            // 
            // checkBoxService
            // 
            this.checkBoxService.AutoSize = true;
            this.checkBoxService.Location = new System.Drawing.Point(98, 12);
            this.checkBoxService.Name = "checkBoxService";
            this.checkBoxService.Size = new System.Drawing.Size(62, 17);
            this.checkBoxService.TabIndex = 1;
            this.checkBoxService.Text = "Service";
            this.checkBoxService.UseVisualStyleBackColor = true;
            this.checkBoxService.Click += new System.EventHandler(this.checkBoxService_Clicked);
            // 
            // checkBoxMaintenance
            // 
            this.checkBoxMaintenance.AutoSize = true;
            this.checkBoxMaintenance.Location = new System.Drawing.Point(184, 12);
            this.checkBoxMaintenance.Name = "checkBoxMaintenance";
            this.checkBoxMaintenance.Size = new System.Drawing.Size(88, 17);
            this.checkBoxMaintenance.TabIndex = 2;
            this.checkBoxMaintenance.Text = "Maintenance";
            this.checkBoxMaintenance.UseVisualStyleBackColor = true;
            this.checkBoxMaintenance.Click += new System.EventHandler(this.checkBoxMaintenance_Clicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 350);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick2);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(278, 8);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // AddTextButton
            // 
            this.AddTextButton.Location = new System.Drawing.Point(661, 8);
            this.AddTextButton.Name = "AddTextButton";
            this.AddTextButton.Size = new System.Drawing.Size(75, 23);
            this.AddTextButton.TabIndex = 5;
            this.AddTextButton.Text = "Add text";
            this.AddTextButton.UseVisualStyleBackColor = true;
            this.AddTextButton.Click += new System.EventHandler(this.AddTextButton_Click);
            // 
            // roomNumbText
            // 
            this.roomNumbText.Location = new System.Drawing.Point(555, 8);
            this.roomNumbText.Name = "roomNumbText";
            this.roomNumbText.Size = new System.Drawing.Size(100, 20);
            this.roomNumbText.TabIndex = 6;
            // 
            // RoomNumbLabel
            // 
            this.RoomNumbLabel.AutoSize = true;
            this.RoomNumbLabel.Location = new System.Drawing.Point(476, 11);
            this.RoomNumbLabel.Name = "RoomNumbLabel";
            this.RoomNumbLabel.Size = new System.Drawing.Size(73, 13);
            this.RoomNumbLabel.TabIndex = 7;
            this.RoomNumbLabel.Text = "Room number";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RoomNumbLabel);
            this.Controls.Add(this.roomNumbText);
            this.Controls.Add(this.AddTextButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBoxMaintenance);
            this.Controls.Add(this.checkBoxService);
            this.Controls.Add(this.checkBoxCleaning);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCleaning;
        private System.Windows.Forms.CheckBox checkBoxService;
        private System.Windows.Forms.CheckBox checkBoxMaintenance;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button AddTextButton;
        private System.Windows.Forms.TextBox roomNumbText;
        private System.Windows.Forms.Label RoomNumbLabel;
    }
}

