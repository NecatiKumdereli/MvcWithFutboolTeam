using System;
using System.Collections.Generic;

namespace _21660110053NecatiKumdereli.Models;

public partial class FootballTeam
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string EstablishDate { get; set; } = null!;

    public string DirectorName { get; set; } = null!;

    public string Captan { get; set; } = null!;

    public string President { get; set; } = null!;

    public virtual ICollection<FootballPlayerHistory> FootballPlayerHistories { get; set; } = new List<FootballPlayerHistory>();
}
