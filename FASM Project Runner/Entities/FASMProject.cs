namespace FASM_Project_Runner
{
    public class FASMProject
    {
        public string EntryFileFullName { get; set; } = "";
        public string ProjectName { get; set; } = "";
		public string OutputType {get; set; } = "exe";
        public string CompilerPath { get; set; } = ""; 
		public FASMProject() {}
        public FASMProject(string entryFileFullName, string projectName, string compilerPath)
        {
            EntryFileFullName = entryFileFullName;
            ProjectName = projectName;
            CompilerPath = compilerPath;
        }
    }
}
