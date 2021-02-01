using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace NotepadPlusPlus
{
    internal class ColorTheme
    {
        public void ColorChangerMainForm(MenuStrip mainMenu,
            ToolStrip fastToolButton,
            StatusStrip statusText,
            TabControl tabOption,
            RichTextBox richTextBox,
            TreeView treeView,
            Color backColor,
            Color foreColor)
        {
            TabPage tabpage = tabOption.SelectedTab;
            mainMenu.BackColor = Color.Black;
            mainMenu.ForeColor = foreColor;
            fastToolButton.BackColor = Color.Black;
            fastToolButton.ForeColor = foreColor;
            richTextBox.BackColor = backColor;
            richTextBox.ForeColor = foreColor;
            statusText.BackColor = Color.Black;
            statusText.ForeColor = foreColor;
            tabpage.BorderStyle = BorderStyle.None;
            tabpage.BackColor = Color.Black;
        }

        public void ColorChangerDeveloperForm(MenuStrip mainMenu,
            ToolStrip fastToolButton,
            StatusStrip statusText,
            TabControl tabOption,
            FastColoredTextBox fastColoredTextBox,
            Color backColor,
            Color foreColor)
        {
            TabPage tabpage = tabOption.SelectedTab;
            tabpage.BorderStyle = BorderStyle.None;
            tabpage.BackColor = Color.Black;
            mainMenu.BackColor = Color.Black;
            mainMenu.ForeColor = foreColor;
            tabOption.BackColor = backColor;
            tabOption.ForeColor = foreColor;
            fastToolButton.BackColor = Color.Black;
            fastToolButton.ForeColor = foreColor;
            fastColoredTextBox.BackColor = backColor;
            fastColoredTextBox.ForeColor = foreColor;
            fastColoredTextBox.IndentBackColor = backColor;
            fastColoredTextBox.LineNumberColor = foreColor;
            statusText.BackColor = Color.Black;
            statusText.ForeColor = foreColor;
        }
    }
}
