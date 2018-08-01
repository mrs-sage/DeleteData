using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DeleteDataBases
{
    public partial class FormDeleteSQLDataBases : Form
    {
        internal static string ConnectionString { get; set; }

        public FormDeleteSQLDataBases()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string deletationSuccessMessage = "";
            string deletationErrorMessage = "";

            SqlConnection SqlConnection = new SqlConnection(ConnectionString);
            SqlConnection.Open();
            SqlCommand cmd;

            foreach (var item in checkedListDataBases.CheckedItems)
            {
                try
                {
                    string query = string.Format("Drop DataBase [{0}]", item.ToString());
                    cmd = new SqlCommand(query, SqlConnection);
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    deletationSuccessMessage += "- Base de dados «" + item.ToString() + "»" + Environment.NewLine;
                }
                catch
                {
                    deletationErrorMessage += "- Base de dados «" + item.ToString() + "»" + Environment.NewLine;
                }
            }


            if(deletationErrorMessage != "")
            {
                MessageBox.Show("Ocurreram erros na eliminação!" + Environment.NewLine + "Consulte o log!");
            }

            Log log = new Log();
            log.WriteInFile(deletationSuccessMessage, true, false);
            log.WriteInFile(deletationErrorMessage, true, true);
            log = null;
            deletationSuccessMessage = "";
            deletationErrorMessage = "";

            SqlConnection.Close();

            txtFilter.Text = "";
            FormDeleteSQLDataBases_Load(sender, e);

            var FileWriteSettings = new IniFile(Form1.ConfigFilepath);
            FileWriteSettings.Write("LastDelete", DateTime.Now.ToShortDateString(), "SQL");
            FileWriteSettings = null;

            lblLastElimination.Text = "Última eliminação: " + DateTime.Now.ToShortDateString();

           
        }

        private void FormDeleteSQLDataBases_Load(object sender, EventArgs e)
        {
            string query = "SELECT name from sys.databases Where name not in ('tempdb', 'msdb', 'model', 'master')";
            if (txtFilter.Text.Trim().Length > 0)
            {
                if (optComeca.Checked)
                {
                    query = string.Format("SELECT name from sys.databases Where name not in ('tempdb', 'msdb', 'model', 'master') and name  like '{0}%'", txtFilter.Text);
                }
                else
                {
                    query = string.Format("SELECT name from sys.databases Where name not in ('tempdb', 'msdb', 'model', 'master') and name  like '%{0}%'", txtFilter.Text);
                }
            }

            try
            {

                checkedListDataBases.Items.Clear();

                // Open connection to the database
                string conString = ConnectionString;


                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();

                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                checkedListDataBases.Items.Add(dr[0].ToString());
                            }

                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Instância desligada!");
            }

            var FileLoadSettings = new IniFile(Form1.ConfigFilepath);


            var lastElimination = "";
            try
            {
                lastElimination = FileLoadSettings.Read("LastDelete", "SQL");

                if (lastElimination == "")
                {
                    lastElimination = " --- ";
                }
            }
            catch
            {
                lastElimination = " --- ";
            }

            lblLastElimination.Text = "Última eliminação: " + lastElimination;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FormDeleteSQLDataBases_Load(sender, e);
        }

        private void picCheckAll_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < checkedListDataBases.Items.Count; i++)
            {
                checkedListDataBases.SetItemChecked(i, true);
            }
        }

        private void picUnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListDataBases.Items.Count; i++)
            {
                checkedListDataBases.SetItemChecked(i, false);
            }
        }
    }
}
