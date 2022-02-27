using System;

namespace VizsgaremekAPI
{
    public class AktivTokenek
    {
        public static string UserToken { get; } = Guid.NewGuid().ToString();
        public static string AdminToken { get; } = Guid.NewGuid().ToString();
    }
}
