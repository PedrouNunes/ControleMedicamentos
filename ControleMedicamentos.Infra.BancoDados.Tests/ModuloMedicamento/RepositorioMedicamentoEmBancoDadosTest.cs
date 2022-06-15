using ControleMedicamento.Infra.BancoDados.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloMedicamento;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using ControleMedicamentos.Infra.BancoDados;
using ControleMedicamentos.Infra.BancoDados.ModuloFornecedor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ControleMedicamento.Infra.BancoDados.Tests.ModuloMedicamento
{
    [TestClass]
    public class RepositorioMedicamentoEmBancoDadosTest
    {
        List<Requisicao> requisicoes = new List<Requisicao>();
        private Fornecedor fornecedor = new Fornecedor("Pedro", "12988758461", "pedro@gmail.com", "São José dos Campos", "SP");
        private Medicamento medicamento;
        private RepositorioMedicamentoEmBancoDados repositorio;
        private RepositorioFornecedorEmBancoDeDados repositorioFornecedor;

        public RepositorioMedicamentoEmBancoDadosTest()
        {


          //  medicamento = new Medicamento("Paracetamol", "Dor de cabeça", "Lote 40", DateTime.Now, requisicoes, fornecedor);
            repositorio = new RepositorioMedicamentoEmBancoDados();
            repositorioFornecedor = new RepositorioFornecedorEmBancoDeDados();
        }


        [TestMethod]
        public void Deve_inserir_medicamento()
        {
            var fornecedor = new Fornecedor("Pedro", "12988758461", "pedro@gmail.com", "São José dos Campos", "SP");
            var repositorioFornecedor = new RepositorioFornecedorEmBancoDeDados();
            repositorioFornecedor.Inserir(fornecedor);

            Medicamento novoMedicamento = new Medicamento("Rivotril", "Dor de cabeça", "Lote 40", DateTime.Now.Date, 15, fornecedor);
            var repositorioMedicamento = new RepositorioMedicamentoEmBancoDados();
            repositorioMedicamento.Inserir(novoMedicamento);

            Medicamento medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(novoMedicamento.Id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(novoMedicamento.Id, medicamentoEncontrado.Id);
            Assert.AreEqual(novoMedicamento.Nome, medicamentoEncontrado.Nome);
            Assert.AreEqual(novoMedicamento.Descricao, medicamentoEncontrado.Descricao);
            Assert.AreEqual(novoMedicamento.Lote, medicamentoEncontrado.Lote);
            Assert.AreEqual(novoMedicamento.Validade, medicamentoEncontrado.Validade);
            Assert.AreEqual(novoMedicamento.Fornecedor.Id, medicamentoEncontrado.Fornecedor.Id);
        }


        [TestMethod]
        public void Deve_editar_medicamento()
        {
            var fornecedor = new Fornecedor("Pedro", "12988758461", "pedro@gmail.com", "São José dos Campos", "SP");
            var repositorioFornecedor = new RepositorioFornecedorEmBancoDeDados();
            repositorioFornecedor.Inserir(fornecedor);

            Medicamento novoMedicamento = new Medicamento("Rivotril", "Dor de cabeça", "Lote 40", DateTime.Now.Date, 15, fornecedor);
            var repositorioMedicamento = new RepositorioMedicamentoEmBancoDados();
            repositorioMedicamento.Inserir(novoMedicamento);

            Medicamento novo = repositorioMedicamento.SelecionarPorNumero(novoMedicamento.Id);
            novo.Nome = "Paracetamol";
            novo.Descricao = "Dor de garganta";
            novo.Lote = "Lote 2";
            novo.Validade = DateTime.Now.Date;
            novo.QuantidadeDisponivel = 10;
            novo.Fornecedor = repositorioFornecedor.SelecionarPorId(1);

            repositorioMedicamento.Editar(novo);

            Medicamento medicamentoEncontrado = repositorioMedicamento.SelecionarPorNumero(novoMedicamento.Id);

            Assert.IsNotNull(medicamentoEncontrado);
            Assert.AreEqual(novo.Id, medicamentoEncontrado.Id);

        }


        [TestMethod]
        public void Deve_excluir_Medicamento()
        {
            //arrange           
            repositorio.Inserir(medicamento);

            //action           
            repositorio.Excluir(medicamento);

            //assert
            var medicamentoEncontrado = repositorio.SelecionarPorNumero(medicamento.Id);
            Assert.IsNull(medicamentoEncontrado);
        }



        [TestMethod]
        public void Deve_selecionar_um_medicamento()
        {
            var fornecedor = new Fornecedor("Pedro", "12988758461", "pedro@gmail.com", "São José dos Campos", "SP");
            var repositorioFornecedor = new RepositorioFornecedorEmBancoDeDados();
            repositorioFornecedor.Inserir(fornecedor);

            Medicamento novoMedicamento = new Medicamento("Rivotril", "Dor de cabeça", "Lote 40", DateTime.Now.Date, 15, fornecedor);
            var repositorioMedicamento = new RepositorioMedicamentoEmBancoDados();
            repositorioMedicamento.Inserir(novoMedicamento);

            Medicamento med = repositorioMedicamento.SelecionarPorNumero(novoMedicamento.Id);

            Assert.IsNotNull(med);
            Assert.AreEqual(novoMedicamento.Id, med.Id);
            Assert.AreEqual(novoMedicamento.Nome, med.Nome);
            Assert.AreEqual(novoMedicamento.Descricao, med.Descricao);

        }

        [TestMethod]
        public void Deve_selecionar_todos_um_medicamentos()
        {
            var fornecedor = new Fornecedor("Pedro", "12988758461", "pedro@gmail.com", "São José dos Campos", "SP");
            var repositorioFornecedor = new RepositorioFornecedorEmBancoDeDados();
            repositorioFornecedor.Inserir(fornecedor);

            var repositorioMedicamento = new RepositorioMedicamentoEmBancoDados();
            Medicamento m1 = new Medicamento("Rivotril", "Dor de cabeça", "Lote 40", DateTime.Now.Date, 15, fornecedor);
            repositorioMedicamento.Inserir(m1);

            Medicamento m2 = new Medicamento("Rivotril", "Dor de cabeça", "Lote 40", DateTime.Now.Date, 15, fornecedor);
            repositorioMedicamento.Inserir(m2);

            Medicamento m3 = new Medicamento("Rivotril", "Dor de cabeça", "Lote 40", DateTime.Now.Date, 15, fornecedor);
            repositorioMedicamento.Inserir(m3);

            var medicamentos = repositorioMedicamento.SelecionarTodos();

            Assert.AreEqual(3, medicamentos.Count);

            Assert.AreEqual("Nome teste 1", medicamentos[0].Nome);
            Assert.AreEqual("Nome teste 2", medicamentos[1].Nome);
            Assert.AreEqual("Nome teste 3", medicamentos[2].Nome);
        }
    }
}
