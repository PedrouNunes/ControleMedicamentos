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
            // Assert.AreEqual(fornecedor, fornecedorEncontrado);
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
           // Assert.AreEqual(fornecedor, pacienteEncontrado);
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
           // Assert.AreEqual(fornecedor, pacienteEncontrado);
        }

        //[TestMethod]
        //public void Deve_selecionar_todos_os_fornecedores()
        //{
        //    //arrange
        //    var p01 = new Fornecedor("Messi", "321654987", "m10@gmail.com", "Lages", "SC");
        //    var p02 = new Fornecedor("Arrasdca", "321654987", "arrasca@gmail.com", "Lages", "SC");
        //    var p03 = new Fornecedor("Cristiano", "321654987", "crt@gmail.com", "Lages", "SC");

        //    var repositorio = new RepositorioFornecedorEmBancoDeDados();
        //    repositorio.Inserir(p01);
        //    repositorio.Inserir(p02);
        //    repositorio.Inserir(p03);

        //    //action
        //    var fornecedores = repositorio.SelecionarTodos();

        //    //assert

        //    Assert.AreEqual(3, fornecedores.Count);

        //    Assert.AreEqual(p01.Nome, fornecedores[0].Nome);
        //    Assert.AreEqual(p02.Nome, fornecedores[1].Nome);
        //    Assert.AreEqual(p03.Nome, fornecedores[2].Nome);
        //}
    }
}
