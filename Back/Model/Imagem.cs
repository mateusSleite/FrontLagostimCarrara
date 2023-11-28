using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class Imagem
{
    public int Id { get; set; }

    public byte[] Foto { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
