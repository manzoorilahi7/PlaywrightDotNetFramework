using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenUtil
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Playwright Codegen Util";
            string PsFileDir = @"C:\Users\manzo\source\repos\PlaywrightDotNetFramework\PlaywrightTests\bin\Debug\net6.0";
            Console.WriteLine("Enter URL to launch: ");
            string url = Console.ReadLine();

            //PowerShell ps = PowerShell.Create();

            //ps.AddCommand($"Set-Location -path {PsFileDir}");
            //ps.AddCommand($@".\playwright.ps1 codegen {url}");

            //ps.Invoke();

            using (Runspace runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();
                runspace.SessionStateProxy.Path.SetLocation(PsFileDir);
                using (Pipeline pipeline = runspace.CreatePipeline())
                {
                    pipeline.Commands.Add("node --version");
                    //pipeline.Commands.Add($@".\playwright.ps1 codegen {url}");
                    pipeline.Invoke();
                }
                runspace.Close();
            }

        }
        
    }
}
