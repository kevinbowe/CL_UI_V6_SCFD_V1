namespace CL_UI_V6_SCFD_V1;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class DeletePersonById
{
	//////////////////////////////////////////////////////////////////////////////
	public static async Task<string> DeletePersonByIdAsync(HttpClient client, int Id)
	{
		client.DefaultRequestHeaders.Add("Get", "application/json");
		client.BaseAddress = new Uri("http://localhost:5073");
		HttpResponseMessage response;

		try
		{
			response = await client.DeleteAsync($"DeletePersonById/{Id}");
			response.EnsureSuccessStatusCode();
		} 
		catch (HttpRequestException ex) when (ex is {StatusCode: System.Net.HttpStatusCode.NotFound}) 
		{ 
			return "Not Found";
		}
		catch (HttpRequestException ex) when (ex is {StatusCode: System.Net.HttpStatusCode.InternalServerError})
		{ 
			return "Error: Internal Server Error - 500";
		}
		catch (HttpRequestException ex) when (ex is {StatusCode: System.Net.HttpStatusCode.BadRequest})
		{
			return $"{ex.Message}";
		}

		//			Serialize the HTTP content to a string as an asynchronous operation.
		var serializedResponse = await response.Content.ReadAsStringAsync();
		if (serializedResponse.Length <= 0 ) // This will ALWAYS be zero length // not helpful
			return $"Person Id [{Id}] deleted";
		return $"Person Id [{Id}] not found";
	}

//////////////////////////////////////////////////////////////////////////////
	public static async Task<PersonResponse> DeletePersonByIdTWOAsync(HttpClient client, int Id)
	{
		client.DefaultRequestHeaders.Add("Get", "application/json");
		client.BaseAddress = new Uri("http://localhost:5073");
		HttpResponseMessage response = await client.DeleteAsync($"DeletePersonByIdTWO/{Id}");
		response.EnsureSuccessStatusCode();

		//			Serialize the HTTP response content, asynchronously.
		//				The response.Content property is the type Http.StreamContent.
		//				ReadAsStringAsync(~) will read the stream and generate a serialized response string.
		var serializedResponse = await response.Content.ReadAsStringAsync();

		var objectResponse = JsonSerializer.Deserialize<Person>(
						serializedResponse, 
						new JsonSerializerOptions()
						{
							PropertyNameCaseInsensitive = true
						}
		);

		if (serializedResponse.Length <= 0 || objectResponse?.Id <= 0)
		{
				return new PersonResponse()
				{ 
					ResponseCode = response.StatusCode,	
					ResponseMessage = Id < 0 ? "ERROR: Person Id missing": $"Person Id [{Id}] not found",
					Person = null
				};
		};

		//////////////////////////////////////////////////////////////////////////
		// 		If we get here, there was data to serialize

		return new PersonResponse()
		{ 
				ResponseCode = response.StatusCode,	
				ResponseMessage = "Record Deleted",
				Person = objectResponse
		};
	}
}
