using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Host.Mef;

namespace NotepadPlusPlus
{
    public partial class DeveloperEditor : Form
    {
        // Путь файла который присваивается в filepath.
        private string _filePath = string.Empty;
        // Записывается в список путей файла.
        private readonly List<string> _openedFilesList = new List<string>();

        // Сколько новых файлов открыто.
        private int _filesNew;
        // Цифры в секундах для timeInterval.
        private int _timeLeft = 300;
        // Для сохранения файлов Журналирования.
        private int _count;
        // Нужен для автосохранения.
        private int _newTime;

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
                // Минусуется время.
                _timeLeft--;
                // Если время равно нулю, то выполняется это действие.
                if (_timeLeft <= 0)
                {
                    timerInterval.Stop();
                    // Нужен для журналирования, файл сохраняется в пути exe-шника
                    string path = $@"backup/BackupDeveloperText {_count++}.rtf";
                    //
                    TabPage tb = tabOption.SelectedTab;
                    TabControl.TabPageCollection tabcoll = tabOption.TabPages;
                    foreach (TabPage tabpage in tabcoll)
                    {
                        SelectedPageTextBox().SaveToFile(path, Encoding.Default);
                        SelectedPageTextBox().SaveToFile(tb.AccessibleDescription, Encoding.Default);
                        File.AppendAllText("DataHistoryEditor.txt", tb.AccessibleDescription + Environment.NewLine);
                    }

                    _timeLeft = _newTime;
                    timerInterval.Start();
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
            TabPage tabpage = tabOption.SelectedTab;
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
            FastColoredTextBox fastColoredTextBox = fcbTextBox;
            // Если вкладок меньше или равно нуля, то создаём новый файл.
            if (tabOption.TabCount >= 0)
            {
                TabPage tabPage = new TabPage { Text = $@"Untitled ({++_filesNew})" };
                FastColoredTextBox textBox =
                    new FastColoredTextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };
                tabPage.Controls.Add(textBox);

                // Создаём новую вкладку и текст-бокс.
                tabOption.SelectedTab = tabPage;
                // Добавляем в новую вкладку текст-бокс.
                tabOption.TabPages.Add(tabPage); // В главный параметр вкладок добавляем новый со всем функционалом.
                var fastColoredTextBox1 = tabOption.TabPages[tabOption.SelectedIndex].Controls[0];
                fastColoredTextBox1.Select();

                // Добавим контекстное меню в новую вкладку.
                fastColoredTextBox1.ContextMenuStrip = contextOption;
                fastColoredTextBox1.TextChanged += FcbTextBox_TextChanged;
                _openedFilesList.Add(tabPage.Text);
                Text = " Untitled " + _filesNew + @" Notepad (Peergrade Version)";
            }
            else
            {
                // Часто происходит, что после создания новой вкладки, первая вкладка очищается, вот и сделал тут условие.
                tabOption.TabPages[0].Controls[0].Text = fastColoredTextBox.Text;
            }
        }


        private void StatusFileDetector()
        {
            TabPage tabPage = tabOption.SelectedTab;
            if (tabPage.Text.Contains(".cs"))
            {
                fileStatusStrip.Text = " C# Файл ";
                SelectedPageTextBox().Language = Language.CSharp;
            }
            if (tabPage.Text.Contains(".js"))
            {
                fileStatusStrip.Text = " JS Файл ";
                SelectedPageTextBox().Language = Language.JS;
            }
            if (tabPage.Text.Contains(".xml"))
            {
                fileStatusStrip.Text = "XML Файл";
                SelectedPageTextBox().Language = Language.XML;
            }
            if (tabPage.Text.Contains(".html"))
            {
                fileStatusStrip.Text = "HTML Файл";
                SelectedPageTextBox().Language = Language.HTML;
            }
            if (tabPage.Text.Contains(".json"))
            {
                SelectedPageTextBox().Language = Language.JSON;
                fileStatusStrip.Text = "JSON Файл";
            }
            if (tabPage.Text.Contains(".php"))
            {
                fileStatusStrip.Text = "PHP Файл";
                SelectedPageTextBox().Language = Language.PHP;
            }
            if (tabPage.Text.Contains(".rtf"))
            {
                fileStatusStrip.Text = "RTF Файл";
                SelectedPageTextBox().Language = Language.Custom;
            }
            if (tabPage.Text.Contains(".docx"))
            {
                fileStatusStrip.Text = "DOCX Файл";
                SelectedPageTextBox().Language = Language.Custom;
            }
            if (tabPage.Text.Contains(".py"))
            {
                fileStatusStrip.Text = "Python Файл";
                SelectedPageTextBox().Language = Language.JS;
            }
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
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // После открытия создаётся новая вкладка.
                    tabOption.SelectedTab = tabpage;
                    // Заполняем текстбокс на полный экран.
                    fastColoredTextBox.Dock = DockStyle.Fill;
                    // Убираем рамку текст-бокса.
                    fastColoredTextBox.BorderStyle = BorderStyle.None;
                    // Добавляем в новую вкладку текст-бокс.
                    tabpage.Controls.Add(fastColoredTextBox);
                    // В главный параметр вкладок добавляем новый со всем функционалом.
                    tabOption.TabPages.Add(tabpage);

                    // Проверка на расширение файла, если оно такого формата, то это Microsoft Docs жи есть.
                    if (openFile.FileName.Contains(".rtf"))
                        fastColoredTextBox.Text = File.ReadAllText(openFile.FileName);
                    else
                        fastColoredTextBox.Text = File.ReadAllText(openFile.FileName);

                    // Задаю коротко и надёжное имя вкладки.
                    tabpage.Text = openFile.SafeFileName;
                    fastColoredTextBox.TextChanged += FcbTextBox_TextChanged;
                    fastColoredTextBox.ContextMenuStrip = contextOption;
                    tabpage.AccessibleDescription = openFile.FileName;
                    tabpage.ContextMenuStrip = contextTabMenuStrip;
                    _filePath = openFile.FileName;

                    StatusFileDetector();

                    Text = $@"{_filePath} NotePad (PeerGrade Version)";
                    // Добавляю в список недавних открытых файлов
                    _openedFilesList.Add(_filePath);
                    File.AppendAllText("DataHistoryDeveloperEditor.txt", _filePath + Environment.NewLine);
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
                TabPage tb = tabOption.SelectedTab;
                if (tb.Text.Contains("Untitled"))
                {
                    TabControl.TabPageCollection tabcoll = tabOption.TabPages;
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
                                _filePath = tabpage.AccessibleDescription;
                                Text = $@"{_filePath} NotePad (PeerGrade Version)";
                                File.AppendAllText("DataHistoryDeveloperEditor.txt", _filePath + Environment.NewLine);
                            }
                            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                FileSaveFunction(saveFileDialog1.FileName);
                                _filePath = saveFileDialog1.FileName;
                                Text = $@"{_filePath} NotePad (PeerGrade Version)";
                                openFile.FileName = saveFileDialog1.FileName;
                                tabpage.Text = openFile.SafeFileName;
                                tabpage.AccessibleDescription = openFile.FileName;

                                _openedFilesList.Add(_filePath);
                                File.AppendAllText("DataHistoryDeveloperEditor.txt", _filePath + Environment.NewLine);
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

                        openFile.FileName = saveFile.FileName;
                        tb.Text = openFile.SafeFileName;
                        _filePath = openFile.FileName;
                        File.AppendAllText("DataHistoryDeveloperEditor.txt", _filePath + Environment.NewLine);
                        _openedFilesList.Add(_filePath);
                        tb.AccessibleDescription = openFile.FileName;
                    }
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
                            FileSaveFunction(saveFileDialog1.FileName);

                            Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                            openFile.FileName = saveFileDialog1.FileName;
                            tabPage.Text = openFile.SafeFileName;
                            tabPage.AccessibleDescription = saveFileDialog1.FileName;
                            File.AppendAllText("DataHistoryDeveloperEditor.txt", _filePath + Environment.NewLine);
                        }
                    }
                    else
                    {
                        FileSaveFunction(tabPage.AccessibleDescription);

                        Text = $@"{tabPage.AccessibleDescription} NotePad (PeerGrade Version)";
                        openFile.FileName = tabPage.AccessibleDescription;
                        tabPage.Text = openFile.SafeFileName;
                        File.AppendAllText("DataHistoryDeveloperEditor.txt", _filePath + Environment.NewLine);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Выбор шрифта, фона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontOption_Click(object sender, EventArgs e)
        {
            try
            {
                fontOption.ShowDialog();
                SelectedPageTextBox().Font = fontOption.Font;
                SelectedPageTextBox().ForeColor = fontOption.Color;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BackgroundTextTheme(object sender, EventArgs e)
        {
            colorOption.ShowDialog();
            SelectedPageTextBox().BackColor = colorOption.Color;
        }

        private void SelectMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().SelectAll();
        }

        private void CopyMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().Copy();
        }

        private void PasteMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().Paste();
        }

        private void SelectAllMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().SelectAll();
        }

        private void CutMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().Cut();
        }

        private void FileSaveFunction(string path)
        {
            StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default);
            if (path.Contains(".rtf"))
                streamWriter.WriteLine(SelectedPageTextBox().Rtf);
            else
                streamWriter.WriteLine(SelectedPageTextBox().Text);

            _filePath = path;
            Text = $@"{_filePath} NotePad (PeerGrade Version)";
            streamWriter.Close();
        }

        private void SaveFileButton_Click(object sender, EventArgs e) => SaveFile_Click(sender, e);

        private void CompileCode_Click(object sender, EventArgs e)
        {
            CompilerCSharp compilerCSharp = new CompilerCSharp();
            compilerCSharp.CompilerResults(SelectedPageTextBox().Text, tabOption);
        }

        private void SyntaxCsharp_Click(object sender, EventArgs e)
        {
            try
            {

                if (tabOption.TabPages.Count >= 1)
                {
                    SelectedPageTextBox().Language = Language.CSharp;
                    SelectedPageTextBox().Text = File.ReadAllText("CSharpExample.cs");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SyntaxHTML_Click(object sender, EventArgs e)
        {
            if (tabOption.TabPages.Count >= 1)
            {
                SelectedPageTextBox().Language = Language.HTML;
                SelectedPageTextBox().Text = @"<!DOCTYPE html>
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
            if (tabOption.TabPages.Count >= 1)
            {
                SelectedPageTextBox().Language = Language.JS;
                SelectedPageTextBox().Text = @"function createEmail( to, from, subject, message ) {
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
            if (tabOption.TabPages.Count >= 1)
                SelectedPageTextBox().Text = string.Empty;
        }

        private void SyntaxXML_Click(object sender, EventArgs e)
        {
            if (tabOption.TabPages.Count >= 1)
            {
                SelectedPageTextBox().Language = Language.XML;
                SelectedPageTextBox().Text = @"<?xml version=""1.0""?>
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
            BackColor = Color.Black;
        }



        private void HackerTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerDeveloperForm(mainMenu, toolButtons, statusStrip1, tabOption, SelectedPageTextBox(), Color.Black, Color.LawnGreen);
            BackColor = Color.Black;
        }


        private void DefaultTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerDeveloperForm(mainMenu, toolButtons, statusStrip1, tabOption, SelectedPageTextBox(), DefaultBackColor, DefaultForeColor);
            BackColor = Color.Black;
        }


        private void ForeColorTheme_Click(object sender, EventArgs e)
        {
            colorOption.ShowDialog();
            SelectedPageTextBox().ForeColor = colorOption.Color;
        }



        private void FcbTextBox_TextChanged(object sender, EventArgs e)
        {
            TabPage tabPage = tabOption.SelectedTab;
            string text = SelectedPageTextBox()?.Text;
            string[] lines = text.Split('\n');
            statusLabel.Text = $@"Symbols: {text.Length}";
            rowsInfo.Text = $@"Rows: {lines.Length}";
            _filePath = tabPage.AccessibleDescription;
        }

        private void TabOption_SelectedIndexChanged(object sender, EventArgs e)
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

        private void UpdateWindow()
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

        private void WindowList(object sender, EventArgs e)
        {
            ToolStripItem toolstripitem = (ToolStripItem)sender;
            TabControl.TabPageCollection tabcoll = tabOption.TabPages;
            foreach (TabPage tb in tabcoll)
            {
                if (toolstripitem.Text == tb.Text)
                {
                    tabOption.SelectedTab = tb;
                    var fcTextBox = tabOption.TabPages[tabOption.SelectedIndex].Controls[0];
                    fcTextBox.Select();
                    UpdateWindow();
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
                            SaveFile_Click(sender, e);
                            break;
                        }

                        tabOption.TabPages.Remove(tabpage);
                        TabOption_SelectedIndexChanged(sender, e);
                        IEnumerable<string> sent = new[] {string.Empty};
                        string[] arrPages = File.ReadAllLines("DataHistoryDeveloperEditor.txt");
                        for (int i = 0; i < arrPages.Length; i++)
                        {
                            sent = arrPages[i].Split(' ')
                                .Distinct(StringComparer.CurrentCultureIgnoreCase);
                        }
                        File.WriteAllLines("DataHistoryDeveloperEditor.txt", sent);
                        File.AppendAllText("DataHistoryDeveloperEditor.txt", _filePath + Environment.NewLine);
                    }
                }
                File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Closing DeveloperEditor {Environment.NewLine}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void TimerStart()
        {
            _newTime = _timeLeft;
            timerInterval.Interval = 1000;
            timerInterval.Start();
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Tick += Timer_Tick;
            timerInterval.Start();
        }


        private void DeveloperEditor_Load(object sender, EventArgs e)
        {
            try
            {
                fcbTextBox.ContextMenuStrip = contextOption;
                tabOption.ContextMenuStrip = contextTabMenuStrip;
                string path = "DataHistoryDeveloperEditor.txt";
                string debugLog = "DebugLog.txt";
                if (!File.Exists(path))
                    File.Create(path);
                else
                {
                    string[] arrPages = File.ReadAllLines("DataHistoryDeveloperEditor.txt");
                    if (arrPages.Length >= 1)
                    {
                        for (int i = 0; i < arrPages.Length; i++)
                        {
                            TabPage tabpage = new TabPage();
                            FastColoredTextBox fctText = new FastColoredTextBox
                            { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };
                            var sent = arrPages[i].Trim(' ').Split(' ')
                                .Distinct(StringComparer.CurrentCultureIgnoreCase);
                            File.WriteAllLines("DataHistoryDeveloperEditor.txt", sent);
                            openFile.FileName = arrPages[i];
                            if (openFile.CheckFileExists)
                            {
                                tabOption.SelectedTab = tabpage;
                                tabOption.TabPages.Add(tabpage);
                                tabpage.Controls.Add(fctText);
                                tabpage.ContextMenuStrip = contextOption;
                                fctText.Text = File.ReadAllText(arrPages[i]);
                                tabpage.Text = openFile.SafeFileName;
                                StatusFileDetector();
                            }
                        }
                    }

                    if (File.Exists(debugLog))
                        File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Opening DeveloperEditor {Environment.NewLine}");
                    else
                    {
                        File.Create(debugLog);
                        File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Opening DeveloperEditor {Environment.NewLine}");
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
            if (tabOption.TabPages.Count >= 1)
            {
                SelectedPageTextBox().Language = Language.JSON;
                SelectedPageTextBox().Text = @"{
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
            if (tabOption.TabPages.Count >= 1)
            {

                SelectedPageTextBox().Language = Language.PHP;
                SelectedPageTextBox().Text = @" public function set($name, $value)
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
                var newIndex = tabOption.TabPages.IndexOf(tabOption.SelectedTab) - 1;

                tabOption.TabPages.Remove(tabOption.SelectedTab);
                if (tabOption.TabPages.Count != 0)
                    tabOption.SelectedTab = tabOption.TabPages[Math.Max(newIndex, 0)];
                if (_openedFilesList.Count != 1)
                    _openedFilesList.RemoveAt(newIndex);
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
        private void UpdateWindowToolStripMenuItem_Click(object sender, EventArgs e) => UpdateWindow();

        /// <summary>
        /// The cut context menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CutContextMenu_Click(object sender, EventArgs e) => CutButton_Click(sender, e);

        /// <summary>
        /// The select context menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SelectContextMenu_Click(object sender, EventArgs e) => SelectMenu_Click(sender, e);

        /// <summary>
        /// The redo contex menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RedoContextMenu_Click(object sender, EventArgs e) => RedoMenu_Click(sender, e);

        /// <summary>
        /// The undo context menu_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UndoContextMenu_Click(object sender, EventArgs e) => UndoMenu_Click(sender, e);

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
                if (tabOption.TabPages.Count >= 1)
                    if (SelectedPageTextBox().TextLength > 0)
                        SelectedPageTextBox().SelectedText = string.Empty;
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
        private void FullWindowedToolStripMenuItem_Click(object sender, EventArgs e) => WindowState = FormWindowState.Maximized;

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
                if (tabOption.TabPages.Count >= 1)
                    SelectedPageTextBox().Font = new Font(SelectedPageTextBox().Font, FontStyle.Bold);
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
                if (tabOption.TabPages.Count >= 1)
                    SelectedPageTextBox().Font = new Font(SelectedPageTextBox().Font, FontStyle.Italic);
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
                if (tabOption.TabPages.Count >= 1)
                    SelectedPageTextBox().Font = new Font(SelectedPageTextBox().Font, FontStyle.Underline);
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
                if (tabOption.TabPages.Count >= 1)
                    SelectedPageTextBox().Font = new Font(SelectedPageTextBox().Font, FontStyle.Strikeout);
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
            _timeLeft = 300;
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
            _timeLeft = 600;
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
            _timeLeft = 1200;
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
            timerInterval.Stop();
            saveIntervalMenuItem.ShortcutKeyDisplayString = "OFF";
            _timeLeft = 0;
        }

        private void SyntaxPython_Click(object sender, EventArgs e)
        {
            if (tabOption.TabPages.Count >= 1)
            {
                SelectedPageTextBox().Language = Language.JS;
                SelectedPageTextBox().Text = @" class MyClass:
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
            tabOption.TabPages.Remove(tabOption.SelectedTab);
        }

        private void DeleteToolStripMenu_Click_1(object sender, EventArgs e)
        {
            DeleteToolStripMenu_Click(sender, e);
        }

        private void NewDeveloperWindow_Click(object sender, EventArgs e)
        {
            var newNotepad = new DeveloperEditor();
            newNotepad.Show();
        }

        private void FormattingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workspace = new AdhocWorkspace(MefHostServices.DefaultHost);
            var formattedSource = Formatter.Format(CSharpSyntaxTree.ParseText(SelectedPageTextBox()
                            .Text)
                        .GetRoot(),
                    workspace)
                .ToFullString();
            SelectedPageTextBox().Text = formattedSource;
        }

        private void debugInfo_Click(object sender, EventArgs e) => MessageBox.Show("Debug info is located on .exe path");

        private void aboutPanel_Click(object sender, EventArgs e) => MessageBox.Show("Build version: " + ProductVersion);

        private void UndoMenu_Click(object sender, EventArgs e) => BackButton_Click(sender, e);

        private void RedoMenu_Click(object sender, EventArgs e) => ReturnButton_Click(sender, e);
        // Закрытие приложения.
        private void ExitTool_Click(object sender, EventArgs e) => Application.Exit();

        // Переходит в событие создания нового файла.
        private void NewFile_Button(object sender, EventArgs e) => NewFile_Click(sender, e);

        // Переходит в событие открытия нового файла.
        private void OpenFile_Button(object sender, EventArgs e) => OpenFile_Click(sender, e);

        // Переходит в событие сохранения файла с выбором расширения.
        private void SaveAs_Button(object sender, EventArgs e) => SaveAsFile_Click(sender, e);

        // Переходит в события копии текста.
        private void CopyText(object sender, EventArgs e) => CopyMenu_Click(sender, e);

        private void PasteText(object sender, EventArgs e) => PasteMenu_Click(sender, e);

        private void CutText(object sender, EventArgs e) => CutMenu_Click(sender, e);

        private void BackButton_Click(object sender, EventArgs e) => SelectedPageTextBox()?.Undo();

        private void ReturnButton_Click(object sender, EventArgs e) => SelectedPageTextBox()?.Redo();

        private void CutButton_Click(object sender, EventArgs e) => CutMenu_Click(sender, e);

        private void CopyButton_Click(object sender, EventArgs e) => CopyMenu_Click(sender, e);

        private void SelectAll_Click(object sender, EventArgs e) => SelectAllMenu_Click(sender, e);

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().Zoom < 500)
                SelectedPageTextBox().Zoom += 25;
            else
                MessageBox.Show($@"The zoom value is greater than {SelectedPageTextBox().Zoom}!");
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().Zoom <= 0)
                MessageBox.Show($@"The zoom value is less than {SelectedPageTextBox().Zoom}!");
            else
                SelectedPageTextBox().Zoom -= 15;
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
    }
}
