using System.Collections.Generic;

namespace Petstore.Data
{
    public interface IOrderPetsByCategoryName {
        IList<Pet> OrderByCategoryName(IList<Pet> pets);
    }
}