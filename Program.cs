
using CL_UI_V6_SCFD_V1;
using System.Text;
using static Menus;

int BOTTOM_OF_RESULTS = 0;

////////////////////////////////////////////////////////////////////////////////
//			LOAD THE APP HEADER

LoadHeadUI();

////////////////////////////////////////////////////////////////////////////////
//			SAVE THE CURRENT CURSOR POSITION

int TOP_OF_CONSOLE = Console.GetCursorPosition().Top;


while(true)
{
	/////////////////////////////////////////////////////////////////////////////
	//		RESTORE THE CURRENT CURSOR POSITION TO THE TOP

	Console.SetCursorPosition(0, TOP_OF_CONSOLE);

	/////////////////////////////////////////////////////////////////////////////
	//			LOAD THE MAIN MENU

	MenuOption menuOption = MainMenuExp();

	/////////////////////////////////////////////////////////////////////////////
	//			SAVE THE CURSOR POSITION DIRECTLY UNDER THE MAIN MENU

	int UNDER_MENU = Console.GetCursorPosition().Top;

	/////////////////////////////////////////////////////////////////////////////
	//		CLEAR OLD RESULTS

	//			Calculate the number of lines that should be cleared.
	int linesToClear = BOTTOM_OF_RESULTS - UNDER_MENU;
	if (linesToClear > 0) ClearInput(UNDER_MENU,linesToClear);

	/////////////////////////////////////////////////////////////////////////////
	//			HANDLE THE Q - Quit MAIN MENU OPTION

	if (menuOption.Label.Contains('Q')) 
	{ 
		Console.WriteLine();
		return;
	}

	/////////////////////////////////////////////////////////////////////////////
	//		ALWAYS WRITE ONE BLANK LINE HERE

	Console.WriteLine();

	/////////////////////////////////////////////////////////////////////////////
	///		PROCESS ADDITIONAL INPUT

	Console.CursorVisible = true;

	int personId = 1;
	Person inputPerson = new Person();
	//
	//		Display Submenu when appropriate
	switch (menuOption.Option) 
	{
		// case 1:	break; //	Display ALL persons
		case 2:	//	Get Person by Id
			personId = ReadPersonIdUI("Enter the Person Id to display:  ");
			break;
		case 3:	//	Delete Person by Id
			personId = ReadPersonIdUI("Enter the Person Id to delete:  ");
			break;
		// case 4:	break; //	Delete person with Person Object -- Create person object
		case 5:	//	Insert Person -- Create person object
			inputPerson = InsertPersonUI();
			break;
		case 6:	//	Update person -- create person object
			personId = ReadPersonIdUI("Enter the Person Id to update:  ");
			break;
	}

	Console.ResetColor();
	Console.CursorVisible = false;

	/////////////////////////////////////////////////////////////////////////////
	///		VALIDATE INPUT
	if (inputPerson.Id < 0) return;

	/////////////////////////////////////////////////////////////////////////////
	//			EXECUTE THE REQUESTED MENU OPTION

	await new ProcessWorkers().ProcessWork(menuOption.Option, personId, inputPerson);

	/////////////////////////////////////////////////////////////////////////////
	//			DISPLAY THE CONTINUE / QUIT MENU

	var continueQuitMenuOption = ContinueQuitMenu();
	if(continueQuitMenuOption.Label.Contains('Q')) 
	{ 
		Console.WriteLine(); 
		return; 
	}
	//			SAVE THE CURSOR POSITION AT THE BOTTOM OF THE RESULTS.

	BOTTOM_OF_RESULTS = Console.GetCursorPosition().Top;

} // END_WHILE(true)

////////////////////////////////////////////////////////////////////////////////
void LoadHeadUI()
{
	Console.Clear();
	Console.OutputEncoding = Encoding.UTF8;
	Console.CursorVisible = false;
	Console.ForegroundColor = ConsoleColor.Cyan;

	Console.WriteLine("Console Menu Experiment.");
	Console.WriteLine("This App requires $ dotnet run EF_API_V4 and $ dotnet run CL_UI_V6_SCFD_V1 to be running.");
	Console.WriteLine("The SqlDockerMac container must also be running.\n");

	Console.ResetColor();

	Console.WriteLine($"\nTo Navigate, use ⬆️  ⬇️  or enter menu Number to select menu choice. ");
	Console.WriteLine("Press \u001b[32m<return>\u001b[0m to EXECUTE selected choice.\n");
}

public class MenuOption
{
	public int Option {get; set;} = 0;
	public string OptionLabel {get; set;} = String.Empty;
	public string LabelPad {get; set;} = "   "; //false;
	public string Label {get; set;} = String.Empty;
}
