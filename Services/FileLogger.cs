namespace BooksApi.Services
{
    public class FileLogger : ILogger {

        //log directory and file path
        string logDirectory;
        string logPath;

        public FileLogger() {
            logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            if(!Directory.Exists(logDirectory)) 
                    Directory.CreateDirectory(logDirectory);

            logPath = Path.Combine(logDirectory, $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
            
         }

        public void Info(String source) {
            File.AppendAllText(logPath, $"{DateTime.Now:yyyyMMdd_HHmmss} Info: {source} \n");
        }

        public void Error(String source) {
            File.AppendAllText(logPath, $"{DateTime.Now:yyyyMMdd_HHmmss} Error: {source} \n");
        }
    }
}