using System;
using lab2_cs.Models;

namespace lab2_cs.Tools.Managers
{
    internal static class StationManager
    {

        internal static Person CurrentPerson { get; set; }
        
        internal static void CloseApp()
        {
            Environment.Exit(1);
        }
    }
}
