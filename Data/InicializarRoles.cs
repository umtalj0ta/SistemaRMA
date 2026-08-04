using Microsoft.AspNetCore.Identity;

namespace SistemaRMA.Data;

public static class InicializadorRoles
{
    public static async Task CriarRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = {"Utilizador", "Gestor", "Administrador"};

        foreach (var role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                var newRole = new IdentityRole(role);
                await roleManager.CreateAsync(newRole);
            }
        }
    }
}