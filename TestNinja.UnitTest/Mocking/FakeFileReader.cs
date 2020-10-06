using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return string.Empty;
        }
    }
}