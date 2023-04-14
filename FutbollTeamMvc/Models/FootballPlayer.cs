using System;
using System.Collections.Generic;

namespace _21660110053NecatiKumdereli.Models;

public partial class FootballPlayer
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string BirthDate { get; set; } = null!;

    public string Position { get; set; } = null!;

    public long Number { get; set; }

    public string Country { get; set; } = null!;

    public virtual ICollection<FootballPlayerHistory> FootballPlayerHistories { get; set; } = new List<FootballPlayerHistory>();
}
