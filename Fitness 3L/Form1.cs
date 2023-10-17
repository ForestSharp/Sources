using Fitnes_3L.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;


namespace Fitnes_3L
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createTabPage(string namePage)
        {
            int openTab = 0;

            foreach (TabPage tabPage in tabControl.TabPages)
                if (tabPage.Text == namePage)
                {
                    tabControl.SelectTab(tabPage);
                    openTab += 1;
                }

            if (openTab == 0)
            {
                TabPage newTabPage = new TabPage(namePage);

                TableLayoutPanel newTableLayoutPanelTop = CreateMenuEditString();

                newTabPage.BackColor = SystemColors.ControlDark;

                switch (namePage)
                {
                    case "����������":
                        readNewStringViewItems(namePage);
                        newTabPage.Controls.Add(listViewWorker);
                        break;
                    case "������":
                        readNewStringViewItems(namePage);
                        newTabPage.Controls.Add(listViewServic);
                        break;
                    case "����������":
                        readNewStringViewItems(namePage);
                        newTabPage.Controls.Add(listViewTraining);
                        break;
                    case "����������":
                        readNewStringViewItems(namePage);
                        newTabPage.Controls.Add(listViewTimetable);
                        break;
                }

                newTabPage.Controls.Add(newTableLayoutPanelTop);
                tabControl.TabPages.Add(newTabPage);
                tabControl.SelectTab(newTabPage);
            }
            visibleTabControl();
        }

        private void workerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTabPage("����������");
        }

        private void fitnessServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTabPage("������");
        }

        private void trainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTabPage("����������");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl.SelectedTab;
            clearListView((ListView)tabPage.Controls[0]);
            tabControl.TabPages.Remove(tabPage);

            visibleTabControl();
        }

        private void visibleTabControl()
        {
            if (tabControl.TabPages.Count != 0)
                tabControl.Visible = true;
            else
                tabControl.Visible = false;
        }

        private TableLayoutPanel CreateMenuEditString()
        {

            // ������������� ����������� 
            TableLayoutPanel newTableLayoutPanelTop = new TableLayoutPanel();

            newTableLayoutPanelTop.Name = "EditTableLayout";

            FlowLayoutPanel editFlowLayoutPanel = new FlowLayoutPanel();

            // ������������� � �������� ������ ���������� ��� ������ � ���������
            Button closeButton = CreateEditButton("�������");
            Button addButton = CreateEditButton("��������");
            Button editButton = CreateEditButton("�������������");
            Button deleteButton = CreateEditButton("�������");
            Button refreshButton = CreateEditButton("��������");

            // �������������� �������������� �����������
            editFlowLayoutPanel.Dock = DockStyle.Fill;

            newTableLayoutPanelTop.Dock = DockStyle.Top;
            newTableLayoutPanelTop.ColumnCount = 2;

            ColumnStyle columnStyle = new ColumnStyle(); // ����� ������� ��� ������ ���������� �� ��������������� ����� � ��
            columnStyle.SizeType = SizeType.Percent;
            columnStyle.Width = 100;

            newTableLayoutPanelTop.Height = 40;
            newTableLayoutPanelTop.ColumnStyles.Add(columnStyle);

            columnStyle = new ColumnStyle(); // ����� ������� ��� ������� �������� ������� �������
            columnStyle.SizeType = SizeType.Absolute;
            columnStyle.Width = 30;

            newTableLayoutPanelTop.ColumnStyles.Add(columnStyle);

            // ���������� ������ � ���������
            editFlowLayoutPanel.Controls.Add(addButton);
            //editFlowLayoutPanel.Controls.Add(editButton); 
            editFlowLayoutPanel.Controls.Add(deleteButton);
            editFlowLayoutPanel.Controls.Add(refreshButton);

            // ����������� ����������� � ����
            newTableLayoutPanelTop.Controls.Add(editFlowLayoutPanel);
            newTableLayoutPanelTop.Controls.Add(closeButton);

            return newTableLayoutPanelTop;
        }

        private Button CreateEditButton(string actionButton)
        {
            Button button = new Button();
            button.UseVisualStyleBackColor = true;
            button.Location = new System.Drawing.Point(3, 3);

            switch (actionButton)
            {
                case "��������":
                    button.Text = actionButton;
                    button.Size = new System.Drawing.Size(75, 23);
                    button.Click += addButton_Click;
                    break;
                case "�������������":
                    button.Text = actionButton;
                    button.Size = new System.Drawing.Size(100, 23);
                    button.Click += editButton_Click;
                    break;
                case "�������":
                    button.Size = new System.Drawing.Size(75, 23);
                    button.Text = actionButton;
                    button.Click += deleteButton_Click;
                    break;
                case "�������":
                    button.Text = "X";
                    button.Size = new System.Drawing.Size(23, 23);
                    button.Click += closeButton_Click;
                    break;
                case "��������":
                    button.Text = "��������";
                    button.Size = new System.Drawing.Size(80, 23);
                    button.Click += refreshButton_Click;
                    break;
            }

            return button;
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTabPage("����������");
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshListView();
        }

        public void refreshListView()
        {
            TabPage tabPage = tabControl.SelectedTab;
            clearListView((ListView)tabPage.Controls[0]);
            readNewStringViewItems(tabPage.Text);
        }

        private void clearListView(ListView listView)
        {
            listView.Items.Clear();
        }

        private void readNewStringViewItems(string nameTables)
        {
            // �������������� �����, ���� �������� ������ �� ��
            ConnectionSQL connectionSQL = new ConnectionSQL();
            SqlDataReader reader = connectionSQL.ReadTable(nameTables);

            ListViewItem newStringViewItem;
            if (reader.HasRows) // ���� ���� ������
            {
                while (reader.Read()) // ��������� ��������� ������
                {
                    switch (nameTables)
                    {
                        case "����������":
                            newStringViewItem = new ListViewItem();
                            newStringViewItem.Text = reader.GetValue("���_����������").ToString();
                            newStringViewItem.SubItems.AddRange(new string[] { reader.GetValue("���").ToString(),
                                reader.GetValue("�����").ToString(),
                                reader.GetValue("����_��������").ToString()});
                            listViewWorker.Items.Add(newStringViewItem);
                            break;
                        case "������":
                            newStringViewItem = new ListViewItem();
                            newStringViewItem.Text = reader.GetValue("���_������").ToString();
                            newStringViewItem.SubItems.AddRange(new string[] { reader.GetValue("������������ ������").ToString() });
                            listViewServic.Items.Add(newStringViewItem);
                            break;
                        case "����������":
                            newStringViewItem = new ListViewItem();
                            newStringViewItem.Text = reader.GetValue("���_����������").ToString();
                            newStringViewItem.SubItems.AddRange(new string[] { reader.GetValue("���_����������").ToString() });
                            listViewTraining.Items.Add(newStringViewItem);
                            break;
                        case "����������":
                            newStringViewItem = new ListViewItem();
                            newStringViewItem.Text = string.Format("{0:d}", reader.GetValue("����"));
                            newStringViewItem.SubItems.AddRange(new string[] { reader.GetValue("�����").ToString(),
                                reader.GetValue("���").ToString(),
                                reader.GetValue("������������ ������").ToString(),
                                reader.GetValue("���_����������").ToString()});
                            listViewTimetable.Items.Add(newStringViewItem);
                            break;
                    }
                }
            }
            connectionSQL.CloseConnection();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addNewStringDataBase();
        }

        private void addNewStringDataBase()
        {
            �reateStringTablesDB �reateStringTablesDB = new �reateStringTablesDB();
            TabPage tabPage = tabControl.SelectedTab;

            �reateStringTablesDB.nameTable = tabControl.SelectedTab.Text;
            �reateStringTablesDB.listView = (ListView)tabPage.Controls[0];
            �reateStringTablesDB.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteRecordFromTheDatabase();
        }


        private void deleteRecordFromTheDatabase()
        {
            ListView listView = new ListView();
            ListViewItem[] listViewItem = new ListViewItem[1];
            string nameTable = tabControl.SelectedTab.Text;

            listViewWorker.SelectedItems.CopyTo(listViewItem, 0);

            switch (nameTable)
            {
                case "����������":
                    listViewWorker.SelectedItems.CopyTo(listViewItem, 0);
                    listView = listViewWorker;
                    break;
                case "������":
                    listViewServic.SelectedItems.CopyTo(listViewItem, 0);
                    listView = listViewServic;
                    break;
                case "����������":
                    listViewTraining.SelectedItems.CopyTo(listViewItem, 0);
                    listView = listViewTraining;
                    break;
                case "����������":
                    listViewTimetable.SelectedItems.CopyTo(listViewItem, 0);
                    listView = listViewTraining;
                    break;
            }

            ConnectionSQL connectionSQL = new ConnectionSQL();

            int deleteNumber = connectionSQL.deleteRecordFromTheDatabase(listViewItem[0], nameTable);

            if (deleteNumber > 0)
            {
                clearListView(listView);
                readNewStringViewItems(nameTable);
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private async void timerConnectionBaseCheck_Tick(object sender, EventArgs e)
        {
            updateCheckConnection();
        }

        private async void updateCheckConnection()
        {
            ConnectionSQL connectionSQL = new ConnectionSQL();
            connectionSQL.AsyncOpenConnection();
            if(connectionSQL.CheckConnection())
            {
                statusConnectToolStripStatusLabel1.Text = "���� ����������� � ��";
                statusConnectToolStripStatusLabel1.Image = Resources.trueConnect;
                connectionSQL.CloseConnection();
            }
            else
            {
                statusConnectToolStripStatusLabel1.Text = "��� ����������� � ��";
                statusConnectToolStripStatusLabel1.Image = Resources.falseConnect;
            }
        }
    }
}