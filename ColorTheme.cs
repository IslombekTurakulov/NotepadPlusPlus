using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace NotepadPlusPlus
{
    class ColorTheme
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
            mainMenu.BackColor = backColor;
            mainMenu.ForeColor = foreColor;
            fastToolButton.BackColor = backColor;
            fastToolButton.ForeColor = foreColor;
            richTextBox.BackColor = backColor;
            richTextBox.ForeColor = foreColor;
            statusText.BackColor = backColor;
            statusText.ForeColor = foreColor;
            tabpage.BorderStyle = BorderStyle.None;
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
            mainMenu.BackColor = backColor;
            mainMenu.ForeColor = foreColor;
            fastToolButton.BackColor = backColor;
            fastToolButton.ForeColor = foreColor;
            fastColoredTextBox.BackColor = backColor;
            fastColoredTextBox.ForeColor = foreColor;
            statusText.BackColor = backColor;
            statusText.ForeColor = foreColor;
            tabpage.BorderStyle = BorderStyle.None;
        }
    }
}
