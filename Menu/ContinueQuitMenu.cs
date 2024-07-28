using System.Runtime.InteropServices;
using CL_UI_V6_SCFD_V1;

public static partial class Menus
{
	public static List<MenuOption> ContinueQuitMenuInit()
	{
		//			These are the menu options that will be displayed
		List<MenuOption> menuOptions = new List<MenuOption>
		{
			new MenuOption() { Option = 1, OptionLabel = "C.", Label = $"{CYAN}Continue" },
			new MenuOption() { Option = 2, OptionLabel = "Q.", Label = $"{CYAN}Quit" }
		};
		return menuOptions;
	}

	/////////////////////////////////////////////////////////////////////////////
	public static MenuOption ContinueQuitMenu() 
	{
		ConsoleKeyInfo key;
		bool isSelected = false;
		var option = 1;
		var cqMenuOptions = ContinueQuitMenuInit();

		//			Get current cursor Position.
		int CQ_TOP = Console.GetCursorPosition().Top;

		while(!isSelected) 
		{
			Console.SetCursorPosition(0,CQ_TOP);

			//		Display menu options
			foreach(var Mo in cqMenuOptions)
			{
				Console.WriteLine(
					$"{(Mo.Option == option ? $"{GreenCheck} {GREEN}": "   ")} "+
					$"{Mo.OptionLabel}{Mo.LabelPad}{Mo.Label} {WHITE} -- {option}"
				);
			}
			//		Hide the input character by setting ReadKey(true).
			//		Display the input character by setting ReadKey(false) or ReadKey().
			key = Console.ReadKey(true);

			switch (key.Key)
			{
				case ConsoleKey.C:  
				{ 
					option = 1;
					break; 
				}
 				case ConsoleKey.Q:  
				{ 
					option = 2;
					break; 
				}
				case ConsoleKey.UpArrow:
					option = option == 1 ? 2 : 1;
					break;
				case ConsoleKey.DownArrow: 
					option = option == 2 ? 1 : 2;
					break;
				case ConsoleKey.Enter: 
					isSelected = true; 
					//			Clear the menu
					ClearInput(CQ_TOP,2);
					break;
			}
		} // END_WHILE

		//			If we get here, the Cx selected <return/enter> key.
		return cqMenuOptions.Where(o => o.Option == option).First();
	}
} // END_CLASS
