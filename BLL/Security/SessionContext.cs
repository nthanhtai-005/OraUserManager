using System;
using System.Collections.Generic;

namespace BLL.Security
{
    public static class SessionContext
    {
        public static string CurrentUsername { get; set; }

        // Sử dụng HashSet với StringComparer.OrdinalIgnoreCase để không phân biệt hoa thường
        public static HashSet<string> SystemPrivileges { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Hàm kiểm tra quyền
        public static bool HasPrivilege(string privilegeName)
        {
            // Nếu là ADMIN như SYS hoặc ADMIN_BM cho pass luôn
            if (CurrentUsername != null && CurrentUsername.Equals("ADMIN_BM", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return SystemPrivileges.Contains(privilegeName);
        }

        public static void ClearSession()
        {
            CurrentUsername = null;
            SystemPrivileges.Clear();
        }
    }
}