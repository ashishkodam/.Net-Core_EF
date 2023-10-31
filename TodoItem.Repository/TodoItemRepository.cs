using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TodoItem.Repository;
using TodoItem.Shared.Model;

namespace TodoItem.Repository
{
    using TodoItem.Shared.Model;

    public class TodoItemRepository : ITodoItemRepository
    {

        private readonly string _connectionString;

        public TodoItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TodoItem Create(TodoItem todoItem)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            var sql = "INSERT INTO \"TodoItems\" (\"Name\", \"IsComplete\") VALUES (@Name, @IsComplete) RETURNING \"Id\"";
            var id = dbConnection.ExecuteScalar<int>(sql, todoItem);

            todoItem.Id = id;
            return todoItem;
        }

        public TodoItem Get(int id)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            var sql = "SELECT * FROM \"TodoItems\" WHERE \"Id\" = @Id";
            return dbConnection.QuerySingleOrDefault<TodoItem>(sql, new { Id = id });
        }

        public async Task<List<TodoItem>> GetAll()
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            var sql = "SELECT * FROM \"TodoItems\"";
            return (await dbConnection.QueryAsync<TodoItem>(sql)).AsList();
        }

        public TodoItem Update(TodoItem todoItem)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            var sql = "UPDATE \"TodoItems\" SET \"Name\" = @Name, \"IsComplete\" = @IsComplete WHERE \"Id\" = @Id";
            dbConnection.Execute(sql, todoItem);
            return todoItem;
        }

        public bool Delete(int id)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(_connectionString);
            dbConnection.Open();

            var sql = "DELETE FROM \"TodoItems\" WHERE \"Id\" = @Id";
            return dbConnection.Execute(sql, new { Id = id }) > 0;
        }
    }
}