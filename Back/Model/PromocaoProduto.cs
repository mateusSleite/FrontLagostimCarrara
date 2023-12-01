using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class PromocaoProduto
{
    public int Id { get; set; }

    public int Quantidade { get; set; }

    public int? Idpedido { get; set; }

    public int? Idpromocao { get; set; }

    public virtual Pedido IdpedidoNavigation { get; set; }

    public virtual Promocao IdpromocaoNavigation { get; set; }
}
