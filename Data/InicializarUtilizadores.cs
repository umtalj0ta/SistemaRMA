using Microsoft.AspNetCore.Identity;

namespace SistemaRMA.Data;

public static class InicializadorUtilizadores
{
    public static async Task CriarUtilizadoresAsync(UserManager<IdentityUser> userManager)
    {
        var utilizadores = new[]
        {
            new
            {
                Email = "utilizador@empresa.pt",
                Password = "Teste123!",
                Perfil = "Utilizador"
            },
            new
            {
                Email = "gestor@empresa.pt",
                Password = "Teste123!",
                Perfil = "Gestor"
            },
            new
            {
                Email = "admin@empresa.pt",
                Password = "Teste123!",
                Perfil = "Administrador"
            }
        };
        foreach( var dados in utilizadores)
        {
        var user = await userManager.FindByEmailAsync(dados.Email);

        if (user == null)
        {
                user = new IdentityUser
                {
                    UserName = dados.Email,
                    Email = dados.Email
                };
                
                await userManager.CreateAsync(user, dados.Password);  
        }
            var PertenceAoPerfil = await userManager.IsInRoleAsync(user, dados.Perfil);

            if(!PertenceAoPerfil)
            {
                await userManager.AddToRoleAsync(user, dados.Perfil);            
            }  
        }
    }
}