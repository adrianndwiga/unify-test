using System;
using Petstore.Data;

namespace Petstore.Core
{
    public class RealWriter : IWriter
    {
        public void Write(Pet pet)
        {
            if (pet.Category != null){
                Console.WriteLine($"category ${pet.Category.Name}, pets name ${pet.Name}, status ${pet.Status}");
            }
        }
    }
}