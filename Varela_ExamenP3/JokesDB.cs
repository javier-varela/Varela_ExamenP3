using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varela_ExamenP3.Models;

namespace Varela_ExamenP3
{
    public class JokesDB
    {
        SQLiteAsyncConnection Database;


        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(JVConstants.DatabasePath, JVConstants.Flags);
            _ = await Database.CreateTableAsync<Joke>();
        }

        public async Task<int> SaveItemAsync(Joke item)
        {
            await Init();
            if ((await Database.Table<Joke>().FirstOrDefaultAsync(j => j.id == item.id))!=null)
            {
                return await Database.UpdateAsync(item);
            }
            
            return await Database.InsertAsync(item);
        }

        public async Task<List<Joke>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Joke>().ToListAsync();
        }



    }
}
