using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public string Name { get; set; } = null!;

    public string? Test { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
