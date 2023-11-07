using System;
using System.Collections.Generic;
using System.Text;

namespace TESTE.ApiNetCore.Application.Models
{
    public class RetornoPagamentosARModel
    {
        public string IdPagamento { get; set; }
        public string CodigoEmpresa { get; set; }
        public string Contrato { get; set; }
        public string Status { get; set; }
        public string Mensagem { get; set; }
        public string ReferenciaERP { get; set; }
        public DateTime DataHoraPagamento { get; set; }
    }
}
