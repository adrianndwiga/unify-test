using System.Collections.Generic;

namespace Petstore.Data
{
    public class Pet
    {
        public long Id { get; set; }
        public Category Category { get; set; }

        public string Name { get; set; }
        public IList<string> PhotoUrls { get; set; }
        public IList<Tag> Tags { get; set; }
        public string Status { get; set; }
    }
}