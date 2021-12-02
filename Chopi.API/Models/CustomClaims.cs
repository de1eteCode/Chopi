namespace Chopi.API.Models
{
    public static class CustomClaimTypes
    {
        public const string Permmision = "account:permission";
    }

    public static class CustomClaimValues
    {
        #region Account

        public const string ReadSelfAccount         = "account:self:read";
        public const string UpdateSelfAccount       = "account:self:update";

        public const string ReadAnotherAccount      = "account:another:read";
        public const string UpdateAnotherAccount    = "account:another:update";

        public const string UpdateRoleAccount       = "account:role:update";

        #endregion

        #region Roles

        public const string ReadRole                = "role:read";
        public const string CreateRole              = "role:create";
        public const string UpdateRole              = "role:update";
        public const string DeleteRole              = "role:delete";

        #endregion
    }
}
