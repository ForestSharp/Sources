using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Fitnes_3L
{
    public partial class СreateStringTablesDB : Form
    {
        public СreateStringTablesDB()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void СreateStringTablesDB_Shown(object sender, EventArgs e)
        {
            switch (nameTable)
            {
                case "Сотрудники":
                    groupBox1.Text = "Добавить сотрудника";
                    createFormWorker();
                    break;
                case "Услуги":
                    groupBox1.Text = "Добавить услугу";
                    createFormServic();
                    break;
                case "Тренировки":
                    groupBox1.Text = "Добавить тренировку";
                    createFormTraining();
                    break;
                case "Расписание":
                    groupBox1.Text = "Добавить расписание";
                    PopulateDataTables();
                    createFormTimetable();
                    break;
            }
        }

        private void createFormWorker()
        {
            Label labelId = new Label();
            Label labelFullName = new Label();
            Label labelAddress = new Label();
            Label labelDataBithday = new Label();

            TextBox textBoxId = new TextBox();
            TextBox textBoxFullName = new TextBox();
            TextBox textBoxAddress = new TextBox();
            TextBox textBoxDataBithday = new TextBox();

            labelId.Text = "ID";
            labelFullName.Text = "ФИО";
            labelAddress.Text = "Адрес";
            labelDataBithday.Text = "Дата рождения";

            textBoxId.Name = "ID";
            textBoxAddress.Name = "Address";
            textBoxDataBithday.Name = "DataBithday";
            textBoxFullName.Name = "FullName";


            labelId.Location = new Point(10, 42);
            labelId.Width = 20;
            labelFullName.Location = new Point(10, 72);
            labelFullName.Width = 40;
            labelAddress.Location = new Point(10, 102);
            labelAddress.Width = 45;
            labelDataBithday.Location = new Point(10, 132);
            labelDataBithday.Width = 100;

            textBoxId.Location = new Point(55, 40);
            textBoxId.Width = 50;
            textBoxFullName.Location = new Point(55, 70);
            textBoxFullName.Width = 375;
            textBoxAddress.Location = new Point(55, 100);
            textBoxAddress.Width = 375;
            textBoxDataBithday.Location = new Point(115, 130);
            textBoxDataBithday.Width = 70;

            groupBox1.Controls.Add(labelId);
            groupBox1.Controls.Add(labelFullName);
            groupBox1.Controls.Add(labelAddress);
            groupBox1.Controls.Add(labelDataBithday);

            groupBox1.Controls.Add(textBoxId);
            groupBox1.Controls.Add(textBoxFullName);
            groupBox1.Controls.Add(textBoxAddress);
            groupBox1.Controls.Add(textBoxDataBithday);


        }

        private void createFormServic()
        {
            Label labelId = new Label();
            Label labelNameServic = new Label();

            TextBox textBoxId = new TextBox();
            TextBox textBoxNameServic = new TextBox();

            labelId.Text = "ID";
            labelNameServic.Text = "Наименование\nуслуги";

            textBoxId.Name = "ID";
            textBoxNameServic.Name = "NameServic";

            labelId.Location = new Point(10, 42);
            labelId.Width = 20;
            labelNameServic.Location = new Point(10, 72);
            labelNameServic.Width = 95;
            labelNameServic.Height = 40;

            textBoxId.Location = new Point(30, 40);
            textBoxId.Width = 50;
            textBoxNameServic.Location = new Point(105, 70);
            textBoxNameServic.Width = 340;

            groupBox1.Controls.Add(labelId);
            groupBox1.Controls.Add(labelNameServic);

            groupBox1.Controls.Add(textBoxId);
            groupBox1.Controls.Add(textBoxNameServic);
        }

        private void createFormTraining()
        {
            Label labelId = new Label();
            Label labelTypeTraining = new Label();

            TextBox textBoxId = new TextBox();
            TextBox textBoxTypeTraining = new TextBox();

            labelId.Text = "ID";
            labelTypeTraining.Text = "Вид\nтренировки";

            textBoxId.Name = "ID";
            labelTypeTraining.Name = "TypeTraining";

            labelId.Location = new Point(10, 42);
            labelId.Width = 20;
            labelTypeTraining.Location = new Point(10, 72);
            labelTypeTraining.Width = 75;
            labelTypeTraining.Height = 40;

            textBoxId.Location = new Point(30, 40);
            textBoxId.Width = 50;
            textBoxTypeTraining.Location = new Point(90, 70);
            textBoxTypeTraining.Width = 355;

            groupBox1.Controls.Add(labelId);
            groupBox1.Controls.Add(labelTypeTraining);

            groupBox1.Controls.Add(textBoxId);
            groupBox1.Controls.Add(textBoxTypeTraining);
        }

        private void createFormTimetable()
        {
            Label labelData = new Label();
            Label labelTime = new Label();
            Label labelFullName = new Label();
            Label labelNameServic = new Label();
            Label labelTypeTraining = new Label();

            DateTimePicker dateTimePickerData = new DateTimePicker();
            DateTimePicker dateTimePickerTime = new DateTimePicker();
            ComboBox comboBoxFullName = new ComboBox();
            ComboBox comboBoxNameServic = new ComboBox();
            ComboBox comboBoxTypeTraining = new ComboBox();

            labelData.Text = "Дата";
            labelTime.Text = "Время";
            labelFullName.Text = "ФИО";
            labelNameServic.Text = "Наименование\nуслуги";
            labelTypeTraining.Text = "Вид\nтренировки";

            dateTimePickerData.Name = "Data";
            dateTimePickerTime.Name = "Time";
            comboBoxFullName.Name = "FullName";
            comboBoxNameServic.Name = "NameServic";
            comboBoxTypeTraining.Name = "TypeTraining";

            labelData.Location = new Point(10, 42);
            labelData.Width = 40;
            labelTime.Location = new Point(10, 72);
            labelTime.Width = 45;
            labelFullName.Location = new Point(10, 102);
            labelFullName.Width = 40;
            labelNameServic.Location = new Point(10, 132);
            labelNameServic.Width = 95;
            labelNameServic.Height = 40;
            labelTypeTraining.Location = new Point(10, 172);
            labelTypeTraining.Width = 75;
            labelTypeTraining.Height = 40;

            dateTimePickerData.Location = new Point(55, 40);
            dateTimePickerData.Width = 75;
            dateTimePickerData.Format = DateTimePickerFormat.Short;
            dateTimePickerTime.Location = new Point(55, 70);
            dateTimePickerTime.Width = 75;
            dateTimePickerTime.Format = DateTimePickerFormat.Time;
            dateTimePickerTime.ShowUpDown = true;
            comboBoxFullName.Location = new Point(55, 100);
            comboBoxFullName.Width = 385;
            comboBoxNameServic.Location = new Point(110, 130);
            comboBoxNameServic.Width = 330;
            comboBoxTypeTraining.Location = new Point(110, 175);
            comboBoxTypeTraining.Width = 330;
            comboBoxFullName.DataSource = anArrayToPopulateTheCombobox(dataSetWorker);
            comboBoxNameServic.DataSource = anArrayToPopulateTheCombobox(dataSetServic);
            comboBoxTypeTraining.DataSource = anArrayToPopulateTheCombobox(dataSetTraining);

            groupBox1.Controls.Add(labelData);
            groupBox1.Controls.Add(labelTime);
            groupBox1.Controls.Add(labelFullName);
            groupBox1.Controls.Add(labelNameServic);
            groupBox1.Controls.Add(labelTypeTraining);

            groupBox1.Controls.Add(dateTimePickerData);
            groupBox1.Controls.Add(dateTimePickerTime);
            groupBox1.Controls.Add(comboBoxFullName);
            groupBox1.Controls.Add(comboBoxNameServic);
            groupBox1.Controls.Add(comboBoxTypeTraining);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addDatabase();
        }

        private void addDatabase()
        {
            preparingDataForWritingToTheDatabase();
        }

        private void preparingDataForWritingToTheDatabase()
        {
            Dictionary<string, string> dictData = new Dictionary<string, string>();

            fillingInDataForTheDatabase(dictData);

            ConnectionSQL connectionSQL = new ConnectionSQL();
            int numberInsert = connectionSQL.AddNewStringTables(nameTable, dictData);

            if (numberInsert > 0)
            {
                ListViewItem newStringViewItem = new ListViewItem();
                switch (nameTable)
                {
                    case "Сотрудники":
                        newStringViewItem.Text = dictData["Код_сотрудника"];
                        newStringViewItem.SubItems.AddRange(new string[] { dictData["ФИО"], dictData["Адрес"], dictData["Дата_рождения"] });
                        break;
                    case "Услуги":
                        newStringViewItem.Text = dictData["Код_услуги"];
                        newStringViewItem.SubItems.Add(dictData["Наименование услуги"]);
                        break;
                    case "Тренировки":
                        newStringViewItem.Text = dictData["Код_тренировки"];
                        newStringViewItem.SubItems.Add(dictData["Вид_тренировки"]);
                        break;
                    case "Расписание":
                        newStringViewItem.Text = dictData["Дата"];
                        newStringViewItem.SubItems.AddRange(new string[] { dictData["Время"], dictData["ФИО"], dictData["Наименование услуги"], dictData["Вид_тренировки"] });
                        break;
                }


                listView.Items.Add(newStringViewItem);

                Close();
            }
        }

        // Заполнение данных для записи в БД
        private void fillingInDataForTheDatabase(Dictionary<string, string> dicData)
        {
            switch (nameTable)
            {
                case "Сотрудники":
                    dicData.Add("Код_сотрудника", groupBox1.Controls[4].Text);
                    dicData.Add("ФИО", groupBox1.Controls[5].Text);
                    dicData.Add("Адрес", groupBox1.Controls[6].Text);
                    dicData.Add("Дата_рождения", groupBox1.Controls[7].Text);
                    break;
                case "Услуги":
                    dicData.Add("Код_услуги", groupBox1.Controls[2].Text);
                    dicData.Add("Наименование услуги", groupBox1.Controls[3].Text);
                    break;
                case "Тренировки":
                    dicData.Add("Код_тренировки", groupBox1.Controls[2].Text);
                    dicData.Add("Вид_тренировки", groupBox1.Controls[3].Text);
                    break;
                case "Расписание":
                    string[] idWorker = groupBox1.Controls[7].Text.Split();
                    string[] idServic = groupBox1.Controls[8].Text.Split();
                    string[] idTraining = groupBox1.Controls[9].Text.Split();

                    dicData.Add("Дата", groupBox1.Controls[5].Text);
                    dicData.Add("Время", groupBox1.Controls[6].Text);
                    dicData.Add("Код_сотрудника", idWorker[0]);
                    dicData.Add("Код_услуги", idServic[0]);
                    dicData.Add("Код_тренировки", idTraining[0]);
                    dicData.Add("ФИО", idWorker[1]);
                    dicData.Add("Наименование услуги", idServic[1]);
                    dicData.Add("Вид_тренировки", idTraining[1]);
                    break;
            }
        }

        private void PopulateDataTables()
        {
            ConnectionSQL connectionSQL = new ConnectionSQL();

            dataSetWorker = connectionSQL.ReadTablesDatabaseInDataSet("SELECT * FROM Сотрудники");
            dataSetServic = connectionSQL.ReadTablesDatabaseInDataSet("SELECT * FROM Услуги");
            dataSetTraining = connectionSQL.ReadTablesDatabaseInDataSet("SELECT * FROM Тренировки");
        }

        private List<string> anArrayToPopulateTheCombobox(DataSet dataSet)
        {
            List<string> arrayString = new List<string>();

            foreach (DataTable dt in dataSet.Tables)
                foreach (DataRow dataRow in dt.Rows)
                    arrayString.Add($"{dataRow.ItemArray[0].ToString()} {dataRow.ItemArray[1].ToString()}");

            return arrayString;
        }
    }


}
