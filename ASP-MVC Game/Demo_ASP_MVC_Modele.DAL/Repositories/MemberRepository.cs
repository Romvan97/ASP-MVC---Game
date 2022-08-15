using Demo_ASP_MVC_Modele.DAL.Entities;
using Demo_ASP_MVC_Modele.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.DAL.Repositories
{
    public class MemberRepository : RepositoryBase<int, MemberEntity>, IMemberRepository
    {
        public MemberRepository(IDbConnection connection)
            : base(connection, "Member", "Id") // crée le construsteur de la classe parent
        { }
        protected override MemberEntity Convert(IDataRecord record)
        {
            return new MemberEntity
            {
                Id = (int)record["Id"],
                Pseudo = (string)record["Pseudo"],
                Email = (string)record["Email"],
                PwdHash = null
            };
        }

        public override int Insert(MemberEntity entity)
        {
            // Utilisation d'ADO.NET

            // 1 - Créer la commande
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                // 2- On défini la requete SQL
                cmd.CommandText = "INSERT INTO [Member]([Pseudo], [Email], [Pwd_Hash])" +
                    " OUTPUT inserted.[Id]" +
                    " VALUES (@Pseudo, @Email, @PwdHash)";

                // 3 - On ajoute les parametres SQL grâce à une fonction faite par nous mêmes
                AddParameter(cmd, "@Pseudo", entity.Pseudo);
                AddParameter(cmd, "@Email", entity.Email);
                AddParameter(cmd, "@PwdHash", entity.PwdHash);

                // 4 - On ouvre la connection 
                ConnectionOpen();

                // 5 - On execute la commande
                int id = (int)cmd.ExecuteScalar(); // Execute scalar sert à renvoyer une seul information
                                                    // Execute NonQuery ne renvoit rien sert juste à supprimer, modifier, ajouter
                                                    // Execute Reader renvoit tout sert à recevoir les informations

                // 6 - On ferme la commande
                _Connection.Close();
                return id;
            }

                
        }

        public override bool Update(MemberEntity entity)
        {
            throw new NotImplementedException();
        }

        public MemberEntity GetByPseudo(string pseudo)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM {TableName} WHERE pseudo = @pseudo";
                AddParameter(cmd, "@pseudo", pseudo);

                ConnectionOpen();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return Convert(reader);
                    return null;
                }
            }
        }

        public string GetHashByPseudo(string pseudo)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT Pwd_Hash FROM {TableName} WHERE pseudo = @pseudo";
                AddParameter(cmd, "@pseudo", pseudo);

                ConnectionOpen();
                object result = cmd.ExecuteScalar();
                _Connection.Close();

                return result is DBNull ? null : (string)result;
            }
        }

        public bool CheckUserExists(string email, string pseudo)
        {
            using(IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Member WHERE Email LIKE @email OR Pseudo LIKE @pseudo";

                AddParameter(cmd, "@email", email);
                AddParameter(cmd, "@pseudo", pseudo);

                ConnectionOpen();
                using(IDataReader reader = cmd.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        
    }
}
