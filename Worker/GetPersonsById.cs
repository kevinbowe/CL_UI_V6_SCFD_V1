namespace CL_UI_V6_SCFD_V1;

using System;
using System.Net.Http;
using System.Threading.Tasks;

using System.Text.Json;
public static class GetPersonById
{
	//////////////////////////////////////////////////////////////////////////////
	public static async Task<PersonResponse> GetPersonByIdAsync(HttpClient client, int Id)
	{
		client.DefaultRequestHeaders.Add("Get", "application/json");
		client.BaseAddress = new Uri("http://localhost:8080");
		
		HttpResponseMessage response;

		try
		{
			response = await client.GetAsync($"GetPersonById/{Id}");
			response.EnsureSuccessStatusCode();
		} 
		catch (HttpRequestException ex) when (ex is {StatusCode: System.Net.HttpStatusCode.NotFound})
		{
			return new PersonResponse()
			{ 
				ResponseCode = System.Net.HttpStatusCode.NotFound,	
				ResponseMessage = "Missing Person Id"
			};
		}

		//			Serialize the HTTP response content, asynchronously.
		//				The response.Content property is the type Http.StreamContent.
		//				ReadAsStringAsync(~) will read the stream and generate a serialized response string.
		var serializedResponse = await response.Content.ReadAsStringAsync();

		//			This executes if personId is 0 -- These records do not exist.
		if (serializedResponse.Length <= 0 ) 
			return new PersonResponse()
			{ 
				ResponseCode = response.StatusCode,	
				ResponseMessage = Id < 0 ? "ERROR: Person Id missing": $"Person Id [{Id}] not found",
				Person = null
			};

		//////////////////////////////////////////////////////////////////////////
		// 		If we get here, We got a match

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
