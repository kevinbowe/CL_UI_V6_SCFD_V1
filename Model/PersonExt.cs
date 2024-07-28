namespace CL_UI_V6_SCFD_V1;
using System.Reflection;
using System.Text;
using static Helper;

public static class PersonExt
{
	public static StringBuilder SbPadLeft (StringBuilder strBuilder, int spaces) => strBuilder.Insert(0," ", spaces);

	public static Func<string , int, string> PadLeft = (str, spaces) => {
		for(int i = 1; i <= spaces; i++) str = ' ' + str; 
		return str;
	};

	public static StringBuilder OutputProperties(
		this Person person, string[]? personPropertyFilterList = null, string orientation = "landscape") 
	{
		var strBuilder = new StringBuilder();
		
		//		Get all of the property names in the Person Class.
		IList<PropertyInfo> personPropInfoList = new List<PropertyInfo>(person.GetType().GetProperties());

		//			Is there a Property FilterList ?
		if (personPropertyFilterList != null) 
		{
			//		Search the personPropInfoList looking for a matching property 
			//		in the personPropertyFilterList
			foreach(PropertyInfo personPropInfo in personPropInfoList)
			{
				string? propMatch = personPropertyFilterList.Where(e => personPropInfo.Name == e).FirstOrDefault();
				if (propMatch == null) continue;
				strBuilder = OutputFriendlyName(person, personPropInfo, strBuilder, orientation);
			}
			//		Output the output stringBuilder sting based on the requested orientation: portrait or landscape.
			return orientation == "landscape" ? SbPadLeft(strBuilder, 5) : strBuilder;
		}

		//////////////////////////////////////////////////////////////////////////
		//		If we get here; There is a Property FilterList

			// Grab all the properties in the Persons class.
			foreach(PropertyInfo personPropInfo in personPropInfoList) 
			{
				strBuilder = person.OutputFriendlyName(personPropInfo, strBuilder, orientation);
			}
		return strBuilder;
	}

	public static string SetFriendlyName(PropertyInfo personPropInfo)
	{
		string propMatch;
		// Create friendly names
		switch(personPropInfo.Name) 
		{
			case "InsertDte_sys" :
				propMatch = "Added";
				break;
			case "doB_sys" :
				propMatch = "DoB";
				break;
			case "WorkStartsAt_sys" :
				propMatch = "Start Time";
				break;
			case "CurrentTime_sys" :
				propMatch = "Added On";
				break;
			default:
				propMatch = personPropInfo.Name;
				break;
		}
		return propMatch;
	}

	public static StringBuilder PadFriendlyNameLandscape (StringBuilder strBuilder, string str, PropertyInfo? personPropInfo)
	{
		var padder = 20;
		//
		switch(personPropInfo?.Name)
		{
			case "Id" :
				strBuilder.Append(str.PadRight(padder,' '));
				break;
			case "SSN" :
				strBuilder.Append(str.PadRight(7+padder,' '));
				break;
			case "FirstName" :
				strBuilder.Append(str.PadRight(13+padder,' '));
				break;
			case "LastName" :
				strBuilder.Append(str.PadRight(16+padder,' '));
				break;
			case "CurrentTime_sys" : 	/* Added-On */
				strBuilder.Append(str.PadRight(28+padder,' '));
				break;
			case "InsertDte_sys" : 		/* Added */
				strBuilder.Append(str.PadRight(20+padder,' '));
				break;
			case "WorkStartsAt_sys" : 	/* Start Time */
				strBuilder.Append(str.PadRight(11+padder,' '));
				break;
			case "doB_sys" : 	/* DoB */
				strBuilder.Append(str.PadRight(7+padder,' '));
				break;
		}
		return strBuilder;
	}

	public static StringBuilder OutputFriendlyName( 
		this Person person, PropertyInfo personPropInfo, StringBuilder strBuilder, string orientation)
	{
		var propMatch = SetFriendlyName(personPropInfo);

		//			Fetch the value associated with the actual property name
		object? propertyValue = personPropInfo?.GetValue(person);
 		//		
 		if (personPropInfo?.PropertyType.Name == "DateOnly")
 		{
			propertyValue = ObjectToDateOnlyFmt(propertyValue);
 		}
		var str = $"{Menus.GREEN}{propMatch}: {Menus.WHITE} {propertyValue}";

		if (orientation == "portrait")
		{
		//			Pad the input string with Nx spaces to the left.
		//			Append an '\n' to the end of the line.
		return strBuilder.Append( PadLeft(str,5) + '\n' );
		}

		//////////////////////////////////////////////////////////////////////////
		//			If we get here, orientation == "landscape".

		return PadFriendlyNameLandscape(strBuilder, str, personPropInfo);

	}

}
