using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class BlogHistory
{
    public int BlogHistoryId { get; set; }

    public int BlogId { get; set; }

    public string Name { get; set; } = null!;
}
