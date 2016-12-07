using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ArmA_String_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string D1 = "1. Wählen Sie eine Datei oder ein Ordner aus",
            D2 = "2. Wählen Sie Beerkan's " + '"' + "ChangeText" + '"' + " Datei aus oder geben Sie es direkt ein",
            D3 = "3. Konvertieren",
            D4 = "Durchsuchen",
            D5 = "Datei",
            D6 = "Ordner",
            D7 = "Beerkan's " + '"' + "ChangeText" + '"' + " Datei",
            D8 = "Alter Text",
            D9 = "Neuer Text",
            D10 = "Select path",
            D11 = "Select file",
            D12 = "Text files(*.txt;*.hpp;*.htm;*.html;*.sqs;*.sqf;*.fsm;*.bifsm;*.sqm;*.cpp;*.xml;*.bikb)|*.txt;*.hpp;*.htm;*.html;*.sqs;*.sqf;*.fsm;*.bifsm;*.sqm;*.cpp;*.xml;*.bikb",
            D13 = "Beerkan's " + '"' + "ChangeText" + '"' + " file (*.txt)|*.txt",
            D14 = "Kovertieren",
            D15 = "Groß-/Kleinschreibung beachten (2x schneller)",
            D16 = "Nur ganze Wörter ersetzen",
            FileErrorMessage = "Can't access file:",
            PathErrorMessage = "Can't access path:",
            FileChangedMessage = "File changed:",
            SourceErrorMessage1 = "Wrong file: " + '"' + "{0}" + '"',
            SourceErrorMessage2 = "Wrong parameter (Spaces are not allowed): " + '"' + "{0}" + '"',
            DownloadErrorMesssage = "Server is unreachable",
            DownloadMesssage = "Please wait",
            FinalMessage = "Change(s): {0}\nFile(s): {1}\nTime: {2}ms",
            FilePath = "",
            FolderPath = "",
            TempPath = Path.GetTempPath() + @"ChangeText.txt",
            WholeWordFilter = "\\b",
            OldString, NewString;
        private string OwnVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        private List<string> ConvertStrings = new List<string>();
        private List<string> AllFilesToConvert = new List<string>();
        private List<string> AllActionMessages = new List<string>();
        private Stopwatch BenchTimer = new Stopwatch();
        private int ChangeCount = 0, ChangedFileCount = 0;
        private bool CaseSensitive = false;
//#1------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FileBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openConfigDialog = new OpenFileDialog();
                openConfigDialog.Title = D11;
                openConfigDialog.Filter = D12;
                if (FilePathBox.TextLength > 0)
                {
                    openConfigDialog.InitialDirectory = Path.GetDirectoryName(FilePathBox.Text);
                }
                else
                {
                    openConfigDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                DialogResult objResult = openConfigDialog.ShowDialog(this);
                if (objResult == DialogResult.OK)
                {
                    FilePathBox.Text = openConfigDialog.FileName;
                    FilePath = openConfigDialog.FileName;
                    if (FolderPathBox.TextLength > 0)
                    {
                        FolderPathBox.Text = "";
                        FolderPath = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class #1 Method #1\n" + ex.Message);
            }
        }
//#2------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FolderBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
                objDialog.Description = D10;
                if (FolderPathBox.TextLength > 0)
                {
                    objDialog.SelectedPath = FolderPathBox.Text;
                }
                else
                {
                    objDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                DialogResult objResult = objDialog.ShowDialog(this);
                if (objResult == DialogResult.OK)
                {
                    FolderPathBox.Text = objDialog.SelectedPath;
                    FolderPath = objDialog.SelectedPath;
                    if (FilePathBox.TextLength > 0)
                    {
                        FilePathBox.Text = "";
                        FilePath = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class #1 Method #2\n" + ex.Message);
            }
        }
//#3------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SourceBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                ActionBox.Items.Clear();
                OpenFileDialog openConfigDialog = new OpenFileDialog();
                openConfigDialog.Title = D11;
                openConfigDialog.Filter = D13;
                if (SourceFilePathBox.TextLength > 0)
                {
                    openConfigDialog.InitialDirectory = Path.GetDirectoryName(SourceFilePathBox.Text);
                }
                else
                {
                    openConfigDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                DialogResult objResult = openConfigDialog.ShowDialog(this);
                if (objResult == DialogResult.OK)
                {
                    SourceFilePathBox.Text = openConfigDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class #1 Method #3\n" + ex.Message);
            }
        }
//#4------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeCount = 0;
                ChangedFileCount = 0;
                ActionBox.Items.Clear();
                FileBrowse.Enabled = false;
                FolderBrowse.Enabled = false;
                SourceBrowse.Enabled = false;
                DownloadSourceButton.Enabled = false;
                ConvertButton.Enabled = false;
                OldStringTextBox.Enabled = false;
                NewStringTextBox.Enabled = false;
                CaseSensitiveCheckBox.Enabled = false;
                WholeWordCheckBox.Enabled = false;
                OldString = OldStringTextBox.Text;
                NewString = NewStringTextBox.Text;
                Thread WorkThread = new Thread(new ThreadStart(Threadhandler));
                WorkThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class #1 Method #4\n" + ex.Message);
            }
        }
//#5------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool ConvertString(string CurrentFilePath)
        {
            StringBuilder SourceText = new StringBuilder();
            try
            {
                SourceText.Append(File.ReadAllText(CurrentFilePath));
                int OldCount = ChangeCount;
                string NewSourceText = SourceText.ToString();
                for (int i = 0; i < ConvertStrings.Count; i += 2)
                {
                    if (CaseSensitive)
                    {
                        int ChangeCount2 = Regex.Matches(NewSourceText, WholeWordFilter + ConvertStrings[i] + WholeWordFilter).Count;
                        if (ChangeCount2 > 0)
                        {
                            NewSourceText = SourceText.Replace(WholeWordFilter + ConvertStrings[i] + WholeWordFilter, ConvertStrings[i + 1]).ToString();
                            ChangeCount += ChangeCount2;
                        }
                    }
                    else
                    {
                        int ChangeCount2 = Regex.Matches(NewSourceText, WholeWordFilter + ConvertStrings[i] + WholeWordFilter, RegexOptions.IgnoreCase).Count;
                        if (ChangeCount2 > 0)
                        {
                            NewSourceText = Regex.Replace(NewSourceText, WholeWordFilter + ConvertStrings[i] + WholeWordFilter, ConvertStrings[i + 1], RegexOptions.IgnoreCase);
                            ChangeCount += ChangeCount2;
                        }
                    }
                }
                if ((OldString.Length > 0) && (NewString.Length > 0))
                {
                    if (CaseSensitive)
                    {
                        int ChangeCount2 = Regex.Matches(NewSourceText, WholeWordFilter + OldString + WholeWordFilter).Count;
                        if (ChangeCount2 > 0)
                        {
                            NewSourceText = SourceText.Replace(WholeWordFilter + OldString + WholeWordFilter, NewString).ToString();
                            ChangeCount += ChangeCount2;
                        }
                    }
                    else
                    {
                        int ChangeCount2 = Regex.Matches(NewSourceText, WholeWordFilter + OldString + WholeWordFilter, RegexOptions.IgnoreCase).Count;
                        if (ChangeCount2 > 0)
                        {
                            NewSourceText = Regex.Replace(NewSourceText, WholeWordFilter + OldString + WholeWordFilter, NewString, RegexOptions.IgnoreCase);
                            ChangeCount += ChangeCount2;
                        }
                    }
                }
                if (ChangeCount > OldCount)
                {
                    File.Delete(CurrentFilePath);
                    File.WriteAllText(CurrentFilePath, NewSourceText);
                    AllActionMessages.Add(FileChangedMessage + CurrentFilePath);
                    ChangedFileCount++;
                }
            }
            catch
            {
                AllActionMessages.Add(FileErrorMessage + CurrentFilePath);
            }
            return true;
        }
//#6------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool CheckSubFolders(string FolderPath)
        {
            try
            {
                File.WriteAllText(FolderPath + @"\A2StringConverterWriteTest.txt", "");
                File.Delete(FolderPath + @"\A2StringConverterWriteTest.txt");
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.txt", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.hpp", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.htm", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.html", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.sqs", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.sqf", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.fsm", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.bifsm", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.sqm", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.cpp", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.xml", SearchOption.TopDirectoryOnly));
                AllFilesToConvert.AddRange(Directory.GetFiles(FolderPath, "*.bikb", SearchOption.TopDirectoryOnly));
                string[] TempFolders = Directory.GetDirectories(FolderPath, "*", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < TempFolders.Length; i++)
                {
                    CheckSubFolders(TempFolders[i]);
                }
                return true;
            }
            catch
            {
                AllActionMessages.Add(PathErrorMessage + FolderPath);
                return false;
            }
        }
//#7------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Threadhandler()
        {
            try
            {
                BenchTimer.Start();
                ProgressBar1.Invoke(new Action<int>(s => { ProgressBar1.Minimum = s; }), 0);
                ProgressBar1.Invoke(new Action<int>(s => { ProgressBar1.Maximum = s; }), 1);
                ProgressBar1.Invoke(new Action<int>(s => { ProgressBar1.Value = s; }), 0);
                AllFilesToConvert.Clear();
                AllActionMessages.Clear();
                if (FilePath.Length > 0)
                {
                    ConvertString(FilePath);
                    ProgressBar1.Invoke(new Action<int>(s => { ProgressBar1.Value = s; }), 1);
                }
                if (FolderPath.Length > 0)
                {
                    CheckSubFolders(FolderPath);
                    ProgressBar1.Invoke(new Action<int>(s => { ProgressBar1.Maximum = s; }), AllFilesToConvert.Count - 1);
                    for (int i = 0; i < AllFilesToConvert.Count; i++)
                    {
                        ConvertString(AllFilesToConvert[i]);
                        ProgressBar1.Invoke(new Action<int>(s => { ProgressBar1.Value = s; }), i);
                    }
                }
                MethodInvoker AddItems = delegate
                     {
                         for (int i = 0; i < AllActionMessages.Count; i++)
                         {
                             ActionBox.Items.Add(AllActionMessages[i]);
                         }
                     };
                ActionBox.BeginInvoke(AddItems);
                BenchTimer.Stop();
                MessageBox.Show(string.Format(FinalMessage, ChangeCount, ChangedFileCount, BenchTimer.ElapsedMilliseconds.ToString()));
                BenchTimer.Reset();
                FileBrowse.Invoke(new Action<bool>(s => { FileBrowse.Enabled = s; }), true);
                FolderBrowse.Invoke(new Action<bool>(s => { FolderBrowse.Enabled = s; }), true);
                ConvertButton.Invoke(new Action<bool>(s => { ConvertButton.Enabled = s; }), true);
                OldStringTextBox.Invoke(new Action<bool>(s => { OldStringTextBox.Enabled = s; }), true);
                NewStringTextBox.Invoke(new Action<bool>(s => { NewStringTextBox.Enabled = s; }), true);
                CaseSensitiveCheckBox.Invoke(new Action<bool>(s => { CaseSensitiveCheckBox.Enabled = s; }), true);
                WholeWordCheckBox.Invoke(new Action<bool>(s => { WholeWordCheckBox.Enabled = s; }), true);
                if (!SourceFilePathBox.Text.Equals(TempPath))
                {
                    SourceBrowse.Invoke(new Action<bool>(s => { SourceBrowse.Enabled = s; }), true);
                    DownloadSourceButton.Invoke(new Action<bool>(s => { DownloadSourceButton.Enabled = s; }), true);
                }
            }
            catch
            {
            }
        }
//#8------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FilePathBox_TextChanged(object sender, EventArgs e)
        {
            if (((FilePathBox.TextLength > 0) || (FolderPathBox.TextLength > 0)) && ((SourceFilePathBox.TextLength > 0) || ((OldStringTextBox.TextLength > 0) && (NewStringTextBox.TextLength > 0))))
            {
                ConvertButton.Enabled = true;
            }
            else
            {
                ConvertButton.Enabled = false;
            }
        }
//#9------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FolderPathBox_TextChanged(object sender, EventArgs e)
        {
            if (((FilePathBox.TextLength > 0) || (FolderPathBox.TextLength > 0)) && ((SourceFilePathBox.TextLength > 0) || ((OldStringTextBox.TextLength > 0) && (NewStringTextBox.TextLength > 0))))
            {
                ConvertButton.Enabled = true;
            }
            else
            {
                ConvertButton.Enabled = false;
            }
        }
//#10-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SourceFilePathBox_TextChanged(object sender, EventArgs e)
        {
            if (((FilePathBox.TextLength > 0) || (FolderPathBox.TextLength > 0)) && ((SourceFilePathBox.TextLength > 0) || ((OldStringTextBox.TextLength > 0) && (NewStringTextBox.TextLength > 0))))
            {
                ConvertButton.Enabled = true;
            }
            else
            {
                ConvertButton.Enabled = false;
            }
            if (SourceFilePathBox.TextLength > 0)
            {
                try
                {
                    string StringSource = File.ReadAllText(SourceFilePathBox.Text);
                    var SyncArray = new string[] { };
                    if (StringSource.Contains("\r\n"))
                    {
                        SyncArray = Regex.Split(StringSource, "\r\n");
                    }
                    else
                    {
                        SyncArray = Regex.Split(StringSource, "\n");
                    }
                    if ((SyncArray.Length > 1) && !SyncArray[0].Equals(string.Empty) && !SyncArray[1].Equals(string.Empty))
                    {
                        ConvertStrings.Clear();
                        for (int i = 0; i < SyncArray.Length; i++)
                        {
                            if ((SyncArray[i].Length > 0) && !SyncArray[i].Contains(" "))
                            {
                                ConvertStrings.Add(SyncArray[i]);
                            }
                            if ((SyncArray[i].Length > 0) && SyncArray[i].Contains(" "))
                            {
                                ActionBox.Items.Add(string.Format(SourceErrorMessage2, SyncArray[i]));
                                ConvertStrings.Clear();
                                SourceFilePathBox.Text = string.Empty;
                                break;
                            }
                        }
                        if (SourceFilePathBox.Text.Equals(TempPath))
                        {
                            SourceBrowse.Enabled = false;
                            DownloadSourceButton.Enabled = false;
                        }
                    }
                    else
                    {
                        ActionBox.Items.Add(string.Format(SourceErrorMessage1, SourceFilePathBox.Text));
                        SourceFilePathBox.Text = string.Empty;
                    }
                }
                catch
                {
                    MessageBox.Show(FileErrorMessage + SourceFilePathBox.Text);
                    SourceFilePathBox.Text = string.Empty;
                }
            }
        }
//#10-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void OldStringText_TextChanged(object sender, EventArgs e)
        {
            if (((FilePathBox.TextLength > 0) || (FolderPathBox.TextLength > 0)) && ((SourceFilePathBox.TextLength > 0) || ((OldStringTextBox.TextLength > 0) && (NewStringTextBox.TextLength > 0))))
            {
                ConvertButton.Enabled = true;
            }
            else
            {
                ConvertButton.Enabled = false;
            }
        }
//#12-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void NewStringText_TextChanged(object sender, EventArgs e)
        {
            if (((FilePathBox.TextLength > 0) || (FolderPathBox.TextLength > 0)) && ((SourceFilePathBox.TextLength > 0) || ((OldStringTextBox.TextLength > 0) && (NewStringTextBox.TextLength > 0))))
            {
                ConvertButton.Enabled = true;
            }
            else
            {
                ConvertButton.Enabled = false;
            }
        }
//#13-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
//#14-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void CaseSensitiveBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CaseSensitiveCheckBox.Checked)
            {
                CaseSensitive = true;
            }
            else
            {
                CaseSensitive = false;
            }
        }
//#15-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool Translate()
        {
            try
            {
                string Language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                if (Language.Equals("de"))
                {
                    Step1Box.Text = D1;
                    Step2Box.Text = D2;
                    Step3Box.Text = D3;
                    FileBrowse.Text = D4;
                    FolderBrowse.Text = D4;
                    SourceBrowse.Text = D4;
                    FileLabel.Text = D5;
                    FolderLabel.Text = D6;
                    SourceLabel.Text = D7;
                    OldStringLabel.Text = D8;
                    NewStringLabel.Text = D9;
                    D10 = "Pfad auswählen";
                    D11 = "Datei auswählen";
                    D12 = "Text Dateien(*.txt;*.hpp;*.htm;*.html;*.sqs;*.sqf;*.fsm;*.bifsm;*.sqm;*.cpp;*.xml;*.bikb)|*.txt;*.hpp;*.htm;*.html;*.sqs;*.sqf;*.fsm;*.bifsm;*.sqm;*.cpp;*.xml;*.bikb";
                    D13 = "Beerkan's " + '"' + "ChangeText" + '"' + " Datei (*.txt)|*.txt";
                    ConvertButton.Text = D14;
                    CaseSensitiveCheckBox.Text = D15;
                    WholeWordCheckBox.Text = D16;
                    FileErrorMessage = "Dateizugriff verweigert:";
                    PathErrorMessage = "Ordnerzugriff verweigert:";
                    SourceErrorMessage1 = "Falsche Datei: " + '"' + "{0}" + '"';
                    SourceErrorMessage2 = "Falscher Parameter (Leerzeichen sind nicht erlaubt): " + '"' + "{0}" + '"';
                    DownloadErrorMesssage = "Server ist nicht erreichbar";
                    DownloadMesssage = "Bitte warten";
                    FileChangedMessage = "Geänderte Datei:";
                    FinalMessage = "Änderung(en): {0}\nDatei(en): {1}\nZeit: {2}ms";
                    int NewLocationX = Step3Box.Location.X + Step3Box.Size.Width - CaseSensitiveCheckBox.Location.X - CaseSensitiveCheckBox.Size.Width;
                    ConvertButton.Location = new Point(NewLocationX + ((Step3Box.Location.X + Step3Box.Size.Width - NewLocationX) / 2) - (ConvertButton.Size.Width / 2) - 5, ConvertButton.Location.Y);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Class #1 Method #15\n" + ex.Message);
                Environment.Exit(0);
            }
            return true;
        }
//#16-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            Translate();
        }
//#17-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void DownloadSourceButton_Click(object sender, EventArgs e)
        {
            DownloadSourceButton.Enabled = false;
            DownloadSourceButton.Text = DownloadMesssage;
            Thread DownloadThread = new Thread(new ThreadStart(DownloadSource));
            DownloadThread.Start();
        }
//#18-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void DownloadSource()
        {
            try
            {
                if (File.Exists(TempPath))
                {
                    File.Delete(TempPath);
                }
                WebClient client1 = new WebClient();
                client1.Headers.Add("User-Agent", string.Format("ArmA String Converter - Version: {0}", OwnVersion));
                client1.Headers.Add("Accept", "*/*");
                client1.DownloadFileAsync(new Uri("https://dl.dropboxusercontent.com/u/19329173/ChangeText.txt"), TempPath);
                client1.DownloadFileCompleted += new AsyncCompletedEventHandler(client1_DownloadFileCompleted);
            }
            catch
            {
                MessageBox.Show(DownloadErrorMesssage);
                DownloadSourceButton.Invoke(new Action<bool>(s => { DownloadSourceButton.Enabled = s; }), false);
                DownloadSourceButton.Invoke(new Action<string>(s => { DownloadSourceButton.Text = s; }), "Download");
            }
        }
//#19-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        void client1_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadSourceButton.Invoke(new Action<bool>(s => { DownloadSourceButton.Enabled = s; }), true);
            DownloadSourceButton.Invoke(new Action<string>(s => { DownloadSourceButton.Text = s; }), "Download");
            if (!File.ReadAllText(TempPath).Equals(string.Empty))
            {
                SourceFilePathBox.Invoke(new Action<string>(s => { SourceFilePathBox.Text = s; }), TempPath);
            }
            else
            {
                MessageBox.Show(DownloadErrorMesssage);
            }
        }
//#20-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void WholeWordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (WholeWordCheckBox.Checked)
            {
                WholeWordFilter = "\\b";
            }
            else
            {
                WholeWordFilter = "";
            }
        }
    }
}
