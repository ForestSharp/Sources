using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Fitnes_3L
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            timetableToolStripMenuItem = new ToolStripMenuItem();
            Catalog = new ToolStripMenuItem();
            workerToolStripMenuItem = new ToolStripMenuItem();
            fitnessServicesToolStripMenuItem = new ToolStripMenuItem();
            trainingToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            statusConnectToolStripStatusLabel1 = new ToolStripStatusLabel();
            tabControl = new TabControl();
            columnHeaderFullName = new ColumnHeader();
            columnHeaderFullNameTimetable = new ColumnHeader();
            columnHeaderDataBirthday = new ColumnHeader();
            columnHeaderAddress = new ColumnHeader();
            columnHeaderIdWorker = new ColumnHeader();
            columnHeaderIdServic = new ColumnHeader();
            columnHeaderIdTraining = new ColumnHeader();
            columnHeaderNameServic = new ColumnHeader();
            columnHeaderNameServicTimetable = new ColumnHeader();
            columnHeaderTypeTraining = new ColumnHeader();
            columnHeaderTypeTrainingTimetable = new ColumnHeader();
            columnHeaderData = new ColumnHeader();
            columnHeaderTime = new ColumnHeader();
            listViewWorker = new ListView();
            listViewServic = new ListView();
            listViewTraining = new ListView();
            listViewTimetable = new ListView();
            timerConnectionBaseCheck = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlDark;
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { timetableToolStripMenuItem, Catalog });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1148, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // timetableToolStripMenuItem
            // 
            timetableToolStripMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            timetableToolStripMenuItem.ForeColor = SystemColors.MenuText;
            timetableToolStripMenuItem.Name = "timetableToolStripMenuItem";
            timetableToolStripMenuItem.Overflow = ToolStripItemOverflow.AsNeeded;
            timetableToolStripMenuItem.Size = new Size(139, 23);
            timetableToolStripMenuItem.Text = "Расписание зала";
            timetableToolStripMenuItem.Click += timetableToolStripMenuItem_Click;
            // 
            // Catalog
            // 
            Catalog.DropDownItems.AddRange(new ToolStripItem[] { workerToolStripMenuItem, fitnessServicesToolStripMenuItem, trainingToolStripMenuItem });
            Catalog.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Catalog.ForeColor = SystemColors.MenuText;
            Catalog.Name = "Catalog";
            Catalog.Overflow = ToolStripItemOverflow.AsNeeded;
            Catalog.Size = new Size(75, 23);
            Catalog.Text = "Каталог";
            // 
            // workerToolStripMenuItem
            // 
            workerToolStripMenuItem.BackColor = SystemColors.ControlDark;
            workerToolStripMenuItem.Name = "workerToolStripMenuItem";
            workerToolStripMenuItem.Size = new Size(163, 24);
            workerToolStripMenuItem.Text = "Сотрудники";
            workerToolStripMenuItem.Click += workerToolStripMenuItem_Click;
            // 
            // fitnessServicesToolStripMenuItem
            // 
            fitnessServicesToolStripMenuItem.BackColor = SystemColors.ControlDark;
            fitnessServicesToolStripMenuItem.Name = "fitnessServicesToolStripMenuItem";
            fitnessServicesToolStripMenuItem.Size = new Size(163, 24);
            fitnessServicesToolStripMenuItem.Text = "Услуги";
            fitnessServicesToolStripMenuItem.Click += fitnessServicesToolStripMenuItem_Click;
            // 
            // trainingToolStripMenuItem
            // 
            trainingToolStripMenuItem.BackColor = SystemColors.ControlDark;
            trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            trainingToolStripMenuItem.Size = new Size(163, 24);
            trainingToolStripMenuItem.Text = "Тренировки";
            trainingToolStripMenuItem.Click += trainingToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.ControlDark;
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusConnectToolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 530);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1148, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusConnectToolStripStatusLabel1
            // 
            statusConnectToolStripStatusLabel1.Image = Properties.Resources.falseConnect;
            statusConnectToolStripStatusLabel1.ImageTransparentColor = SystemColors.AppWorkspace;
            statusConnectToolStripStatusLabel1.Name = "statusConnectToolStripStatusLabel1";
            statusConnectToolStripStatusLabel1.Size = new Size(149, 17);
            statusConnectToolStripStatusLabel1.Text = "Нет подключения к БД";
            statusConnectToolStripStatusLabel1.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.HotTrack = true;
            tabControl.ImeMode = ImeMode.NoControl;
            tabControl.Location = new Point(0, 27);
            tabControl.Name = "tabControl";
            tabControl.RightToLeft = RightToLeft.No;
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1148, 503);
            tabControl.TabIndex = 2;
            tabControl.Visible = false;
            // 
            // columnHeaderFullName
            // 
            columnHeaderFullName.Text = "ФИО";
            columnHeaderFullName.Width = 300;
            // 
            // columnHeaderFullNameTimetable
            // 
            columnHeaderFullNameTimetable.Text = "ФИО";
            columnHeaderFullNameTimetable.Width = 300;
            // 
            // columnHeaderDataBirthday
            // 
            columnHeaderDataBirthday.Text = "Дата рождения";
            columnHeaderDataBirthday.Width = 100;
            // 
            // columnHeaderAddress
            // 
            columnHeaderAddress.Text = "Адрес";
            columnHeaderAddress.Width = 300;
            // 
            // columnHeaderIdWorker
            // 
            columnHeaderIdWorker.Text = "ID";
            // 
            // columnHeaderIdServic
            // 
            columnHeaderIdServic.Text = "ID";
            // 
            // columnHeaderIdTraining
            // 
            columnHeaderIdTraining.Text = "ID";
            // 
            // columnHeaderNameServic
            // 
            columnHeaderNameServic.Text = "Наименование услуги";
            columnHeaderNameServic.Width = 300;
            // 
            // columnHeaderNameServicTimetable
            // 
            columnHeaderNameServicTimetable.Text = "Наименование услуги";
            columnHeaderNameServicTimetable.Width = 300;
            // 
            // columnHeaderTypeTraining
            // 
            columnHeaderTypeTraining.Text = "Вид тренировки";
            columnHeaderTypeTraining.Width = 300;
            // 
            // columnHeaderTypeTrainingTimetable
            // 
            columnHeaderTypeTrainingTimetable.Text = "Вид тренировки";
            columnHeaderTypeTrainingTimetable.Width = 300;
            // 
            // columnHeaderData
            // 
            columnHeaderData.Text = "Дата";
            columnHeaderData.Width = 100;
            // 
            // columnHeaderTime
            // 
            columnHeaderTime.Text = "Время";
            columnHeaderTime.Width = 100;
            // 
            // listViewWorker
            // 
            listViewWorker.BackColor = SystemColors.ControlDark;
            listViewWorker.Columns.AddRange(new ColumnHeader[] { columnHeaderIdWorker, columnHeaderFullName, columnHeaderAddress, columnHeaderDataBirthday });
            listViewWorker.Dock = DockStyle.Fill;
            listViewWorker.ForeColor = SystemColors.ControlText;
            listViewWorker.FullRowSelect = true;
            listViewWorker.GridLines = true;
            listViewWorker.Location = new Point(0, 0);
            listViewWorker.Name = "listViewWorker";
            listViewWorker.Size = new Size(121, 97);
            listViewWorker.TabIndex = 0;
            listViewWorker.UseCompatibleStateImageBehavior = false;
            listViewWorker.View = View.Details;
            // 
            // listViewServic
            // 
            listViewServic.BackColor = SystemColors.ControlDark;
            listViewServic.Columns.AddRange(new ColumnHeader[] { columnHeaderIdServic, columnHeaderNameServic });
            listViewServic.Dock = DockStyle.Fill;
            listViewServic.ForeColor = SystemColors.ControlText;
            listViewServic.FullRowSelect = true;
            listViewServic.GridLines = true;
            listViewServic.Location = new Point(0, 0);
            listViewServic.Name = "listViewServic";
            listViewServic.Size = new Size(121, 97);
            listViewServic.TabIndex = 0;
            listViewServic.UseCompatibleStateImageBehavior = false;
            listViewServic.View = View.Details;
            // 
            // listViewTraining
            // 
            listViewTraining.BackColor = SystemColors.ControlDark;
            listViewTraining.Columns.AddRange(new ColumnHeader[] { columnHeaderIdTraining, columnHeaderTypeTraining });
            listViewTraining.Dock = DockStyle.Fill;
            listViewTraining.ForeColor = SystemColors.ControlText;
            listViewTraining.FullRowSelect = true;
            listViewTraining.GridLines = true;
            listViewTraining.Location = new Point(0, 0);
            listViewTraining.Name = "listViewTraining";
            listViewTraining.Size = new Size(121, 97);
            listViewTraining.TabIndex = 0;
            listViewTraining.UseCompatibleStateImageBehavior = false;
            listViewTraining.View = View.Details;
            // 
            // listViewTimetable
            // 
            listViewTimetable.BackColor = SystemColors.ControlDark;
            listViewTimetable.Columns.AddRange(new ColumnHeader[] { columnHeaderData, columnHeaderTime, columnHeaderFullNameTimetable, columnHeaderNameServicTimetable, columnHeaderTypeTrainingTimetable });
            listViewTimetable.Dock = DockStyle.Fill;
            listViewTimetable.ForeColor = SystemColors.ControlText;
            listViewTimetable.FullRowSelect = true;
            listViewTimetable.GridLines = true;
            listViewTimetable.Location = new Point(0, 0);
            listViewTimetable.Name = "listViewTimetable";
            listViewTimetable.Size = new Size(121, 97);
            listViewTimetable.TabIndex = 0;
            listViewTimetable.UseCompatibleStateImageBehavior = false;
            listViewTimetable.View = View.Details;
            // 
            // timerConnectionBaseCheck
            // 
            timerConnectionBaseCheck.Enabled = true;
            timerConnectionBaseCheck.Interval = 5000;
            timerConnectionBaseCheck.Tick += timerConnectionBaseCheck_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1148, 552);
            Controls.Add(tabControl);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Фитнес центр 3L";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem Catalog;
        private ToolStripMenuItem timetableToolStripMenuItem;
        private ToolStripMenuItem workerToolStripMenuItem;
        private ToolStripMenuItem fitnessServicesToolStripMenuItem;
        private ToolStripMenuItem trainingToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusConnectToolStripStatusLabel1;
        private TabControl tabControl;
        private ListView listViewWorker;
        private ListView listViewServic;
        private ListView listViewTraining;
        private ListView listViewTimetable;
        private ColumnHeader columnHeaderFullName;
        private ColumnHeader columnHeaderFullNameTimetable;
        private ColumnHeader columnHeaderAddress;
        private ColumnHeader columnHeaderDataBirthday;
        private ColumnHeader columnHeaderIdWorker;
        private ColumnHeader columnHeaderIdServic;
        private ColumnHeader columnHeaderIdTraining;
        private ColumnHeader columnHeaderNameServic;
        private ColumnHeader columnHeaderNameServicTimetable;
        private ColumnHeader columnHeaderTypeTraining;
        private ColumnHeader columnHeaderTypeTrainingTimetable;
        private ColumnHeader columnHeaderData;
        private ColumnHeader columnHeaderTime;
        private System.Windows.Forms.Timer timerConnectionBaseCheck;
    }
}