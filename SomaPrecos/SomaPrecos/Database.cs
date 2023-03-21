using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
//using SQLite.Net;

namespace SomaPrecos
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Produto>().Wait();
        }

        public Task<List<Produto>> GetProdutosAsync()
        {
            //Get all Produtos.
            return database.Table<Produto>().ToListAsync();
        }

        public Task<Produto> GetProdutoAsync(int id)
        {
            // Get a specific Produto.
            return database.Table<Produto>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveProdutoAsync(Produto Produto)
        {
            if (Produto.Id != 0)
            {
                // Update an existing Produto.
                return database.UpdateAsync(Produto);
            }
            else
            {
                // Save a new Produto.
                return database.InsertAsync(Produto);
            }
        }

        public Task<int> DeleteProdutoAsync(Produto Produto)
        {
            // Delete a Produto.
            return database.DeleteAsync(Produto);
        }

        public Task<int> Count()
        {
            return database.Table<Produto>().CountAsync();
        }

    }

}

