using System;
using System.Collections.Generic;

namespace JamahaApi.Models;

public partial class Partsdatacollection
{
    public int Id { get; set; }

    public int ModeldatacollectionId { get; set; }

    public string? PartNewsFileUrl { get; set; }

    public string SelectableId { get; set; } = null!;

    public string PartNo { get; set; } = null!;

    public string PartName { get; set; } = null!;

    public int Quantity { get; set; }

    public string? Remarks { get; set; }

    public string? AppSerial { get; set; }

    public string? RefNo { get; set; }

    public string? Chapter { get; set; }

    public virtual Modeldatacollection Modeldatacollection { get; set; } = null!;
}
