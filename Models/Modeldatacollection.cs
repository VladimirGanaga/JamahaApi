using System;
using System.Collections.Generic;

namespace JamahaApi.Models;

public partial class Modeldatacollection
{
    public int Id { get; set; }

    public string ProdPictureFileUrl { get; set; } = null!;

    public string? Nickname { get; set; }

    public string ModelName { get; set; } = null!;

    public string ModelYear { get; set; } = null!;

    public string? ModelTypeCode { get; set; }

    public string ProductNo { get; set; } = null!;

    public string? ColorType { get; set; }

    public string? ModelBaseCode { get; set; }

    public string? ColorName { get; set; }

    public string? CalledCode { get; set; }

    public bool? VinNoSearch { get; set; }

    public string? ProdPictureNo { get; set; }

    public string? ReleaseYymm { get; set; }

    public string? ModelComment { get; set; }

    public string? ProdCategory { get; set; }

    public virtual ICollection<Partsdatacollection> Partsdatacollections { get; } = new List<Partsdatacollection>();
}
