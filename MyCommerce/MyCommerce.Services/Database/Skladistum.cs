﻿using System;
using System.Collections.Generic;

namespace MyCommerce.Services.Database;

public partial class Skladistum
{
    public int SkladisteId { get; set; }

    public string Naziv { get; set; } = null!;

    public string? Adresa { get; set; }

    public string? Opis { get; set; }

    public virtual ICollection<Izlazi> Izlazis { get; } = new List<Izlazi>();

    public virtual ICollection<Ulazi> Ulazis { get; } = new List<Ulazi>();
}
