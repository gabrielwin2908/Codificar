using System;
using System.Collections.Generic;

namespace Funcionarios.Model
{
    public partial class Servicos
    {
        public int CodCliente { get; set; }
        public string NomeCliente { get; set; }
        public DateTime? DataOrcamento { get; set; }
        public string Vendedor { get; set; }
        public string DescricaoOrcamento { get; set; }
        public decimal? ValorOrcado { get; set; }
    }
}
