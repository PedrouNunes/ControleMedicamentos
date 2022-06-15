using ControleMedicamentos.Dominio.ModuloFornecedor;
using ControleMedicamentos.Dominio.ModuloRequisicao;
using System;
using System.Collections.Generic;

namespace ControleMedicamentos.Dominio.ModuloMedicamento
{
    public class Medicamento : EntidadeBase<Medicamento>
    {
        private string v1;
        private string v2;
        private string v3;
        private DateTime date;
        private int v4;
        private Fornecedor fornecedor;

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lote { get; set; }
        public DateTime Validade { get; set; }
        public int QuantidadeDisponivel { get; set; }

        public List<Requisicao> Requisicoes { get; set; }

        public Fornecedor Fornecedor{ get; set; }

        public int QuantidadeRequisicoes { get { return Requisicoes.Count; } }

        public Medicamento(string nome, string descricao, string lote, DateTime validade, List<Requisicao> requisicoes, int quantidadeDisponivel, Fornecedor fornecedor)
        {
            Nome = nome;
            Descricao = descricao;
            Lote = lote;
            Validade = validade;
            Requisicoes = new List<Requisicao>();
            QuantidadeDisponivel = quantidadeDisponivel;
            Fornecedor = fornecedor;
            Requisicoes = requisicoes;
        }

        public Medicamento(string nome, string descricao, string lote, DateTime validade, int quantidadeDisponivel, Fornecedor fornecedor)
        {
            Nome = nome;
            Descricao = descricao;
            Lote = lote;
            Validade = validade;
            Requisicoes = new List<Requisicao>();
            QuantidadeDisponivel = quantidadeDisponivel;
            Fornecedor = fornecedor;
        }

        public Medicamento()
        {
        }
    }
}
