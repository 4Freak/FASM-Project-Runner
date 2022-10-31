namespace FASM_Project_Runner
{
    public class Entry
    {
        // args start with 0
        public static void Main(string[] args)
        {
/*			args = new string[2];
			args[0] = "compileAndExecute";
			args[1] = "D:\\BSUIR\\5_Sem\\OSaSP\\Projects\\_041\\Lab4.asm";
*/			args[1] = args[1].Replace('/', Path.DirectorySeparatorChar);
			var commandHandler = new CommandHandler();
			try
			{
				commandHandler.HandleCommand(ref args);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
        }
    }
}