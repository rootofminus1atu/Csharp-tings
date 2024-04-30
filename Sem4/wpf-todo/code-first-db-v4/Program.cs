using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_first_db_v4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Db db = new Db();

            using (db)
            {
                Player p1 = new Player() { Name = "joe", Position = "Presi" };

                Team t1 = new Team() { Name = "humans" };
                t1.Players.Add(p1);

                db.Teams.Add(t1);

                db.SaveChanges();
            }
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Player> Players { get; set; } = new List<Player>();
    }

    public class Db : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public Db() : base() { }
    }

}
