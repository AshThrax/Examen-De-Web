namespace Api.Handler
{
    public static class Permission
    {
        public static List<string> myPermission()
        {
            return new List<string> 
            { 
                "read:message",
                "write:message",
                "read:users",
                "write:users"
            };
        }
    }
}
