﻿using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class RoomKind
{
    public int RoomKindId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
