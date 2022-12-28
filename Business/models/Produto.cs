using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.models
{
    public partial class Produto
    {
        public Produto() { }

        private int _id = default!;
        private string _nome = default!;
        private string _descricao = default!;
        private DateTime _dataCriacao = default!;
        private DateTime _dataValidade = default!;
        private int _quantidadeEstoque = default!;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public DateTime Data_Criacao
        {
            get { return _dataCriacao; }
            set { _dataCriacao = value; }
        }
        public DateTime Data_Validade
        {
            get { return _dataValidade; }
            set { _dataValidade = value; }
        }
        public int Quantidade_Estoque
        {
            get { return _quantidadeEstoque; }
            set { _quantidadeEstoque = value; }
        }

    }
}
