using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace FASM_Project_Runner
{
	internal class CompileAndExecute : ICommandHandlercs
	{
		public void HandleCommnad(FASMProject fasmProject, ref string[] args)
		{
			string [] cmpParam = new string [2];
			fasmProject.EntryFileFullName = fasmProject.EntryFileFullName.Replace('/', Path.DirectorySeparatorChar);
			fasmProject.CompilerPath = fasmProject.CompilerPath.Replace('/', Path.DirectorySeparatorChar);
			cmpParam [0] = fasmProject.EntryFileFullName;
			cmpParam [1] = fasmProject.EntryFileFullName.Substring(0, fasmProject.EntryFileFullName.LastIndexOf(Path.DirectorySeparatorChar)) + 
							Path.DirectorySeparatorChar +
							fasmProject.ProjectName +
							"." + 
							fasmProject.OutputType;
			
			
			// TODO cmpParam to string
			StringBuilder sb = new StringBuilder();
			foreach (var param in cmpParam)
			{
				sb.Append("\"" + param.ToString() + "\" ");
			}

			Console.WriteLine("Fasm compiler: \n");

			var startInfo = new ProcessStartInfo(fasmProject.CompilerPath);
			startInfo.Arguments = sb.ToString();
			startInfo.WorkingDirectory = fasmProject.CompilerPath.Substring(0, fasmProject.CompilerPath.LastIndexOf(Path.DirectorySeparatorChar));
			var proc = Process.Start(startInfo);
			proc.WaitForExit();

			if (fasmProject.OutputType == "exe")
			{
				Console.WriteLine($"\nProject \"{fasmProject.ProjectName}\": \n");

				// TODO: fix "space" troubles
				startInfo = new ProcessStartInfo(cmpParam[1]);
				startInfo.Arguments = null;
				startInfo.WorkingDirectory = fasmProject.EntryFileFullName.Substring(0, fasmProject.EntryFileFullName.LastIndexOf(Path.DirectorySeparatorChar));
				proc = Process.Start(startInfo);
				proc.WaitForExit();
			}
			else
			{
				Console.WriteLine("\nFile not execute \nProject settings output format are not \"exe\"");
			}
		}
	}
}
