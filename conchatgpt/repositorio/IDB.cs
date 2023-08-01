using System.Data;

namespace conchatgpt.repositorio
{
    public interface IDB
    {
        public DataTable Get(string sql);
    }
}
