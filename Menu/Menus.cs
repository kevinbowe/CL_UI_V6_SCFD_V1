using CL_UI_V6_SCFD_V1;

public static partial class Menus
{
	public static string GreenCheck {get;} = "✅";
   public static string YELLOW {get;} = "\u001B[33m";
	public static string GREEN {get;} = "\u001b[32m";
	public static string RED  {get;} = "\u001b[31m";
	public static string CYAN {get;} = "\u001b[36m";
	public static string MAGENTA {get;} = "\u001b[35m";
	public static string WHITE {get;} = "\u001b[0m";

	public static int SetOptionByLetter(int option, List<MenuOption> menuOptions, 
		char inputLetter, List<int>? disabledList)
	{
		var menuOption = menuOptions.Where(e => e.OptionLabel.Contains(inputLetter)).FirstOrDefault();
		if (menuOption is null) return option;

		if(disabledList is not null && disabledList.Contains(menuOption.Option)) return option;

		option = menuOption.Option; // set the E to the OptionList Number
		return option;
	}

	////////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// Clear Nx lines in console menu
	/// </summary>
	/// <param name="currentLine"></param>
	/// <param name="lineCount"></param>
	static public void ClearInput(int currentLine, int lineCount)
	{
		
		(int left, int right) = Console.GetCursorPosition();

		for(int i=0; i<lineCount; i++)
		{
			Console.SetCursorPosition(0, currentLine+i);
			ClearCurrentConsoleLine();
		}
		Console.SetCursorPosition(left, right);
	}

	////////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// Clear the current console line
	/// </summary>
	static public void ClearCurrentConsoleLine()
	{
		Console.Write(new string(' ', Console.WindowWidth)); 
	}
} // END_CLASS
	
