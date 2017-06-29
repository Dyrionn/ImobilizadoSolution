using ImobilizadoSolution.Infra;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ImobilizadoSolution.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        protected MongoClient _conexao;
        protected IMongoDatabase _bancoDados;
        protected string _nomeTabela;

        public BaseRepository(string nomeTabela)
        {
            _conexao = new MongoClient(MongoDbInfra.ConnectionString());
            _bancoDados = _conexao.GetDatabase(MongoDbInfra.NomeBanco);
            _nomeTabela = nomeTabela;
        }

        internal BaseRepository() { }

        public void Adicionar(T entity)
        {
            _bancoDados.GetCollection<T>(_nomeTabela).InsertOne(entity);
        }

        public void Atualizar(T entity, ObjectId value)
        {
            var filter = Builders<T>
                .Filter.Eq("_id", value);

            var results = _bancoDados.GetCollection<T>(_nomeTabela)
                .Find(filter).ToList();

            _bancoDados.GetCollection<T>(_nomeTabela)
                .ReplaceOne(filter, entity);

        }

        public void Deletar(ObjectId value)
        {
            var filter = Builders<T>
                .Filter.Eq("_id", value);

            var results = _bancoDados.GetCollection<T>(_nomeTabela)
                .DeleteOne(filter);
        }

        public async Task<List<T>> Listar()
        {
            var list = await _bancoDados.GetCollection<T>(_nomeTabela)
                .Find(_ => true)
                .ToListAsync();

            return list;
        }


        public async Task<T> ListarPorCodigo(ObjectId codigo)
        {
            var filter = Builders<T>
                .Filter.Eq("_id", codigo);

            var list = await _bancoDados.GetCollection<T>(_nomeTabela)
                .Find(filter)
                .ToListAsync();

            return list.FirstOrDefault();
        }
    }
}
