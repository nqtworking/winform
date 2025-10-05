namespace StudentManagementWinForms
{
    public static class UserSession
    {
        public static string Username { get; set; }
        public static bool IsLoggedIn { get; set; }
        
        public static void Logout()
        {
            Username = null;
            IsLoggedIn = false;
        }
    }
}