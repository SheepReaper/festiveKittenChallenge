using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ListeningPostApiServer.Extensions
{
    public static class ControllerExtensions
    {
        public static void Log(this ControllerBase controller, string message)
        {
            var fancy = "".PadLeft(18, '-');

            Debug.WriteLine($"{fancy}\n{message}\n{fancy}");
        }
    }
}
