using Microsoft.Data.SqlClient;
using RepasoActividadesEventos.Models;
using System.Data;

namespace RepasoActividadesEventos.Repositories
{
    public class RepositoryInscripciones
    {
        private DataTable tablaInscripciones;
        private SqlConnection cn;
        private SqlCommand com;
        public RepositoryInscripciones()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITALES;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            string sql = "select * from Inscripciones";
            SqlDataAdapter ad =
            new SqlDataAdapter(sql, this.cn);
            this.tablaInscripciones = new DataTable();
            ad.Fill(this.tablaInscripciones);
        }

        public List<Inscripciones> GetInscripcionesUsuario(int id)
        {
            var consulta = from datos in this.tablaInscripciones.AsEnumerable()
                           where datos.Field<int>("Id_Usuario") == id
                           select datos;


            if (consulta.Count() == 0)
                return null;
            List<Inscripciones> ins = new List<Inscripciones>();
            foreach (var row in consulta)
            {
                Inscripciones i = new Inscripciones
                {
                    IdInscripcion = row.Field<int>("Id_Inscripcion"),
                    IdUsuario = row.Field<int>("Id_Usuario"),
                    IdEventoActividad = row.Field<int>("IdEventoActividad"),
                    QuiereSerCapitan = row.Field<bool>("Quiere_Ser_Capitan"),
                    FechaInscripcion = row.Field<DateTime>("Fecha_Inscripcion")

                };
                ins.Add(i);
            }
            ;
            return ins;
        }
    }
}
