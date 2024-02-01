using CheckMate.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate.Data
{
    // DatabaseContext class provides methods to interact with SQLite database
    public class DatabaseContext : IAsyncDisposable
    {
        // Database name constant
        private const string DbName = "MyDatabase.db3";

        // Specifies for different platforms the File System path
        public static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);

        // Gets the full path of the database
        string fullPath = DbPath;

        // SQLiteAsyncConnection instance for database operations
        private SQLiteAsyncConnection _connection;

        // *Property* to get the database connection, creates if not exists
        private SQLiteAsyncConnection _Database => (_connection ??= new SQLiteAsyncConnection(DbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache));



        // Create table if it doesn't exist for a specified type (TTable is a generic type parameter for the method
        private async Task CreatTableIfNonexistent<TTable>() where TTable : class, new()
        {
            await _Database.CreateTableAsync<TTable>();
        }

        // Get a table asynchronously for a specified type
        private async Task<AsyncTableQuery<TTable>> GetTableAsync<TTable>() where TTable: class, new()
        {
            await CreatTableIfNonexistent<TTable>();
            return _Database.Table<TTable>();
        }

        // Get all tasks of a specified type from the table
        public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.ToListAsync();
        }

        // Get filtered tasks of a specified type based on a predicate
        public async Task<IEnumerable<TTable>> GetFilteredAsync<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.Where(predicate).ToListAsync();
        }

        // Get a task of a specified type by its primary key
        public async Task<TTable> GetTaskByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
        {
            await CreatTableIfNonexistent<TTable>();
            return await _Database.GetAsync<TTable>(primaryKey);
        }

        // Add a task of a specified type to the table
        public async Task<bool> AddTaskAsync<TTable>(TTable task) where TTable : class, new()
        {
            await CreatTableIfNonexistent<TTable>();
            return await _Database.InsertAsync(task) > 0;
        }

        // Update a task of a specified type in the table
        public async Task<bool> UpdateTaskAsync<TTable>(TTable task) where TTable : class, new()
        {
            await CreatTableIfNonexistent<TTable>();
            return await _Database.UpdateAsync(task) > 0;
        }

        // Delete a task of a specified type from the table
        public async Task<bool> DeleteTaskAsync<TTable>(TTable task) where TTable : class, new()
        {
            await CreatTableIfNonexistent<TTable>();
            return await _Database.DeleteAsync(task) > 0;
        }

        // Delete a task of a specified type from the table by its primary key
        public async Task<bool> DeleteTaskByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
        {
            await CreatTableIfNonexistent<TTable>();
            return await _Database.DeleteAsync<TTable>(primaryKey) > 0;
        }

        // DisposeAsync method to close the database connection
        public async ValueTask DisposeAsync()
        {
            await _connection?.CloseAsync();
        }
    }
}
