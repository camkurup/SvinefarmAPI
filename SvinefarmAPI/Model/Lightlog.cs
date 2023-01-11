using System;
using System.Collections.Generic;

namespace SvinefarmAPI.Model;

public partial class Lightlog
{
    public int Id { get; set; }

    public int? Leveloflight { get; set; }

    public DateTime? Timeoflog { get; set; }

    public int? Lightlevelinstable { get; set; }
}
