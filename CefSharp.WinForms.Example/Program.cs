// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CefSharp.Example;
using CefSharp.WinForms.Example.Minimal;

namespace CefSharp.WinForms.Example
{
    class Program
    {
	    private static string _additionalPath = null;
			private static string AdditionalPath 
			{ 
				get
				{
					if (_additionalPath != null)
						return _additionalPath;
					_additionalPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Environment.Is64BitProcess ? "x64" : "x86");
					return _additionalPath;
				}
			}

			[STAThread]
        static void Main()
        {
	        try
	        {
		        var path = Environment.GetEnvironmentVariable("Path");
						path = path + ";" + AdditionalPath;
						Console.Out.WriteLine(path);
		        Environment.SetEnvironmentVariable("Path", path);
						AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;

		        CefExample.Init();

		        var browser = new BrowserForm();
		        //var browser = new SimpleBrowserForm();
		        //var browser = new TabulationDemoForm();
		        Application.Run(browser);
	        }
	        catch (Exception e)
	        {
		        Console.Error.WriteLine(e);
	        }
        }

	    private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
	    {
				string[] fields = args.Name.Split(',');
				string assemblyName = fields[0];
				string assemblyCulture;
				if (fields.Length < 2)
					assemblyCulture = null;
				else
					assemblyCulture = fields[2].Substring(fields[2].IndexOf('=') + 1);


				string assemblyFileName = assemblyName + ".dll";
				string assemblyPath = Path.Combine(AdditionalPath, assemblyFileName);
		    if (!File.Exists(assemblyPath)) return null;
				Assembly loadingAssembly = Assembly.LoadFrom(assemblyPath);
				return loadingAssembly;
	    }
    }
}
