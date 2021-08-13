using Petstore.Data;

namespace Petstore.Core
{
    public interface IWriter {
        void Write(Pet pet);
    }
}