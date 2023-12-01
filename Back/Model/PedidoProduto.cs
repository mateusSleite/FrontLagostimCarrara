using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class PedidoProduto
{
    public int Id { get; set; }

    public int Quantidade { get; set; }

    public int? Idpedido { get; set; }

    public int? Idproduto { get; set; }

    public virtual Pedido IdpedidoNavigation { get; set; }

    public virtual Produto IdprodutoNavigation { get; set; }
}
