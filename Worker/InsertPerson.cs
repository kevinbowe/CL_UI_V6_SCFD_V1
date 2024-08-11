namespace CL_UI_V6_SCFD_V1;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;

public class InsertPerson
{
	//////////////////////////////////////////////////////////////////////////////
	public static async Task<PersonResponse> InsertPersonAsync(HttpClient client, Person inputPerson)
	{
		client.DefaultRequestHeaders.Add("Post", "application/json");
		// client.BaseAddress = new Uri("http://localhost:5000");
		client.BaseAddress = new Uri("http://localhost:5073");

		var jsonContent = JsonContent.Create(inputPerson);

		using HttpResponseMessage response = await client.PostAsync("InsertPerson", jsonContent);

		//			Serialize the HTTP content to a string as an asynchronous operation.
		var serializedResponse = await response.Content.ReadAsStringAsync();

		//			Deserialize the serialized response string into a List<Person>> collection and return. 
		return new PersonResponse()
		{
			ResponseCode = System.Net.HttpStatusCode.Accepted,
			ResponseMessage = "OK",
			Person = JsonSerializer.Deserialize<Person>(
					serializedResponse, 
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
			)
		};
	}
}
