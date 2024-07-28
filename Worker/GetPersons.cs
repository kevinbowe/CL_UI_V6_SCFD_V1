namespace CL_UI_V6_SCFD_V1;

using System;
using System.Net.Http;
using System.Threading.Tasks;

using System.Text.Json;
public static class GetPersons
{
	//////////////////////////////////////////////////////////////////////////////
	///		'async' declare the function 'GetPersonsAsync' to be ASYNC
	///		Task<List<Person>> declares an asynchronous return type.
	///		This is based on the Deserialize<List<Person>>(~)
	public static async Task<PersonListResponse> GetPersonsAsync(HttpClient client)
	{
		client.DefaultRequestHeaders.Add("Get", "application/json");
		client.BaseAddress = new Uri("http://localhost:5073");
		using HttpResponseMessage response = await client.GetAsync("GetPersons/");

		//			Serialize the HTTP response content, asynchronously.
		//				The response.Content property is the type Http.StreamContent.
		//				ReadAsStringAsync(~) will read the stream and generate a serialized response string.
		var serializedResponse = await response.Content.ReadAsStringAsync();
		
		//			Deserialize the serialized response string into a List<Person>> collection and return. 
		var personList = JsonSerializer.Deserialize<List<Person>>(serializedResponse, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true} );
		return new PersonListResponse()
		{
			ResponseCode = response.StatusCode,
			ResponseMessage = "Persons Retrieved",
			PersonList = personList
		};
	}
}
