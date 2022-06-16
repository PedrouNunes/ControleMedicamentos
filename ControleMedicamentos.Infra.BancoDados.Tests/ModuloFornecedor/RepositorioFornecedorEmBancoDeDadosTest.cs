using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Infra.BancoDados.Tests.ModuloFornecedor
{
    [TestClass]
    public class RepositorioFornecedorEmBancoDeDadosTest
    {
        private Fornecedor fornecedor;
        private RepositorioFornecedorEmBancoDeDados repositorio;


        public RepositorioFornecedorEmBancoDeDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBFORNECEDOR; DBCC CHECKIDENT (TBFORNECEDOR, RESEED, 0)");

            fornecedor = new Fornecedor("Pedro da Silva", "321654987", "jose@gmail.com", "Lages", "SC");
            repositorio = new RepositorioFornecedorEmBancoDeDados();
        }
        
        [TestMethod]
        public void Deve_inserir_novo_fornecedor()
        {
            //action
            repositorio.Inserir(fornecedor);

            //assert
            var fornecedorEncontrado = repositorio.SelecionarPorId(fornecedor.Id);

            Assert.IsNotNull(fornecedorEncontrado);
            Assert.AreEqual(fornecedor, fornecedorEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_fornecedor()
        {
            //arrange                      
            repositorio.Inserir(fornecedor);

            //action
            fornecedor.Nome = "Pedro de Moraes";
            fornecedor.Telefone = "987654321";
            fornecedor.Email = "Pedro@gmail.com";
            fornecedor.Cidade = "São José dos Campos";
            fornecedor.Estado = "SP";

            repositorio.Editar(fornecedor);

            //assert
            var pacienteEncontrado = repositorio.SelecionarPorId(fornecedor.Id);

            Assert.IsNotNull(pacienteEncontrado);
            Assert.AreEqual(fornecedor, pacienteEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_fornecedor()
        {
            //arrange           
            repositorio.Inserir(fornecedor);

            //action           
            repositorio.Excluir(fornecedor);

            //assert
            var pacienteEncontrado = repositorio.SelecionarPorId(fornecedor.Id);
            Assert.IsNull(pacienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_fornecedor()
        {
            //arrange          
            repositorio.Inserir(fornecedor);

            //action
            var pacienteEncontrado = repositorio.SelecionarPorId(fornecedor.Id);

            //assert
            Assert.IsNotNull(pacienteEncontrado);
            Assert.AreEqual(fornecedor, pacienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_fornecedores()
        {
            //arrange
            var f01 = new Fornecedor("Pedro da Silva", "321654987", "pedro@gmail.com", "São José", "SC");
            var f02 = new Fornecedor("João da Silva", "321654987", "joao@gmail.com", "Floripa", "SC");
            var f03 = new Fornecedor("Mario da Silva", "321654987", "mario@gmail.com", "Lages", "SC");

            var repositorio = new RepositorioFornecedorEmBancoDeDados();
            repositorio.Inserir(f01);
            repositorio.Inserir(f02);
            repositorio.Inserir(f03);

            //action
            var fornecdores = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, fornecdores.Count);

            Assert.AreEqual(f01.Nome, fornecdores[0].Nome);
            Assert.AreEqual(f02.Nome, fornecdores[1].Nome);
            Assert.AreEqual(f03.Nome, fornecdores[2].Nome);
        }
    }
}
