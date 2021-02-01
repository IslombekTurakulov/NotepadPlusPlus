
using System.ComponentModel;
using System.Windows.Forms;

namespace NotepadPlusPlus
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveIntervalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.redoStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.alignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.middleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontOptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underLinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strikeOutToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developerEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.csharpEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.wikipediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.fastToolButton = new System.Windows.Forms.ToolStrip();
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
            this.fontOptionButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.boldButton = new System.Windows.Forms.ToolStripButton();
            this.underlineButton = new System.Windows.Forms.ToolStripButton();
            this.italicButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseTabPageButton = new System.Windows.Forms.ToolStripButton();
            this.fontOption = new System.Windows.Forms.FontDialog();
            this.colorOption = new System.Windows.Forms.ColorDialog();
            this.contextOption = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.redoContexMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusTextEditor = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.rowsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.nameAppLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabOption = new System.Windows.Forms.TabControl();
            this.tabControlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openedPagesLabel = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.timerInterval = new System.Windows.Forms.Timer(this.components);
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.aboutPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.fastToolButton.SuspendLayout();
            this.contextOption.SuspendLayout();
            this.statusTextEditor.SuspendLayout();
            this.tabControlContextMenu.SuspendLayout();
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
            this.developerEditor,
            this.toolStripMenuItem5});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(781, 27);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "Main Menu";
            // 
            // fileToolMenuItem
            // 
            this.fileToolMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolItem,
            this.toolStripMenuItem11,
            this.saveToolMenuItem,
            this.saveAsToolItem,
            this.saveToolItem,
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
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem11.Image")));
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(255, 24);
            this.toolStripMenuItem11.Text = "В новом окне";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.NewFormTool_Click);
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
            // saveIntervalMenuItem
            // 
            this.saveIntervalMenuItem.AccessibleDescription = "";
            this.saveIntervalMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstToolStripMenuItem,
            this.secondToolStripMenuItem,
            this.thirdToolStripMenuItem,
            this.toolStripMenuItem6,
            this.stopToolStripMenuItem});
            this.saveIntervalMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveIntervalMenuItem.Image")));
            this.saveIntervalMenuItem.Name = "saveIntervalMenuItem";
            this.saveIntervalMenuItem.ShortcutKeyDisplayString = "ON";
            this.saveIntervalMenuItem.Size = new System.Drawing.Size(255, 24);
            this.saveIntervalMenuItem.Text = "Автосохранение";
            // 
            // firstToolStripMenuItem
            // 
            this.firstToolStripMenuItem.Name = "firstToolStripMenuItem";
            this.firstToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.firstToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.firstToolStripMenuItem.Text = "5 минут";
            this.firstToolStripMenuItem.Click += new System.EventHandler(this.FirstTimeToolStripMenuItem_Click);
            // 
            // secondToolStripMenuItem
            // 
            this.secondToolStripMenuItem.Name = "secondToolStripMenuItem";
            this.secondToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.secondToolStripMenuItem.Text = "10 минут";
            this.secondToolStripMenuItem.Click += new System.EventHandler(this.SecondTimeToolStripMenuItem_Click);
            // 
            // thirdToolStripMenuItem
            // 
            this.thirdToolStripMenuItem.Name = "thirdToolStripMenuItem";
            this.thirdToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.thirdToolStripMenuItem.Text = "20 минут ";
            this.thirdToolStripMenuItem.Click += new System.EventHandler(this.ThirdTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(146, 6);
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
            this.undoToolStripMenu,
            this.toolStripMenuItem9,
            this.redoStripMenuItem,
            this.DeleteToolStripMenu,
            this.alignToolStripMenuItem});
            this.editToolItem.Name = "editToolItem";
            this.editToolItem.Size = new System.Drawing.Size(67, 23);
            this.editToolItem.Text = "&Правка";
            // 
            // copyToolItem
            // 
            this.copyToolItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolItem.Image")));
            this.copyToolItem.Name = "copyToolItem";
            this.copyToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolItem.Size = new System.Drawing.Size(214, 24);
            this.copyToolItem.Text = "&Копировать";
            this.copyToolItem.Click += new System.EventHandler(this.CopyText_Click);
            // 
            // pasteToolItem
            // 
            this.pasteToolItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolItem.Image")));
            this.pasteToolItem.Name = "pasteToolItem";
            this.pasteToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolItem.Size = new System.Drawing.Size(214, 24);
            this.pasteToolItem.Text = "&Вставить";
            this.pasteToolItem.Click += new System.EventHandler(this.PasteText_Click);
            // 
            // cutToolItem
            // 
            this.cutToolItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolItem.Image")));
            this.cutToolItem.Name = "cutToolItem";
            this.cutToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolItem.Size = new System.Drawing.Size(214, 24);
            this.cutToolItem.Text = "&Вырезать";
            this.cutToolItem.Click += new System.EventHandler(this.CutText_Click);
            // 
            // selectToolItem
            // 
            this.selectToolItem.Image = ((System.Drawing.Image)(resources.GetObject("selectToolItem.Image")));
            this.selectToolItem.Name = "selectToolItem";
            this.selectToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectToolItem.Size = new System.Drawing.Size(214, 24);
            this.selectToolItem.Text = "&Выделить Всё";
            this.selectToolItem.Click += new System.EventHandler(this.SelectMenu_Click);
            // 
            // undoToolStripMenu
            // 
            this.undoToolStripMenu.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenu.Image")));
            this.undoToolStripMenu.Name = "undoToolStripMenu";
            this.undoToolStripMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenu.Size = new System.Drawing.Size(214, 24);
            this.undoToolStripMenu.Text = "Отменить";
            this.undoToolStripMenu.Click += new System.EventHandler(this.UndoToolStripMenu_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItem9.Size = new System.Drawing.Size(214, 24);
            this.toolStripMenuItem9.Text = "Повтор";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // redoStripMenuItem
            // 
            this.redoStripMenuItem.Name = "redoStripMenuItem";
            this.redoStripMenuItem.Size = new System.Drawing.Size(211, 6);
            // 
            // DeleteToolStripMenu
            // 
            this.DeleteToolStripMenu.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripMenu.Image")));
            this.DeleteToolStripMenu.Name = "DeleteToolStripMenu";
            this.DeleteToolStripMenu.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteToolStripMenu.Size = new System.Drawing.Size(214, 24);
            this.DeleteToolStripMenu.Text = "Удалить";
            this.DeleteToolStripMenu.Click += new System.EventHandler(this.DeleteToolStripMenu_Click);
            // 
            // alignToolStripMenuItem
            // 
            this.alignToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftSideToolStripMenuItem,
            this.middleToolStripMenuItem,
            this.rightSideToolStripMenuItem});
            this.alignToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("alignToolStripMenuItem.Image")));
            this.alignToolStripMenuItem.Name = "alignToolStripMenuItem";
            this.alignToolStripMenuItem.Size = new System.Drawing.Size(214, 24);
            this.alignToolStripMenuItem.Text = "Вид";
            // 
            // leftSideToolStripMenuItem
            // 
            this.leftSideToolStripMenuItem.Name = "leftSideToolStripMenuItem";
            this.leftSideToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.leftSideToolStripMenuItem.Text = "Левый край";
            this.leftSideToolStripMenuItem.Click += new System.EventHandler(this.LeftSideToolStripMenuItem_Click);
            // 
            // middleToolStripMenuItem
            // 
            this.middleToolStripMenuItem.Name = "middleToolStripMenuItem";
            this.middleToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.middleToolStripMenuItem.Text = "Центр";
            this.middleToolStripMenuItem.Click += new System.EventHandler(this.MiddleToolStripMenuItem_Click);
            // 
            // rightSideToolStripMenuItem
            // 
            this.rightSideToolStripMenuItem.Name = "rightSideToolStripMenuItem";
            this.rightSideToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.rightSideToolStripMenuItem.Text = "Правый край";
            this.rightSideToolStripMenuItem.Click += new System.EventHandler(this.RightSideToolStripMenuItem_Click);
            // 
            // fontToolItem
            // 
            this.fontToolItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontOptionsMenu,
            this.toolStripMenuItem2,
            this.boldToolStripMenuItem,
            this.italicToolStripMenuItem,
            this.underLinedToolStripMenuItem,
            this.strikeOutToolStripItem,
            this.toolStripMenuItem14,
            this.форматироватьToolStripMenuItem});
            this.fontToolItem.Name = "fontToolItem";
            this.fontToolItem.Size = new System.Drawing.Size(70, 23);
            this.fontToolItem.Text = "&Формат";
            // 
            // fontOptionsMenu
            // 
            this.fontOptionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("fontOptionsMenu.Image")));
            this.fontOptionsMenu.Name = "fontOptionsMenu";
            this.fontOptionsMenu.Size = new System.Drawing.Size(243, 24);
            this.fontOptionsMenu.Text = "Настройка Шрифта";
            this.fontOptionsMenu.Click += new System.EventHandler(this.FontOption_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(240, 6);
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
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(240, 6);
            // 
            // форматироватьToolStripMenuItem
            // 
            this.форматироватьToolStripMenuItem.Name = "форматироватьToolStripMenuItem";
            this.форматироватьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.форматироватьToolStripMenuItem.Size = new System.Drawing.Size(243, 24);
            this.форматироватьToolStripMenuItem.Text = "Форматировать";
            this.форматироватьToolStripMenuItem.Click += new System.EventHandler(this.FormatterToolStripMenuItem_Click);
            // 
            // themeToolMenu
            // 
            this.themeToolMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundThemeItem,
            this.foreColorTheme,
            this.generalThemeItem,
            this.toolStripMenuItem8,
            this.toolStripMenuItem10,
            this.toolStripMenuItem7,
            this.UpdateWindowToolStripMenuItem});
            this.themeToolMenu.Name = "themeToolMenu";
            this.themeToolMenu.Size = new System.Drawing.Size(88, 23);
            this.themeToolMenu.Text = "Настройка";
            // 
            // backgroundThemeItem
            // 
            this.backgroundThemeItem.Image = ((System.Drawing.Image)(resources.GetObject("backgroundThemeItem.Image")));
            this.backgroundThemeItem.Name = "backgroundThemeItem";
            this.backgroundThemeItem.Size = new System.Drawing.Size(187, 24);
            this.backgroundThemeItem.Text = "Задний фон";
            this.backgroundThemeItem.Click += new System.EventHandler(this.BackgroundTextTheme);
            // 
            // foreColorTheme
            // 
            this.foreColorTheme.Image = ((System.Drawing.Image)(resources.GetObject("foreColorTheme.Image")));
            this.foreColorTheme.Name = "foreColorTheme";
            this.foreColorTheme.Size = new System.Drawing.Size(187, 24);
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
            this.generalThemeItem.Size = new System.Drawing.Size(187, 24);
            this.generalThemeItem.Text = "Фон приложения";
            // 
            // blackThemeItem
            // 
            this.blackThemeItem.Name = "blackThemeItem";
            this.blackThemeItem.Size = new System.Drawing.Size(170, 24);
            this.blackThemeItem.Text = "Black";
            this.blackThemeItem.Click += new System.EventHandler(this.BlackTheme_Click);
            // 
            // hackerThemeItem
            // 
            this.hackerThemeItem.Name = "hackerThemeItem";
            this.hackerThemeItem.Size = new System.Drawing.Size(170, 24);
            this.hackerThemeItem.Text = "Hacker";
            this.hackerThemeItem.Click += new System.EventHandler(this.HackerTheme_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(167, 6);
            // 
            // defaultThemeitem
            // 
            this.defaultThemeitem.Name = "defaultThemeitem";
            this.defaultThemeitem.Size = new System.Drawing.Size(170, 24);
            this.defaultThemeitem.Text = "Default (White)";
            this.defaultThemeitem.Click += new System.EventHandler(this.DefaultTheme_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(184, 6);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem10.Image")));
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(187, 24);
            this.toolStripMenuItem10.Text = "Во весь экран";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.FullWindowedToolStrip_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(184, 6);
            // 
            // UpdateWindowToolStripMenuItem
            // 
            this.UpdateWindowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UpdateWindowToolStripMenuItem.Image")));
            this.UpdateWindowToolStripMenuItem.Name = "UpdateWindowToolStripMenuItem";
            this.UpdateWindowToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.UpdateWindowToolStripMenuItem.Text = "Обновить окно";
            this.UpdateWindowToolStripMenuItem.Click += new System.EventHandler(this.UpdateWindowToolStripMenuItem_Click);
            // 
            // developerEditor
            // 
            this.developerEditor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csharpEditor,
            this.toolStripMenuItem13});
            this.developerEditor.Name = "developerEditor";
            this.developerEditor.Size = new System.Drawing.Size(102, 23);
            this.developerEditor.Text = "Разработчик";
            // 
            // csharpEditor
            // 
            this.csharpEditor.Image = ((System.Drawing.Image)(resources.GetObject("csharpEditor.Image")));
            this.csharpEditor.Name = "csharpEditor";
            this.csharpEditor.Size = new System.Drawing.Size(213, 24);
            this.csharpEditor.Text = "Режим разработчика";
            this.csharpEditor.Click += new System.EventHandler(this.CsharpEditor_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(210, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikipediaToolStripMenuItem,
            this.toolStripMenuItem12,
            this.aboutPanel});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(27, 23);
            this.toolStripMenuItem5.Text = "?";
            // 
            // wikipediaToolStripMenuItem
            // 
            this.wikipediaToolStripMenuItem.Name = "wikipediaToolStripMenuItem";
            this.wikipediaToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.wikipediaToolStripMenuItem.Text = "Wikipedia";
            this.wikipediaToolStripMenuItem.Click += new System.EventHandler(this.WikipediaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(185, 6);
            // 
            // fastToolButton
            // 
            this.fastToolButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.fastToolButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.fontOptionButton,
            this.toolStripSeparator4,
            this.boldButton,
            this.underlineButton,
            this.italicButton,
            this.toolStripButton1,
            this.toolStripSeparator5,
            this.CloseTabPageButton});
            this.fastToolButton.Location = new System.Drawing.Point(0, 27);
            this.fastToolButton.Name = "fastToolButton";
            this.fastToolButton.Size = new System.Drawing.Size(781, 25);
            this.fastToolButton.TabIndex = 2;
            this.fastToolButton.Text = "Панель Быстрого Действия";
            // 
            // NewButton
            // 
            this.NewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewButton.Image = ((System.Drawing.Image)(resources.GetObject("NewButton.Image")));
            this.NewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(23, 22);
            this.NewButton.Text = "Новый";
            this.NewButton.ToolTipText = "Новый";
            this.NewButton.Click += new System.EventHandler(this.NewFile_Button);
            // 
            // OpenButton
            // 
            this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
            this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(23, 22);
            this.OpenButton.Text = "Открыть";
            this.OpenButton.Click += new System.EventHandler(this.OpenFile_Button);
            // 
            // SaveAs
            // 
            this.SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAs.Image = ((System.Drawing.Image)(resources.GetObject("SaveAs.Image")));
            this.SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(23, 22);
            this.SaveAs.Text = "Сохранить как";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Button);
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(23, 22);
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.ToolTipText = "Сохранить";
            this.SaveButton.Click += new System.EventHandler(this.SaveFileButton);
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
            this.BackButton.Text = "Отменить";
            this.BackButton.ToolTipText = "Отменить";
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReturnButton.Image = ((System.Drawing.Image)(resources.GetObject("ReturnButton.Image")));
            this.ReturnButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(23, 22);
            this.ReturnButton.Text = "Повтор";
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
            this.CutButton.Image = global::NotepadPlusPlus.Properties.Resources.Cut_16x1;
            this.CutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutButton.Name = "CutButton";
            this.CutButton.Size = new System.Drawing.Size(23, 22);
            this.CutButton.Text = "Вырезать";
            this.CutButton.Click += new System.EventHandler(this.CutButton_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyButton.Image = ((System.Drawing.Image)(resources.GetObject("CopyButton.Image")));
            this.CopyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(23, 22);
            this.CopyButton.Text = "Копировать";
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectAll.Image = ((System.Drawing.Image)(resources.GetObject("SelectAll.Image")));
            this.SelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(23, 22);
            this.SelectAll.Text = "Выделить всё";
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
            this.ZoomIn.Text = "Увеличить";
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOut.Image")));
            this.ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(23, 22);
            this.ZoomOut.Text = "Уменьшить";
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
            this.printButton.Text = "Печать";
            this.printButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // fontOptionButton
            // 
            this.fontOptionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fontOptionButton.Image = ((System.Drawing.Image)(resources.GetObject("fontOptionButton.Image")));
            this.fontOptionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontOptionButton.Name = "fontOptionButton";
            this.fontOptionButton.Size = new System.Drawing.Size(23, 22);
            this.fontOptionButton.Text = "Настройка шрифта";
            this.fontOptionButton.Click += new System.EventHandler(this.FontOptionButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // boldButton
            // 
            this.boldButton.AccessibleDescription = "Bold";
            this.boldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boldButton.Image = ((System.Drawing.Image)(resources.GetObject("boldButton.Image")));
            this.boldButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldButton.Name = "boldButton";
            this.boldButton.Size = new System.Drawing.Size(23, 22);
            this.boldButton.Text = "Жирный";
            this.boldButton.Click += new System.EventHandler(this.BoldToolButton_Click);
            // 
            // underlineButton
            // 
            this.underlineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.underlineButton.Image = ((System.Drawing.Image)(resources.GetObject("underlineButton.Image")));
            this.underlineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underlineButton.Name = "underlineButton";
            this.underlineButton.Size = new System.Drawing.Size(23, 22);
            this.underlineButton.Text = "Подчёркнутый";
            this.underlineButton.Click += new System.EventHandler(this.UnderlineToolButton_Click);
            // 
            // italicButton
            // 
            this.italicButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italicButton.Image = ((System.Drawing.Image)(resources.GetObject("italicButton.Image")));
            this.italicButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicButton.Name = "italicButton";
            this.italicButton.Size = new System.Drawing.Size(23, 22);
            this.italicButton.Text = "Курсив";
            this.italicButton.Click += new System.EventHandler(this.ItalicToolButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.StrikeOutButtonStrip_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // CloseTabPageButton
            // 
            this.CloseTabPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseTabPageButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseTabPageButton.Image")));
            this.CloseTabPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseTabPageButton.Name = "CloseTabPageButton";
            this.CloseTabPageButton.Size = new System.Drawing.Size(23, 22);
            this.CloseTabPageButton.Text = "Close TabPage";
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
            this.cutToolStripMenuItem,
            this.undoContextMenu,
            this.redoContexMenu,
            this.toolStripMenuItem3,
            this.deleteToolStripMenuItem});
            this.contextOption.Name = "contextMenuStrip1";
            this.contextOption.Size = new System.Drawing.Size(123, 186);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.CopyTextMenu_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.PasteMenu_Click);
            // 
            // selectAllToolStripMenuItem
            // 
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
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutMenu_Click);
            // 
            // undoContextMenu
            // 
            this.undoContextMenu.Name = "undoContextMenu";
            this.undoContextMenu.Size = new System.Drawing.Size(122, 22);
            this.undoContextMenu.Text = "Undo";
            this.undoContextMenu.Click += new System.EventHandler(this.UndoContextMenu_Click);
            // 
            // redoContexMenu
            // 
            this.redoContexMenu.Name = "redoContexMenu";
            this.redoContexMenu.Size = new System.Drawing.Size(122, 22);
            this.redoContexMenu.Text = "Redo";
            this.redoContexMenu.Click += new System.EventHandler(this.RedoContexMenu_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(119, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // statusTextEditor
            // 
            this.statusTextEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripStatusLabel1,
            this.rowsInfo,
            this.toolStripStatusLabel2,
            this.nameAppLabel,
            this.toolStripStatusLabel3});
            this.statusTextEditor.Location = new System.Drawing.Point(0, 379);
            this.statusTextEditor.Name = "statusTextEditor";
            this.statusTextEditor.Size = new System.Drawing.Size(781, 22);
            this.statusTextEditor.TabIndex = 6;
            this.statusTextEditor.Text = "statusTextEditor";
            // 
            // statusLabel
            // 
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(67, 17);
            this.statusLabel.Text = "Символов:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel1.Text = "                        ";
            // 
            // rowsInfo
            // 
            this.rowsInfo.Name = "rowsInfo";
            this.rowsInfo.Size = new System.Drawing.Size(50, 17);
            this.rowsInfo.Text = "Строки:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "                                     ";
            // 
            // nameAppLabel
            // 
            this.nameAppLabel.Name = "nameAppLabel";
            this.nameAppLabel.Size = new System.Drawing.Size(118, 17);
            this.nameAppLabel.Text = "Notepad (PeerGrade)";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel3.Text = "               ";
            // 
            // tabOption
            // 
            this.tabOption.ContextMenuStrip = this.tabControlContextMenu;
            this.tabOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOption.Location = new System.Drawing.Point(0, 52);
            this.tabOption.Name = "tabOption";
            this.tabOption.SelectedIndex = 0;
            this.tabOption.Size = new System.Drawing.Size(663, 327);
            this.tabOption.TabIndex = 5;
            this.tabOption.SelectedIndexChanged += new System.EventHandler(this.TabOption_SelectedIndexChanged);
            // 
            // tabControlContextMenu
            // 
            this.tabControlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1});
            this.tabControlContextMenu.Name = "contextMenuStrip1";
            this.tabControlContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStrip_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.openedPagesLabel);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(663, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 327);
            this.panel1.TabIndex = 8;
            // 
            // openedPagesLabel
            // 
            this.openedPagesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openedPagesLabel.AutoSize = true;
            this.openedPagesLabel.BackColor = System.Drawing.Color.Silver;
            this.openedPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.openedPagesLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openedPagesLabel.Location = new System.Drawing.Point(6, 0);
            this.openedPagesLabel.Name = "openedPagesLabel";
            this.openedPagesLabel.Size = new System.Drawing.Size(100, 16);
            this.openedPagesLabel.TabIndex = 1;
            this.openedPagesLabel.Text = "Opened Pages";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(3, 16);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(115, 307);
            this.treeView1.TabIndex = 0;
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // aboutPanel
            // 
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutPanel.Size = new System.Drawing.Size(188, 24);
            this.aboutPanel.Text = "О программе";
            this.aboutPanel.Click += new System.EventHandler(this.aboutPanel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 401);
            this.Controls.Add(this.tabOption);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusTextEditor);
            this.Controls.Add(this.fastToolButton);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Notepad (PeerGrade Version)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.fastToolButton.ResumeLayout(false);
            this.fastToolButton.PerformLayout();
            this.contextOption.ResumeLayout(false);
            this.statusTextEditor.ResumeLayout(false);
            this.statusTextEditor.PerformLayout();
            this.tabControlContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private ToolStrip fastToolButton;
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
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem saveToolItem;
        private ToolStripButton SaveButton;
        private ToolStripButton OpenButton;
        private ToolStripMenuItem blackThemeItem;
        private ToolStripMenuItem hackerThemeItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem defaultThemeitem;
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
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton printButton;
        private StatusStrip statusTextEditor;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel rowsInfo;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel nameAppLabel;
        private ToolStripMenuItem foreColorTheme;
        private ToolStripButton fontOptionButton;
        private ToolStripMenuItem developerEditor;
        private ToolStripMenuItem csharpEditor;
        private TabControl tabOption;
        private ToolStripMenuItem saveIntervalMenuItem;
        private ToolStripSeparator redoStripMenuItem;
        private Timer timerInterval;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton boldButton;
        private ToolStripButton underlineButton;
        private ToolStripButton italicButton;
        private ToolStripMenuItem undoToolStripMenu;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem alignToolStripMenuItem;
        private ToolStripMenuItem leftSideToolStripMenuItem;
        private ToolStripMenuItem middleToolStripMenuItem;
        private ToolStripMenuItem rightSideToolStripMenuItem;
        private PrintDialog printDialog;
        private ToolStripMenuItem firstToolStripMenuItem;
        private ToolStripMenuItem secondToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripMenuItem boldToolStripMenuItem;
        private ToolStripMenuItem italicToolStripMenuItem;
        private ToolStripMenuItem underLinedToolStripMenuItem;
        private ToolStripMenuItem strikeOutToolStripItem;
        private ToolStripMenuItem selectContextMenu;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem undoContextMenu;
        private ToolStripMenuItem redoContexMenu;
        private ToolStripMenuItem DeleteToolStripMenu;
        private ContextMenuStrip tabControlContextMenu;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem UpdateWindowToolStripMenuItem;
        private ToolStripMenuItem thirdToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripSeparator toolStripMenuItem12;
        private ToolStripMenuItem wikipediaToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton CloseTabPageButton;
        private Panel panel1;
        private TreeView treeView1;
        private ToolStripSeparator toolStripMenuItem14;
        private ToolStripSeparator toolStripMenuItem13;
        private Label openedPagesLabel;
        private ToolStripMenuItem форматироватьToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripMenuItem aboutPanel;
    }
}

