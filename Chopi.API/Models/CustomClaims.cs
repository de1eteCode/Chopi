namespace Chopi.API.Models
{
    public static class CustomClaimTypes
    {
        public const string Permmision = "account:permission";
    }

    public static class CustomClaimValues
    {
        public const string ReadSelfAccount = "account:check:self";
        public const string ReadAnotherAccount = "account:check:another";
    }
}
