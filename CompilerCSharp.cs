using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CSharp;

namespace NotepadPlusPlus
{
    class CompilerCSharp
    {
        public string CompileCode(string path)
        {
            try
            {
                var source = File.ReadAllText($@"{path}");

                // Настройки компиляции
                var providerOptions = new Dictionary<string, string>();
                providerOptions.Add("CompilerVersion", "v2.0");
                var provider = new CSharpCodeProvider(providerOptions);

                var compilerParams = new CompilerParameters();
                compilerParams.OutputAssembly = "foo.exe";
                compilerParams.CompilerOptions = " /out:foo.exe";
                compilerParams.GenerateExecutable = true;

                // Компиляция
                var results = provider.CompileAssemblyFromSource(compilerParams, source);

                // Выводим информацию об ошибках
                string res = $"Number of Errors: {results.Errors.Count} {Environment.NewLine}";
                foreach (CompilerError err in results.Errors)
                    res += $"ERROR {err.ErrorText} {Environment.NewLine}";

                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }
    }
}

