using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUD___Simples
{
    public class ProdutoDAO : IDisposable, IColaboradorDAO
    {
        private SqlConnection conexao;

        public ProdutoDAO()
        {
            this.conexao = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        public void Adicionar(Colaborador c)
        {
            try
            {
                var insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Colaboradores (Nome, Sexo, DataDeNascimento, Ativo, Cargo) VALUES (@Nome, @Sexo, @DataDeNascimento, @Cargo, @Ativo)";

                var paramNome = new SqlParameter("Nome", c.Nome);
                insertCmd.Parameters.Add(paramNome);

                var paramSexo = new SqlParameter("Sexo", c.Sexo);
                insertCmd.Parameters.Add(paramSexo);

                var paramDataDeNascimento = new SqlParameter("DataDeNascimento", c.DataDeNascimento);
                insertCmd.Parameters.Add(paramDataDeNascimento);

                var paramCargo = new SqlParameter("Cargo", c.Cargo);
                insertCmd.Parameters.Add(paramCargo);


                var paramAtivo = new SqlParameter("Ativo", c.Ativo);
                insertCmd.Parameters.Add(paramAtivo);

                insertCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public void Atualizar(Colaborador c)
        {
            try
            {
                var updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Colaboradores SET Nome = @nome, Sexo = @Sexo, DataDeNascimento = @DataDeNascimento, Cargo = @Cargo, Ativo = @Ativo WHERE Id = @id";

                var paramNome = new SqlParameter("Nome", c.Nome);
                var paramSexo = new SqlParameter("Sexo", c.Sexo);
                var paramDataDeNascimento = new SqlParameter("DataDeNascimento", c.DataDeNascimento);
                var paramCargo = new SqlParameter("Cargo", c.Cargo);
                var paramAtivo = new SqlParameter("Ativo", c.Ativo);
                var paramId = new SqlParameter("id", c.Id);
                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramSexo);
                updateCmd.Parameters.Add(paramDataDeNascimento);
                updateCmd.Parameters.Add(paramCargo);
                updateCmd.Parameters.Add(paramAtivo);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public void Remover(Colaborador c)
        {
            try
            {
                var deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Colaboradores WHERE Id = @id";

                var paramId = new SqlParameter("id", c.Id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        public IList<Colaborador> Colaboradores()
        {
            var lista = new List<Colaborador>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Colaboradores";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Colaborador c = new Colaborador();
                c.Id = Convert.ToInt32(resultado["Id"]);
                c.Nome = Convert.ToString(resultado["Nome"]);
                c.Sexo = Convert.ToString(resultado["Sexo"]);
                c.DataDeNascimento = Convert.ToDateTime(resultado["DataDeNascimento"]);
                c.Cargo = Convert.ToString(resultado["Cargo"]);
                c.Ativo = Convert.ToBoolean(resultado["Ativo"]);
                lista.Add(c);
            }
            resultado.Close();

            return lista;
        }

        public IList<Colaborador> Colaborador()
        {
            throw new NotImplementedException();
        }
    }
}