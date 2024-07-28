using CL_UI_V6_SCFD_V1;

public static partial class Menus
{
	/////////////////////////////////////////////////////////////////////////////
	public static int NavDn(int option, int menuOptionCnt, List<int>? disabledList = null){

		if(disabledList is null)
			disabledList = DisabledList;

		if (option == menuOptionCnt && disabledList != null)
		{
			//		Set the option to TOP = 1
			option = 1;
			//		Check to see if the TOP is disabled
			foreach(int disabledOption in disabledList)
			{	
				if (disabledList.Contains(option))
				{
					//		If we get here, the option is disabled
					// 	Get the next option below
					++option;
				}
			}
			return option;
		}

		//////////////////////////////////////////////////////////////////////////
		//		If we get here, we are NOT on the Bottom option.

		++option; // Get next option
		if (disabledList is not null)
		{
			foreach(int disabledOption in disabledList)
			{
				if (disabledList.Contains(option))
				{
					//		Set the current option to the next option (below).
					++option;
					//		Do a limit check on the option
					if(option > menuOptionCnt)
					{
						//		If we get here, the option is invalid.
						option = 1;	//	Set option to Top = 1
					}
				}
			}
		}
		return option;
	}

	/////////////////////////////////////////////////////////////////////////////
	public static int NavUp(int option, int menuOptionCnt, List<int>? disabledList = null ){
		if(disabledList is null)
			disabledList = DisabledList;
		
		if (option == 1)
		{
			//		Set option to BOTTOM = menuOptionCnt
			option = menuOptionCnt; 

			if(disabledList is not null)
			{
				//	Check to see if the BOTTOM is disabled.
				foreach(int disabledOption in disabledList)
				{	
					if (disabledList.Contains(option))
					{
						//		If we get here, the option is disabled.
						//		Get the next option above
						--option;
					}
				}
			}
			return option;
		}

		//////////////////////////////////////////////////////////////////////////
		//		If we get here, we are NOT on the TOP option.

		--option;	// Get next option
		if (disabledList is not null)
		{
			foreach(int disabledOption in disabledList)
			{
				if (disabledList.Contains(option)) 
				{
					//		Set the current option to the next option above
					--option;
					//		Do a limit check on the option
					if (option <= 1) 
					{
						//		If we get here, the option is invalid
						option = menuOptionCnt;//	Set option to Bottom = menuOptionCnt
					}
				}
			}
		}
		return option;
	}

} // END_CLASS
