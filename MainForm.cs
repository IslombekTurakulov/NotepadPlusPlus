using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Host.Mef;
using System.Collections.Generic;
using System.Drawing.Printing;
using Formatter = Microsoft.CodeAnalysis.Formatting.Formatter;

namespace NotepadPlusPlus
{ 
    public partial class MainForm : Form
    {
        private string _filePath = string.Empty;
        private readonly List<string> _openedFilesList = new List<string> { };
        private int _timeleft = 300;
        private int _newTime = 0;
        private int _filesNew = 0;

        private int _backupCount = 0;

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
                    this.timerInterval.Stop();
                    string path = $@"backup/BackupMainFormText {this._backupCount++}.rtf";
                    TabControl.TabPageCollection tabcoll = this.tabOption.TabPages;
                    TabPage tb = tabOption.SelectedTab;

                    foreach (TabPage tabPage in tabcoll)
                    {
                        this.SelectedTab().SaveFile(path);
                        this.SelectedTab().SaveFile(tb.AccessibleDescription);
                        File.AppendAllText("DataHistoryEditor.txt", tb.AccessibleDescription + Environment.NewLine);
                    }

                    this._timeleft = this._newTime;
                    this.timerInterval.Start();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void UpdateDocumentSelectorList()
        {
            TabControl.TabPageCollection tabcoll = this.tabOption.TabPages;
            this.treeView1.Nodes.Clear();
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
                this.Text = @"NotePad (PeerGrade Version)";

                RichTextBox rtb = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    ContextMenuStrip = this.contextOption
                };

                TabPage tb = new TabPage { Text = $@"Untitled ({++this._filesNew})"};
                tb.Controls.Add(rtb);


                this.tabOption.SelectedTab = tb;
                this.tabOption.TabPages.Add(tb);

                var richTextBox1 = tabOption.TabPages[this.tabOption.SelectedIndex].Controls[0];
                richTextBox1.Select();

                UpdateDocumentSelectorList();
                // add contextmenustrip to richTextBox1
                richTextBox1.TextChanged += this.RichTextBox_TextChanged;
                _openedFilesList.Add(tb.Text);
                this.Text = @"Untitled " + this._filesNew + @" Notepad (Peergrade Version)";
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
                    ContextMenuStrip = this.contextOption
                };

                if (this.openFile.ShowDialog() == DialogResult.OK)
                {
                    this.tabOption.SelectedTab = tabpage;
                    tabpage.Controls.Add(richText);
                    this.tabOption.TabPages.Add(tabpage);
                    if (this.openFile.FileName.Contains(".rtf"))
                        richText.Rtf = File.ReadAllText(this.openFile.FileName);
                    else
                        richText.Text = File.ReadAllText(this.openFile.FileName);

                    richText.TextChanged += RichTextBox_TextChanged;
                    tabpage.Text = this.openFile.SafeFileName;
                    this._filePath = this.openFile.FileName;
                    this.Text = $@"{this._filePath} NotePad (PeerGrade Version)";
                    tabpage.AccessibleDescription = this.openFile.FileName;
                    File.AppendAllText("DataHistoryEditor.txt", this._filePath + Environment.NewLine);
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
                        TabControl.TabPageCollection tabcoll = this.tabOption.TabPages;
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
                                    this._filePath = tabpage.AccessibleDescription;
                                    tabpage.AccessibleDescription = this.openFile.FileName;
                                    this.Text = $@"{tabpage.AccessibleDescription} NotePad (PeerGrade Version)";
                                    File.AppendAllText("DataHistoryEditor.txt", this._filePath + Environment.NewLine);
                                }
                                else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    NewFileInterval(saveFileDialog1.FileName);
                                    this.Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                                    this.openFile.FileName = saveFileDialog1.FileName;
                                    tabpage.AccessibleDescription = this.openFile.FileName;
                                    tabpage.Text = openFile.SafeFileName;
                                    this._filePath = saveFileDialog1.FileName;
                                    File.AppendAllText("DataHistoryEditor.txt", this._filePath + Environment.NewLine);
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
                        this.Text = $@"{tabPage.AccessibleDescription} NotePad (PeerGrade Version)";
                        File.AppendAllText("DataHistoryEditor.txt", this._filePath + Environment.NewLine);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SaveFileButton(object sender, EventArgs e) => this.SaveFile_Click(sender, e);

        private RichTextBox SelectedTab()
        {
            RichTextBox richTextBox = null;
                TabPage tabpage = this.tabOption.SelectedTab;
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
                            this.Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
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
                            this.Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
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

        private void NewFile_Button(object sender, EventArgs e) => this.NewFile_Click(sender, e);

        private void OpenFile_Button(object sender, EventArgs e) => this.OpenFile_Click(sender, e);

        private void SaveAs_Button(object sender, EventArgs e) => this.SaveAsFile_Click(sender, e);

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
                this.fontOption.ShowDialog();
                SelectedTab().Font = this.fontOption.Font;
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
                this.colorOption.ShowDialog();
                SelectedTab().BackColor = this.colorOption.Color;
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
        private void CopyTextMenu_Click(object sender, EventArgs e) => this.CopyText_Click(sender, e);

        private void PasteMenu_Click(object sender, EventArgs e) => this.PasteText_Click(sender, e);

        private void CutMenu_Click(object sender, EventArgs e) => this.CutText_Click(sender, e);

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
            this.BackColor = Color.Black;
        }

        private void HackerTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerMainForm(mainMenu, fastToolButton, statusTextEditor, tabOption,SelectedTab(), treeView1,Color.Black, Color.LawnGreen);
            this.BackColor = Color.Black; 
        }

        private void DefaultTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerMainForm(mainMenu, fastToolButton, statusTextEditor, tabOption,SelectedTab(), treeView1, DefaultBackColor, DefaultForeColor);
            this.BackColor = DefaultBackColor;
        }



        private void BackButton_Click(object sender, EventArgs e) => this.UndoToolStripMenu_Click(sender, e);

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            SelectedTab().Redo();
        }

        private void CutButton_Click(object sender, EventArgs e) => this.CutMenu_Click(sender, e);

        private void CopyButton_Click(object sender, EventArgs e) => this.CopyTextMenu_Click(sender, e);

        private void SelectAll_Click(object sender, EventArgs e) => this.SelectAllMenu_Click(sender, e);

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
                if (this.SelectedTab().ZoomFactor < 2)
                    this.SelectedTab().ZoomFactor = 0;
                else
                    this.SelectedTab().ZoomFactor -= 2;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ForeColorTheme_Click(object sender, EventArgs e)
        {
            this.colorOption.ShowDialog();
            this.SelectedTab().ForeColor = this.colorOption.Color;
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = this.SelectedTab().Text;
                string[] lines = text.Split('\n');
                this.statusLabel.Text = $@"Символов: {text.Length}";
                this.rowsInfo.Text = $@"Строк: {lines.Length}";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void FontOptionButton_Click(object sender, EventArgs e) => this.FontOption_Click(sender, e);

        private void CsharpEditor_Click(object sender, EventArgs e)
        {
            DeveloperEditor developerEditor = new DeveloperEditor();
            developerEditor.ShowDialog();
        }


        private void BoldToolButton_Click(object sender, EventArgs e) => this.BoldToolStripMenuItem_Click(sender, e);

        private void UnderlineToolButton_Click(object sender, EventArgs e) => this.UnderLinedToolStripMenuItem_Click(sender, e);

        private void ItalicToolButton_Click(object sender, EventArgs e) => this.ItalicToolStripMenuItem_Click(sender, e);

        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedTab().SelectionFont = new Font(
                    this.SelectedTab().SelectionFont,
                    FontStyle.Bold ^ this.SelectedTab().SelectionFont.Style);
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
                this.SelectedTab().SelectionFont = new Font(
                    this.SelectedTab().SelectionFont,
                    FontStyle.Italic ^ this.SelectedTab().SelectionFont.Style);
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
                this.SelectedTab().SelectionFont = new Font(
                    this.SelectedTab().SelectionFont,
                    FontStyle.Underline ^ this.SelectedTab().SelectionFont.Style);
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
                this.SelectedTab().SelectionFont = new Font(
                    this.SelectedTab().SelectionFont,
                    FontStyle.Strikeout ^ this.SelectedTab().SelectionFont.Style);
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
        private void UndoToolStripMenu_Click(object sender, EventArgs e) => this.SelectedTab().Undo();

        /// <summary>
        /// The tool strip redo item
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e) => this.SelectedTab().Redo();

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


        private void LeftSideToolStripMenuItem_Click(object sender, EventArgs e) => this.SelectedTab().SelectionAlignment = HorizontalAlignment.Left;

        private void MiddleToolStripMenuItem_Click(object sender, EventArgs e) => this.SelectedTab().SelectionAlignment = HorizontalAlignment.Center;

        private void RightSideToolStripMenuItem_Click(object sender, EventArgs e) => this.SelectedTab().SelectionAlignment = HorizontalAlignment.Right;

        private void FirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._timeleft = 300;
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        private void SecondTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._timeleft = 600;
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        private void ThirdTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._timeleft = 1200;
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timerInterval.Stop();
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "OFF";
            this._timeleft = 0;
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
                            this.SaveFile_Click(sender, e);
                            break;
                        }
                        tabOption.TabPages.Remove(tabpage);
                        this.TabOption_SelectedIndexChanged(sender, e);
                        

                        _filePath = tabpage.AccessibleDescription;
                        string[] arrPages = File.ReadAllLines("DataHistoryEditor.txt");
                        for (int i = 0; i < arrPages.Length; i++)
                            if (!arrPages[i].Contains(_filePath))
                                File.AppendAllText("DataHistoryEditor.txt", this._filePath + Environment.NewLine);
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        void TimerStart()
        {
            this._newTime = this._timeleft;
            this.timerInterval.Interval = 1000;
            this.timerInterval.Start();
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            this.timerInterval.Tick += Timer_Tick;
            this.timerInterval.Start();
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
                        RichTextBox fctText = new RichTextBox
                        {
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None,
                            ContextMenuStrip = this.contextOption
                        };
                        this.openFile.FileName = arrPages[i];
                        if (openFile.CheckFileExists)
                        {
                            if (arrPages[i].Contains(".rtf"))
                                fctText.Rtf = File.ReadAllText(arrPages[i]);
                            else
                                fctText.Text = File.ReadAllText(arrPages[i]);
                            TabPage tabpage = new TabPage()
                            {
                                Controls = { fctText },
                                Text = openFile.SafeFileName,
                                AccessibleDescription = openFile.FileName,
                                ContextMenuStrip = tabControlContextMenu
                            };
                            this.tabOption.SelectedTab = tabpage;
                            this.tabOption.TabPages.Add(tabpage);
                        }
                        UpdateDocumentSelectorList();
                    }
                }
                this.tabOption.ContextMenuStrip = this.tabControlContextMenu;
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
                if (this.SelectedTab().TextLength > 0)
                    this.SelectedTab().Select();
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
                if (this.SelectedTab().TextLength > 0)
                    this.SelectedTab().SelectedText = string.Empty;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void UndoContextMenu_Click(object sender, EventArgs e) => this.UndoToolStripMenu_Click(sender, e);

        private void RedoContexMenu_Click(object sender, EventArgs e) => this.RedoToolStripMenuItem_Click(sender, e);

        private void DeleteToolStripMenu_Click(object sender, EventArgs e) => this.DeleteToolStrip_Click(sender, e);

        private void DeleteToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabOption.TabCount > 1)
                {
                    var newIndex = this.tabOption.TabPages.IndexOf(this.tabOption.SelectedTab) - 1;

                    this.tabOption.TabPages.Remove(this.tabOption.SelectedTab);
                    if (this.tabOption.TabPages.Count != 0)
                        this.tabOption.SelectedTab = this.tabOption.TabPages[Math.Max(newIndex, 0)];

                    if (this._openedFilesList.Count != 1)
                        this._openedFilesList.RemoveAt(newIndex);
                    this.UpdateDocumentSelectorList();
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void UpdateWindowToolStripMenuItem_Click(object sender, EventArgs e) => this.UpdateWindow();

        private void FullWindowedToolStrip_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Maximized;

        private void UpdateWindow()
        {
            try
            {
                TabControl.TabPageCollection tabcoll = this.tabOption.TabPages;

                foreach (TabPage tabpage in tabcoll)
                {
                    ToolStripMenuItem menuitem = new ToolStripMenuItem();
                    string s = tabpage.Text;
                    menuitem.Text = s;
                    if (tabOption.SelectedTab == tabpage)
                        menuitem.Checked = true;
                    else
                        menuitem.Checked = false;

                    this.Invalidate();

                    menuitem.Click += this.WindowList;
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
                TabControl.TabPageCollection tabcoll = this.tabOption.TabPages;
                foreach (TabPage tb in tabcoll)
                {
                    if (toolstripitem.Text == tb.Text)
                    {
                        tabOption.SelectedTab = tb;

                        var richTextBox1 = tabOption.TabPages[tabOption.SelectedIndex].Controls[0];
                        richTextBox1.Select();
                        this.UpdateWindow();
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
                    TabPage tabpage = this.tabOption.SelectedTab;

                    foreach (string filename in _openedFilesList)
                    {
                        if (tabpage != null)
                        {
                            string str = filename.Substring(filename.LastIndexOf("\\") + 1);
                            if (tabpage.Text.Contains("*"))
                            {
                                string str2 = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                if (str == str2)
                                    this.Text = $@"{tabpage.Text}" + " Notepad (Peergrade Version)";
                            }

                            else
                            {
                                if (str == tabpage.Text)
                                    this.Text = $@"{tabpage.Text}" + " Notepad (Peergrade Version)";
                            }
                        }
                    }

                    this.UpdateWindow();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void WikipediaToolStripMenuItem_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Higher_School_of_Economics");

        private void CloseTabPageButton_Click(object sender, EventArgs e) => DeleteToolStripMenuItem_Click(sender, e);

        private void FormatterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workspace = new AdhocWorkspace(MefHostServices.DefaultHost);
            var formattedSource = Formatter.Format(CSharpSyntaxTree.ParseText(SelectedTab().Text).GetRoot(), workspace).ToFullString();
            SelectedTab().Text = formattedSource;
        }

        private void StrikeOutButtonStrip_Click(object sender, EventArgs e) => StrikeOutToolStripItem_Click(sender, e);
    }
}
