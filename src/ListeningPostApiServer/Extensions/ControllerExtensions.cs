using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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