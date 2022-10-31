using System.ComponentModel;
using System.Text.Json;

namespace FASM_Project_Runner
{
	public class CommandHandler
	{
		private Dictionary<String,ICommandHandlercs> _handlers; 
		private int _commandID = 0;
		private int _startFileID = 1;
		private FileSeeker _fileSeeker;

		public CommandHandler()
		{
			_handlers = new Dictionary<String,ICommandHandlercs>{
				{"compileAndExecute", new CompileAndExecute()},
				{"compile", new Compile()}
			};
			_fileSeeker = new FileSeeker();
		}

		public void HandleCommand(ref string [] args)
		{		
			string [] myArgs = new string[0];
			if (args.Length < 2)
			{
				throw new ArgumentException("Incorrect amount of arguments");
			}
			string fasmProjectName = _fileSeeker.SeekFASMProject(args[_startFileID]);
			FASMProject fasmProject = new FASMProject();
			using (FileStream fs = File.OpenRead(fasmProjectName))
			{
				if (fs != null)
				{
					 fasmProject= JsonSerializer.Deserialize<FASMProject>(fs);
				};
			};

			if (_handlers.ContainsKey(args[_commandID]))
			{
				_handlers[args[_commandID]].HandleCommnad(fasmProject, ref myArgs);
			}
			else
			{
				throw new ArgumentException("Incorrect command");
			}
		}
	}
}
