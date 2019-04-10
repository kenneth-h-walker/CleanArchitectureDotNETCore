using System;
using System.Collections.Generic;
using System.Text;
using BookstoreIoC.Core.Entities;
using BookstoreIoC.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace BookstoreIoC.Infrastructure.Data.DapperBookstore
{
    internal class AuthorRepository : DapperRepositoryBase<Author,int>, IAuthorRepository
    {
        public AuthorRepository(string connectionString) : base(connectionString)
        {
        }

        public Author GetByName(string name)
        {
            using (IDbConnection connection = CreateConnection())
            {
                string query = "SELECT AuthorId,Name,IsActive FROM Bookstore.dbo.Author WHERE Name = @Name";
                connection.Open();
                return connection.Query<Author>(query, new { Name = name }).FirstOrDefault();
            }
        }

        public override void Add(Author entity)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                string query =
@"INSERT INTO Author (Name,IsActive)
VALUES (@Name,@IsActive)";
                connection.Execute(query,
                    new { Name = entity.Name, IsActive = entity.IsActive });
            }
        }

        public override async Task AddAsync(Author entity)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                if (entity.IsActive == null)
                {
                    string query =
@"INSERT INTO Author (Name)
VALUES (@Name)";
                    await connection.ExecuteAsync(query,
                        new { Name = entity.Name, IsActive = entity.IsActive });
                }
                else
                {
                    string query =
@"INSERT INTO Author (Name,IsActive)
VALUES (@Name,@IsActive)";
                    await connection.ExecuteAsync(query,
                        new { Name = entity.Name, IsActive = entity.IsActive });
                }
            }
        }

        public override void Delete(Author entity)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM Author WHERE AuthorId = @Id";
                connection.Execute(query, new { Id = entity.AuthorId });
            }
        }

        public override async Task DeleteAsync(Author entity)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM Author WHERE AuthorId = @Id";
                await connection.ExecuteAsync(query, new { Id = entity.AuthorId });
            }
        }

        public override Author GetById(int id)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                string query = "SELECT AuthorId,Name,IsActive FROM Bookstore.dbo.Author WHERE AuthorId = @Id";
                return connection.Query<Author>(query, new { Id = id }).FirstOrDefault();
            }
        }

        public override async Task<Author> GetByIdAsync(int id)
        {
            using (IDbConnection connection = CreateConnection())
            {
                string query = "SELECT AuthorId,Name,IsActive FROM Bookstore.dbo.Author WHERE AuthorId = @Id";
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<Author>(query, new { Id = id });
            }
        }

        public override IEnumerable<Author> ListAll()
        {
            throw new NotImplementedException();
        }

        public override async Task<List<Author>> ListAllAsync()
        {
            string query = "SELECT AuthorId,Name,IsActive FROM Author";
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                IEnumerable<Author> allAuthors;
                allAuthors = await connection.QueryAsync<Author>(query);
                return allAuthors.ToList();
            }
        }

        public override void Update(Author entity)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                string query =
@"UPDATE Author
SET Name=@Name,IsActive=@IsActive
WHERE AuthorId=@Id";
                connection.Execute(query,
                    new { Id = entity.AuthorId, Name = entity.Name, IsActive = entity.IsActive });
            }
        }

        public override async Task UpdateAsync(Author entity)
        {
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();
                string query =
@"UPDATE Author
SET Name=@Name,IsActive=@IsActive
WHERE AuthorId=@Id";
                await connection.ExecuteAsync(query,
                    new { Id=entity.AuthorId, Name = entity.Name, IsActive = entity.IsActive });
            }
        }

    }
}
