using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Ingredientes { get; set; }

    public string Descricao { get; set; }

    public decimal Preco { get; set; }

    public int? Idimagem { get; set; }

    public virtual Imagem IdimagemNavigation { get; set; }

    public virtual ICollection<PedidoProduto> PedidoProdutos { get; } = new List<PedidoProduto>();
}
