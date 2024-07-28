using CL_UI_V6_SCFD_V1;

public static partial class Helper
{
	public static string ObjectToDateOnlyFmt(object? propertyValueObj)
	{
			//			Convert the object to a string
			string? valueStr = propertyValueObj?.ToString();
			
			//			Parse the string into a DateOnly object
			DateOnly.TryParse( valueStr, out DateOnly propertyValueDateOnly);

			//			Format the DateOnly object into YYYY-MM-DD format.
			return propertyValueDateOnly.ToString("o");
	}
}