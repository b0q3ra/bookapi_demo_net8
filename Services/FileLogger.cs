namespace BooksApi.Services
{
    public class FileLogger : ILogger {
        string logDirectory;
        string logPath;

        public FileLogger() {
            logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            if(!Directory.Exists(logDirectory)) 
                    Directory.CreateDirectory(logDirectory);

            logPath = Path.Combine(logDirectory, $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
            
         }

        public void Info(String source) {
            File.WriteAllText(logPath, $"{DateTime.Now:yyyyMMdd_HHmmss} Info: {source}");
        }

        public void Error(String source) {
            File.WriteAllText(logPath, $"{DateTime.Now:yyyyMMdd_HHmmss} Error: {source}");
        }
    }
}