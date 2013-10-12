using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Corespring.Resources
{
	[DataContract]
	public class Organization
	{
		[DataMember(Name = "id")]
		public string id { get; set; }

		[DataMember(Name = "name")]
		public string name { get; set; }

		[DataMember(Name = "path")]
		public ICollection<string> path;

		[DataMember(Name = "isRoot")]
		public bool root { get; set; }

		public Organization(string id, string name, ICollection<string> path, bool root)
		{
			this.id = id;
			this.name = name;
			this.path = path;
			this.root = root;
		}
	}
}

