using CL_UI_V6_SCFD_V1;

public static partial class Menus
{

	/////////////////////////////////////////////////////////////////////////////
	/// <summary>
	/// Read Person Id 
	/// </summary>
	/// <param name="message"></param>
	/// <returns>int personId </returns>
	public static int ReadPersonIdUI(string message)
	{
		Console.Write(message);
		var input = Console.ReadLine();
		var success = int.TryParse(input, out int personId);
		if(!success) return -1;
		return personId;
	}

} // END_CLASS
	
