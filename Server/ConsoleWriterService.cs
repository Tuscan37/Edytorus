using MCSkinEditor.Shared;

namespace MCSkinEditor.Server
{
    public class ConsoleWriterService : IConsoleWriterService
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
