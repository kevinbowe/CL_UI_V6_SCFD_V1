using CL_UI_V6_SCFD_V1;

public static partial class Menus
{

	/////////////////////////
	/// <summary>
	/// Collect fields for generating a new Person object
	/// </summary>
	/// <returns>Person</returns>
	/// <exception cref="Exception"></exception>
	public static Person InsertPersonUI()
	{
		string? firstName, lastName, ssn, dob;
		string[] dobSplit;
		int[]	dobSplitInt = new int[3];
		Console.CursorVisible = true;

		try 
		{
			while(true) 
			{
				(int left2, int top2) = Console.GetCursorPosition();

				// FirstName -- 'Kevin'
				Console.Write($"{GREEN}Enter the First Name:{WHITE} ");
				(int firstNameleft, int firstNameTop) = Console.GetCursorPosition();
				
				Menus.ClearCurrentConsoleLine();
				
				Console.SetCursorPosition(firstNameleft, firstNameTop);
				firstName = Console.ReadLine();

				// LastName -- 'Bowe'
				Console.Write(	$"{GREEN}Enter the Last Name:{WHITE}   ");
				(int lastNameleft, int lastNameTop) = Console.GetCursorPosition();
				Menus.ClearCurrentConsoleLine();
				Console.SetCursorPosition(lastNameleft, lastNameTop);
				lastName = Console.ReadLine();
				
				// Social Security Number -- '300204000'
				Console.Write(	$"{GREEN}Enter the SSN:{WHITE}        ");
				(int ssnleft, int ssnTop) = Console.GetCursorPosition();
				Menus.ClearCurrentConsoleLine();
				Console.SetCursorPosition(ssnleft, ssnTop);
				ssn = Console.ReadLine();

				// Date of birth -- '1957-08-22'
				Console.Write(	$"{GREEN}DoB (1999-12-31):{WHITE}     ");
				(int dobleft, int dobTop) = Console.GetCursorPosition();
				Menus.ClearCurrentConsoleLine();
				Console.SetCursorPosition(dobleft, dobTop);
				dob = Console.ReadLine();

				if (dob == null) return new Person();

				if (dob.Length > 0) 
				{
					try 
					{
						dobSplit = dob.Split("-");
						int.TryParse(dobSplit[0], out dobSplitInt[0]);
						int.TryParse(dobSplit[1], out dobSplitInt[1]);
						int.TryParse(dobSplit[2], out dobSplitInt[2]);
					} 
					catch (Exception) 
					{
						throw new Exception($"Invalid Dob format: {dob}");
					};
				}

				//------------------------------------------------------------------------
				Console.WriteLine();
				Console.WriteLine($"S:   {GREEN}Save{WHITE}");
				Console.WriteLine($"E:   {CYAN}Edit{WHITE}");
				Console.WriteLine($"C:   {RED}Cancel{WHITE}");
				Console.WriteLine($"{WHITE}------------");
				Console.Write($"{GREEN}Select Option:{WHITE}   ");

				(int continueleft, int continuetop) = Console.GetCursorPosition();
				Menus.ClearCurrentConsoleLine();
				Console.SetCursorPosition(continueleft,continuetop);
				//
				var selectContinueEdit = Console.ReadLine();

				//				Edit
				if(selectContinueEdit == "e")
				{
					//			Return to top of input and clear everything.
					ClearInput(firstNameTop, 10);
					//			Go to the top of the Person input
					Console.SetCursorPosition(left2, top2);
					continue;
				}
				//				Cancel
				if(selectContinueEdit == "c")
				{
					return new Person() {Id = -1};
				}

				break;
			}
			Console.CursorVisible = false;
				
			//---------------------------------------------------------------------------
			//	Validate the input data
			
			if(String.IsNullOrEmpty(firstName)) throw new Exception("Bad First Name");
			if(String.IsNullOrEmpty(lastName)) throw new Exception("Bad Last Name");

			if (!int.TryParse(ssn, out var convert))
				throw new Exception($"Bad SSN: must be integer: {ssn}");
			if(String.IsNullOrEmpty(ssn)) throw new Exception("Bad SSN");

			if( dobSplitInt[0] <= 0 || dobSplitInt[0] < 1000 ) 
				throw new Exception($"Bad DOB Year: {dobSplitInt[0]}");

			if (dobSplitInt[1] <= 0 || dobSplitInt[1] > 12 ) 
					throw new Exception($"Bad DOB Month: {dobSplitInt[1]}");

			if (dobSplitInt[2] <= 0 || dobSplitInt[2] > 31 ) 
					throw new Exception($"Bad DOB Day: {dobSplitInt[2]}");

			//---------------------------------------------------------------------------
			//	If we get here, the data is ready for the person object.
			//	It should be valid

			//			Create the Person Object
			var person = new Person()
			{
				FirstName = firstName,
				LastName = lastName,
				SSN = ssn,
				InsertDte_sys = DateTime.Now,

				//			The DateOnly object only accepts a date value.
				//			The input must be parsed from a single string above
				doB_sys = new DateOnly(dobSplitInt[0], dobSplitInt[1], dobSplitInt[2]),

				WorkStartsAt_sys = new TimeOnly(8, 0, 0),
				CurrentTime_sys = System.DateTimeOffset.Now
			};
			return person;
		} 
		catch (Exception ex) 
		{
			Console.WriteLine(ex.Message);
			return new Person() { Id = -1};
		}
	}

} // END_CLASS
	
