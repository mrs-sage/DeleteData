using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DeleteDataBases
{
    internal class Log
    {
        private readonly string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\LoreGDPR\Logs\";


        private bool CreateFile(string FileName)
        {
            FileName = folderPath + FileName;
            bool IsNew = false;
            if (!File.Exists(FileName))
            {
                using (StreamWriter sw = File.CreateText(FileName)) { }
                IsNew = true;
            }
            return IsNew;
        }


        internal void WriteInFile(string Message, bool IsSql, bool IsError = false)
        {
            if (Message == "")
            {
                return;
            }

            if (IsSql)
            {
                if (IsError)
                {
                    string write = "*** Em " + DateTime.Now.ToString() + " | Erro ao eliminar:" + Environment.NewLine + Message;
                    string fileName = "ErrorSQL_" + DateTime.Now.Month.ToString("d2") + ".txt";
                    writeNow(fileName, write);
                }
                else
                {
                    string write = "*** Em " + DateTime.Now.ToString() + " | Eliminados:" + Environment.NewLine + Message;
                    string fileName = "LogSQL_" + DateTime.Now.Month.ToString("d2") + ".txt";
                    writeNow(fileName, write);
                }
            }
            else
            {
                if (IsError)
                {
                    string write = "*** Em " + DateTime.Now.ToString() + " | Erro ao eliminar:" + Environment.NewLine + Message;
                    string fileName = "ErrorLocalData_" + DateTime.Now.Month.ToString("d2") + ".txt";
                    writeNow(fileName, write);
                }
                else
                {
                    string write = "*** Em " + DateTime.Now.ToString() + " | Eliminados os seguintes ficheiros/pastas:" + Environment.NewLine + Message;
                    string fileName = "LogLocalData_" + DateTime.Now.Month.ToString("d2") + ".txt";
                    writeNow(fileName, write);
                }

            }
        }

        private void writeNow(string file, string Message)
        {
            string Enters = "";
            if (!CreateFile(file))
            {
                Enters = Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }

            string _message = Enters + Message;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(_message);
                File.AppendAllText(folderPath + file, sb.ToString());
                sb.Clear();
            }
            catch
            {
            }
        }


        internal void DeleteOldLogs()
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(folderPath);
                FileInfo[] Files = d.GetFiles();
                foreach (FileInfo file in Files)
                {
                    var myFile = file.ToString();

                    if (myFile.Contains(DateTime.Now.Month.ToString("d2")))
                    {

                    }
                    else
                    {
                        file.Delete();
                    }
                }
            }
            catch { }
        }

    }
}
