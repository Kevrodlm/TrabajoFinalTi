using System.Reflection.Metadata;
using System.Data;
using System.Data.SqlClient;

namespace conchatgpt.repositorio
{
    public class DB : IDB
    {
        private string _conectionString;//NO OLVIDA PONER EN LA CONFIG
        public DB()
        {
            //_conectionString = " user id = pagina_Web_SQLLogin_1; pwd=abor9yw6ol;data source = nueva_base.mssql.somee.com;initial catalog = nueva_base";
            _conectionString = @"Data Source= DESKTOP-TB72TPH\SQLEXPRESS01; Initial Catalog=nueva_base; Trusted_Connection=True ";
        }

        public DataTable Get(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_conectionString))
            {
                //AHORA SI ULTILIZARA LA CONECCION, TOMA ESO XDFXDXDXDX

                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();  //la consulta

                using(SqlDataReader reader = command.ExecuteReader())
                {//con este leemos 
                    dt.Load(reader);

                }
            }
            return dt;
        }
    }
}
