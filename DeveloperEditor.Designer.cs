
using System.ComponentModel;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace NotepadPlusPlus
{
    partial class DeveloperEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeveloperEditor));
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.saveIntervalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.textAlignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.middleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontOptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underLinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strikeOutToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.форматироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundThemeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foreColorTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.generalThemeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackThemeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hackerThemeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.defaultThemeitem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.FullWindowedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullWindowedToolStrip = new System.Windows.Forms.ToolStripSeparator();
            this.updateWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileCodeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.syntaxOption = new System.Windows.Forms.ToolStripMenuItem();
            this.csharpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JsonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SyntaxPython = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorForSyntax = new System.Windows.Forms.ToolStripSeparator();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.debugInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolButtons = new System.Windows.Forms.ToolStrip();
            this.NewButton = new System.Windows.Forms.ToolStripButton();
            this.OpenButton = new System.Windows.Forms.ToolStripButton();
            this.SaveAs = new System.Windows.Forms.ToolStripButton();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripSeparator();
            this.BackButton = new System.Windows.Forms.ToolStripButton();
            this.ReturnButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CutButton = new System.Windows.Forms.ToolStripButton();
            this.CopyButton = new System.Windows.Forms.ToolStripButton();
            this.SelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseTabPageButton = new System.Windows.Forms.ToolStripButton();
            this.fontOption = new System.Windows.Forms.FontDialog();
            this.colorOption = new System.Windows.Forms.ColorDialog();
            this.contextOption = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.redoContexMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabOption = new System.Windows.Forms.TabControl();
            this.contextTabMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentPages = new System.Windows.Forms.TabPage();
            this.fcbTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.fileStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.rowsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameAppLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerInterval = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.documentMap1 = new FastColoredTextBoxNS.DocumentMap();
            this.mainMenu.SuspendLayout();
            this.toolButtons.SuspendLayout();
            this.contextOption.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.contextTabMenuStrip.SuspendLayout();
            this.recentPages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fcbTextBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // mainMenu
            // 
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolMenuItem,
            this.editToolItem,
            this.fontToolItem,
            this.themeToolMenu,
            this.compileMenuItem,
            this.syntaxOption,
            this.toolStripMenuItem5});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(798, 27);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "Main Menu";
            // 
            // fileToolMenuItem
            // 
            this.fileToolMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolItem,
            this.toolStripMenuItem10,
            this.saveToolMenuItem,
            this.saveAsToolItem,
            this.saveToolItem,
            this.toolStripSeparator6,
            this.saveIntervalMenuItem,
            this.toolStripMenuItem1,
            this.exitToolItem});
            this.fileToolMenuItem.Name = "fileToolMenuItem";
            this.fileToolMenuItem.Size = new System.Drawing.Size(53, 23);
            this.fileToolMenuItem.Text = "&Файл";
            // 
            // newToolItem
            // 
            this.newToolItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolItem.Image")));
            this.newToolItem.Name = "newToolItem";
            this.newToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolItem.Size = new System.Drawing.Size(255, 24);
            this.newToolItem.Text = "&Новый";
            this.newToolItem.Click += new System.EventHandler(this.NewFile_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = global::NotepadPlusPlus.Properties.Resources.WindowsForm_16x;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(255, 24);
            this.toolStripMenuItem10.Text = "В новом окне";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.NewDeveloperWindow_Click);
            // 
            // saveToolMenuItem
            // 
            this.saveToolMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolMenuItem.Image")));
            this.saveToolMenuItem.Name = "saveToolMenuItem";
            this.saveToolMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.saveToolMenuItem.Size = new System.Drawing.Size(255, 24);
            this.saveToolMenuItem.Text = "&Открыть";
            this.saveToolMenuItem.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // saveAsToolItem
            // 
            this.saveAsToolItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolItem.Image")));
            this.saveAsToolItem.Name = "saveAsToolItem";
            this.saveAsToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolItem.Size = new System.Drawing.Size(255, 24);
            this.saveAsToolItem.Text = "&Сохранить как";
            this.saveAsToolItem.Click += new System.EventHandler(this.SaveAsFile_Click);
            // 
            // saveToolItem
            // 
            this.saveToolItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolItem.Image")));
            this.saveToolItem.Name = "saveToolItem";
            this.saveToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolItem.Size = new System.Drawing.Size(255, 24);
            this.saveToolItem.Text = "&Сохранить";
            this.saveToolItem.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(252, 6);
            // 
            // saveIntervalMenuItem
            // 
            this.saveIntervalMenuItem.AccessibleDescription = "";
            this.saveIntervalMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstToolStripMenuItem,
            this.secondToolStripMenuItem,
            this.thirdToolStripMenuItem,
            this.toolStripSeparator7,
            this.stopToolStripMenuItem});
            this.saveIntervalMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveIntervalMenuItem.Image")));
            this.saveIntervalMenuItem.Name = "saveIntervalMenuItem";
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "OFF";
            this.saveIntervalMenuItem.Size = new System.Drawing.Size(255, 24);
            this.saveIntervalMenuItem.Text = "Автосохранение";
            // 
            // firstToolStripMenuItem
            // 
            this.firstToolStripMenuItem.Name = "firstToolStripMenuItem";
            this.firstToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.firstToolStripMenuItem.Text = "5 минут";
            this.firstToolStripMenuItem.Click += new System.EventHandler(this.FirstToolStripMenuItem_Click);
            // 
            // secondToolStripMenuItem
            // 
            this.secondToolStripMenuItem.Name = "secondToolStripMenuItem";
            this.secondToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.secondToolStripMenuItem.Text = "10 минут";
            this.secondToolStripMenuItem.Click += new System.EventHandler(this.SecondToolStripMenuItem_Click);
            // 
            // thirdToolStripMenuItem
            // 
            this.thirdToolStripMenuItem.Name = "thirdToolStripMenuItem";
            this.thirdToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.thirdToolStripMenuItem.Text = "20 минут ";
            this.thirdToolStripMenuItem.Click += new System.EventHandler(this.ThirdToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(146, 6);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.stopToolStripMenuItem.Text = "Отключить";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(252, 6);
            // 
            // exitToolItem
            // 
            this.exitToolItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolItem.Image")));
            this.exitToolItem.Name = "exitToolItem";
            this.exitToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolItem.Size = new System.Drawing.Size(255, 24);
            this.exitToolItem.Text = "&Выход";
            this.exitToolItem.Click += new System.EventHandler(this.ExitTool_Click);
            // 
            // editToolItem
            // 
            this.editToolItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolItem,
            this.pasteToolItem,
            this.cutToolItem,
            this.selectToolItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem7,
            this.toolStripMenuItem2,
            this.DeleteToolStripMenu,
            this.textAlignToolStripMenuItem});
            this.editToolItem.Name = "editToolItem";
            this.editToolItem.Size = new System.Drawing.Size(67, 23);
            this.editToolItem.Text = "&Правка";
            // 
            // copyToolItem
            // 
            this.copyToolItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolItem.Image")));
            this.copyToolItem.Name = "copyToolItem";
            this.copyToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolItem.Size = new System.Drawing.Size(213, 24);
            this.copyToolItem.Text = "&Копировать";
            this.copyToolItem.Click += new System.EventHandler(this.CopyText);
            // 
            // pasteToolItem
            // 
            this.pasteToolItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolItem.Image")));
            this.pasteToolItem.Name = "pasteToolItem";
            this.pasteToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolItem.Size = new System.Drawing.Size(213, 24);
            this.pasteToolItem.Text = "&Вставить";
            this.pasteToolItem.Click += new System.EventHandler(this.PasteText);
            // 
            // cutToolItem
            // 
            this.cutToolItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolItem.Image")));
            this.cutToolItem.Name = "cutToolItem";
            this.cutToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolItem.Size = new System.Drawing.Size(213, 24);
            this.cutToolItem.Text = "&Вырезать";
            this.cutToolItem.Click += new System.EventHandler(this.CutText);
            // 
            // selectToolItem
            // 
            this.selectToolItem.Image = ((System.Drawing.Image)(resources.GetObject("selectToolItem.Image")));
            this.selectToolItem.Name = "selectToolItem";
            this.selectToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectToolItem.Size = new System.Drawing.Size(213, 24);
            this.selectToolItem.Text = "&Выделить всё";
            this.selectToolItem.Click += new System.EventHandler(this.SelectMenu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(213, 24);
            this.toolStripMenuItem3.Text = "Отмена";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.UndoMenu_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem7.Image")));
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItem7.Size = new System.Drawing.Size(213, 24);
            this.toolStripMenuItem7.Text = "Вернуться";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.RedoMenu_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(210, 6);
            // 
            // DeleteToolStripMenu
            // 
            this.DeleteToolStripMenu.Image = global::NotepadPlusPlus.Properties.Resources.DeleteStep_16x;
            this.DeleteToolStripMenu.Name = "DeleteToolStripMenu";
            this.DeleteToolStripMenu.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteToolStripMenu.Size = new System.Drawing.Size(213, 24);
            this.DeleteToolStripMenu.Text = "Удалить";
            this.DeleteToolStripMenu.Click += new System.EventHandler(this.DeleteToolStripMenu_Click_1);
            // 
            // textAlignToolStripMenuItem
            // 
            this.textAlignToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftSideToolStripMenuItem,
            this.middleToolStripMenuItem,
            this.rightSideToolStripMenuItem});
            this.textAlignToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("textAlignToolStripMenuItem.Image")));
            this.textAlignToolStripMenuItem.Name = "textAlignToolStripMenuItem";
            this.textAlignToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.textAlignToolStripMenuItem.Text = "Вид";
            // 
            // leftSideToolStripMenuItem
            // 
            this.leftSideToolStripMenuItem.Name = "leftSideToolStripMenuItem";
            this.leftSideToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.leftSideToolStripMenuItem.Text = "Левый край";
            // 
            // middleToolStripMenuItem
            // 
            this.middleToolStripMenuItem.Name = "middleToolStripMenuItem";
            this.middleToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.middleToolStripMenuItem.Text = "В центре";
            // 
            // rightSideToolStripMenuItem
            // 
            this.rightSideToolStripMenuItem.Name = "rightSideToolStripMenuItem";
            this.rightSideToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.rightSideToolStripMenuItem.Text = "Правый край";
            // 
            // fontToolItem
            // 
            this.fontToolItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontOptionsMenu,
            this.toolStripMenuItem9,
            this.boldToolStripMenuItem,
            this.italicToolStripMenuItem,
            this.underLinedToolStripMenuItem,
            this.strikeOutToolStripItem,
            this.toolStripMenuItem12,
            this.форматироватьToolStripMenuItem});
            this.fontToolItem.Name = "fontToolItem";
            this.fontToolItem.Size = new System.Drawing.Size(70, 23);
            this.fontToolItem.Text = "Формат";
            // 
            // fontOptionsMenu
            // 
            this.fontOptionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("fontOptionsMenu.Image")));
            this.fontOptionsMenu.Name = "fontOptionsMenu";
            this.fontOptionsMenu.Size = new System.Drawing.Size(243, 24);
            this.fontOptionsMenu.Text = "Настройка Шрифта";
            this.fontOptionsMenu.Click += new System.EventHandler(this.FontOption_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(240, 6);
            // 
            // boldToolStripMenuItem
            // 
            this.boldToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("boldToolStripMenuItem.Image")));
            this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            this.boldToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+B";
            this.boldToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.boldToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.boldToolStripMenuItem.Text = "Жирный";
            this.boldToolStripMenuItem.Click += new System.EventHandler(this.BoldToolStripMenuItem_Click);
            // 
            // italicToolStripMenuItem
            // 
            this.italicToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("italicToolStripMenuItem.Image")));
            this.italicToolStripMenuItem.Name = "italicToolStripMenuItem";
            this.italicToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.italicToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.italicToolStripMenuItem.Text = "Курсив";
            this.italicToolStripMenuItem.Click += new System.EventHandler(this.ItalicToolStripMenuItem_Click);
            // 
            // underLinedToolStripMenuItem
            // 
            this.underLinedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("underLinedToolStripMenuItem.Image")));
            this.underLinedToolStripMenuItem.Name = "underLinedToolStripMenuItem";
            this.underLinedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.underLinedToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.underLinedToolStripMenuItem.Text = "Подчёркнутый";
            this.underLinedToolStripMenuItem.Click += new System.EventHandler(this.UnderLinedToolStripMenuItem_Click);
            // 
            // strikeOutToolStripItem
            // 
            this.strikeOutToolStripItem.Image = ((System.Drawing.Image)(resources.GetObject("strikeOutToolStripItem.Image")));
            this.strikeOutToolStripItem.Name = "strikeOutToolStripItem";
            this.strikeOutToolStripItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D5)));
            this.strikeOutToolStripItem.Size = new System.Drawing.Size(243, 24);
            this.strikeOutToolStripItem.Text = "Зачёркнутый";
            this.strikeOutToolStripItem.Click += new System.EventHandler(this.StrikeOutToolStripItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(240, 6);
            // 
            // форматироватьToolStripMenuItem
            // 
            this.форматироватьToolStripMenuItem.Name = "форматироватьToolStripMenuItem";
            this.форматироватьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.форматироватьToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.форматироватьToolStripMenuItem.Text = "Форматировать";
            this.форматироватьToolStripMenuItem.Click += new System.EventHandler(this.FormattingToolStripMenuItem_Click);
            // 
            // themeToolMenu
            // 
            this.themeToolMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundThemeItem,
            this.foreColorTheme,
            this.generalThemeItem,
            this.toolStripMenuItem8,
            this.FullWindowedToolStripMenuItem,
            this.FullWindowedToolStrip,
            this.updateWindowToolStripMenuItem});
            this.themeToolMenu.Name = "themeToolMenu";
            this.themeToolMenu.Size = new System.Drawing.Size(88, 23);
            this.themeToolMenu.Text = "Настройка";
            // 
            // backgroundThemeItem
            // 
            this.backgroundThemeItem.Image = ((System.Drawing.Image)(resources.GetObject("backgroundThemeItem.Image")));
            this.backgroundThemeItem.Name = "backgroundThemeItem";
            this.backgroundThemeItem.Size = new System.Drawing.Size(196, 24);
            this.backgroundThemeItem.Text = "Задний фон";
            this.backgroundThemeItem.Click += new System.EventHandler(this.BackgroundTextTheme);
            // 
            // foreColorTheme
            // 
            this.foreColorTheme.Image = ((System.Drawing.Image)(resources.GetObject("foreColorTheme.Image")));
            this.foreColorTheme.Name = "foreColorTheme";
            this.foreColorTheme.Size = new System.Drawing.Size(196, 24);
            this.foreColorTheme.Text = "Передний фон";
            this.foreColorTheme.Click += new System.EventHandler(this.ForeColorTheme_Click);
            // 
            // generalThemeItem
            // 
            this.generalThemeItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackThemeItem,
            this.hackerThemeItem,
            this.toolStripMenuItem4,
            this.defaultThemeitem});
            this.generalThemeItem.Image = ((System.Drawing.Image)(resources.GetObject("generalThemeItem.Image")));
            this.generalThemeItem.Name = "generalThemeItem";
            this.generalThemeItem.Size = new System.Drawing.Size(196, 24);
            this.generalThemeItem.Text = "Тема";
            // 
            // blackThemeItem
            // 
            this.blackThemeItem.Name = "blackThemeItem";
            this.blackThemeItem.Size = new System.Drawing.Size(122, 24);
            this.blackThemeItem.Text = "Black";
            this.blackThemeItem.Click += new System.EventHandler(this.BlackTheme_Click);
            // 
            // hackerThemeItem
            // 
            this.hackerThemeItem.Name = "hackerThemeItem";
            this.hackerThemeItem.Size = new System.Drawing.Size(122, 24);
            this.hackerThemeItem.Text = "Hacker";
            this.hackerThemeItem.Click += new System.EventHandler(this.HackerTheme_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(119, 6);
            // 
            // defaultThemeitem
            // 
            this.defaultThemeitem.Name = "defaultThemeitem";
            this.defaultThemeitem.Size = new System.Drawing.Size(122, 24);
            this.defaultThemeitem.Text = "Default";
            this.defaultThemeitem.Click += new System.EventHandler(this.DefaultTheme_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(193, 6);
            // 
            // FullWindowedToolStripMenuItem
            // 
            this.FullWindowedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FullWindowedToolStripMenuItem.Image")));
            this.FullWindowedToolStripMenuItem.Name = "FullWindowedToolStripMenuItem";
            this.FullWindowedToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.FullWindowedToolStripMenuItem.Text = "Во весь экран";
            this.FullWindowedToolStripMenuItem.Click += new System.EventHandler(this.FullWindowedToolStripMenuItem_Click);
            // 
            // FullWindowedToolStrip
            // 
            this.FullWindowedToolStrip.Name = "FullWindowedToolStrip";
            this.FullWindowedToolStrip.Size = new System.Drawing.Size(193, 6);
            // 
            // updateWindowToolStripMenuItem
            // 
            this.updateWindowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateWindowToolStripMenuItem.Image")));
            this.updateWindowToolStripMenuItem.Name = "updateWindowToolStripMenuItem";
            this.updateWindowToolStripMenuItem.Size = new System.Drawing.Size(196, 24);
            this.updateWindowToolStripMenuItem.Text = "Обновить вкладки";
            this.updateWindowToolStripMenuItem.Click += new System.EventHandler(this.UpdateWindowToolStripMenuItem_Click);
            // 
            // compileMenuItem
            // 
            this.compileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileCodeMenu});
            this.compileMenuItem.Name = "compileMenuItem";
            this.compileMenuItem.Size = new System.Drawing.Size(100, 23);
            this.compileMenuItem.Text = "Компиляция";
            // 
            // compileCodeMenu
            // 
            this.compileCodeMenu.Image = ((System.Drawing.Image)(resources.GetObject("compileCodeMenu.Image")));
            this.compileCodeMenu.Name = "compileCodeMenu";
            this.compileCodeMenu.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.compileCodeMenu.Size = new System.Drawing.Size(216, 24);
            this.compileCodeMenu.Text = "Компиляция Кода";
            this.compileCodeMenu.Click += new System.EventHandler(this.CompileCode_Click);
            // 
            // syntaxOption
            // 
            this.syntaxOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csharpMenuItem,
            this.htmlMenuItem,
            this.xmlMenuItem,
            this.jsMenuItem,
            this.JsonMenuItem,
            this.PhpMenuItem,
            this.SyntaxPython,
            this.separatorForSyntax,
            this.defaultToolStripMenuItem});
            this.syntaxOption.Name = "syntaxOption";
            this.syntaxOption.Size = new System.Drawing.Size(86, 23);
            this.syntaxOption.Text = "Синтаксис";
            // 
            // csharpMenuItem
            // 
            this.csharpMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("csharpMenuItem.Image")));
            this.csharpMenuItem.Name = "csharpMenuItem";
            this.csharpMenuItem.Size = new System.Drawing.Size(141, 24);
            this.csharpMenuItem.Text = "C#";
            this.csharpMenuItem.Click += new System.EventHandler(this.SyntaxCsharp_Click);
            // 
            // htmlMenuItem
            // 
            this.htmlMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("htmlMenuItem.Image")));
            this.htmlMenuItem.Name = "htmlMenuItem";
            this.htmlMenuItem.Size = new System.Drawing.Size(141, 24);
            this.htmlMenuItem.Text = "HTML";
            this.htmlMenuItem.Click += new System.EventHandler(this.SyntaxHTML_Click);
            // 
            // xmlMenuItem
            // 
            this.xmlMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xmlMenuItem.Image")));
            this.xmlMenuItem.Name = "xmlMenuItem";
            this.xmlMenuItem.Size = new System.Drawing.Size(141, 24);
            this.xmlMenuItem.Text = "XML";
            this.xmlMenuItem.Click += new System.EventHandler(this.SyntaxXML_Click);
            // 
            // jsMenuItem
            // 
            this.jsMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("jsMenuItem.Image")));
            this.jsMenuItem.Name = "jsMenuItem";
            this.jsMenuItem.Size = new System.Drawing.Size(141, 24);
            this.jsMenuItem.Text = "JS";
            this.jsMenuItem.Click += new System.EventHandler(this.SyntaxJS_Click);
            // 
            // JsonMenuItem
            // 
            this.JsonMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("JsonMenuItem.Image")));
            this.JsonMenuItem.Name = "JsonMenuItem";
            this.JsonMenuItem.Size = new System.Drawing.Size(141, 24);
            this.JsonMenuItem.Text = "JSON";
            this.JsonMenuItem.Click += new System.EventHandler(this.JsonMenuItem_Click);
            // 
            // PhpMenuItem
            // 
            this.PhpMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PhpMenuItem.Image")));
            this.PhpMenuItem.Name = "PhpMenuItem";
            this.PhpMenuItem.Size = new System.Drawing.Size(141, 24);
            this.PhpMenuItem.Text = "PHP";
            this.PhpMenuItem.Click += new System.EventHandler(this.PhpMenuItem_Click);
            // 
            // SyntaxPython
            // 
            this.SyntaxPython.Image = global::NotepadPlusPlus.Properties.Resources.DcHj7iYW0AAWrgo;
            this.SyntaxPython.Name = "SyntaxPython";
            this.SyntaxPython.Size = new System.Drawing.Size(141, 24);
            this.SyntaxPython.Text = "Python";
            this.SyntaxPython.Click += new System.EventHandler(this.SyntaxPython_Click);
            // 
            // separatorForSyntax
            // 
            this.separatorForSyntax.Name = "separatorForSyntax";
            this.separatorForSyntax.Size = new System.Drawing.Size(138, 6);
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.defaultToolStripMenuItem.Text = "Обычный";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.SyntaxDefault_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugInfo,
            this.toolStripMenuItem6,
            this.aboutPanel});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(27, 23);
            this.toolStripMenuItem5.Text = "?";
            // 
            // debugInfo
            // 
            this.debugInfo.Name = "debugInfo";
            this.debugInfo.Size = new System.Drawing.Size(147, 24);
            this.debugInfo.Text = "Debug Info";
            this.debugInfo.Click += new System.EventHandler(this.debugInfo_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(144, 6);
            // 
            // aboutPanel
            // 
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Size = new System.Drawing.Size(147, 24);
            this.aboutPanel.Text = "About";
            this.aboutPanel.Click += new System.EventHandler(this.aboutPanel_Click);
            // 
            // toolButtons
            // 
            this.toolButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewButton,
            this.OpenButton,
            this.SaveAs,
            this.SaveButton,
            this.toolStripButton5,
            this.BackButton,
            this.ReturnButton,
            this.toolStripSeparator1,
            this.CutButton,
            this.CopyButton,
            this.SelectAll,
            this.toolStripSeparator2,
            this.ZoomIn,
            this.ZoomOut,
            this.toolStripSeparator3,
            this.printButton,
            this.toolStripSeparator4,
            this.CloseTabPageButton});
            this.toolButtons.Location = new System.Drawing.Point(0, 27);
            this.toolButtons.Name = "toolButtons";
            this.toolButtons.Size = new System.Drawing.Size(798, 25);
            this.toolButtons.TabIndex = 2;
            this.toolButtons.Text = "toolStrip1";
            // 
            // NewButton
            // 
            this.NewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewButton.Image = ((System.Drawing.Image)(resources.GetObject("NewButton.Image")));
            this.NewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(23, 22);
            this.NewButton.Text = "New";
            this.NewButton.ToolTipText = "New";
            this.NewButton.Click += new System.EventHandler(this.NewFile_Button);
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(23, 22);
            this.OpenButton.Text = "Open";
            this.OpenButton.Click += new System.EventHandler(this.OpenFile_Button);
            // 
            // SaveAs
            // 
            this.SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAs.Image = ((System.Drawing.Image)(resources.GetObject("SaveAs.Image")));
            this.SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(23, 22);
            this.SaveAs.Text = "Save As";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Button);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(23, 22);
            this.SaveButton.Text = "Save";
            this.SaveButton.ToolTipText = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(6, 25);
            // 
            // BackButton
            // 
            this.BackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(23, 22);
            this.BackButton.Text = "Back";
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReturnButton.Image = ((System.Drawing.Image)(resources.GetObject("ReturnButton.Image")));
            this.ReturnButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(23, 22);
            this.ReturnButton.Text = "Return";
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CutButton
            // 
            this.CutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CutButton.Image = ((System.Drawing.Image)(resources.GetObject("CutButton.Image")));
            this.CutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutButton.Name = "CutButton";
            this.CutButton.Size = new System.Drawing.Size(23, 22);
            this.CutButton.Text = "Cut";
            this.CutButton.Click += new System.EventHandler(this.CutButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyButton.Image = ((System.Drawing.Image)(resources.GetObject("CopyButton.Image")));
            this.CopyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(23, 22);
            this.CopyButton.Text = "Copy";
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectAll.Image = ((System.Drawing.Image)(resources.GetObject("SelectAll.Image")));
            this.SelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(23, 22);
            this.SelectAll.Text = "Select All";
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ZoomIn
            // 
            this.ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomIn.Image")));
            this.ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(23, 22);
            this.ZoomIn.Text = "Zoom in";
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOut.Image")));
            this.ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(23, 22);
            this.ZoomOut.Text = "Zoom Out";
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // printButton
            // 
            this.printButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(23, 22);
            this.printButton.Text = "Print";
            this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // CloseTabPageButton
            // 
            this.CloseTabPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseTabPageButton.Image = global::NotepadPlusPlus.Properties.Resources.CloseDocumentGroup_16x_32;
            this.CloseTabPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseTabPageButton.Name = "CloseTabPageButton";
            this.CloseTabPageButton.Size = new System.Drawing.Size(23, 22);
            this.CloseTabPageButton.Text = "Закрыть";
            this.CloseTabPageButton.Click += new System.EventHandler(this.CloseTabPageButton_Click);
            // 
            // fontOption
            // 
            this.fontOption.ShowApply = true;
            this.fontOption.ShowColor = true;
            // 
            // colorOption
            // 
            this.colorOption.AnyColor = true;
            // 
            // contextOption
            // 
            this.contextOption.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.selectAllToolStripMenuItem,
            this.selectContextMenu,
            this.cutContextMenu,
            this.redoContexMenu,
            this.undoContextMenu,
            this.toolStripSeparator5,
            this.toolStripMenuItem11});
            this.contextOption.Name = "contextMenuStrip1";
            this.contextOption.Size = new System.Drawing.Size(123, 186);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem1.Image")));
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.CopyMenu_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem1.Image")));
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.PasteMenu_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectAllToolStripMenuItem.Image")));
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllMenu_Click);
            // 
            // selectContextMenu
            // 
            this.selectContextMenu.Name = "selectContextMenu";
            this.selectContextMenu.Size = new System.Drawing.Size(122, 22);
            this.selectContextMenu.Text = "Select";
            this.selectContextMenu.Click += new System.EventHandler(this.SelectContextMenu_Click);
            // 
            // cutContextMenu
            // 
            this.cutContextMenu.Image = ((System.Drawing.Image)(resources.GetObject("cutContextMenu.Image")));
            this.cutContextMenu.Name = "cutContextMenu";
            this.cutContextMenu.Size = new System.Drawing.Size(122, 22);
            this.cutContextMenu.Text = "Cut";
            this.cutContextMenu.Click += new System.EventHandler(this.CutContextMenu_Click);
            // 
            // redoContexMenu
            // 
            this.redoContexMenu.Image = ((System.Drawing.Image)(resources.GetObject("redoContexMenu.Image")));
            this.redoContexMenu.Name = "redoContexMenu";
            this.redoContexMenu.Size = new System.Drawing.Size(122, 22);
            this.redoContexMenu.Text = "Redo";
            this.redoContexMenu.Click += new System.EventHandler(this.RedoContextMenu_Click);
            // 
            // undoContextMenu
            // 
            this.undoContextMenu.Image = ((System.Drawing.Image)(resources.GetObject("undoContextMenu.Image")));
            this.undoContextMenu.Name = "undoContextMenu";
            this.undoContextMenu.Size = new System.Drawing.Size(122, 22);
            this.undoContextMenu.Text = "Undo";
            this.undoContextMenu.Click += new System.EventHandler(this.UndoContextMenu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem11.Image")));
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem11.Text = "Delete";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.DeleteToolStripMenu_Click);
            // 
            // tabOption
            // 
            this.tabOption.ContextMenuStrip = this.contextTabMenuStrip;
            this.tabOption.Controls.Add(this.recentPages);
            this.tabOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOption.Location = new System.Drawing.Point(0, 52);
            this.tabOption.Name = "tabOption";
            this.tabOption.SelectedIndex = 0;
            this.tabOption.Size = new System.Drawing.Size(608, 376);
            this.tabOption.TabIndex = 5;
            this.tabOption.SelectedIndexChanged += new System.EventHandler(this.TabOption_SelectedIndexChanged);
            // 
            // contextTabMenuStrip
            // 
            this.contextTabMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextTabMenuStrip.Name = "contextTabMenuStrip";
            this.contextTabMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // recentPages
            // 
            this.recentPages.Controls.Add(this.fcbTextBox);
            this.recentPages.Cursor = System.Windows.Forms.Cursors.Default;
            this.recentPages.Location = new System.Drawing.Point(4, 22);
            this.recentPages.Name = "recentPages";
            this.recentPages.Padding = new System.Windows.Forms.Padding(3);
            this.recentPages.Size = new System.Drawing.Size(600, 350);
            this.recentPages.TabIndex = 0;
            this.recentPages.Text = "Untitled";
            this.recentPages.UseVisualStyleBackColor = true;
            // 
            // fcbTextBox
            // 
            this.fcbTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fcbTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fcbTextBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fcbTextBox.BackBrush = null;
            this.fcbTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fcbTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fcbTextBox.CharHeight = 14;
            this.fcbTextBox.CharWidth = 8;
            this.fcbTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fcbTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fcbTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fcbTextBox.FindEndOfFoldingBlockStrategy = FastColoredTextBoxNS.FindEndOfFoldingBlockStrategy.Strategy2;
            this.fcbTextBox.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.AllTextRange;
            this.fcbTextBox.IsReplaceMode = false;
            this.fcbTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fcbTextBox.LeftBracket = '(';
            this.fcbTextBox.LeftBracket2 = '{';
            this.fcbTextBox.Location = new System.Drawing.Point(3, 3);
            this.fcbTextBox.Name = "fcbTextBox";
            this.fcbTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.fcbTextBox.RightBracket = ')';
            this.fcbTextBox.RightBracket2 = '}';
            this.fcbTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.fcbTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fcbTextBox.ServiceColors")));
            this.fcbTextBox.Size = new System.Drawing.Size(594, 344);
            this.fcbTextBox.TabIndex = 8;
            this.fcbTextBox.WideCaret = true;
            this.fcbTextBox.Zoom = 100;
            this.fcbTextBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.FcbTextBox_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStatusStrip,
            this.toolStripStatusLabel4,
            this.statusLabel,
            this.toolStripStatusLabel1,
            this.rowsInfo,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.nameAppLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(798, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // fileStatusStrip
            // 
            this.fileStatusStrip.Name = "fileStatusStrip";
            this.fileStatusStrip.Size = new System.Drawing.Size(31, 17);
            this.fileStatusStrip.Text = "File: ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(130, 17);
            this.toolStripStatusLabel4.Text = "                                         ";
            // 
            // statusLabel
            // 
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(58, 17);
            this.statusLabel.Text = "Symbols: ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel1.Text = "                   ";
            // 
            // rowsInfo
            // 
            this.rowsInfo.Name = "rowsInfo";
            this.rowsInfo.Size = new System.Drawing.Size(38, 17);
            this.rowsInfo.Text = "Rows:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel3.Text = "                    ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel2.Text = "                   ";
            // 
            // nameAppLabel
            // 
            this.nameAppLabel.Name = "nameAppLabel";
            this.nameAppLabel.Size = new System.Drawing.Size(118, 17);
            this.nameAppLabel.Text = "Notepad (PeerGrade)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.documentMap1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(608, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 376);
            this.panel1.TabIndex = 9;
            // 
            // documentMap1
            // 
            this.documentMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentMap1.ForeColor = System.Drawing.Color.Maroon;
            this.documentMap1.Location = new System.Drawing.Point(0, 0);
            this.documentMap1.Name = "documentMap1";
            this.documentMap1.Size = new System.Drawing.Size(190, 376);
            this.documentMap1.TabIndex = 2;
            this.documentMap1.Target = null;
            this.documentMap1.Text = "documentMap1";
            // 
            // DeveloperEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.tabOption);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolButtons);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeveloperEditor";
            this.Text = "Notepad (PeerGrade Version)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeveloperEditor_FormClosing);
            this.Load += new System.EventHandler(this.DeveloperEditor_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolButtons.ResumeLayout(false);
            this.toolButtons.PerformLayout();
            this.contextOption.ResumeLayout(false);
            this.tabOption.ResumeLayout(false);
            this.contextTabMenuStrip.ResumeLayout(false);
            this.recentPages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fcbTextBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;
        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolMenuItem;
        private ToolStripMenuItem newToolItem;
        private ToolStripMenuItem saveToolMenuItem;
        private ToolStripMenuItem saveAsToolItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolItem;
        private ToolStrip toolButtons;
        private ToolStripButton NewButton;
        private ToolStripButton SaveAs;
        private ToolStripMenuItem editToolItem;
        private ToolStripMenuItem copyToolItem;
        private ToolStripMenuItem pasteToolItem;
        private ToolStripMenuItem cutToolItem;
        private ToolStripMenuItem fontToolItem;
        private ToolStripMenuItem fontOptionsMenu;
        private FontDialog fontOption;
        private ToolStripMenuItem themeToolMenu;
        private ToolStripMenuItem backgroundThemeItem;
        private ToolStripMenuItem generalThemeItem;
        private ColorDialog colorOption;
        private ToolStripMenuItem selectToolItem;
        private ContextMenuStrip contextOption;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem saveToolItem;
        private ToolStripButton SaveButton;
        private ToolStripButton OpenButton;
        private ToolStripMenuItem compileMenuItem;
        private ToolStripMenuItem compileCodeMenu;
        private ToolStripMenuItem syntaxOption;
        private ToolStripMenuItem csharpMenuItem;
        private ToolStripMenuItem htmlMenuItem;
        private ToolStripMenuItem jsMenuItem;
        private ToolStripMenuItem defaultToolStripMenuItem;
        private ToolStripMenuItem xmlMenuItem;
        private ToolStripMenuItem blackThemeItem;
        private ToolStripMenuItem hackerThemeItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem defaultThemeitem;
        private TabControl tabOption;
        private ToolStripSeparator toolStripButton5;
        private ToolStripButton BackButton;
        private ToolStripButton ReturnButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton CutButton;
        private ToolStripButton CopyButton;
        private ToolStripButton SelectAll;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton ZoomIn;
        private ToolStripButton ZoomOut;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem aboutPanel;
        private ToolStripMenuItem debugInfo;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator separatorForSyntax;
        private ToolStripButton printButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel rowsInfo;
        private ToolStripStatusLabel nameAppLabel;
        private ToolStripMenuItem foreColorTheme;
        private FastColoredTextBox fcbTextBox;
        private TabPage recentPages;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem textAlignToolStripMenuItem;
        private ToolStripMenuItem leftSideToolStripMenuItem;
        private ToolStripMenuItem middleToolStripMenuItem;
        private ToolStripMenuItem rightSideToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem JsonMenuItem;
        private ToolStripMenuItem PhpMenuItem;
        private ContextMenuStrip contextTabMenuStrip;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem updateWindowToolStripMenuItem;
        private ToolStripMenuItem selectContextMenu;
        private ToolStripMenuItem cutContextMenu;
        private ToolStripMenuItem redoContexMenu;
        private ToolStripMenuItem undoContextMenu;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripSeparator FullWindowedToolStrip;
        private ToolStripMenuItem FullWindowedToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem boldToolStripMenuItem;
        private ToolStripMenuItem italicToolStripMenuItem;
        private ToolStripMenuItem underLinedToolStripMenuItem;
        private ToolStripMenuItem strikeOutToolStripItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem saveIntervalMenuItem;
        private ToolStripMenuItem firstToolStripMenuItem;
        private ToolStripMenuItem secondToolStripMenuItem;
        private ToolStripMenuItem thirdToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem stopToolStripMenuItem;
        private Timer timerInterval;
        private ToolStripStatusLabel fileStatusStrip;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripMenuItem SyntaxPython;
        private ToolStripButton CloseTabPageButton;
        private ToolStripMenuItem DeleteToolStripMenu;
        private ToolStripMenuItem toolStripMenuItem10;
        private Panel panel1;
        private ToolStripSeparator toolStripMenuItem12;
        private ToolStripMenuItem форматироватьToolStripMenuItem;
        private DocumentMap documentMap1;
    }
}

