//css_dbg /t:library;
using System;
using System.IO;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.JScript;
using Microsoft.CSharp;
using System.Diagnostics;
using System.Collections.Generic;

//css_import ccscompiler;
//css_import cppcompiler;
//css_import xamlcompiler;

public class CSSCodeProvider
{
	static public ICodeCompiler CreateCompiler(string sourceFile)
	{
        //Debug.Assert(false);
        var compilerVersion35 = new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } };

        if (Path.GetExtension(sourceFile).ToLower() == ".vb")
            return (new Microsoft.VisualBasic.VBCodeProvider(compilerVersion35)).CreateCompiler();
        else if (Path.GetExtension(sourceFile).ToLower() == ".js")
            return (new Microsoft.JScript.JScriptCodeProvider()).CreateCompiler();
        else if (Path.GetExtension(sourceFile).ToLower() == ".ccs")
            return new CSScriptCompilers.CSharpCompiler("v3.5");
        else if (Path.GetExtension(sourceFile).ToLower() == ".cpp")
            return new CSScriptCompilers.CPPCompiler();
        else
            return new CSScriptCompilers.CSCompiler("v3.5");
	}
}
