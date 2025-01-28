namespace BooksApi.Services
{
    public interface ILogger
    {
        void Info(String source);
        void Error(String source);
    }
}