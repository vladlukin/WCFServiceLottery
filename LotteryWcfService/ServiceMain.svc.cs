using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceLibrary;

namespace LotteryWcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    [AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiceMain : IServiceMain, IDisposable
    {
        private SqlConnection _connection;

        public ServiceMain()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lotteryDBConnectionString"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public string GetNameById(int id)
        {
            string name = "";
            string query = "select nameParticipant from ParticipantList where idParticipant = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.Add(new SqlParameter()
            {
                DbType = DbType.Int32,
                Value = id,
                ParameterName = "id"
            });
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                name = reader.GetString(0);
            }
            return name;

        }

        public List<string> GetCustomers()
        {
           /* List<Participant> participants = new List<Participant>();
              string query = "select idParticipant, nameParticipant from ParticipantList where isWinner = 0";
              SqlCommand command = new SqlCommand(query, _connection);
              SqlDataReader reader = command.ExecuteReader();
              participants = new List<Participant>();
              while (reader.Read())
              {
                  participants.Add(new Participant()
                  {
                      idParticipant = reader.GetInt32(0),
                      nameParticipant = reader.GetString(1),
                      isWinner = 0
                  });
              }*/

            List<string> names = new List<string>();
            string query = "select idParticipant, nameParticipant from ParticipantList where isWinner = 0";
            SqlCommand command = new SqlCommand(query, _connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // string row = String.Concat("<li id=\"", Convert.ToString(reader.GetInt32(0)), "\">", reader.GetString(1), "</li>");
                    string row = String.Concat("<label><input type = \"checkbox\" id=\"", Convert.ToString(reader.GetInt32(0)), "\"/>", Convert.ToString(reader.GetString(1)), "</label><br>");

                    names.Add(row);

                }
                reader.Close();
                reader = null;
                command = null;
            }
            catch (SqlException e)
            {
                throw;
            }
                   
            return names;
        }

        public void MakeWinner(int id)
        {
            string query = "update ParticipantList set isWinner = 1 where idParticipant = @id";
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.Add(new SqlParameter()
            {
                DbType = DbType.Int32,
                Value = id,
                ParameterName = "id"
            });
            try
            {
                command.ExecuteNonQuery();
                command.Transaction.Commit();

            }
            catch(SqlException e)
            {
                throw;
            }
        }

        public void MakeWinners(List<int> winners)
        {
            foreach (int idWinner in winners)
            {
                MakeWinner(idWinner);
            }
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
