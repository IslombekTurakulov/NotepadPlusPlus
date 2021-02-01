using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace NotepadPlusPlus
{
    class CompilerCSharp
    {
        public void CompilerResults(string textBox, TabControl tabOption)
        {
            // Код был взят и усовершенствован с официальной страницы документации Майкрософт 
            // Ссылка: https://docs.microsoft.com/ru-ru/troubleshoot/dotnet/csharp/compile-code-using-compiler
            TabPage tabpage = tabOption.SelectedTab;
           

            CodeDomProvider icc = CodeDomProvider.CreateProvider("CSharp");
            var output = "Result.exe";

            CompilerParameters parameters =
                new CompilerParameters { GenerateExecutable = true, OutputAssembly = output };

            // Make sure we generate an EXE, not a DLL
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, textBox);

            TabPage tabPage = new TabPage { Text = $@"Compile ({tabpage.Text})" };
            FastColoredTextBox coloredTextBox =
                new FastColoredTextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None };
            tabPage.Controls.Add(coloredTextBox);
            tabOption.TabPages.Add(tabPage);
            if (results.Errors.Count > 0)
            {
                coloredTextBox.ForeColor = Color.Red;
                foreach (CompilerError compErr in results.Errors)
                {
                    coloredTextBox.Text = coloredTextBox.Text +
                                          @"Line number " + compErr.Line +
                                          @", Error Number: " + compErr.ErrorNumber +
                                          ", '" + compErr?.ErrorText + ";" +
                                          Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                // Successful Compile
                coloredTextBox.ForeColor = Color.Blue;

                coloredTextBox.Text = "Succesful Compile! The output is located on exe path";
                // If we clicked run then launch our EXE
                Process.Start(output);
            }
        }
    }
}
