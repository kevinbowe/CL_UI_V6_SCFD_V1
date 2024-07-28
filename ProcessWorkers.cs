using CL_UI_V6_SCFD_V1;
using System.Text;

public class ProcessWorkers
{
	public HttpClient client = new HttpClient();
	public PersonResponse? personResponse { get; set; }

	public async Task<object> ProcessWork(int option, int personId, Person inputPerson)
	{
		var strBuilder = new StringBuilder();
		string[]? propertyList = null;

		switch (option)
		{
			case 1: // Get Persons
				PersonListResponse personListResponse = await GetPersons.GetPersonsAsync(client);
				if(personListResponse.PersonList == null) break;

				foreach (Person? person in personListResponse.PersonList)
				{
					propertyList = new[] { "Id", "FirstName", "LastName", "SSN", "doB_sys", "WorkStartsAt_sys" };
					strBuilder = person.OutputProperties(propertyList, "landscape"); // Landscape by default
					Console.WriteLine($"{strBuilder}");
				}
				Console.WriteLine();
				break;

			case 2: // Get PersonById
				personResponse = await GetPersonById.GetPersonByIdAsync(client, personId);
				if (personResponse.Person is null) break;

				propertyList = new[] { "Id", "FirstName", "LastName", "SSN", "doB_sys", "WorkStartsAt_sys" };
				strBuilder = personResponse.Person.OutputProperties(propertyList, "portrait");
				Console.WriteLine($"{strBuilder}");
				break;


			case 3: // Delete PersonById
				personResponse = await DeletePersonById.DeletePersonByIdTWOAsync(client, personId);
				//
				Console.WriteLine();
				//
				if (personResponse.Person != null)
				{
					Console.WriteLine($"{PersonExt.PadLeft("Record deleted",6)}");
					Console.WriteLine();
					
					propertyList = new[] { "Id", "FirstName", "LastName", "SSN", "InsertDte_sys", "doB_sys", "WorkStartsAt_sys" };
					strBuilder = personResponse.Person.OutputProperties(propertyList, "portrait");
					Console.WriteLine($"{strBuilder}");
				}
				else 
				{
					Console.WriteLine($"{PersonExt.PadLeft($"Not Found: ID: [ {personId} ]",6)}");
					System.Console.WriteLine();
				}
				break;

			case 4: // Delete Person (Object) -- Disabled
					  // Console.WriteLine(await DeletePerson.DeletePersonAsync(client));      
				break;
			case 5: // Insert Person
				Console.WriteLine();
				personResponse = await InsertPerson.InsertPersonAsync(client, inputPerson);
				//
				if (personResponse.Person is not null)
				{
					Console.WriteLine($"{PersonExt.PadLeft("Record inserted",6)}");
					Console.WriteLine();
					//
					propertyList = new[] { "Id", "FirstName", "LastName", "SSN", "InsertDte_sys", "doB_sys", "WorkStartsAt_sys" };
					strBuilder = personResponse.Person.OutputProperties(propertyList, "portrait");
					Console.WriteLine(strBuilder);
				}
				break;

			case 6: // Update Person
				personResponse = await GetPersonById.GetPersonByIdAsync(client, personId);

				if(personResponse.Person == null) break;

				//////////////////////////////////////////////////////////////////////////
				//		Update Person Menu

				Person? personObj = Menus.UpdatePersonFieldUI(personResponse.Person);
				if (personObj == null || personObj.Id == 0) return new object();

				//////////////////////////////////////////////////////////////////////////
				Console.WriteLine(await UpdatePerson.UpdatePersonAsync(client, personObj));
				Console.WriteLine();
				//
				if (personResponse.Person is not null)
				{
					propertyList = new[] { "Id", "FirstName", "LastName", "SSN", "doB_sys", "WorkStartsAt_sys" };
					strBuilder = personResponse.Person.OutputProperties(propertyList, "portrait");
					Console.WriteLine($"{strBuilder}");
				}
				break;
			case 7: // <return> to continue
				break;
		}
		return new object();
	}
}
