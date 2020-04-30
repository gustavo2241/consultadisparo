using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaDisparos.Models
{
    public class DisparosErroSemProcessoFlgDisparadoZeroContext
    {
        public string ConnectionString { get; set; }

        public DisparosErroSemProcessoFlgDisparadoZeroContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<DisparosErroSemProcessoFlgDisparadoZeroModel> GetAllErroProcessoFlgDisparadoZerado()
        {
            List<DisparosErroSemProcessoFlgDisparadoZeroModel> list = new List<DisparosErroSemProcessoFlgDisparadoZeroModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select iddisparo,flgdisparado,flgenfileirado,txtnome,datAgendamento,datExpiracao,Nomebase FROM vw_consultadisparosemprocessoflgdisparadozerado vw WHERE NOT EXISTS(SELECT iddisparo FROM tb_ignorar ig  WHERE ig.iddisparo = vw.iddisparo AND ig.nomebase = vw.nomebase)", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DisparosErroSemProcessoFlgDisparadoZeroModel()
                        {
                            idDisparo = reader["iddisparo"].ToString(),
                            flgDisparado = reader["flgdisparado"].ToString(),
                            flgEnfileirado = reader["flgenfileirado"].ToString(),
                            txtNome = reader["txtnome"].ToString(),
                            dataAgendamento = reader["datAgendamento"].ToString(),
                            dataExpiracao = reader["datExpiracao"].ToString(),
                            nomeBase = reader["Nomebase"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}

