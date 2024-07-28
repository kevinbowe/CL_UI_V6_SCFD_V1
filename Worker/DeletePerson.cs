namespace CL_UI_V6_SCFD_V1;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
public static class DeletePerson
{
	//////////////////////////////////////////////////////////////////////////////
	public static async Task<string> DeletePersonAsync(HttpClient client)
	{
		client.DefaultRequestHeaders.Add("Put", "application/json");
		client.BaseAddress = new Uri("http://localhost:5073");

		var jsonObj = new {
			id = "39",
			firstName = "Kevin",
			lastName = "BoweC_New",
			ssn = "333225555",
			insertDte_sys = "2024-06-13T00:00:00.000Z",
			doB_sys = "1957-08-22",
			workStartsAt_sys = "07:00:00",
			currentTime_sys = "2024-06-13T12:06:45.111Z"
		};
		var jsonContent = JsonContent.Create(jsonObj);

		using HttpResponseMessage response = await client.PutAsync("DeletePerson", jsonContent);

		//			Serialize the HTTP content to a string as an asynchronous operation.
		return await response.Content.ReadAsStringAsync();
}
}
