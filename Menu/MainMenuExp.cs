using CL_UI_V6_SCFD_V1;

public static partial class Menus
{
	public static List<MenuOption> MainMenuExpInit()
	{
		//			These are the menu options that will be displayed
		List<MenuOption> menuOptions = new List<MenuOption>
		{
			new MenuOption() { Option = 1, OptionLabel = "1.", Label = "GetPersons" },
			new MenuOption() { Option = 2, OptionLabel = "2.", Label = "GetPersonById" },
			new MenuOption() { Option = 3, OptionLabel = "3.", Label = "DeletePersonById" },
			new MenuOption() { Option = 4, OptionLabel = "4.", Label = $"{MAGENTA}DeletePerson {WHITE} - skip" },
			new MenuOption() { Option = 5, OptionLabel = "5.", Label = "InsertPerson" },
			new MenuOption() { Option = 6, OptionLabel = "6.", Label = "UpdatePerson" },
			new MenuOption() { Option = 7, OptionLabel = "", LabelPad = String.Empty, Label = "-------------------" },
			new MenuOption() { Option = 8, OptionLabel = "Q.", Label = $"{CYAN}Quit" }
		};
		return menuOptions;
	}

	public static List<int>? DisabledList = new List<int>(){ 4, 7}; 
	public static List<int>? DisabledNumList = new List<int>() { 4,7,8,9 };

	/////////////////////////////////////////////////////////////////////////////
	public static MenuOption MainMenuExp(List<MenuOption>? MenuOptions = null, List<int>? disabledList = null, List<int>? disabledNumList = null) 
	{
		ConsoleKeyInfo key;
		bool isSelected = false;

		//			Load the MenuOptions.
		//			Use the local menu options above if menu options were not passed as argument. 
		if (MenuOptions is null) 
		{
			MenuOptions = MainMenuExpInit();
		}

		if(disabledList is null) 
		{
			disabledList = DisabledList;
		}

		if(disabledNumList is null) 
		{
			disabledNumList = DisabledNumList;
		}

		(int left, int top) = Console.GetCursorPosition();

		//			Select the FIRST option that is NOT disabled.
		var optionInit = 0; // Default Option
		var option = NavDn(optionInit, MenuOptions.Count, disabledList);

		while(!isSelected) 
		{
			Console.SetCursorPosition(left, top);

			//		Output menu options
			foreach(var Mo in MenuOptions)
			{
				Console.WriteLine(
					$"{(Mo.Option == option ? $"{GreenCheck} {GREEN}": "   ")} "+
					$"{Mo.OptionLabel}{Mo.LabelPad}{Mo.Label} {WHITE}"
				);
			}
			//		Hide the input character by setting ReadKey(true).
			//		Display the input character by setting ReadKey(false) or ReadKey().
			key = Console.ReadKey(true);

			switch (key.Key)
			{
				case ConsoleKey.D1: case ConsoleKey.NumPad1: 
				{
					if( disabledNumList is not null && disabledNumList.Contains(1) ) break;
					option = 1; 
					break; 
				}
				case ConsoleKey.D2: case ConsoleKey.NumPad2: 
				{
					if( disabledNumList is not null && disabledNumList.Contains(2) ) break;
					option = 2; 
					break; 
				}
				case ConsoleKey.D3: case ConsoleKey.NumPad3: 
				{ 
					if( disabledNumList is not null && disabledNumList.Contains(3) ) break;
					option = 3; 
					break; 
				}
				case ConsoleKey.D4: case ConsoleKey.NumPad4: 
				{ 
					if( disabledNumList is not null && disabledNumList.Contains(4) ) break;
					option = 4; 
					break; 
				}
				case ConsoleKey.D5: case ConsoleKey.NumPad5: 
				{ 
					if( disabledNumList is not null && disabledNumList.Contains(5) ) break;
					option = 5; 
					break; 
				}
				case ConsoleKey.D6: case ConsoleKey.NumPad6: 
				{ 
					if( disabledNumList is not null && disabledNumList.Contains(6) ) break;
					option = 6; 
					break; 
				}
				case ConsoleKey.D7: case ConsoleKey.NumPad7: 
				{ 
					if( disabledNumList is not null && disabledNumList.Contains(7) ) break;
					option = 7; 
					break; 
				}
				case ConsoleKey.D8: case ConsoleKey.NumPad8: 
				{ 
					if( disabledNumList is not null && disabledNumList.Contains(8) ) break;
					option = 8; 
					break; 
				}
				case ConsoleKey.D9: case ConsoleKey.NumPad9: 
				{ 
					if( disabledNumList is not null && disabledNumList.Contains(9) ) break;
					option = 9; 
					break; 
				}
				// case ConsoleKey.D0: case ConsoleKey.NumPad0: {}
				
 				case ConsoleKey.E:  
				{ 
					//		If no match return option unchanged else return new option.
					option = SetOptionByLetter(option, MenuOptions, 'E', disabledList);
					break; 
				}
 				case ConsoleKey.Q:  
				{ 
					//		If no match return option unchanged else return new option.
					option = SetOptionByLetter(option, MenuOptions, 'Q', disabledList);
					break; 
				}
				case ConsoleKey.C:  
				{ 
					//		If no match return option unchanged else return new option.
					option = SetOptionByLetter(option, MenuOptions, 'C', disabledList);
					break; 
				}
 				case ConsoleKey.S:  
				{ 
					//		If no match return option unchanged else return new option.
					option = SetOptionByLetter(option, MenuOptions, 'S', disabledList);
					break; 
				}

				////////////////////////////////////////////////////////////////////
				case ConsoleKey.UpArrow:
					option = NavUp(option, MenuOptions.Count, disabledList);
					break;
				////////////////////////////////////////////////////////////////////
				case ConsoleKey.DownArrow: 
					option = NavDn(option, MenuOptions.Count, disabledList);
					break;
				////////////////////////////////////////////////////////////////////
				case ConsoleKey.Enter: isSelected = true; break;
			}
		}
		return MenuOptions.Where(o => o.Option == option).First();
	}
} // END_CLASS
