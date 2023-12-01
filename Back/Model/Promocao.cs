using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Promocao
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Codigo { get; set; }

    public string Descricao { get; set; }

    public decimal Preco { get; set; }

    public int? Idimagem { get; set; }

    public virtual Imagem IdimagemNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();

    public virtual ICollection<PromocaoProduto> PromocaoProdutos { get; } = new List<PromocaoProduto>();
}
