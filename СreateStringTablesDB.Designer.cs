using System.Data;

namespace Fitnes_3L
{
    partial class СreateStringTablesDB
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
            panel1 = new Panel();
            appButton = new Button();
            closeButton = new Button();
            groupBox1 = new GroupBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(appButton);
            panel1.Controls.Add(closeButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 245);
            panel1.Name = "panel1";
            panel1.Size = new Size(454, 35);
            panel1.TabIndex = 0;
            // 
            // appButton
            // 
            appButton.Dock = DockStyle.Right;
            appButton.Location = new Point(302, 0);
            appButton.Name = "appButton";
            appButton.Size = new Size(77, 35);
            appButton.TabIndex = 0;
            appButton.Text = "Добавить";
            appButton.UseVisualStyleBackColor = true;
            appButton.Click += addButton_Click;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.Location = new Point(379, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 35);
            closeButton.TabIndex = 1;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(454, 245);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // СreateStringTablesDB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 280);
            ControlBox = false;
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "СreateStringTablesDB";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Диалоговое окно";
            TransparencyKey = Color.WhiteSmoke;
            Shown += СreateStringTablesDB_Shown;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public string nameTable;
        public ListView listView;
        private Panel panel1;
        private Button appButton;
        private Button closeButton;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private DataSet dataSetWorker;
        private DataSet dataSetServic;
        private DataSet dataSetTraining;
    }
}