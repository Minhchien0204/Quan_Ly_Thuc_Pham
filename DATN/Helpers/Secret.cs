using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN.Helpers
{
    public class Secret
    {
        public const string Admin = "Admin";

        public const string GiaoVien = "GiaoVien";

        public const string NhaBep = "NhaBep";

        public const string ThucPham = "ThucPham";

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }

        public static AuthorizationPolicy GiaoVienPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(GiaoVien).Build();
        }

        public static AuthorizationPolicy NhaBepPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(NhaBep).Build();
        }

        public static AuthorizationPolicy ThucPhamPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(ThucPham).Build();
        }
    }
}
