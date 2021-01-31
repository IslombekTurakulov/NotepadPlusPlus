using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Host.Mef;

namespace NotepadPlusPlus
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    using FastColoredTextBoxNS;

    public partial class DeveloperEditor : Form
    {
        // Путь файла который присваивается в filepath
        private string _filePath = string.Empty;
        // Записывается в список путей файла
        private readonly List<string> _openedFilesList = new List<string>();

        // Сколько новых файлов открыто
        private int _filesNew;

        private int _timeLeft = 300;

        private int _count = 0;
        private int _newTime = 0;

        public DeveloperEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                _timeLeft--;
                if (_timeLeft <= 0)
                {
                    this.timerInterval.Stop();
                    string path = $@"backup/BackupDeveloperText {this._count++}.rtf";
                    TabControl.TabPageCollection tabcoll = this.tabOption.TabPages;
                    foreach (TabPage tabpage in tabcoll)
                        this.SelectedPageTextBox().SaveToFile(path, Encoding.Default);

                    this._timeLeft = this._newTime;
                    this.timerInterval.Start();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private FastColoredTextBox SelectedPageTextBox()
        {
            // Присваиваю выбранную вкладку в новый TabPage.
            TabPage tabpage = this.tabOption.SelectedTab;
            // И тут идёт проверка , если внутри вкладки если текстбокс то присваивается.
            foreach (var c in tabpage.Controls)
                if (c is FastColoredTextBox box)
                {
                    documentMap1.Target = box;
                    return box;
                }

            return null;
        }

        /// <summary>
        /// The new file click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void NewFile_Click(object sender, EventArgs e)
        {
            // Присвоим текст к новому текстбоксу.
            FastColoredTextBox fastColoredTextBox = this.fcbTextBox;
            // Если вкладок меньше или равно нуля, то создаём новый файл.
            if (this.tabOption.TabCount >= 0)
            {
                TabPage tabPage = new TabPage { Text = $@"Untitled ({++this._filesNew})" };
                FastColoredTextBox textBox =
                    new FastColoredTextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };
                tabPage.Controls.Add(textBox);

                // Создаём новую вкладку и текст-бокс.
                this.tabOption.SelectedTab = tabPage;
                // Добавляем в новую вкладку текст-бокс.
                this.tabOption.TabPages.Add(tabPage); // В главный параметр вкладок добавляем новый со всем функционалом.
                var fastColoredTextBox1 = this.tabOption.TabPages[this.tabOption.SelectedIndex].Controls[0];
                fastColoredTextBox1.Select();

                // Добавим контекстное меню в новую вкладку.
                fastColoredTextBox1.ContextMenuStrip = this.contextOption;
                fastColoredTextBox1.TextChanged += this.FcbTextBox_TextChanged;
                this._openedFilesList.Add(tabPage.Text);
                Text = " Untitled " + this._filesNew + @" Notepad (Peergrade Version)";
            }
            else
            {
                // Часто происходит, что после создания новой вкладки, первая вкладка очищается, вот и сделал тут условие.
                this.tabOption.TabPages[0].Controls[0].Text = fastColoredTextBox.Text;
            }
        }


        private Language StatusFileDetector()
        {
            if (this._filePath.Contains("."))
            {
                this.fileStatusStrip.Text = " Файл "; ;
                return Language.Custom;
            }
            if (this._filePath.Contains(".cs"))
            {
                this.fileStatusStrip.Text = " C# Файл ";
                return Language.CSharp;
            }
            if (this._filePath.Contains(".js"))
            {
                this.fileStatusStrip.Text = " JS Файл ";
                return Language.JS;
            }
            if (this._filePath.Contains(".xml"))
            {
                this.fileStatusStrip.Text = "XML Файл";
                return Language.XML;
            }
            if (this._filePath.Contains(".html"))
            {
                this.fileStatusStrip.Text = "HTML Файл";
                return Language.HTML;
            }
            if (this._filePath.Contains(".json"))
            {
                this.SelectedPageTextBox().Language = Language.JSON;
                this.fileStatusStrip.Text = "JSON Файл";
            }
            if (this._filePath.Contains(".php"))
            {
                this.fileStatusStrip.Text = "PHP Файл";
                return Language.PHP;
            }
            if (this._filePath.Contains(".rtf"))
            {
                this.fileStatusStrip.Text = "RTF Файл";
                return Language.Custom;
            }
            if (this._filePath.Contains(".docx"))
            {
                this.fileStatusStrip.Text = "DOCX Файл";
                return Language.Custom;
            }
            if (this._filePath.Contains(".py"))
            {
                this.fileStatusStrip.Text = "Python Файл";
                return Language.JS;
            }

            return Language.CSharp;
        }

        /// <summary>
        /// Открытие файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаём новую вкладку и текст-бокс.
                TabPage tabpage = new TabPage();
                FastColoredTextBox fastColoredTextBox = new FastColoredTextBox();
                // Если пользователь после выбора файла для открытия нажал "ОК".
                // Происходит это действие.
                if (this.openFile.ShowDialog() == DialogResult.OK)
                {
                    // После открытия создаётся новая вкладка.
                    this.tabOption.SelectedTab = tabpage;
                    // Заполняем текстбокс на полный экран.
                    fastColoredTextBox.Dock = DockStyle.Fill;
                    // Убираем рамку текст-бокса.
                    fastColoredTextBox.BorderStyle = BorderStyle.None;
                    // Добавляем в новую вкладку текст-бокс.
                    tabpage.Controls.Add(fastColoredTextBox);
                    // В главный параметр вкладок добавляем новый со всем функционалом.
                    this.tabOption.TabPages.Add(tabpage);

                    // Проверка на расширение файла, если оно такого формата, то это Microsoft Docs жи есть.
                    if (this.openFile.FileName.Contains(".rtf"))
                        fastColoredTextBox.Text = File.ReadAllText(this.openFile.FileName);
                    else
                        fastColoredTextBox.Text = File.ReadAllText(this.openFile.FileName);

                    // Задаю коротко и надёжное имя вкладки.
                    tabpage.Text = this.openFile.SafeFileName;
                    fastColoredTextBox.TextChanged += this.FcbTextBox_TextChanged;
                    fastColoredTextBox.ContextMenuStrip = this.contextOption;
                    tabpage.AccessibleDescription = openFile.FileName;
                    tabpage.ContextMenuStrip = this.contextTabMenuStrip;
                    this._filePath = this.openFile.FileName;

                    StatusFileDetector();

                    this.Text = $@"{this._filePath} NotePad (PeerGrade Version)";
                    // Добавляю в список недавних открытых файлов
                    this._openedFilesList.Add(this._filePath);
                    DataSaver();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SaveAsFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabOption.TabCount >= 1)
                {
                    // Создаём меню сохранения файлов и добавляем фильтр сохранения.
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog
                    {
                        Filter =
                            @"Текстовый документ (*.txt)|*.txt|C# (*.cs)|*.cs|JavaScript (*.js)|*.js|HTML (*.html)|*.html|CSS (*.css)|*.css|RTF (*.rtf)|*.rtf|JSON (*.json)|*.json|PHP (*.php)|*.php|Doc (*.docx)|*.docx|Все файлы (*.)|*."
                    };
                    // Если пользователь нажал "ОК".
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        FileSaveFunction(saveFileDialog1.FileName);
                        TabPage tabPage = tabOption.SelectedTab;
                        tabPage.Text = saveFileDialog1.FileName;
                        _filePath = saveFileDialog1.FileName;

                        // Добавляем в список путь файла
                        this._openedFilesList.Add(this._filePath);
                        DataSaver();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// Закрытие приложения.
        /// </summary>
        /// <param name="sender">Вызывает событие</param>
        /// <param name="e">Отправка действий</param>
        private void ExitTool_Click(object sender, EventArgs e) => Application.Exit();

        /// <summary>
        /// Переходит в событие создания нового файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFile_Button(object sender, EventArgs e) => this.NewFile_Click(sender, e);

        /// <summary>
        /// Переходит в событие открытия нового файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_Button(object sender, EventArgs e) => this.OpenFile_Click(sender, e);

        // Переходит в событие сохранения файла с выбором расширения.
        private void SaveAs_Button(object sender, EventArgs e) => this.SaveAsFile_Click(sender, e);

        // Переходит в события копии текста.
        private void CopyText(object sender, EventArgs e) => CopyMenu_Click(sender, e);

        private void PasteText(object sender, EventArgs e) => PasteMenu_Click(sender, e);

        private void CutText(object sender, EventArgs e) => CutMenu_Click(sender, e);

        private void FontOption_Click(object sender, EventArgs e)
        {
            try
            {
                this.fontOption.ShowDialog();
                this.SelectedPageTextBox().Font = this.fontOption.Font;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BackgroundTextTheme(object sender, EventArgs e)
        {
            this.colorOption.ShowDialog();
            this.SelectedPageTextBox().BackColor = this.colorOption.Color;
        }

        private void SelectMenu_Click(object sender, EventArgs e)
        {
            if (this.SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().Select();
        }

        private void CopyMenu_Click(object sender, EventArgs e)
        {
            if (this.SelectedPageTextBox().TextLength > 0)
                this.SelectedPageTextBox().Copy();
        }

        private void PasteMenu_Click(object sender, EventArgs e)
        {
            if (this.SelectedPageTextBox().TextLength > 0)
                this.SelectedPageTextBox().Paste();
        }

        private void SelectAllMenu_Click(object sender, EventArgs e)
        {
            if (this.SelectedPageTextBox().TextLength > 0)
                this.SelectedPageTextBox().SelectAll();
        }

        private void CutMenu_Click(object sender, EventArgs e)
        {
            if (this.SelectedPageTextBox().TextLength > 0)
                this.SelectedPageTextBox().Cut();
        }

        private void FileSaveFunction(string path)
        {
            StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default);
            if (path.Contains(".rtf"))
                streamWriter.WriteLine(this.SelectedPageTextBox().Rtf);
            else
                streamWriter.WriteLine(this.SelectedPageTextBox().Text);

            this._filePath = path;
            this.Text = $@"{this._filePath} NotePad (PeerGrade Version)";
            streamWriter.Close();
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                TabPage tb = tabOption.SelectedTab;
                if (tb.Text.Contains("Untitled"))
                {
                    TabControl.TabPageCollection tabcoll = this.tabOption.TabPages;
                    foreach (TabPage tabpage in tabcoll)
                    {
                        tabOption.SelectedTab = tabpage;
                        DialogResult dg = MessageBox.Show(
                            "Do you want to save file " + tabpage.Text,
                            @"Save or Not",
                            MessageBoxButtons.YesNoCancel);

                        if (dg == DialogResult.Yes)
                        {
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog
                            {
                                Filter =
                                                                         @"Текстовый документ (*.txt)|*.txt|C# (*.cs)|*.cs|JavaScript (*.js)|*.js|HTML (*.html)|*.html|CSS (*.css)|*.css|RTF (*.rtf)|*.rtf|JSON (*.json)|*.json|PHP (*.php)|*.php|Doc (*.docx)|*.docx|Все файлы (*.)|*."
                            };

                            if (!tabpage.Text.Contains("Untitled"))
                            {
                                FileSaveFunction(tabpage.AccessibleDescription);
                                this._filePath = tabpage.AccessibleDescription;
                                this.Text = $@"{this._filePath} NotePad (PeerGrade Version)";
                                DataSaver();
                            }
                            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                FileSaveFunction(saveFileDialog1.FileName);
                                this._filePath = saveFileDialog1.FileName;
                                this.Text = $@"{this._filePath} NotePad (PeerGrade Version)";
                                this.openFile.FileName = saveFileDialog1.FileName;
                                tabpage.Text = openFile.SafeFileName;
                                tabpage.AccessibleDescription = openFile.FileName;

                                this._openedFilesList.Add(this._filePath);
                                DataSaver();
                            }
                        }
                        else if (dg == DialogResult.Cancel)
                        {
                            tabOption.Select();
                        }
                    }
                }
                else
                {
                    if (!tb.Text.Contains("Untitled"))
                    {
                        FileSaveFunction(tb.AccessibleDescription);
                    }
                    else if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        FileSaveFunction(saveFile.FileName);

                        this.openFile.FileName = saveFile.FileName;
                        tb.Text = openFile.SafeFileName;
                        _filePath = openFile.FileName;
                        DataSaver();
                        this._openedFilesList.Add(this._filePath);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DataSaver()
        {
            string[] arrPages = File.ReadAllLines("DataHistoryEditor.txt");
            for (int i = 0; i < arrPages.Length; i++)
                if (arrPages[i].Contains(_filePath))
                    File.AppendAllText("DataHistoryEditor.txt", this._filePath + Environment.NewLine);
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            this.SaveFile_Click(sender, e);
        }

        private void CompileCode_Click(object sender, EventArgs e)
        {
            CompilerCSharp compilerCSharp = new CompilerCSharp();
            compilerCSharp.CompilerResults(SelectedPageTextBox().Text, tabOption);
        }

        private void SyntaxCsharp_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.tabOption.TabPages.Count >= 1)
                {
                    this.SelectedPageTextBox().Language = Language.CSharp;
                    this.SelectedPageTextBox().Text = File.ReadAllText("CSharpExample.cs");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SyntaxHTML_Click(object sender, EventArgs e)
        {
            if (this.tabOption.TabPages.Count >= 1)
            {
                this.SelectedPageTextBox().Language = Language.HTML;
                this.SelectedPageTextBox().Text = @"<!DOCTYPE html>
<head>
<title>TestTitle</title>
</head>
    <body>
        <h1> Hello World and PeerGrade! </h1> 
    </body>
</head>
</html>
";
            }

        }

        private void SyntaxJS_Click(object sender, EventArgs e)
        {
            if (this.tabOption.TabPages.Count >= 1)
            {
                this.SelectedPageTextBox().Language = Language.JS;
                this.SelectedPageTextBox().Text = @"function createEmail( to, from, subject, message ) {
 console.log(`
   to: ${to}
   from: ${from}
   subject: ${subject}
   message: ${message}
  `);
};

createEmail(""your@gmail.com"", ""client@gmail.com"", ""Hello"", ""How are you ? "");";
            }

        }

        private void SyntaxDefault_Click(object sender, EventArgs e)
        {
            if (this.tabOption.TabPages.Count >= 1)
                this.SelectedPageTextBox().Text = string.Empty;
        }

        private void SyntaxXML_Click(object sender, EventArgs e)
        {
            if (this.tabOption.TabPages.Count >= 1)
            {
                this.SelectedPageTextBox().Language = Language.XML;
                this.SelectedPageTextBox().Text = @"<?xml version=""1.0""?>
                <CAT>
                <NAME>PeerGrade</NAME>
                <BREED>Iphone</BREED>
                <AGE>99</AGE>
                <ALTERED>yes</ALTERED>
                <DECLAWED>no</DECLAWED>
                <LICENSE>PeerGrade Version</LICENSE>
                </CAT>";
            }
        }

        private void BlackTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerDeveloperForm(mainMenu, toolButtons, statusStrip1, tabOption, SelectedPageTextBox(), Color.Black, Color.White);
            this.BackColor = Color.Black;
        }



        private void HackerTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerDeveloperForm(mainMenu, toolButtons, statusStrip1, tabOption, SelectedPageTextBox(), Color.Black, Color.LawnGreen);
            this.BackColor = Color.Black;
        }


        private void DefaultTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerDeveloperForm(mainMenu, toolButtons, statusStrip1, tabOption, SelectedPageTextBox(), DefaultBackColor, DefaultForeColor);
            this.BackColor = Color.Black;
        }



        private void BackButton_Click(object sender, EventArgs e) => this.SelectedPageTextBox()?.Undo();

        private void ReturnButton_Click(object sender, EventArgs e) => this.SelectedPageTextBox()?.Redo();

        private void CutButton_Click(object sender, EventArgs e) => this.CutMenu_Click(sender, e);

        private void CopyButton_Click(object sender, EventArgs e) => this.CopyMenu_Click(sender, e);

        private void SelectAll_Click(object sender, EventArgs e) => this.SelectAllMenu_Click(sender, e);

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (this.SelectedPageTextBox().Zoom < 500)
                this.SelectedPageTextBox().Zoom += 25;
            else
                MessageBox.Show($@"The zoom value is greater than {this.SelectedPageTextBox().Zoom}!");
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if (this.SelectedPageTextBox().Zoom <= 0)
                MessageBox.Show($@"The zoom value is less than {this.SelectedPageTextBox().Zoom}!");
            else
                this.SelectedPageTextBox().Zoom -= 15;
        }

        private void ForeColorTheme_Click(object sender, EventArgs e)
        {
            this.colorOption.ShowDialog();
            this.SelectedPageTextBox().ForeColor = this.colorOption.Color;
        }


        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument { DocumentName = "Print Document" };

            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            // Call ShowDialog  
            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        private void FcbTextBox_TextChanged(object sender, EventArgs e)
        {
            TabPage tabPage = this.tabOption.SelectedTab;
            string text = this.SelectedPageTextBox()?.Text;
            string[] lines = text.Split('\n');
            this.statusLabel.Text = $@"Symbols: {text.Length}";
            this.rowsInfo.Text = $@"Rows: {lines.Length}";
            this._filePath = tabPage.AccessibleDescription;
        }

        private void TabOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabOption.TabCount > 0)
            {
                TabPage tabpage = this.tabOption.SelectedTab;

                foreach (string filename in this._openedFilesList)
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

        private void UpdateWindow()
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

        private void WindowList(object sender, EventArgs e)
        {
            ToolStripItem toolstripitem = (ToolStripItem)sender;
            TabControl.TabPageCollection tabcoll = this.tabOption.TabPages;
            foreach (TabPage tb in tabcoll)
            {
                if (toolstripitem.Text == tb.Text)
                {
                    tabOption.SelectedTab = tb;
                    var fcTextBox = tabOption.TabPages[tabOption.SelectedIndex].Controls[0];
                    fcTextBox.Select();
                    this.UpdateWindow();
                }
            }
        }

        private void DeveloperEditor_FormClosing(object sender, FormClosingEventArgs e)
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UndoMenu_Click(object sender, EventArgs e) => BackButton_Click(sender, e);

        private void RedoMenu_Click(object sender, EventArgs e) => ReturnButton_Click(sender, e);

        void TimerStart()
        {
            this._newTime = this._timeLeft;
            this.timerInterval.Interval = 1000;
            this.timerInterval.Start();
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            this.timerInterval.Tick += Timer_Tick;
            this.timerInterval.Start();
        }


        private void DeveloperEditor_Load(object sender, EventArgs e)
        {
            try
            {
                this.fcbTextBox.ContextMenuStrip = this.contextOption;
                this.tabOption.ContextMenuStrip = this.contextTabMenuStrip;
                string[] arrPages = File.ReadAllLines("DataHistoryDeveloperEditor.txt");
                if (arrPages.Length >= 1)
                {
                    for (int i = 0; i < arrPages.Length; i++)
                    {
                        TabPage tabpage = new TabPage();
                        FastColoredTextBox fctText = new FastColoredTextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };
                        this.openFile.FileName = arrPages[i];
                        if (this.openFile.CheckFileExists)
                        {
                            this.tabOption.SelectedTab = tabpage;
                            this.tabOption.TabPages.Add(tabpage);
                            tabpage.Controls.Add(fctText);
                            fctText.Language = this.StatusFileDetector();
                            tabpage.ContextMenuStrip = this.contextOption;
                            fctText.Text = File.ReadAllText(arrPages[i]);
                            tabpage.Text = this.openFile.SafeFileName;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void JsonMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabOption.TabPages.Count >= 1)
            {
                this.SelectedPageTextBox().Language = Language.JSON;
                this.SelectedPageTextBox().Text = @"{
    ""users"": [
            {{repeat(5)}}
            {
                ""id"": {{id()}},
                ""guid"": {{guid()}},
            ""description"": {{string(50)}},
            ""birth_year"": {{random(1975, 2005)}},
            ""date_created"": {{timestamp()}}
            }
            ]
        }";
            }
        }

        private void PhpMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tabOption.TabPages.Count >= 1)
            {

                this.SelectedPageTextBox().Language = Language.PHP;
                this.SelectedPageTextBox().Text = @" public function set($name, $value)
 {
     if ($value instanceof \Innomatic\Tpl\Template) {
         // This is a subtemplate, process it.
         //
         $this->vars[$name] = $value->parse();
     } else {
         // This is a string, it must be passed as a CDATA.
         //
         $this->vars[$name] = $value;
         $this->tplEngine->set($name, \Shared\Wui\WuiXml::cdata($value));
     }
 }";
            }

        }

        /// <summary>
        /// The delete tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var newIndex = this.tabOption.TabPages.IndexOf(this.tabOption.SelectedTab) - 1;

                this.tabOption.TabPages.Remove(this.tabOption.SelectedTab);
                if (this.tabOption.TabPages.Count != 0)
                    this.tabOption.SelectedTab = this.tabOption.TabPages[Math.Max(newIndex, 0)];
                if (this._openedFilesList.Count != 1)
                    this._openedFilesList.RemoveAt(newIndex);
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// The update window tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UpdateWindowToolStripMenuItem_Click(object sender, EventArgs e) => this.UpdateWindow();

        /// <summary>
        /// The cut context menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CutContextMenu_Click(object sender, EventArgs e) => this.CutButton_Click(sender, e);

        /// <summary>
        /// The select context menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SelectContextMenu_Click(object sender, EventArgs e) => this.SelectMenu_Click(sender, e);

        /// <summary>
        /// The redo contex menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RedoContextMenu_Click(object sender, EventArgs e) => this.RedoMenu_Click(sender, e);

        /// <summary>
        /// The undo context menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UndoContextMenu_Click(object sender, EventArgs e) => this.UndoMenu_Click(sender, e);

        /// <summary>
        /// The delete tool strip menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DeleteToolStripMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabOption.TabPages.Count >= 1)
                    if (this.SelectedPageTextBox().TextLength > 0)
                        this.SelectedPageTextBox().SelectedText = string.Empty;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        /// <summary>
        /// The full windowed tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FullWindowedToolStripMenuItem_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Maximized;

        /// <summary>
        /// The bold tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabOption.TabPages.Count >= 1)
                    this.SelectedPageTextBox().Font = new Font(this.SelectedPageTextBox().Font, FontStyle.Bold);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// The italic tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabOption.TabPages.Count >= 1)
                    this.SelectedPageTextBox().Font = new Font(this.SelectedPageTextBox().Font, FontStyle.Italic);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// The under lined tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UnderLinedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabOption.TabPages.Count >= 1)
                    this.SelectedPageTextBox().Font = new Font(this.SelectedPageTextBox().Font, FontStyle.Underline);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// The strike out tool strip item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void StrikeOutToolStripItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabOption.TabPages.Count >= 1)
                    this.SelectedPageTextBox().Font = new Font(this.SelectedPageTextBox().Font, FontStyle.Strikeout);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// The first tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void FirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._timeLeft = 300;
            TimerStart();
        }

        /// <summary>
        /// The second tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._timeLeft = 600;
            TimerStart();
        }

        /// <summary>
        /// The third tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ThirdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._timeLeft = 1200;
            TimerStart();
        }

        /// <summary>
        /// The stop tool strip menu item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timerInterval.Stop();
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "OFF";
            this._timeLeft = 0;
        }

        private void SyntaxPython_Click(object sender, EventArgs e)
        {
            if (this.tabOption.TabPages.Count >= 1)
            {
                this.SelectedPageTextBox().Language = Language.JS;
                this.SelectedPageTextBox().Text = @" class MyClass:
    # Return the resource to default setting
    def reset(self):
        self.setting = 0
class ObjectPool:
    def __init__(self, size):
        self.objects = [MyClass() for _ in range(size)]
    def acquire(self):
        if self.objects:
            return self.objects.pop()
        else:
            self.objects.append(MyClass())
            return self.objects.pop()
    def release(self, reusable):
        reusable.reset()
        self.objects.append(reusable)";
            }

        }

        private void CloseTabPageButton_Click(object sender, EventArgs e)
        {
            this.tabOption.TabPages.Remove(this.tabOption.SelectedTab);
        }

        private void DeleteToolStripMenu_Click_1(object sender, EventArgs e)
        {
            this.DeleteToolStripMenu_Click(sender, e);
        }

        private void NewDeveloperWindow_Click(object sender, EventArgs e)
        {
            var newNotepad = new DeveloperEditor();
            newNotepad.Show();
        }

        private void FormattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workspace = new AdhocWorkspace(MefHostServices.DefaultHost);
            var formattedSource = Formatter.Format(CSharpSyntaxTree.ParseText(SelectedPageTextBox().Text).GetRoot(), workspace).ToFullString();
            SelectedPageTextBox().Text = formattedSource;
        }
    }
}
