JSONParser is an MVC application which takes in a .json file of a specific structure and returns the sum of labeled Items' IDs, i.e., if the item has a label member, its ID member is summed among its siblings.

For example, a .json file with the following contents would return 46, 0, 248:

	[
	 {
		"menu":{
		   "header":"menu",
		   "items":[
			  {
				 "id":27
			  },
			  {
				 "id":0,
				 "label":"Label 0"
			  },
			  null,
			  {
				 "id":93
			  },
			  {
				 "id":85
			  },
			  {
				 "id":54
			  },
			  null,
			  {
				 "id":46,
				 "label":"Label 46"
			  }
		   ]
		}
	 },
	 {
		"menu":{
		   "header":"menu",
		   "items":[
			  {
				 "id":81
			  }
		   ]
		}
	 },
	 {
		"menu":{
		   "header":"menu",
		   "items":[
			  {
				 "id":70,
				 "label":"Label 70"
			  },
			  {
				 "id":85,
				 "label":"Label 85"
			  },
			  {
				 "id":93,
				 "label":"Label 93"
			  },
			  {
				 "id":2
			  }
		   ]
		}
	 }
	]

The application leverages the JsonConvert method DeserializeObject from the Newtonsoft.Json namespace in order to convert the JSON string into its POCO counterpart.

The Plain Old CLR Object structure is:

	public class container
	{
		public menu menu { get; set; }
		public int sum { get; set; }
	}

	public class menu
	{
		public string header { get; set; }
		public List<item> items { get; set; }
	}

	public class item
	{
		public int id { get; set; }
		public string label { get; set; }
	}

The business logic is in the JPService class in the JSONParser.Data project. The SumLabeledIds method takes a container class, strips the null items, then sets the sum property to the sum of the labeled items' IDs.

The Results.cshtml displays the index, name, and result of the sum in a table.

There are unit tests on each of the controller actions. 

***The Test project's App.config has a "FilePath" application setting used to specify an example.json file for the test to run. Please update this setting appropriately for your environment.***