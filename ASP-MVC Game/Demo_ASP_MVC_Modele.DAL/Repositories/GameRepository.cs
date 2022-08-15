using Demo_ASP_MVC_Modele.DAL.Entities;
using Demo_ASP_MVC_Modele.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.DAL.Repositories
{
    public class GameRepository : RepositoryBase<int, GameEntity>, IGameRepository
    {
        public GameRepository(IDbConnection connection)
            : base(connection, "Game", "Id") // crée le construsteur de la classe parent
        { }

        protected override GameEntity Convert(IDataRecord record)
        {
            return new GameEntity
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                Description = record["Description"] is DBNull ? null :  (string)record["Description"],
                IsCoop = (bool)record["Coop"],
                NbPlayerMin = (int)record["Nb_player_min"],
                NbPlayerMax = (int)record["Nb_player_max"],
                Age = record["Age"] is DBNull ? null : (int)record["Age"]
            };
        }

        #region CRUD
        public override int Insert(GameEntity entity)
        {
            // Créer la commande
            IDbCommand cmd = _Connection.CreateCommand();

            // On défini la requete SQL
            cmd.CommandText = "INSERT INTO Game([Name], [Description], [Nb_Player_Min], [Nb_Player_Max], [Age], [Coop])" +
                " OUTPUT inserted.[Id]" +
                " VALUES (@Name, @Desc, @NbPlayerMin, @NbPlayerMax, @Age, @Coop)";

            // On ajoute les parametres SQL
            AddParameter(cmd, "@Name", entity.Name);
            AddParameter(cmd, "@Desc", entity.Description);
            AddParameter(cmd, "@NbPlayerMin", entity.NbPlayerMin);
            AddParameter(cmd, "@NbPlayerMax", entity.NbPlayerMax);
            AddParameter(cmd, "@Age", entity.Age);
            AddParameter(cmd, "@Coop", entity.IsCoop);

            _Connection.Open();
            int id = (int)cmd.ExecuteScalar();
            _Connection.Close();

            return id;
        }

        public override bool Update(GameEntity entity)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
               
                cmd.CommandText = "UPDATE Game SET Name = @Name, " +
                    "Description = @Desc, " +
                    "Nb_player_min = @NbPlayerMin, " +
                    "Nb_player_max = @NbPlayerMax, " +
                    "Age = @Age, " +
                    "Coop = @Coop " +
                    "WHERE Id = @id";

                AddParameter(cmd, "@id", entity.Id);
                AddParameter(cmd, "@Name", entity.Name);
                AddParameter(cmd, "@Desc", entity.Description);
                AddParameter(cmd, "@NbPlayerMin", entity.NbPlayerMin);
                AddParameter(cmd, "@NbPlayerMax", entity.NbPlayerMax);
                AddParameter(cmd, "@Age", entity.Age);
                AddParameter(cmd, "@Coop", entity.IsCoop);

                _Connection.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        // Méthodes pour la gestion des favoris (avoir le profil et les favoris de l'utilisateur)
        public IEnumerable<GameEntity> GetByMemberId(int id)
        {
            using (IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT G.* FROM Game G JOIN Favorite F ON F.IdGame = G.Id WHERE F.IdMember = @Id";

                AddParameter(cmd, "@Id", id);

                ConnectionOpen();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return Convert(reader); // retourne les informations en ajoutant automatiquement dans la liste
                    }
                }
            }
        }

        public bool AddFavoriteGame(int memberId, int gameId)
        {
            using(IDbCommand cmd = _Connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Favorite (IdMember, IdGame) VALUES (@mid, @gid)";

                AddParameter(cmd, "@mid", memberId);
                AddParameter(cmd, "@gid", gameId);

                ConnectionOpen();

                return cmd.ExecuteNonQuery() == 1;
            }
        }
        #endregion
    }
}
