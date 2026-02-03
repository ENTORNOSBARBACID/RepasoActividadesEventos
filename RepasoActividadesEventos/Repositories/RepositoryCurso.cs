using Microsoft.Data.SqlClient;
using RepasoActividadesEventos.Models;
using System.Data;

namespace RepasoActividadesEventos.Repositories
{
    public class RepositoryCurso
    {
        private DataTable tablaCurso;
        private SqlConnection cn;
        private SqlCommand com;
        public RepositoryCurso()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITALES;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            string sql = "select * from Cursostajamar";
            SqlDataAdapter ad =
            new SqlDataAdapter(sql, this.cn);
            this.tablaCurso = new DataTable();
            ad.Fill(this.tablaCurso);
        }

        public Curso GetCursos(int idCurso)
        {
            var consulta = from datos in this.tablaCurso.AsEnumerable()
                           where datos.Field<int>("IDCURSO") == idCurso
                           select datos;
            if (consulta.Count() == 0)
                return null;
            var row = consulta.First();
            Curso c = new Curso
            {
                IdCurso = row.Field<int>("IDCURSO"),
                Nombre = row.Field<string>("NOMBRE"),
                FechaInicio = row.Field<DateTime>("FECHAINICIO"),
                FechaFin = row.Field<DateTime>("FECHAFIN"),
                Activo = row.Field<bool>("ACTIVO")
            };
            return c;
        }
    }
}
