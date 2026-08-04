using Microsoft.AspNetCore.Identity;

namespace SistemaRMA.Data;

public static class InicializadorPerfis
{
    public static async Task CriarPerfisAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] perfis = {"Utilizador", "Gestor", "Administrador"};

        foreach (var perfil in perfis)
        {
            if (!await roleManager.RoleExistsAsync(perfil))
            {
                await roleManager.CreateAsync(new IdentityRole(perfil));
            }
        }
    }
}