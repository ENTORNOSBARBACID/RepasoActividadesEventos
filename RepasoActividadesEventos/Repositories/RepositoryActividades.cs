using Microsoft.Data.SqlClient;
using RepasoActividadesEventos.Models;
using System.Data;

namespace RepasoActividadesEventos.Repositories
{
    public class RepositoryActividades
    {
        private DataTable tablaActividades;
        private SqlConnection cn;
        private SqlCommand com;
        public RepositoryActividades()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITALES;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            string sql = "select * from Actividades";
            SqlDataAdapter ad =
            new SqlDataAdapter(sql, this.cn);
            this.tablaActividades = new DataTable();
            ad.Fill(this.tablaActividades);
        }

        public List<Actividades> GetActividades()
        {
            var consulta = from datos in this.tablaActividades.AsEnumerable()
                           select datos;


            if (consulta.Count() == 0)
                return null;
            List<Actividades> actividades = new List<Actividades>();
            foreach (var row in consulta)
            {
                Actividades a = new Actividades
                {
                    idActividad = row.Field<int>("id_Actividad"),
                    Nombre = row.Field<string>("Nombre"),
                    jugadores_min = row.Field<int>("jugadores_min")
                };
                actividades.Add(a);
            }
            return actividades;

        }
    }
    
}
