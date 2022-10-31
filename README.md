# *The design is very human*

# How run FASM code from Notepad++
- **Clone** this repository and compile it to get executable file **.exe*
> Currently it is "FASM Project Runner.exe"
> Example path: "...\FASM Project Runner\bin\Debug\net6.0\FASM Project Runner.exe"
- **Move** FASM compiler .exe to FASM\Include
> Example path: D:\Programms for work\FASM\INCLUDE\FASM.EXE
- Create **JSON** project file in your FASM project directory
>JSON file **must** contain "*_FASMPROGECT.json*" in name 
>JSON example:
>{
    "EntryFileFullName": "D:/FASM Projects/NppTest/NppTest.asm",
	"ProjectName": "NppTestCompiled",
	"OutputType": "exe", 
	"CompilerPath": "D:/Programms for work/FASM/INCLUDE/FASM.EXE"
}
>- **EntryFileFullName** - file from which compilation begins (*Entry point*)
>- **ProjectName** - your output file name
>- **OutputType** - type of your output file (*exe/img/png/...*)
>- **CompilerPath** - path to FASM compiler
>
>**Where JSON file should be**: recommended place JSON file in your FASM project **root** directory. 
- Open **Notepad++**, press F5 (Run) and enter command next way: cmd /k "*Path to FASM Project Runner.exe*" *command* "$(FULL_CURRENT_PATH)"
> **Command example**: cmd /k cd /d "D:\BSUIR\0_Anything_Else\FASM Project Runner\FASM Project Runner\bin\Release\net6.0" && "FASM Project Runner.exe" compileAndExecute "$(FULL_CURRENT_PATH)"
> **cmd** - command line
>  **/k** - don't close command line after executing all commands
>  **cd /d "%Path%"** - change directory (optional command)
> **Path to FASM Project Runner.exe** - full path to your compiled .exe file in step one
> **Command** - command that FASM Project Runner.exe **must** execute
> **List** of command that FASM Project Runner.exe **can** execute:
>- compile and execute - compile and execute your project
> 
> **$(FULL_CURRENT_PATH)** - Notepad++ keyword, replaced by full path for current editing file 
- Now you can **Run** it or **Save** and bind to proposed shortcuts 