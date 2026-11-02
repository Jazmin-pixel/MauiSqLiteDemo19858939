using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiSqLiteDemo19858939
{
    public class localservidor
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public localservidor()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));

            //le indica al sistema que crea la tabla de nuestro cliente
            _connection.CreateTableAsync<Cliente>();
        }

        //Metodo para listar los registros de nuestra tabla
        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _connection.Table<Cliente>().ToListAsync();
        }

        //metodo para listar los registros por id
        public async Task<Cliente> GetById(int id)
        {
            return await _connection.Table<Cliente>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //metodo para crear un registro 
        public async Task Create(Cliente cliente)
        {
            await _connection.InsertAsync(cliente);
        }

        //metodo para actualizar 
        public async Task Update(Cliente cliente)
        {
            await _connection.UpdateAsync(cliente);
        }

        //metodo para eliminar
        public async Task Delete(Cliente cliente)
        {
            await _connection.DeleteAsync(cliente);
        }
    }
}
