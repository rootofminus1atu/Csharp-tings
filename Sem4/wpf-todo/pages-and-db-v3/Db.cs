using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pages_and_db_v3
{
    public class TodoItemFromDb
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class Db : DbContext
    {
        public DbSet<TodoItemFromDb> TodoItemsFromDb { get; set; }

        public Db() : base() { }
        // connect with `Db db = new Db();` in main
    }
}
