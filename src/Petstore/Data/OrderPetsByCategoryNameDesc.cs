using System.Collections.Generic;
using System.Linq;

namespace Petstore.Data
{
    public class OrderPetsByCategoryNameDesc : IOrderPetsByCategoryName
    {
        private string SortByName(Pet pet) {
            if (pet.Category == null) {
                return "Unknown";
            }
            return pet.Category.Name;
        }
        public IList<Pet> OrderByCategoryName(IList<Pet> pets)
        {
            return pets.OrderByDescending(SortByName).ToList();
        }
    }
}