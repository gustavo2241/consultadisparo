using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaDisparos.Models
{
    public class DisparosErroSemAssociacaoFlgDisparadoZeroContext
    {
        public string ConnectionString { get; set; }

        public DisparosErroSemAssociacaoFlgDisparadoZeroContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<DisparosErroSemAssociacaoFlgDisparadoZeroModel> GetAllErroAssociacaoFlgDisparadoZerado()
        {
            List<DisparosErroSemAssociacaoFlgDisparadoZeroModel> list = new List<DisparosErroSemAssociacaoFlgDisparadoZeroModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select iddisparo,flgdisparado,flgenfileirado,txtnome,datAgendamento,datExpiracao,Nomebase FROM vw_consultadisparosemassociacaoflgdisparadozerado vw WHERE NOT EXISTS(SELECT iddisparo FROM tb_ignorar ig  WHERE ig.iddisparo = vw.iddisparo AND ig.nomebase = vw.nomebase)", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DisparosErroSemAssociacaoFlgDisparadoZeroModel()
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

