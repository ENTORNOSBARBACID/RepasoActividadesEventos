using Microsoft.Data.SqlClient;
using RepasoActividadesEventos.Models;
using System.Data;

namespace RepasoActividadesEventos.Repositories
{
    public class RepositoryAlumnos
    {
        private DataTable tablaUsuarios;
        private SqlConnection cn;
        private SqlCommand com;
        public RepositoryAlumnos()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITALES;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            string sql = "select * from USUARIOSTAJAMAR";
            SqlDataAdapter ad =
            new SqlDataAdapter(sql, this.cn);
            this.tablaUsuarios = new DataTable();
            ad.Fill(this.tablaUsuarios);
        }

        public List<Usuarios> LoadUsuarios()
        {
            var consulta = from datos in this.tablaUsuarios.AsEnumerable()
                           select datos;
            List<Usuarios> usuarios = new List<Usuarios>();
            foreach (var row in consulta)
            {
                Usuarios usu = new Usuarios()
                {
                    IdUsuario = row.Field<int>("IDUSUARIO"),
                    Nombre = row.Field<string>("NOMBRE"),
                    Apellidos = row.Field<string>("APELLIDOS"),
                    Email = row.Field<string>("EMAIL"),
                    Imagen = row.Field<string>("IMAGEN"),
                    IdCurso = row.Field<int>("IDCURSO")
                };
                usuarios.Add(usu);
            }
            return usuarios;
        }
        public Usuarios FindUsuario(int id)
        {
            var consulta = from datos in this.tablaUsuarios.AsEnumerable()
                           where datos.Field<int>("IDUSUARIO") == id
                           select datos;


            if (consulta.Count() == 0)
                return null;

            var row = consulta.First();
            Usuarios usu = new Usuarios
            {
                IdUsuario = row.Field<int>("IDUSUARIO"),
                Nombre = row.Field<string>("NOMBRE"),
                Apellidos = row.Field<string>("APELLIDOS"),
                Email = row.Field<string>("EMAIL"),
                Imagen = row.Field<string>("IMAGEN"),
                IdCurso = row.Field<int>("IDCURSO")
            };

            return usu;
        }
    }
}
