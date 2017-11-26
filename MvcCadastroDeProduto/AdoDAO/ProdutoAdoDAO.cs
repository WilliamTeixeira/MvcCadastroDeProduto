using MvcCadastroDeProduto.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcCadastroDeProduto.AdoDAO
{
    public class ProdutoAdoDAO : BaseDAO
    {
        public void Inserir(Produto obj)
        {
            string sql = "INSERT INTO produto (codigo, descricao, preco) VALUES (@codigo, @descricao, @preco);";

            MySqlCommand cmd = new MySqlCommand(sql);

            cmd.Parameters.Add(new MySqlParameter("@codigo", obj.Codigo));
            cmd.Parameters.Add(new MySqlParameter("@descricao", obj.Descricao));
            cmd.Parameters.Add(new MySqlParameter("@preco", obj.Preco));

            ExecutarComando(cmd);
        }

        public void Alterar(Produto obj)
        {
            string sql = "UPDATE produto SET codigo = @codigo, descricao = @descricao, preco = @preco WHERE id = @id;";

            MySqlCommand cmd = new MySqlCommand(sql);
            cmd.Parameters.Add(new MySqlParameter("@id", obj.Id));
            cmd.Parameters.Add(new MySqlParameter("@codigo", obj.Codigo));
            cmd.Parameters.Add(new MySqlParameter("@descricao", obj.Descricao));
            cmd.Parameters.Add(new MySqlParameter("@preco", obj.Preco));

            ExecutarComando(cmd);
        }

        public void Excluir(Produto obj)
        {
            string sql = "DELETE FROM produto WHERE id = @id;";

            MySqlCommand cmd = new MySqlCommand(sql);

            cmd.Parameters.Add(new MySqlParameter("@id", obj.Id));

            ExecutarComando(cmd);
        }

        public Produto RetornarPorId(int id)
        {
            string sql = "SELECT * FROM produto WHERE id = @id;";

            MySqlCommand cmd = new MySqlCommand(sql);

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            DataSet ds = RetornarDataSet(cmd);

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return RetornarObj(ds.Tables[0].Rows[0]);
        }

        public List<Produto> RetornarTodos()
        {
            List<Produto> objs = new List<Produto>();

            string sql = "SELECT * FROM produto ORDER BY descricao;";

            MySqlCommand cmd = new MySqlCommand(sql);
            
            DataSet ds = RetornarDataSet(cmd);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                foreach (DataRow reg in ds.Tables[0].Rows)
                    objs.Add(RetornarObj(reg));

            return objs;
        }

        private Produto RetornarObj(DataRow reg)
        {
            Produto obj = new Produto();

            obj.Id = Convert.ToInt32(reg["id"]);
            obj.Codigo = Convert.ToInt32(reg["codigo"]);
            obj.Descricao = reg["descricao"].ToString();
            obj.Preco = Convert.ToDouble(reg["preco"]);

            return obj;
        }

    }
}