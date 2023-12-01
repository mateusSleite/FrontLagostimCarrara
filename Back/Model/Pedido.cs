using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Pedido
{
    public int Id { get; set; }

    public DateTime DataPedido { get; set; }

    public bool Verificacao { get; set; }

    public decimal Valor { get; set; }

    public int? Idusuario { get; set; }

    public int? Idpromocao { get; set; }

    public virtual Promocao IdpromocaoNavigation { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; }

    public virtual ICollection<PedidoProduto> PedidoProdutos { get; } = new List<PedidoProduto>();

    public virtual ICollection<PromocaoProduto> PromocaoProdutos { get; } = new List<PromocaoProduto>();
}
