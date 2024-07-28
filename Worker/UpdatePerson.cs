namespace CL_UI_V6_SCFD_V1;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

public static class UpdatePerson
{
	//////////////////////////////////////////////////////////////////////////////
	public static async Task<string> UpdatePersonAsync(HttpClient client, Person person)
	{
		client.DefaultRequestHeaders.Add("Put", "application/json");

		var jsonContent = JsonContent.Create(person);
		
		using HttpResponseMessage response = await client.PutAsync("UpdatePerson", jsonContent);

		//			Serialize the HTTP content to a string as an asynchronous operation.
		return await response.Content.ReadAsStringAsync();
	}
}
