using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Host.Mef;

namespace NotepadPlusPlus
{ 
    public partial class MainForm : Form
    {
        private string _filePath = string.Empty;
        private readonly List<string> _openedFilesList = new List<string>();
        private int _timeleft = 300;
        private int _newTime;
        private int _filesNew;

        private int _backupCount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void NewFormTool_Click(object sender, EventArgs e)
        {
            var newNotepad = new MainForm();
            newNotepad.Show();
        }

        private void NewFileInterval(string path)
        {
            StreamWriter streamWriter = new StreamWriter(
                path,
                false,
                Encoding.Default);
            if (path.Contains(".rtf"))
                streamWriter.WriteLine(SelectedTab().Rtf);
            else
                streamWriter.WriteLine(SelectedTab().Text);

            streamWriter.Close();
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                _timeleft--;

                if (_timeleft <= 0)
                {
                    timerInterval.Stop();
                    string path = $@"backup/BackupMainFormText {_backupCount++}.rtf";
                    TabControl.TabPageCollection tabcoll = tabOption.TabPages;
                    TabPage tb = tabOption.SelectedTab;

                    foreach (TabPage tabPage in tabcoll)
                    {
                        SelectedTab().SaveFile(path);
                        SelectedTab().SaveFile(tb.AccessibleDescription);
                        File.AppendAllText("DataHistoryEditor.txt", tb.AccessibleDescription + Environment.NewLine);
                    }

                    _timeleft = _newTime;
                    timerInterval.Start();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void UpdateDocumentSelectorList()
        {
            TabControl.TabPageCollection tabcoll = tabOption.TabPages;
            treeView1.Nodes.Clear();
            foreach (TabPage tabPage in tabcoll)
            {
                string fileName = tabPage.Text;
                Color color;
                if (fileName.Contains("*"))
                    fileName = fileName.Remove(fileName.Length - 1);
                if (fileName.Contains("Untitled"))
                    color = Color.FromArgb(245, 255, 245);
                else
                    color = Color.FromArgb(255, 250, 250);

                TreeNode trnode = new TreeNode { Text = fileName, BackColor = color };
                treeView1.Nodes.Add(trnode);
            }
        }

        private void NewFile_Click(object sender, EventArgs e)
        {
            try
            {
                Text = @"NotePad (PeerGrade Version)";

                RichTextBox rtb = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    ContextMenuStrip = contextOption
                };

                TabPage tb = new TabPage { Text = $@"Untitled ({++_filesNew})"};
                tb.Controls.Add(rtb);


                tabOption.SelectedTab = tb;
                tabOption.TabPages.Add(tb);

                var richTextBox1 = tabOption.TabPages[tabOption.SelectedIndex].Controls[0];
                richTextBox1.Select();

                UpdateDocumentSelectorList();
                // add contextmenustrip to richTextBox1
                richTextBox1.TextChanged += RichTextBox_TextChanged;
                richTextBox1.ContextMenuStrip = contextOption;
                _openedFilesList.Add(tb.Text);
                Text = @"Untitled " + _filesNew + @" Notepad (Peergrade Version)";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                TabPage tabpage = new TabPage();
                RichTextBox richText = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    ContextMenuStrip = contextOption
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    tabOption.SelectedTab = tabpage;
                    tabpage.Controls.Add(richText);
                    tabOption.TabPages.Add(tabpage);
                    if (openFile.FileName.Contains(".rtf"))
                        richText.Rtf = File.ReadAllText(openFile.FileName);
                    else
                        richText.Text = File.ReadAllText(openFile.FileName);

                    richText.TextChanged += RichTextBox_TextChanged;
                    tabpage.Text = openFile.SafeFileName;
                    _filePath = openFile.FileName;
                    Text = $@"{_filePath} NotePad (PeerGrade Version)";
                    tabpage.AccessibleDescription = openFile.FileName;
                    File.AppendAllText("DataHistoryEditor.txt", _filePath + Environment.NewLine);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

      

        private void SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabOption.TabCount >= 1)
                {
                    TabPage tabPage = tabOption.SelectedTab;
                    if (tabPage.Text.Contains("Untitled"))
                    {
                        TabControl.TabPageCollection tabcoll = tabOption.TabPages;
                        foreach (TabPage tabpage in tabcoll)
                        {
                            DialogResult dg = MessageBox.Show(
                                @"Хотите ли вы сохранить файл " + tabpage.Text,
                                @"Да или Нет",
                                MessageBoxButtons.YesNoCancel);
                            if (dg == DialogResult.Yes)
                            {
                                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                                {
                                    Filter =
                                        "Текстовый документ (*.txt)|*.txt|C# (*.cs)|*.cs|JavaScript (*.js)|*.js|HTML (*.html)|*.html|CSS (*.css)|*.css|RTF (*.rtf)|*.rtf|Все файлы (*.)|*."
                                };

                                if (!tabpage.Text.Contains("Untitled"))
                                {
                                    NewFileInterval(tabpage.AccessibleDescription);
                                    _filePath = tabpage.AccessibleDescription;
                                    tabpage.AccessibleDescription = openFile.FileName;
                                    Text = $@"{tabpage.AccessibleDescription} NotePad (PeerGrade Version)";
                                    File.AppendAllText("DataHistoryEditor.txt", _filePath + Environment.NewLine);
                                }
                                else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    NewFileInterval(saveFileDialog1.FileName);
                                    Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                                    openFile.FileName = saveFileDialog1.FileName;
                                    tabpage.AccessibleDescription = openFile.FileName;
                                    tabpage.Text = openFile.SafeFileName;
                                    _filePath = saveFileDialog1.FileName;
                                    File.AppendAllText("DataHistoryEditor.txt", _filePath + Environment.NewLine);
                                }
                            }
                            else if (dg == DialogResult.Cancel)
                            {
                                tabOption.Select();
                                break;
                            }
                        }

                    }
                    else
                    {
                        NewFileInterval(path: tabPage.AccessibleDescription);
                        Text = $@"{tabPage.AccessibleDescription} NotePad (PeerGrade Version)";
                        File.AppendAllText("DataHistoryEditor.txt", _filePath + Environment.NewLine);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SaveFileButton(object sender, EventArgs e) => SaveFile_Click(sender, e);

        private RichTextBox SelectedTab()
        {
            RichTextBox richTextBox = null;
                TabPage tabpage = tabOption.SelectedTab;
                foreach (var c in tabpage.Controls)
                    if (c is RichTextBox box)
                        richTextBox = box;
                return richTextBox;
        }

        private void SaveAsFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabOption.TabCount >= 1)
                {
                    TabPage tabPage = tabOption.SelectedTab;
                    if (!tabPage.Text.Contains("Untitled"))
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog
                        {
                            Filter =
                                "Текстовый документ (*.txt)|*.txt|C# (*.cs)|*.cs|JavaScript (*.js)|*.js|HTML (*.html)|*.html|CSS (*.css)|*.css|RTF (*.rtf)|*.rtf|Все файлы (*.)|*."
                        };

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            NewFileInterval(saveFileDialog1.FileName);
                            Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                            openFile.FileName = saveFileDialog1.FileName;
                            tabPage.Text = openFile.SafeFileName;
                            tabPage.AccessibleDescription = saveFileDialog1.FileName;
                        }
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog
                        {
                            Filter =
                                "Текстовый документ (*.txt)|*.txt|C# (*.cs)|*.cs|JavaScript (*.js)|*.js|HTML (*.html)|*.html|CSS (*.css)|*.css|RTF (*.rtf)|*.rtf|Все файлы (*.)|*."
                        };

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            NewFileInterval(saveFileDialog1.FileName);
                            Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                            openFile.FileName = saveFileDialog1.FileName;
                            tabPage.Text = openFile.SafeFileName;
                            tabPage.AccessibleDescription = saveFileDialog1.FileName;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ExitTool_Click(object sender, EventArgs e) => Application.Exit();

        private void NewFile_Button(object sender, EventArgs e) => NewFile_Click(sender, e);

        private void OpenFile_Button(object sender, EventArgs e) => OpenFile_Click(sender, e);

        private void SaveAs_Button(object sender, EventArgs e) => SaveAsFile_Click(sender, e);

        private void CopyText_Click(object sender, EventArgs e)
        {
            if (SelectedTab().TextLength > 0)
                SelectedTab().Copy();
        }

        private void PasteText_Click(object sender, EventArgs e)
        {
            if (SelectedTab().TextLength > 0)
                SelectedTab().Paste();
        }

        private void CutText_Click(object sender, EventArgs e)
        {
            if (SelectedTab().TextLength > 0)
                SelectedTab().Cut();
        }

        private void FontOption_Click(object sender, EventArgs e)
        {
            try
            {
                fontOption.ShowDialog();
                SelectedTab().Font = fontOption.Font;
                SelectedTab().ForeColor = fontOption.Color;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BackgroundTextTheme(object sender, EventArgs e)
        {
            try
            {
                colorOption.ShowDialog();
                SelectedTab().BackColor = colorOption.Color;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SelectMenu_Click(object sender, EventArgs e)
        {
            if (SelectedTab().TextLength > 0)
                SelectedTab().SelectAll();
        }
        private void CopyTextMenu_Click(object sender, EventArgs e) => CopyText_Click(sender, e);

        private void PasteMenu_Click(object sender, EventArgs e) => PasteText_Click(sender, e);

        private void CutMenu_Click(object sender, EventArgs e) => CutText_Click(sender, e);

        private void SelectAllMenu_Click(object sender, EventArgs e)
        {
            if (SelectedTab().TextLength > 0)
                SelectedTab().SelectAll();
        }

        /// <summary>
        /// The black theme_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BlackTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerMainForm(mainMenu, fastToolButton, statusTextEditor, tabOption,SelectedTab(), treeView1, Color.Black, Color.White);
            BackColor = Color.Black;
        }

        private void HackerTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerMainForm(mainMenu, fastToolButton, statusTextEditor, tabOption,SelectedTab(), treeView1,Color.Black, Color.LawnGreen);
            BackColor = Color.Black; 
        }

        private void DefaultTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerMainForm(mainMenu, fastToolButton, statusTextEditor, tabOption,SelectedTab(), treeView1, DefaultBackColor, DefaultForeColor);
            BackColor = DefaultBackColor;
        }



        private void BackButton_Click(object sender, EventArgs e) => UndoToolStripMenu_Click(sender, e);

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            SelectedTab().Redo();
        }

        private void CutButton_Click(object sender, EventArgs e) => CutMenu_Click(sender, e);

        private void CopyButton_Click(object sender, EventArgs e) => CopyTextMenu_Click(sender, e);

        private void SelectAll_Click(object sender, EventArgs e) => SelectAllMenu_Click(sender, e);

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedTab().ZoomFactor < 50)
                    SelectedTab().ZoomFactor += 2;
                else
                    // It's my max zoom in value
                    MessageBox.Show(@"Размер увеличения текстового окна выше 50!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedTab().ZoomFactor < 2)
                    SelectedTab().ZoomFactor = 0;
                else
                    SelectedTab().ZoomFactor -= 2;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ForeColorTheme_Click(object sender, EventArgs e)
        {
            colorOption.ShowDialog();
            SelectedTab().ForeColor = colorOption.Color;
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = SelectedTab().Text;
                string[] lines = text.Split('\n');
                statusLabel.Text = $@"Символов: {text.Length}";
                rowsInfo.Text = $@"Строк: {lines.Length}";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void FontOptionButton_Click(object sender, EventArgs e) => FontOption_Click(sender, e);

        private void CsharpEditor_Click(object sender, EventArgs e)
        {
            DeveloperEditor developerEditor = new DeveloperEditor();
            developerEditor.ShowDialog();
        }


        private void BoldToolButton_Click(object sender, EventArgs e) => BoldToolStripMenuItem_Click(sender, e);

        private void UnderlineToolButton_Click(object sender, EventArgs e) => UnderLinedToolStripMenuItem_Click(sender, e);

        private void ItalicToolButton_Click(object sender, EventArgs e) => ItalicToolStripMenuItem_Click(sender, e);

        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedTab().SelectionFont = new Font(
                    SelectedTab().SelectionFont,
                    FontStyle.Bold ^ SelectedTab().SelectionFont.Style);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedTab().SelectionFont = new Font(
                    SelectedTab().SelectionFont,
                    FontStyle.Italic ^ SelectedTab().SelectionFont.Style);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void UnderLinedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedTab().SelectionFont = new Font(
                    SelectedTab().SelectionFont,
                    FontStyle.Underline ^ SelectedTab().SelectionFont.Style);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void StrikeOutToolStripItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedTab().SelectionFont = new Font(
                    SelectedTab().SelectionFont,
                    FontStyle.Strikeout ^ SelectedTab().SelectionFont.Style);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary> The undo tool strip menu_ click. </summary>
        /// <param name="sender">The sender.
        /// </param>
        /// <param name="e"> The e.
        /// </param>
        private void UndoToolStripMenu_Click(object sender, EventArgs e) => SelectedTab().Undo();

        /// <summary>
        /// The tool strip redo item
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e) => SelectedTab().Redo();

        private void PrintButton_Click(object sender, EventArgs e)
        {

            try
            {
                PrintDialog printDlg = new PrintDialog();
                PrintDocument printDoc = new PrintDocument { DocumentName = "Print Document" };

                printDlg.Document = printDoc;
                printDlg.AllowSelection = true;
                printDlg.AllowSomePages = true;
                //Call ShowDialog  
                if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void LeftSideToolStripMenuItem_Click(object sender, EventArgs e) => SelectedTab().SelectionAlignment = HorizontalAlignment.Left;

        private void MiddleToolStripMenuItem_Click(object sender, EventArgs e) => SelectedTab().SelectionAlignment = HorizontalAlignment.Center;

        private void RightSideToolStripMenuItem_Click(object sender, EventArgs e) => SelectedTab().SelectionAlignment = HorizontalAlignment.Right;

        private void FirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timeleft = 300;
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        private void SecondTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timeleft = 600;
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        private void ThirdTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timeleft = 1200;
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerInterval.Stop();
            saveIntervalMenuItem.ShortcutKeyDisplayString = "OFF";
            _timeleft = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (tabOption.TabCount > 0)
                {
                    TabControl.TabPageCollection tabcoll = tabOption.TabPages;
                    foreach (TabPage tabpage in tabcoll)
                    {
                        tabOption.SelectedTab = tabpage;
                        if (tabpage.Text.Contains("Untitled"))
                        {
                            SaveFile_Click(sender, e);
                            break;
                        }
                        tabOption.TabPages.Remove(tabpage);
                        TabOption_SelectedIndexChanged(sender, e);
                        

                        _filePath = tabpage.AccessibleDescription;
                        string[] arrPages = File.ReadAllLines("DataHistoryEditor.txt");
                        for (int i = 0; i < arrPages.Length; i++)
                            if (!arrPages[i].Contains(_filePath))
                                File.AppendAllText("DataHistoryEditor.txt", _filePath + Environment.NewLine);
                    }
                }
                File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Closing MainForm {Environment.NewLine}");

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        void TimerStart()
        {
            _newTime = _timeleft;
            timerInterval.Interval = 1000;
            timerInterval.Start();
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Tick += Timer_Tick;
            timerInterval.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                string[] arrPages = File.ReadAllLines("DataHistoryEditor.txt");
                TimerStart();
                if (tabOption.TabCount == 0)
                {
                    NewFile_Click(sender, e);
                }
                if (arrPages.Length >= 1)
                {
                    for (int i = 0; i < arrPages.Length; i++)
                    {
                        var sent = arrPages[i].Trim(' ').Split(' ').Distinct(StringComparer.CurrentCultureIgnoreCase);
                        File.WriteAllLines("DataHistoryEditor.txt", sent);
                        RichTextBox fctText = new RichTextBox
                        {
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None,
                            ContextMenuStrip = contextOption
                        };
                        openFile.FileName = arrPages[i];
                        if (openFile.CheckFileExists)
                        {
                            if (arrPages[i].Contains(".rtf"))
                                fctText.Rtf = File.ReadAllText(arrPages[i]);
                            else
                                fctText.Text = File.ReadAllText(arrPages[i]);

                            TabPage tabpage = new TabPage
                            {
                                Controls = { fctText },
                                Text = openFile.SafeFileName,
                                AccessibleDescription = openFile.FileName,
                                ContextMenuStrip = tabControlContextMenu
                            };
                            tabOption.SelectedTab = tabpage;
                            tabOption.TabPages.Add(tabpage);
                        }
                        UpdateDocumentSelectorList();
                    }
                    tabOption.ContextMenuStrip = tabControlContextMenu;
                    File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Opening MainForm {Environment.NewLine}");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SelectContextMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedTab().TextLength > 0)
                    SelectedTab().Select();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedTab().TextLength > 0)
                    SelectedTab().SelectedText = string.Empty;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void UndoContextMenu_Click(object sender, EventArgs e) => UndoToolStripMenu_Click(sender, e);

        private void RedoContexMenu_Click(object sender, EventArgs e) => RedoToolStripMenuItem_Click(sender, e);

        private void DeleteToolStripMenu_Click(object sender, EventArgs e) => DeleteToolStrip_Click(sender, e);

        private void DeleteToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabOption.TabCount > 1)
                {
                    var newIndex = tabOption.TabPages.IndexOf(tabOption.SelectedTab) - 1;

                    tabOption.TabPages.Remove(tabOption.SelectedTab);
                    if (tabOption.TabPages.Count != 0)
                        tabOption.SelectedTab = tabOption.TabPages[Math.Max(newIndex, 0)];

                    if (_openedFilesList.Count != 1)
                        _openedFilesList.RemoveAt(newIndex);
                    UpdateDocumentSelectorList();
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void UpdateWindowToolStripMenuItem_Click(object sender, EventArgs e) => UpdateWindow();

        private void FullWindowedToolStrip_Click(object sender, EventArgs e) => WindowState = FormWindowState.Maximized;

        private void UpdateWindow()
        {
            try
            {
                TabControl.TabPageCollection tabcoll = tabOption.TabPages;

                foreach (TabPage tabpage in tabcoll)
                {
                    ToolStripMenuItem menuitem = new ToolStripMenuItem();
                    string s = tabpage.Text;
                    menuitem.Text = s;
                    if (tabOption.SelectedTab == tabpage)
                        menuitem.Checked = true;
                    else
                        menuitem.Checked = false;

                    Invalidate();

                    menuitem.Click += WindowList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void WindowList(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem toolstripitem = (ToolStripItem)sender;
                TabControl.TabPageCollection tabcoll = tabOption.TabPages;
                foreach (TabPage tb in tabcoll)
                {
                    if (toolstripitem.Text == tb.Text)
                    {
                        tabOption.SelectedTab = tb;

                        var richTextBox1 = tabOption.TabPages[tabOption.SelectedIndex].Controls[0];
                        richTextBox1.Select();
                        UpdateWindow();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void TabOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabOption.TabCount > 0)
                {
                    TabPage tabpage = tabOption.SelectedTab;

                    foreach (string filename in _openedFilesList)
                    {
                        if (tabpage != null)
                        {
                            string str = filename.Substring(filename.LastIndexOf("\\") + 1);
                            if (tabpage.Text.Contains("*"))
                            {
                                string str2 = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                if (str == str2)
                                    Text = $@"{tabpage.Text}" + " Notepad (Peergrade Version)";
                            }

                            else
                            {
                                if (str == tabpage.Text)
                                    Text = $@"{tabpage.Text}" + " Notepad (Peergrade Version)";
                            }
                        }
                    }

                    UpdateWindow();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void WikipediaToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start("https://en.wikipedia.org/wiki/Higher_School_of_Economics");

        private void CloseTabPageButton_Click(object sender, EventArgs e) => DeleteToolStripMenuItem_Click(sender, e);

        private void FormatterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workspace = new AdhocWorkspace(MefHostServices.DefaultHost);
            var formattedSource = Formatter.Format(CSharpSyntaxTree.ParseText(SelectedTab().Text).GetRoot(), workspace).ToFullString();
            SelectedTab().Text = formattedSource;
        }

        private void StrikeOutButtonStrip_Click(object sender, EventArgs e) => StrikeOutToolStripItem_Click(sender, e);

        private void aboutPanel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Build version: " + ProductVersion);
        }

    }
}
