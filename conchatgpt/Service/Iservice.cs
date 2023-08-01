namespace conchatgpt.Service
{
    public interface Iservice
    {
        public Task<string> Get(string prompt);
    }
}
