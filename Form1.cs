using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            saveConfigMsg.Visible = false;
            genPswMsg.Visible = false;
        }
        private void LoadData()
        {
            if (!File.Exists(_configFilePath))
            {
                MessageBox.Show("config.xml is not found.");
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
                using (FileStream fs = new FileStream(_configFilePath, FileMode.Open))
                {
                    _configData = (Config)serializer.Deserialize(fs);
                }

                if (_configData.Version != null)
                    txtVersion.Text = _configData.Version.Value;

                if (_configData.Uptime != null)
                    txtUptime.Text = _configData.Uptime.Value.ToString();

                dataGridViewAccounts.DataSource = null;
                dataGridViewAccounts.DataSource = _configData.Person.Accounts;

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
                MessageBox.Show("Error reading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SaveConfigBtn_Click(object sender, EventArgs e)
        {

            dataGridViewAccounts.EndEdit();

            _configData.Version.Value = txtVersion.Text;
            _configData.Uptime.Value = long.Parse(txtUptime.Text);

            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using (FileStream fs = new FileStream(_configFilePath, FileMode.Create))
            {
                serializer.Serialize(fs, _configData);
            }

            genPswMsg.Visible = true;
            genPswMsg.Text = "Configuration saved.";
        }

        private void generatePswBtn_Click(object sender, EventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count == 0)
            {
                genPswMsg.Visible = true;
                genPswMsg.Text = "Select at least one user from the table by clicking on the row header on the left.";
                return;
            }

            List<string> selectedUsernames = new List<string>();

            foreach (DataGridViewRow row in dataGridViewAccounts.SelectedRows)
            {
                if (row.DataBoundItem is Account account)
                {
                    selectedUsernames.Add(account.UserName);
                }
            }

            string scriptFileName = "gen_pass.sh";
            string args = string.Join(" ", selectedUsernames);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "bash"; 
            psi.Arguments = $"{scriptFileName} {args}";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true; 
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

          
            using (Process process = Process.Start(psi))
            {
                process.WaitForExit(); 
            }
            
            string resultFile = "generated_passwords.txt";

            if (!File.Exists(resultFile))
            {
                genPswMsg.Visible = true;
                genPswMsg.Text = "Passwords file was not created.";
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(resultFile);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string user = parts[0];
                        string newPass = parts[1];

                        // Kuriems vartotojams atnaujinti slaptažodį.
                        foreach (var acc in _configData.Person.Accounts)
                        {
                            if (acc.UserName == user)
                            {
                                acc.PasswordText = newPass;
                                acc.PasswordType = "plaintext";
                                break; 
                            }
                        }
                    }
                }

                dataGridViewAccounts.Refresh();

                File.Delete(resultFile);

                genPswMsg.Visible = true;
                genPswMsg.Text = $"Successfuly updated {lines.Length} passwords";
            }
            catch (Exception ex)
            {
                genPswMsg.Visible = true;
                genPswMsg.Text = "Klaida apdorojant rezultatus: " + ex.Message;
            }
        }
    }
}