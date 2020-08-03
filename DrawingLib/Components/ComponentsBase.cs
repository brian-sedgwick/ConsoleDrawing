using System.Collections.Generic;
using DrawingLib.Models;

namespace DrawingLib.Components
{
    public class ComponentBase
    {
        protected ComponentBase()
        {
            Characters = new List<CharCoordinate>();
            ZIndex = 0;
            Active = true;
        }
        
        internal List<CharCoordinate> Characters { get; }
        public int ZIndex { get; set; }
        public bool Active { get; set; }
    }
}