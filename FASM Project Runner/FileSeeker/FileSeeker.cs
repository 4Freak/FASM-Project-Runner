using System.Text;
using System;
using System.IO;

namespace FASM_Project_Runner
{
	public class FileSeeker
	{
		private List<string> _visitedDirectories;

		private string _FASMProjectSignature = "_FASMPROJECT.json";

		public FileSeeker()
		{
			_visitedDirectories = new List<string>();
		}

		public string SeekFASMProject(string startFileName)
		{
			string fasmProject = null;
			_visitedDirectories.Clear();
			startFileName = startFileName.Replace('/', Path.DirectorySeparatorChar);
			string currDir = startFileName.Substring(0, startFileName.LastIndexOf(Path.DirectorySeparatorChar));
			if (Directory.Exists(currDir))
			{
				while (fasmProject == null && currDir.Length != 0)
				{
					if (_visitedDirectories.Contains(currDir) == false)
					{
						
						// Search files in first time visited directory
						_visitedDirectories.Add(currDir);		
						var filePaths = Directory.GetFiles(currDir);
						foreach (string fileName in filePaths)
						{
							if (fasmProject == null && fileName.Contains(_FASMProjectSignature))
							{
								fasmProject = fileName;
							}
						}
					}
					else
					{
						
						// Look for directories
						var directoryPaths = Directory.GetDirectories(currDir);
						bool isAllVisited = true;
						foreach (string directoryPath in directoryPaths)
						{
							if (_visitedDirectories.Contains(directoryPath) == false)
							{
								// Not all directories in current directory are visited
								currDir = directoryPath;
								isAllVisited = false;
							}
						}
						
						if (isAllVisited)
						{
							// All directory in current directory are visited
							currDir = currDir.Substring(0, currDir.LastIndexOf(Path.DirectorySeparatorChar));
						}
					}
								
				}
			}
			return fasmProject;
		}
	}
}
