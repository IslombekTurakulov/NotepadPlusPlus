using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Host.Mef;

namespace NotepadPlusPlus
{
    public partial class MainForm : Form
    {
        // Путь файла
        private string _filePath = string.Empty;
        // Создаём список с информацией путей.
        private readonly List<string> _openedFilesList = new List<string>();
        // Оставшееся время.
        private int _timeleft = 300;
        private int _newTime;
        private int _filesNew;

        private int _backupCount;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Формы
        private void NewFormTool_Click(object sender, EventArgs e)
        {
            var newNotepad = new MainForm();
            newNotepad.Show();
        }

        private void CsharpEditor_Click(object sender, EventArgs e)
        {
            DeveloperEditor developerEditor = new DeveloperEditor();
            developerEditor.ShowDialog();
        }
        #endregion

        #region Текстбокс/Обновление информации
        private RichTextBox SelectedTab()
        {
            RichTextBox richTextBox = null;
            TabPage tabpage = tabOption.SelectedTab;
            foreach (var c in tabpage.Controls)
                if (c is RichTextBox box)
                    richTextBox = box;
            return richTextBox;
        }

        public void UpdateDocumentSelectorList()
        {
            TabControl.TabPageCollection tabcoll = tabOption.TabPages;
            TreeView.Nodes.Clear();
            // Перебираем вкладки.
            foreach (TabPage tabPage in tabcoll)
            {
                string fileName = tabPage.Text;
                Color color;
                // Если файл содержит символ и такую букву.
                if (fileName.Contains("*"))
                    fileName = fileName.Remove(fileName.Length - 1);
                if (fileName.Contains("Untitled"))
                    color = Color.Green;
                else

                    color = Color.FromArgb(255, 250, 250);
                // Добавляем новый путь и цвет.
                TreeNode trnode = new TreeNode { Text = fileName, BackColor = color };
                TreeView.Nodes.Add(trnode);
            }
        }
        #endregion

        #region Файл 
        
        #region Новый файл

        /// <summary>
        /// Запись текста в путь
        /// </summary>
        /// <param name="path"></param>
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

        private void NewFile_Click(object sender, EventArgs e)
        {
            try
            {
                Text = @"NotePad (PeerGrade Version)";
                // Создаём объект RichTextBox
                RichTextBox richTextBox = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    ContextMenuStrip = contextOption
                };
                // Создаём новую вкладку.
                TabPage tabPage = new TabPage { Text = $@"Untitled ({++_filesNew})" };

                // Добавляем параметры текстбокса в вкладку
                tabPage.Controls.Add(richTextBox);
                tabPage.AccessibleDescription = tabPage.Text;
                tabOption.SelectedTab = tabPage;
                tabOption.TabPages.Add(tabPage);

                var richTextBox1 = tabOption.TabPages[tabOption.SelectedIndex].Controls[0];
                richTextBox1.Select();
                // Обновление информации про вкладку.
                UpdateDocumentSelectorList();
                // add contextmenustrip to richTextBox1
                richTextBox1.TextChanged += RichTextBox_TextChanged;
                richTextBox1.ContextMenuStrip = contextOption;
                // Добавляем в список название вкладки
                _openedFilesList.Add(tabPage.Text);
                Text = @"Untitled " + _filesNew + @" Notepad (Peergrade Version)";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region Открытие
        private void OpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаём новый объект вкладки и текстбокса.
                TabPage tabpage = new TabPage();
                RichTextBox richText = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    ContextMenuStrip = contextOption
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // Добавляем параметры.
                    tabOption.SelectedTab = tabpage;
                    tabpage.Controls.Add(richText);
                    tabOption.TabPages.Add(tabpage);
                    // Проверка , если путь содержит расширение rtf.
                    if (openFile.FileName.Contains(".rtf"))
                        richText.Rtf = File.ReadAllText(openFile.FileName);
                    else
                        richText.Text = File.ReadAllText(openFile.FileName);

                    richText.TextChanged += RichTextBox_TextChanged;
                    tabpage.Text = openFile.SafeFileName;
                    _filePath = openFile.FileName;
                    // Задаём имя форме.
                    Text = $@"{_filePath} NotePad (PeerGrade Version)";
                    tabpage.AccessibleDescription = openFile.FileName;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion
        
        #region Сохранение
        private void SaveAsFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Если вкладок больше единицы.
                if (tabOption.TabCount >= 1)
                {
                    TabPage tabPage = tabOption.SelectedTab;
                    // Проверка на сохранение.
                    if (!tabPage.Text.Contains("Untitled"))
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog
                        {
                            Filter =
                                "Текстовый документ (*.txt)|*.txt|C# (*.cs)|*.cs|JavaScript (*.js)|*.js|HTML (*.html)|*.html|CSS (*.css)|*.css|RTF (*.rtf)|*.rtf|Все файлы (*.)|*."
                        };

                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            // Метод сохранения файла.
                            NewFileInterval(saveFileDialog1.FileName);
                            // Меняем имя формы.
                            Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                            // Добавляем пути.
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
                            // Метод сохранения файла.
                            NewFileInterval(saveFileDialog1.FileName);
                            // Меняем имя формы.
                            Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                            // Добавляем пути.
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

        private void SaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabOption.TabCount >= 1)
                {
                    // Объявляем выбранную вкладку в tabpage.
                    TabPage tabPage = tabOption.SelectedTab;
                    if (tabPage.Text.Contains("Untitled"))
                    {
                        TabControl.TabPageCollection tabcoll = tabOption.TabPages;
                        foreach (TabPage tabpage in tabcoll)
                        {
                            // Сохранение и вывод сообщения.
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
                                // Если текст не содержит Untitled .
                                if (!tabpage.Text.Contains("Untitled"))
                                {
                                    // Метод сохранения текста в файл.
                                    NewFileInterval(tabpage.AccessibleDescription);
                                    _filePath = tabpage.AccessibleDescription;
                                    tabpage.AccessibleDescription = openFile.FileName;
                                    // Присваиваем имя в форму
                                    Text = $@"{tabpage.AccessibleDescription} NotePad (PeerGrade Version)";
                                    // Добавляем в историю файла.
                                }
                                else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    // Метод сохранения текста в файл
                                    NewFileInterval(saveFileDialog1.FileName);
                                    // Присваиваем имя в форму
                                    Text = $@"{saveFileDialog1.FileName} NotePad (PeerGrade Version)";
                                    openFile.FileName = saveFileDialog1.FileName;
                                    tabpage.AccessibleDescription = openFile.FileName;
                                    tabpage.Text = openFile.SafeFileName;
                                    _filePath = saveFileDialog1.FileName;
                                    // Добавляем в историю файла.
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
                        // Метод сохранения.
                        NewFileInterval(path: tabPage.AccessibleDescription);
                        // Имя формы
                        Text = $@"{tabPage.AccessibleDescription} NotePad (PeerGrade Version)";
                        // Добавляем в историю файла.
                        File.AppendAllText("DataHistoryEditor.txt", _filePath + Environment.NewLine);
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

        #region Темы
        // Тёмная тема
        private void BlackTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerMainForm(mainMenu, fastToolButton, statusTextEditor, tabOption, SelectedTab(), TreeView, Color.DimGray, Color.White);
            BackColor = Color.Black;
            TreeView.BackColor = Color.DimGray;
            File.WriteAllText("ThemeCollector.txt", "Black");
        }
        // Тема хакера
        private void HackerTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerMainForm(mainMenu, fastToolButton, statusTextEditor, tabOption, SelectedTab(), TreeView, Color.DimGray, Color.LawnGreen);
            BackColor = Color.Black;
            TreeView.BackColor = Color.DimGray;
            File.WriteAllText("ThemeCollector.txt", "Hacker");
        }
        // Дефолтная тема
        private void DefaultTheme_Click(object sender, EventArgs e)
        {
            ColorTheme colorTheme = new ColorTheme();
            colorTheme.ColorChangerMainForm(mainMenu, fastToolButton, statusTextEditor, tabOption, SelectedTab(), TreeView, DefaultBackColor, DefaultForeColor);
            BackColor = DefaultBackColor;
            TreeView.BackColor = Color.White;
            BackColor = DefaultBackColor;
            tabOption.SelectedTab.BackColor = DefaultBackColor;
            statusTextEditor.BackColor = Color.WhiteSmoke;
            mainMenu.BackColor = Color.WhiteSmoke;
            fastToolButton.BackColor = Color.AntiqueWhite;
            File.WriteAllText("ThemeCollector.txt", "Light");
        }
        #endregion

        #region Фон текста

        private void ForeColorTheme_Click(object sender, EventArgs e)
        {
            colorOption.ShowDialog();
            SelectedTab().ForeColor = colorOption.Color;
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

        #region Форматирование Текста
        /// <summary>
        /// Форматирование текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var workspace = new AdhocWorkspace(MefHostServices.DefaultHost);
            var formattedSource = Formatter.Format(CSharpSyntaxTree.ParseText(SelectedTab().Text).GetRoot(), workspace).ToFullString();
            SelectedTab().Text = formattedSource;
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
        #endregion

        #endregion

        #region Вид
        private void LeftSideToolStripMenuItem_Click(object sender, EventArgs e) => SelectedTab().SelectionAlignment = HorizontalAlignment.Left;

        private void MiddleToolStripMenuItem_Click(object sender, EventArgs e) => SelectedTab().SelectionAlignment = HorizontalAlignment.Center;

        private void RightSideToolStripMenuItem_Click(object sender, EventArgs e) => SelectedTab().SelectionAlignment = HorizontalAlignment.Right;
        #endregion

        #region Автосохранение
        // Задаём параметры интервала времени.
        private void FourthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timeleft = 60;
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }
        // Задаём параметры интервала времени.
        private void FirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timeleft = 300;
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        // Задаём параметры интервала времени.
        private void SecondTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timeleft = 600;
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        // Задаём параметры интервала времени.
        private void ThirdTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timeleft = 1200;
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Stop();
            TimerStart();
        }

        // Задаём параметры интервала времени.
        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerInterval.Stop();
            saveIntervalMenuItem.ShortcutKeyDisplayString = "OFF";
            _timeleft = 0;
        }
        /// <summary>
        /// Таймер сохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Метод запуска таймера.
        /// </summary>
        void TimerStart()
        {
            _newTime = _timeleft;
            timerInterval.Interval = 1000;
            timerInterval.Start();
            saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            timerInterval.Tick += Timer_Tick;
            timerInterval.Start();
        }

        #endregion

        #region Form Load/Close

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Сохранение путей.
                string path = "DataHistoryEditor.txt";
                string debugLog = "DebugLog.txt";

                // Если файл не существует , то создаём.
                if (!File.Exists(path))
                    File.Create(path);
                else
                {
                    string[] arrPages = File.ReadAllLines(path);
                    for (int i = 0; i < arrPages.Length; i++)
                        if (arrPages[i].Contains("Untitled"))
                            arrPages[i].Remove(i);

                    // Запускаем таймер.
                    TimerStart();
                    if (tabOption.TabCount == 0)
                    {
                        NewFile_Click(sender, e);
                        // Настройка темы.
                        string[] color = File.ReadAllLines("ThemeCollector.txt");
                        if(color[0].Contains("Black"))
                            BlackTheme_Click(sender, e);
                        else if (color[0].Contains("Light"))
                            DefaultTheme_Click(sender, e);
                        else if (color[0].Contains("Hacker"))
                            HackerTheme_Click(sender, e);
                    }

                    // Если ссылок больше чем 1 
                    if (arrPages.Length >= 1)
                    {
                        for (int i = 0; i < arrPages.Length; i++)
                        {
                            // Создаём объект текстбокса.
                            RichTextBox fctText = new RichTextBox
                            {
                                Dock = DockStyle.Fill,
                                BorderStyle = BorderStyle.None,
                                ContextMenuStrip = contextOption
                            };

                            openFile.FileName = arrPages[i];
                            // Проверка на файл.
                            if (openFile.CheckFileExists)
                            {
                                if (!arrPages[i].Contains("Untitled"))
                                {
                                    if (arrPages[i].Contains(".rtf"))
                                        fctText.Rtf = File.ReadAllText(arrPages[i]);
                                    else
                                        fctText.Text = File.ReadAllText(arrPages[i]);

                                    // Создаём объект вкладок.
                                    TabPage tabpage = new TabPage
                                    {
                                        Controls = {fctText},
                                        Text = openFile.SafeFileName,
                                        AccessibleDescription = openFile.FileName,
                                        ContextMenuStrip = tabControlContextMenu
                                    };

                                    // Добавляем в вкладки.
                                    tabOption.SelectedTab = tabpage;
                                    tabOption.TabPages.Add(tabpage);
                                }
                            }

                            UpdateDocumentSelectorList();
                        }

                        tabOption.ContextMenuStrip = tabControlContextMenu;
                        // Если файл не существует, то создаём
                        if (File.Exists(debugLog))
                            File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Opening MainForm {Environment.NewLine}");
                        else
                        {
                            File.Create(debugLog);
                            File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Opening MainForm {Environment.NewLine}");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Собираю инфу про вкладку.
                TabControl.TabPageCollection tabcoll1 = tabOption.TabPages;
                // Читаю с текстового файла.
                string[] arrPages = File.ReadAllLines("DataHistoryEditor.txt");
                // Создаю 3 списка
                List<string> list = new List<string>(arrPages);
                List<string> tabPageUrl = new List<string>();
                List<string> finalList = new List<string>();
                // Добавление вкладок в список.
                foreach (TabPage tabpage in tabcoll1)
                {
                    tabPageUrl.Add(tabpage.AccessibleDescription);
                }
                // Убираю не нужные ссылки.
                finalList = tabPageUrl.Where(g => !list.Contains(g)).ToList();
               

                if (tabOption.TabCount > 0)
                {
                    TabControl.TabPageCollection tabcoll = tabOption.TabPages;
                    // Перебираем вкладки.
                    foreach (TabPage tabpage in tabcoll)
                    {
                        tabOption.SelectedTab = tabpage;
                        // Если не сохранилось, то выполняем условие.
                        if (tabpage.Text.Contains("Untitled"))
                            SaveFile_Click(sender, e);
                        
                        tabOption.TabPages.Remove(tabpage);

                        _filePath = tabpage.AccessibleDescription;
                        // Добавляем ссылки в файл.
                        for (int i = 0; i < finalList.Count; i++)
                        {
                            if(!finalList[i].Contains("Untitled"))
                                File.AppendAllText("DataHistoryEditor.txt", finalList[i] + Environment.NewLine);
                        }

                        break;
                    }
                }
                // Добавляем в дебаг.
                File.AppendAllText("DebugLog.txt", $"[{DateTime.UtcNow}] Closing DeveloperEditor {Environment.NewLine}");

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region Окно/Обновление/Размер
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
        #endregion

        #region Changed Events
        /// <summary>
        /// Событие для того, чтобы взять информацию про строки и символы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Событие индекса вкладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabOption.TabCount > 0)
                {
                    // Присваиваем открытую вкладку в tabpage
                    TabPage tabpage = tabOption.SelectedTab;

                    foreach (string filename in _openedFilesList)
                    {
                        // Если tabpage не null
                        if (tabpage != null)
                        {
                            //Выполняем все действия
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
                    // Обновляем окно
                    UpdateWindow();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region Быстрые клавиши
        
        #region Увеличение зума
        private void ZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedTab()?.ZoomFactor < 50)
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
                if (SelectedTab()?.ZoomFactor < 2)
                    SelectedTab().ZoomFactor = 0;
                else
                    SelectedTab().ZoomFactor -= 2;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region Контестное меню
        private void SaveFileButton(object sender, EventArgs e) => SaveFile_Click(sender, e);

        private void NewFile_Button(object sender, EventArgs e) => NewFile_Click(sender, e);

        private void OpenFile_Button(object sender, EventArgs e) => OpenFile_Click(sender, e);

        private void SaveAs_Button(object sender, EventArgs e) => SaveAsFile_Click(sender, e);

        private void BackButton_Click(object sender, EventArgs e) => UndoToolStripMenu_Click(sender, e);

        private void ReturnButton_Click(object sender, EventArgs e) => SelectedTab()?.Redo();

        private void CutButton_Click(object sender, EventArgs e) => CutMenu_Click(sender, e);

        private void CopyButton_Click(object sender, EventArgs e) => CopyTextMenu_Click(sender, e);

        private void SelectAll_Click(object sender, EventArgs e) => SelectAllMenu_Click(sender, e);
        #endregion

        #region Панель Меню

        private void aboutPanel_Click(object sender, EventArgs e) => MessageBox.Show("Build version: " + ProductVersion);

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

        private void StrikeOutButtonStrip_Click(object sender, EventArgs e) => StrikeOutToolStripItem_Click(sender, e);

        private void CloseTabPageButton_Click(object sender, EventArgs e) => DeleteToolStripMenuItem_Click(sender, e);

        private void ExitTool_Click(object sender, EventArgs e) => Application.Exit();

        private void CopyText_Click(object sender, EventArgs e)
        {
            if (SelectedTab()?.TextLength > 0)
                SelectedTab().Copy();
        }
        private void CopyTextMenu_Click(object sender, EventArgs e) => CopyText_Click(sender, e);

        private void PasteText_Click(object sender, EventArgs e)
        {
            if (SelectedTab()?.TextLength > 0)
                SelectedTab().Paste();
        }
        private void PasteMenu_Click(object sender, EventArgs e) => PasteText_Click(sender, e);
        
        private void CutText_Click(object sender, EventArgs e)
        {
            if (SelectedTab()?.TextLength > 0)
                SelectedTab().Cut();
        }

        private void CutMenu_Click(object sender, EventArgs e) => CutText_Click(sender, e);

        private void FontOptionButton_Click(object sender, EventArgs e) => FontOption_Click(sender, e);
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

        private void SelectMenu_Click(object sender, EventArgs e)
        {
            if (SelectedTab().TextLength > 0)
                SelectedTab().SelectAll();
        }
      
        private void SelectAllMenu_Click(object sender, EventArgs e)
        {
            if (SelectedTab().TextLength > 0)
                SelectedTab().SelectAll();
        }

        private void SelectContextMenu_Click(object sender, EventArgs e) => SelectMenu_Click(sender, e);

        private void UndoContextMenu_Click(object sender, EventArgs e) => UndoToolStripMenu_Click(sender, e);

        private void RedoContexMenu_Click(object sender, EventArgs e) => RedoToolStripMenuItem_Click(sender, e);
        #endregion

        #region Удаление

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
        #endregion

        #endregion

    }
}
