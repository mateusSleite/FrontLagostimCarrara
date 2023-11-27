using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public DateOnly DataNsc { get; set; }
    public string Numero { get; set; }
    public string Senha { get; set; }
    public string Salt { get; set; }

    public int? ImagemId { get; set; }

    public virtual Imagem Imagem { get; set; }

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}