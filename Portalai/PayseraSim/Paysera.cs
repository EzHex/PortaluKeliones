using System.Security.Cryptography;

namespace PayseraSim;

public static class Paysera
{
    public static bool getStatus()
    {
        return RandomNumberGenerator.GetInt32(0, 2) == 1;
    }
}