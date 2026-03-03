using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using teltonika_homework;

namespace teltonika_homework
{
    public partial class Form1 : Form
    {
        private Config _configData;
        private string _configFilePath = "config.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (!File.Exists(_configFilePath))
            {
                MessageBox.Show("config.xml not found!");
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
                using (FileStream fs = new FileStream(_configFilePath, FileMode.Open))
                {
                    _configData = (Config)serializer.Deserialize(fs);
                }

                txtVersion.Text = _configData.Version.Value;
                txtUptime.Text = _configData.Uptime.Value.ToString();

                var bindingSource = new BindingSource();
                bindingSource.DataSource = _configData.Person.Accounts;
                dataGridViewAccounts.DataSource = bindingSource;

                if (dataGridViewAccounts.Columns["Password"] != null)
                {
                    dataGridViewAccounts.Columns["Password"].Visible = false;
                }

                if (dataGridViewAccounts.Columns["PasswordText"] != null)
                {
                    dataGridViewAccounts.Columns["PasswordText"].HeaderText = "Password";
                    dataGridViewAccounts.Columns["PasswordText"].DisplayIndex = 3;
                }

                if (dataGridViewAccounts.Columns["PasswordType"] != null)
                {
                    dataGridViewAccounts.Columns["PasswordType"].HeaderText = "Type";
                    dataGridViewAccounts.Columns["PasswordType"].DisplayIndex = 4;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading: " + ex.Message);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SaveConfig_Click(object sender, EventArgs e)
        {

        }

        private void GeneratePsw_Click(object sender, EventArgs e)
        {

        }

        private void LoadConfig_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}