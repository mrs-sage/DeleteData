using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.TaskScheduler;
using System.Diagnostics;

namespace DeleteDataBases
{
    public partial class Form1 : Form
    {

        internal static string ConfigFilepath = "";
        internal static string ConfigFolderPath = "";

        private const int FO_DELETE = 0x0003;
        private const int FOF_ALLOWUNDO = 0x0040;           // Preserve undo information, if possible. 
        private const int FOF_NOCONFIRMATION = 0x0010;      // Show no confirmation dialog box to the user

        // Struct which contains information that the SHFileOperation function uses to perform file operations. 
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEOPSTRUCT
        {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;
            public string pFrom;
            public string pTo;
            public short fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);


        public static void DeleteFileOrFolder(string path)
        {
            SHFILEOPSTRUCT fileop = new SHFILEOPSTRUCT();
            fileop.wFunc = FO_DELETE;
            fileop.pFrom = path + '\0' + '\0';
            fileop.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;
            SHFileOperation(ref fileop);
        }


        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void ValidateIfClose()
        {
            var dateSeparator = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;

            var FileLoadSettings = new IniFile(ConfigFilepath);

            string DateValue1 = "";
            string DateValue2 = "";
            try
            {
                DateValue1 = FileLoadSettings.Read("LastDelete", "SQL");
            }
            catch { }
            try
            {
                DateValue2 = FileLoadSettings.Read("LastDelete", "DataAnalysis");
            }
            catch { }

            int daysToDelete = 0;
            try
            {
                daysToDelete = Convert.ToInt32(FileLoadSettings.Read("WeeksToDeleteLocalData", "DataAnalysis"));
                daysToDelete = daysToDelete * 7;
            }
            catch
            {
                daysToDelete = 21;
            }


            if (DateValue1 != "" && DateValue2 != "")
            {
                if (DateValue1 != "" && DateValue2 == "")
                {
                    DateValue1 = DateValue1.Replace(".", dateSeparator);
                    DateValue1 = DateValue1.Replace("\\", dateSeparator);
                    DateValue1 = DateValue1.Replace("/", dateSeparator);
                    DateValue1 = DateValue1.Replace("-", dateSeparator);
                    DateTime date1 = DateTime.Parse(DateValue1);

                    DateTime currentDateNow = DateTime.Now;
                    var days = (currentDateNow - date1).TotalDays;
                    if (days <= daysToDelete)
                    {
                        Application.Exit();
                    }
                }
                else if (DateValue2 != "" && DateValue1 == "")
                {
                    DateValue2 = DateValue2.Replace(".", dateSeparator);
                    DateValue2 = DateValue2.Replace("\\", dateSeparator);
                    DateValue2 = DateValue2.Replace("/", dateSeparator);
                    DateValue2 = DateValue2.Replace("-", dateSeparator);
                    DateTime date2 = DateTime.Parse(DateValue2);

                    DateTime currentDateNow = DateTime.Now;
                    var days = (currentDateNow - date2).TotalDays;
                    if (days <= daysToDelete)
                    {
                        Application.Exit();
                    }
                }
                else if (DateValue1 != "" && DateValue2 != "")
                {
                    DateValue1 = DateValue1.Replace(".", dateSeparator);
                    DateValue1 = DateValue1.Replace("\\", dateSeparator);
                    DateValue1 = DateValue1.Replace("/", dateSeparator);
                    DateValue1 = DateValue1.Replace("-", dateSeparator);
                    DateTime date1 = DateTime.Parse(DateValue1);

                    DateValue2 = DateValue2.Replace(".", dateSeparator);
                    DateValue2 = DateValue2.Replace("\\", dateSeparator);
                    DateValue2 = DateValue2.Replace("/", dateSeparator);
                    DateValue2 = DateValue2.Replace("-", dateSeparator);
                    DateTime date2 = DateTime.Parse(DateValue2);

                    if (date1 > date2)
                    {
                        DateTime currentDateNow = DateTime.Now;
                        var days = (currentDateNow - date1).TotalDays;
                        if (days <= daysToDelete)
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        DateTime currentDateNow = DateTime.Now;
                        var days = (currentDateNow - date2).TotalDays;
                        if (days <= daysToDelete)
                        {
                            Application.Exit();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        listBoxSQLInstance.Items.Add("- " + Environment.MachineName + @"\" + instanceName);
                        //MessageBox.Show(Environment.MachineName + @"\" + instanceName);
                    }
                }

            }

            bool goToValidateifClose = true;

            try
            {
                string[] args = Environment.GetCommandLineArgs();
                string debug = args[1].ToString();

                if (debug.ToUpper() == "/DEBUG")
                {
                    goToValidateifClose = false;
                }
            }
            catch { }

            CreateData();

            if (goToValidateifClose)
            {
                ValidateIfClose();
            }

            SetData();

        }

        private void SetData()
        {
            var FileLoadSettings = new IniFile(ConfigFilepath);

            try
            {
                string SqlInstance = FileLoadSettings.Read("SqlInstance", "General");

                if (SqlInstance != "")
                {
                    string[] values = SqlInstance.Split('|');
                    foreach (var s in values)
                    {
                        listBoxSQLInstance.Items.Add("- " + Environment.MachineName + @"\" + s);
                    }
                }
            }
            catch
            {

            }

            var lastEliminationSQL = "";
            try
            {
                lastEliminationSQL = FileLoadSettings.Read("LastDelete", "SQL");

                if (lastEliminationSQL == "")
                {
                    lastEliminationSQL = " --- ";
                }
            }
            catch
            {
                lastEliminationSQL = " --- ";
            }

            lblLastElimination.Text = "Última eliminação: " + lastEliminationSQL;

            try
            {
                var TaskExist = FileLoadSettings.Read("TaskExist", "General");

                if (TaskExist != "1")
                {
                    CreateWindowsTask();
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                var DefaultInstace = Convert.ToInt32(FileLoadSettings.Read("DefaultInstace", "SQL"));
                listBoxSQLInstance.SetSelected(DefaultInstace, true);

            }
            catch (Exception ex)
            {

            }

            try
            {
                var weeksToDel = Convert.ToInt16(FileLoadSettings.Read("WeeksToDeleteLocalData", "DataAnalysis"));
                numericWeeks.Value = weeksToDel;
            }
            catch (Exception ex)
            {
                numericWeeks.Value = 3;
            }

            try
            {
                var folderPath = FileLoadSettings.Read("DataFolder", "DataAnalysis");

                bool existsFolder = System.IO.Directory.Exists(folderPath);
                if (existsFolder)
                {
                    TxtFolderPath.Text = folderPath;
                }
                else
                {
                    TxtFolderPath.Text = "";
                }


            }
            catch (Exception ex)
            {
                TxtFolderPath.Text = "";
            }


            var lastElimination = "";
            try
            {
                lastElimination = FileLoadSettings.Read("LastDelete", "DataAnalysis");

                if (lastElimination == "")
                {
                    lastElimination = " --- ";
                }
            }
            catch
            {
                lastElimination = " --- ";
            }
            lblLastLocalDelete.Text = "Última eliminação: " + lastElimination;

        }
        private void CreateData()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            folder += @"\LoreGDPR";

            ConfigFolderPath = folder;

            bool existsFolder = System.IO.Directory.Exists(folder);
            if (!existsFolder)
            {
                System.IO.Directory.CreateDirectory(folder);
            }

            existsFolder = System.IO.Directory.Exists(folder + @"\Logs");
            if (!existsFolder)
            {
                System.IO.Directory.CreateDirectory(folder + @"\Logs");
            }

            string PathToCurrentDirectory = folder + @"\Config.ini";
            ConfigFilepath = PathToCurrentDirectory;

            if (!File.Exists(PathToCurrentDirectory))
            {
                using (StreamWriter sw = File.CreateText(PathToCurrentDirectory))
                {
                    sw.WriteLine("[SQL]");
                    sw.WriteLine("DefaultInstace=");
                    sw.WriteLine("FilterType=");
                    sw.WriteLine("LastDelete=");
                    sw.WriteLine("[DataAnalysis]");
                    sw.WriteLine("DataFolder=");
                    sw.WriteLine("WeeksToDeleteLocalData=3");
                    sw.WriteLine("LastDelete=");
                    sw.WriteLine("[General]");
                    sw.WriteLine("TaskExist=");
                    sw.WriteLine("SqlInstance=");
                }


                try
                {
                    String fileName = String.Concat(Process.GetCurrentProcess().ProcessName, ".exe");
                    String filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                    File.Copy(filePath, ConfigFolderPath + @"\" + "DeleteDataBases.exe");
                }
                catch
                {

                }

                try
                {
                    String filePath = Path.Combine(Environment.CurrentDirectory, "Microsoft.Win32.TaskScheduler.dll");
                    File.Copy(filePath, ConfigFolderPath + @"\" + "Microsoft.Win32.TaskScheduler.dll");
                }
                catch
                {

                }
            }

            Log log = new Log();
            log.DeleteOldLogs();
            log = null;
        }

        private void CreateWindowsTask()
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    // Create a new task definition and assign properties
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Lore Sage Análise de Dados";

                    // Create a trigger that will fire the task at this time every other day
                    td.Triggers.Add(new DailyTrigger { DaysInterval = 9 });

                    td.Settings.StartWhenAvailable = true;
                    //td.Settings.UseUnifiedSchedulingEngine = true;


                    string app = Form1.ConfigFolderPath + @"\DeleteDataBases.exe";

                    // Create an action that will launch Notepad whenever the trigger fires
                    td.Actions.Add(new ExecAction(app, null, null));


                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition(@"Lore DataBases", td);

                    //// Remove the task we just created
                    //ts.RootFolder.DeleteTask("Test");


                    var FileWriteSettings = new IniFile(Form1.ConfigFilepath);
                    FileWriteSettings.Write("TaskExist", "1", "General");
                    FileWriteSettings = null;
                }
            }
            catch
            {
                MessageBox.Show("Tarefa não criada");
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string conString = "";
            bool error = true;
            bool haveDataBases = false;
            string sqlInstance = "";

            var sqlInstanceID = 0;
            foreach (var item in listBoxSQLInstance.SelectedItems)
            {
                sqlInstance = item.ToString();
                sqlInstanceID++;
            }

            try
            {
                sqlInstance = sqlInstance.Replace("- ", "");

                // Open connection to the database
                conString = string.Format("Server={0};Database={1};Integrated Security=True;MultipleActiveResultSets=true; timeout=5",
                                                       sqlInstance, "master");

                string query = "SELECT name from sys.databases Where name not in ('tempdb', 'msdb', 'model', 'master')";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();

                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            error = false;
                            while (dr.Read())
                            {
                                haveDataBases = true;
                            }

                        }
                    }
                }

            }
            catch
            {
                error = true;
                MessageBox.Show("Instância desligada!");
            }

            if (!error)
            {
                if (haveDataBases)
                {
                    var FileWriteSettings = new IniFile(Form1.ConfigFilepath);
                    FileWriteSettings.Write("DefaultInstace", sqlInstanceID.ToString(), "SQL");
                    FileWriteSettings = null;

                    FormDeleteSQLDataBases.ConnectionString = conString;
                    FormDeleteSQLDataBases formDeleteSQLDataBases = new FormDeleteSQLDataBases();
                    formDeleteSQLDataBases.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Instância sem base de dados!");
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void BtnOpenFolder_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            var dlg1 = new FolderBrowserDialog();
            dlg1.Description = "Select a folder to extract to:";
            dlg1.ShowNewFolderButton = true;
            //dlg1.NewStyle = false;
            dlg1.SelectedPath = TxtFolderPath.Text;
            dlg1.RootFolder = System.Environment.SpecialFolder.MyComputer;

            // Show the FolderBrowserDialog.
            DialogResult result = dlg1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TxtFolderPath.Text = dlg1.SelectedPath;

                var FileWriteSettings = new IniFile(Form1.ConfigFilepath);
                FileWriteSettings.Write("DataFolder", TxtFolderPath.Text, "DataAnalysis");
                FileWriteSettings = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TxtFolderPath.Text.Trim().Length > 0)
            {
                DeleteLocalData();
            }
            else
            {
                MessageBox.Show("Indique a pasta onde constam as base de dados!");
            }
        }

        private void DeleteLocalData()
        {
            int FilesLongerThanXdays = Convert.ToInt32(numericWeeks.Value) * 7;

            var path = TxtFolderPath.Text + "\\";

            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] directories = di.GetDirectories();

            string deletationSuccessMessage = "";
            string deletationErrorMessage = "";

            foreach (var directory in directories)
            {
                DateTime currentDateNow = Convert.ToDateTime(DateTime.Now.AddDays(-FilesLongerThanXdays).ToString("dd-MM-yyyy"));
                DateTime modification;

                if (optCreateDate.Checked)
                {
                    modification = Convert.ToDateTime(Directory.GetCreationTime(di + directory.Name).ToString("dd-MM-yyyy"));
                }
                else
                {
                    modification = Convert.ToDateTime(Directory.GetLastWriteTime(di + directory.Name).ToString("dd-MM-yyyy"));
                }

                if (modification <= currentDateNow)
                {
                    DirectoryInfo di_ = new DirectoryInfo(directory.FullName);
                    DirectoryInfo[] direc = di_.GetDirectories();

                    foreach (FileInfo file in di_.GetFiles())
                    {
                        FileInfo _file = new FileInfo(di_.FullName + @"\" + file);
                        if (IsFileLocked(_file))
                        {
                            deletationErrorMessage += "- Ficheiro «" + file + "» em " + file.DirectoryName + Environment.NewLine;
                            break;
                        }

                        try
                        {
                            DeleteFileOrFolder(di + @"\" + file);
                            //file.Delete();
                            deletationSuccessMessage += "- Ficheiro «" + file + "» em " + file.DirectoryName + Environment.NewLine + Environment.NewLine;

                        }
                        catch
                        {
                            deletationErrorMessage += "- Ficheiro «" + file + "» em " + file.DirectoryName + Environment.NewLine + Environment.NewLine;
                        }
                    }
                    foreach (DirectoryInfo dir in direc)
                    {
                        try
                        {
                            DeleteFileOrFolder(di_ + @"\" + dir);
                            //dir.Delete(true);
                            deletationSuccessMessage += "- Pasta «" + dir + "» em " + dir.FullName + Environment.NewLine + Environment.NewLine;
                        }
                        catch
                        {
                            deletationErrorMessage += "- Pasta «" + dir + "» em " + dir.FullName + Environment.NewLine + Environment.NewLine;
                        }
                    }
                    DeleteFileOrFolder(di + @"\" + directory);
                }
            }

            if (deletationErrorMessage != "")
            {
                MessageBox.Show("Ocorreram erros na eliminação!" + Environment.NewLine + "Consulte o log!");
            }

            Log log = new Log();
            log.WriteInFile(deletationSuccessMessage, false, false);
            log.WriteInFile(deletationErrorMessage, false, true);
            log = null;
            deletationSuccessMessage = "";
            deletationErrorMessage = "";

            foreach (FileInfo file in di.GetFiles())
            {
                FileInfo _file = new FileInfo(di.FullName + @"\" + file);
                if (IsFileLocked(_file))
                {
                    deletationErrorMessage += "- Ficheiro «" + file + "» em " + file.DirectoryName + Environment.NewLine;
                    break;
                }

                string filePath = di + @"\" + file.ToString();
                DateTime currentDateNow = Convert.ToDateTime(DateTime.Now.AddDays(-FilesLongerThanXdays).ToString("dd-MM-yyyy"));
                DateTime modification;

                if (optCreateDate.Checked)
                {
                    modification = Convert.ToDateTime(File.GetCreationTime(filePath).ToString("dd-MM-yyyy"));
                }
                else
                {
                    modification = Convert.ToDateTime(File.GetLastWriteTime(filePath).ToString("dd-MM-yyyy"));
                }

                if (modification <= currentDateNow)
                {
                    try
                    {
                        DeleteFileOrFolder(filePath);
                        deletationSuccessMessage += "- Ficheiro «" + file + "» em " + file.DirectoryName + Environment.NewLine;

                    }
                    catch
                    {
                        deletationErrorMessage += "- Ficheiro «" + file + "» em " + file.DirectoryName + Environment.NewLine;
                    }
                }
            }

            log = new Log();
            log.WriteInFile(deletationSuccessMessage, false, false);
            log.WriteInFile(deletationErrorMessage, false, true);
            log = null;


            var FileWriteSettings = new IniFile(ConfigFilepath);
            FileWriteSettings.Write("LastDelete", DateTime.Now.ToShortDateString(), "DataAnalysis");
            FileWriteSettings = null;

            lblLastLocalDelete.Text = "Última eliminação: " + DateTime.Now.ToShortDateString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ExecuteTxt("LogLocalData_" + DateTime.Now.Month.ToString("d2") + ".txt");
        }

        private void ExecuteTxt(string file)
        {
            file = ConfigFolderPath + @"\Logs\" + file;

            //if (File.Exists(file))
            //{
            //    System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //    proc.StartInfo.UseShellExecute = true;
            //    proc.StartInfo.FileName = file;
            //    proc.Start();
            //    proc.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Sem dados para apresentar!");
            //}
            txtLog.Text = "";
            try
            {
                var x = File.ReadAllText(file);
                txtLog.Text = x;
            }
            catch
            {
                txtLog.Text = "   ***   Nada a apresentar   ***   ";
            }
        }

        private void btnLocalError_Click(object sender, EventArgs e)
        {
            ExecuteTxt("ErrorLocalData_" + DateTime.Now.Month.ToString("d2") + ".txt");
        }

        private void btnSQLHistory_Click(object sender, EventArgs e)
        {
            ExecuteTxt("LogSQL_" + DateTime.Now.Month.ToString("d2") + ".txt");
        }

        private void btnSQLError_Click(object sender, EventArgs e)
        {
            ExecuteTxt("ErrorSQL_" + DateTime.Now.Month.ToString("d2") + ".txt");
        }

        private void numericWeeks_Validating(object sender, CancelEventArgs e)
        {

        }

        private void numericWeeks_ValueChanged(object sender, EventArgs e)
        {

            var FileWriteSettings = new IniFile(ConfigFilepath);
            FileWriteSettings.Write("WeeksToDeleteLocalData", numericWeeks.Value.ToString(), "DataAnalysis");
            FileWriteSettings = null;
        }
    }
}
