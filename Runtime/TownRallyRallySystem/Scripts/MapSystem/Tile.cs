using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TownRally.RallySystem
{
    internal class Tile
    {
        internal int Zoom { get; set; } = 0;
        internal int Horizontal { get; set; } = 0;
        internal int Vertical { get; set; } = 0;
        internal int IndexI { get; set; } = 0;
        internal int IndexJ { get; set; } = 0;
    }
}
