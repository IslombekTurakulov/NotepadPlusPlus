using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        #region Timer
        
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
                        SelectedPageTextBox().SaveToFile(path, Encoding.UTF8);
                        SelectedPageTextBox().SaveToFile(tb.AccessibleDescription, Encoding.UTF8);

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

        /// <summary>
        /// Метод для запуска таймера
        /// </summary>
        void TimerStart()
        {
            _newTime = _timeLeft;
            timerInterval.Interval = 1000;
            timerInterval.Start();
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            // Запускаем счётчик
            timerInterval.Tick += Timer_Tick;
            timerInterval.Start();
        }
        #endregion

        #region Файл

        #region Новый файл

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
            // Если вкладок меньше или равно нуля, то создаём новый файл.
            if (tabOption.TabCount >= 0)
            {
                TabPage tabPage = new TabPage {Text = $@"Untitled ({++_filesNew})"};
                FastColoredTextBox textBox =
                    new FastColoredTextBox {Dock = DockStyle.Fill, BorderStyle = BorderStyle.None};
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
                Text = " Untitled " + _filesNew + @" Notepad (Peergrade Version)";
            }
        }

        #endregion

        #region Открытие

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
                    // Добавляю в список недавних открытых файлов.
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region Сохранение

        /// <summary>
        /// Метод сохранения файла.
        /// </summary>
        /// <param name="path"></param>
        private void FileSaveFunction(string path)
        {
            StreamWriter streamWriter = new StreamWriter(path, false, Encoding.Default);
            // Проверка на путь файла, если расширение rtf, то выполняем это действие.
            if (path.Contains(".rtf"))
                streamWriter.WriteLine(SelectedPageTextBox().Rtf);
            else
                streamWriter.WriteLine(SelectedPageTextBox().Text);

            _filePath = path;
            Text = $@"{_filePath} NotePad (PeerGrade Version)";
            // Закрываем поток.
            streamWriter.Close();
        }

        /// <summary>
        /// Сохранение файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                TabPage tb = tabOption.SelectedTab;
                if (tb.Text.Contains("Untitled"))
                {
                    // Перебираю вкладки для сохранения и проверки на путь.
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

                            // Если это не Untitled то выполняю быстрое сохранение.
                            if (!tabpage.Text.Contains("Untitled"))
                            {
                                // Метод записи.
                                FileSaveFunction(tabpage.AccessibleDescription);
                                _filePath = tabpage.AccessibleDescription;
                                // Меняю название редактора.
                                Text = $@"{_filePath} NotePad (PeerGrade Version)";
                                // Добавляю в историю сохранённых.
                            }
                            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                // Метод записи.
                                FileSaveFunction(saveFileDialog1.FileName);
                                _filePath = saveFileDialog1.FileName;
                                // Меняю название редактора.
                                Text = $@"{_filePath} NotePad (PeerGrade Version)";
                                openFile.FileName = saveFileDialog1.FileName;
                                tabpage.Text = openFile.SafeFileName;
                                tabpage.AccessibleDescription = openFile.FileName;
                                // Добавляю в историю сохранённых.
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
                    // Проверка на сохранение.
                    if (!tb.Text.Contains("Untitled"))
                    {
                        // Метод сохранения.
                        FileSaveFunction(tb.AccessibleDescription);
                    }
                    else if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        // Метод сохранения.
                        FileSaveFunction(saveFile.FileName);

                        // Добавляю в переменные пути сохранения файла.
                        openFile.FileName = saveFile.FileName;
                        tb.Text = openFile.SafeFileName;
                        _filePath = openFile.FileName;
                        // Добавляю в историю сохранённых.
                        File.AppendAllText("DataHistoryDeveloperEditor.txt", _filePath + Environment.NewLine);
                        tb.AccessibleDescription = openFile.FileName;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Сохранение файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Если вкладок больше или равно 1 то выполняем сохранение аналогичное с SaveFile.
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
                            // Метод сохранения.
                            FileSaveFunction(saveFileDialog1.FileName);

                            Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                            openFile.FileName = saveFileDialog1.FileName;
                            tabPage.Text = openFile.SafeFileName;
                            tabPage.AccessibleDescription = saveFileDialog1.FileName;
                            // Запись в историю.
                        }
                    }
                    else
                    {
                        // Метод сохранения.
                        FileSaveFunction(tabPage.AccessibleDescription);

                        Text = $@"{tabPage.AccessibleDescription} NotePad (PeerGrade Version)";
                        openFile.FileName = tabPage.AccessibleDescription;
                        tabPage.Text = openFile.SafeFileName;
                        // Запись в историю.
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #endregion
        
        #region Вкладка и компиляция
        private FastColoredTextBox SelectedPageTextBox()
        {
            // Присваиваю выбранную вкладку в новый TabPage.
            TabPage tabpage = tabOption.SelectedTab;
            // И тут идёт проверка , если внутри вкладки если текстбокс то присваивается.
            foreach (var c in tabpage.Controls)
                if (c is FastColoredTextBox box)
                {
                    documentMap.Target = box;
                    return box;
                }

            return null;
        }
        
        /// <summary>
        /// Компиляция кода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompileCode_Click(object sender, EventArgs e)
        {
            // Создаю объект CompilerCSharp.
            CompilerCSharp compilerCSharp = new CompilerCSharp();
            // Создаю новый файл , в котором записан код.
            File.WriteAllText("compiler.cs", SelectedPageTextBox().Text);
            // Беру информацию про путь файла
            FileInfo directory = new FileInfo("compiler.cs");
            // Создаю новую вкладку и текстбокс
            TabPage tb = new TabPage();
            FastColoredTextBox ftcb = new FastColoredTextBox()
            { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };
            // Ставлю результат в текстбокс
            ftcb.Text = compilerCSharp.CompileCode(@"" + directory.FullName);
            tb.Text = "Compile Completed!";
            // Присваиваю контролы текстбокса
            tb.Controls.Add(ftcb);
            tabOption.TabPages.Add(tb);
        }
        #endregion

        #region Syntax

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
        /// Очень долгая проверка которая занимает 3 секунды , я поленился менять
        /// </summary>
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
                SelectedPageTextBox().Language = Language.Custom;
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

        #endregion

        #region Themes

        private void BlackTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerDeveloperForm(mainMenu, toolButtons, statusStrip1, tabOption, SelectedPageTextBox(), Color.DimGray, Color.White);
            BackColor = Color.DimGray;
            File.WriteAllText("ThemeCollector.txt", "Black");
        }



        private void HackerTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerDeveloperForm(mainMenu, toolButtons, statusStrip1, tabOption, SelectedPageTextBox(), Color.DimGray, Color.LawnGreen);
            BackColor = Color.Black;
            File.WriteAllText("ThemeCollector.txt", "Hacker");
        }


        private void DefaultTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerDeveloperForm(mainMenu, toolButtons, statusStrip1, tabOption, SelectedPageTextBox(), DefaultBackColor, DefaultForeColor);
            BackColor = DefaultBackColor;
            tabOption.SelectedTab.BackColor = DefaultBackColor;
            toolButtons.BackColor = Color.AntiqueWhite;
            mainMenu.BackColor = Color.WhiteSmoke;
            statusStrip1.BackColor = Color.AntiqueWhite;
            File.WriteAllText("ThemeCollector.txt", "Light");
        }


        private void ForeColorTheme_Click(object sender, EventArgs e)
        {
            colorOption.ShowDialog();
            SelectedPageTextBox().ForeColor = colorOption.Color;
        }

        #endregion

        #region Update/Change

        /// <summary>
        /// Событие для получения сведения про строки и символы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FcbTextBox_TextChanged(object sender, EventArgs e)
        {
            TabPage tabPage = tabOption.SelectedTab;
            string text = SelectedPageTextBox()?.Text;
            string[] lines = text.Split('\n');
            statusLabel.Text = $@"Symbols: {text.Length}";
            rowsInfo.Text = $@"Rows: {lines.Length}";
            _filePath = tabPage.AccessibleDescription;
        }

        /// <summary>
        /// Обновление окна
        /// </summary>
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

        /// <summary>
        /// Сколько окон находится в данный момент.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowList(object sender, EventArgs e)
        {
            ToolStripItem toolstripitem = (ToolStripItem)sender;
            TabControl.TabPageCollection tabcoll = tabOption.TabPages;
            foreach (TabPage tb in tabcoll)
            {
                if (toolstripitem.Text == tb.Text)
                {
                    // Перебираем циклом и обновляем каждую вкладку.
                    tabOption.SelectedTab = tb;
                    var fcTextBox = tabOption.TabPages[tabOption.SelectedIndex].Controls[0];
                    fcTextBox.Select();
                    UpdateWindow();
                }
            }
        }

        #endregion

        #region Closing/Load
        private void DeveloperEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Собираю инфу про вкладку.
                TabControl.TabPageCollection tabcoll1 = tabOption.TabPages;
                // Читаю с текстового файла.
                string[] arrPages = File.ReadAllLines("DataHistoryDeveloperEditor.txt");
                // Создаю 3 списка
                List<string> list = new List<string>(arrPages);
                List<string> tabPageUrl = new List<string>();
                List<string> finalList = new List<string>();
                // Добавление вкладок в список.
                foreach (TabPage tabpage in tabcoll1)
                {
                    tabPageUrl.Add(@" " + tabpage.AccessibleDescription);
                }
                // Убираю не нужные ссылки.
                finalList = tabPageUrl.Where(g => !list.Contains(g)).ToList();

                if (finalList.Contains("Untitled"))
                    finalList.Remove("Untitled");

                if (tabOption.TabCount > 0)
                {
                    TabControl.TabPageCollection tabcoll = tabOption.TabPages;
                    // Перебираем вкладки.
                    foreach (TabPage tabpage in tabcoll)
                    {
                        tabOption.SelectedTab = tabpage;
                        // Если не сохранилось, то выполняем условие.
                        if (tabpage.Text.Contains("Untitled"))
                        {
                            SaveFile_Click(sender, e);
                        }
                        tabOption.TabPages.Remove(tabpage);

                        _filePath = tabpage.AccessibleDescription;
                        // Добавляем ссылки в файл.
                        for (int i = 0; i < finalList.Count; i++)
                        {
                            File.AppendAllText("DataHistoryDeveloperEditor.txt", finalList[i] + Environment.NewLine);
                        }
                        break;
                    }
                }
                // Добавляем в Лог.
                File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Closing DeveloperEditor {Environment.NewLine}");

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Запуск формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeveloperEditor_Load(object sender, EventArgs e)
        {
            try
            {
                // Добавляем параметры
                tabOption.ContextMenuStrip = contextTabMenuStrip;
                string path = "DataHistoryDeveloperEditor.txt";
                string debugLog = "DebugLog.txt";
                // Проверка на сушествование.
                if (!File.Exists(path))
                    File.Create(path);
                else
                {
                    string[] arrPages = File.ReadAllLines("DataHistoryDeveloperEditor.txt");
                    // Если ссылок больше чем или равно 1, то выполняем условие.
                    if (tabOption.TabCount == 0)
                    {
                        NewFile_Click(sender, e);
                        string[] color = File.ReadAllLines("ThemeCollector.txt");
                        if(color[0].Contains("Black"))
                            BlackTheme_Click(sender, e);
                        else if (color[0].Contains("Light"))
                            DefaultTheme_Click(sender, e);
                        else if (color[0].Contains("Hacker"))
                            HackerTheme_Click(sender, e);
                    }
                    if (arrPages.Length >= 1)
                    {
                        for (int i = 0; i < arrPages.Length; i++)
                        {
                            // Создаём новую вкладку и текстбокс.
                            TabPage tabpage = new TabPage();
                            FastColoredTextBox fctText = new FastColoredTextBox
                            { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };
                            openFile.FileName = arrPages[i].Trim(' ');
                            // Проверяем , существует ли файл
                            if (openFile.CheckFileExists)
                            {
                                if (openFile.FileName != String.Empty)
                                {
                                    tabOption.SelectedTab = tabpage;
                                    tabOption.TabPages.Add(tabpage);
                                    tabpage.Controls.Add(fctText);
                                    tabpage.ContextMenuStrip = contextOption;
                                    fctText.Text = File.ReadAllText(arrPages[i]);
                                    tabpage.Text = openFile.SafeFileName;

                                    fctText.TextChanged += FcbTextBox_TextChanged;
                                    StatusFileDetector();
                                }
                            }
                        }
                    }
                    // Существует ли файл
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
        #endregion

        #region Кнопки меню и быстрого доступа
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
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// Выбор шрифта, фона.
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

        /// <summary>
        ///  Выбор заднего фона.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundTextTheme(object sender, EventArgs e)
        {
            colorOption.ShowDialog();
            SelectedPageTextBox().BackColor = colorOption.Color;
        }
        /// <summary>
        /// Выделение области.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().SelectAll();
        }
        /// <summary>
        /// Копировать.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().Copy();
        }
        /// <summary>
        /// Вставить текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().Paste();
        }
        /// <summary>
        /// Выделение всей области.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().SelectAll();
        }
        /// <summary>
        /// Вырезать текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutMenu_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().TextLength > 0)
                SelectedPageTextBox().Cut();
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


        private void CloseTabPageButton_Click(object sender, EventArgs e) => tabOption.TabPages.Remove(tabOption.SelectedTab);

        private void DeleteToolStripMenu_Click_1(object sender, EventArgs e) => DeleteToolStripMenu_Click(sender, e);

        private void NewDeveloperWindow_Click(object sender, EventArgs e)
        {
            var newNotepad = new DeveloperEditor();
            newNotepad.Show();
        }
        /// <summary>
        /// Форматирование текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        // Логги программы.
        private void debugInfo_Click(object sender, EventArgs e) => MessageBox.Show("Debug info is located on .exe path");
        // Информация про прогу.
        private void aboutPanel_Click(object sender, EventArgs e) => MessageBox.Show("Build version: " + ProductVersion);
        // Отменяем изменённый текст.
        private void UndoMenu_Click(object sender, EventArgs e) => BackButton_Click(sender, e);
        // Вернём изменённый текст.
        private void RedoMenu_Click(object sender, EventArgs e) => ReturnButton_Click(sender, e);
        private void BackButton_Click(object sender, EventArgs e) => SelectedPageTextBox()?.Undo();
        // Закрытие приложения.
        private void ExitTool_Click(object sender, EventArgs e) => Application.Exit();
        private void ReturnButton_Click(object sender, EventArgs e) => SelectedPageTextBox()?.Redo();
        // Переходит в событие создания нового файла.
        private void NewFile_Button(object sender, EventArgs e) => NewFile_Click(sender, e);
        // Переходит в событие открытия нового файла.
        private void OpenFile_Button(object sender, EventArgs e) => OpenFile_Click(sender, e);
        // Переходит в событие сохранения файла с выбором расширения.
        private void SaveAs_Button(object sender, EventArgs e) => SaveAsFile_Click(sender, e);
        // Переходит в события копии текста.
        private void CopyText(object sender, EventArgs e) => CopyMenu_Click(sender, e);
        // Вставить текст.
        private void PasteText(object sender, EventArgs e) => PasteMenu_Click(sender, e);
        // Вырезать текст.
        private void CutText(object sender, EventArgs e) => CutMenu_Click(sender, e);
        // Вырезать текст
        private void CutButton_Click(object sender, EventArgs e) => CutMenu_Click(sender, e);
        // Копировать текст
        private void CopyButton_Click(object sender, EventArgs e) => CopyMenu_Click(sender, e);
        // Сохранение
        private void SaveFileButton_Click(object sender, EventArgs e) => SaveFile_Click(sender, e);
        // Выделить всё
        private void SelectAll_Click(object sender, EventArgs e) => SelectAllMenu_Click(sender, e);
        // Увеличение текстбокса
        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().Zoom < 500)
                SelectedPageTextBox().Zoom += 25;
            else
                MessageBox.Show($@"The zoom value is greater than {SelectedPageTextBox().Zoom}!");
        }
        // Уменьшение текстбокса
        private void ZoomOut_Click(object sender, EventArgs e)
        {
            if (SelectedPageTextBox().Zoom <= 0)
                MessageBox.Show($@"The zoom value is less than {SelectedPageTextBox().Zoom}!");
            else
                SelectedPageTextBox().Zoom -= 15;
        }
        // Печать файла
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
        #endregion
    }
}
