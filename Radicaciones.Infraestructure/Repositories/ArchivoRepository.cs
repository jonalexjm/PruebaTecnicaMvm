using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;
using Radicaciones.Core.ViewModel;

namespace Radicaciones.Infraestructure.Repositories
{
    public class ArchivoRepository : BaseRepository<Archivo>, IArchivoRepository
    {
         private readonly RadicacionesContext context;
        
         private readonly string _connectionString;
         public ArchivoRepository(RadicacionesContext context
                                  , IConfiguration configuration) : base(context) 
         {
             _connectionString = configuration.GetConnectionString("SqlServerConnection");
        
         }
        public async Task RadicarDocumento(RadicadoViewModel radicadoViewModel)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("RADICACIONES_PRO_APP_INSERTAR_RADICACIONES", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Usuario_Auditoria", "System"));
                    cmd.Parameters.Add(new SqlParameter("@Usuario_Remitente", radicadoViewModel.UsuarioIdRemitente));
                    cmd.Parameters.Add(new SqlParameter("@Usuario_Destinatario", radicadoViewModel.UsuarioIdDestinatario));
                    cmd.Parameters.Add(new SqlParameter("@Tipo_Archivo", radicadoViewModel.TipoArchivoId));
                    cmd.Parameters.Add(new SqlParameter("@Observaciones", radicadoViewModel.Observaciones));
                    cmd.Parameters.Add(new SqlParameter("@Url_Archivo", radicadoViewModel.UrlArchivo));                    
                    cmd.Parameters.Add(new SqlParameter("@Codigo_Respuesta", ParameterDirection.Output));
                    cmd.Parameters.Add(new SqlParameter("@Id_Generado ", ParameterDirection.Output));
                    cmd.Parameters.Add(new SqlParameter("@Mensaje ",  ParameterDirection.Output));

                    try
                    {
                        await sql.OpenAsync();
                        var result = await cmd.ExecuteNonQueryAsync();
                        return;

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    
                }
            }
        }

    }
}
