using System.Text;
using AdocaoPets.Data;
using AdocaoPets.Models;
using AdocaoPets.Models.ViewModels;
using AdocaoPets.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

public class AdminService
{
    private readonly AdocaoPetsContext _context;

    public AdminService(AdocaoPetsContext context)
    {
        _context = context;
    }

    public async Task<List<Admin>> BuscarTodosAsync()
    {
        return await _context.Admin.ToListAsync();
    }
    
    public async Task<Admin> FindByIdAsync(int id)
    {
        return await _context.Admin.FindAsync(id);
    }

    
    // public async Task<List<Admin>> BuscarNomeAdmin()
    // {
    //     var nomes = await _context.Admin
    //         .Where(a => !string.IsNullOrEmpty(a.Nome))
    //         .GroupBy(a => a.Nome)
    //         .Select(group => group.First())
    //         .ToListAsync();
    //     return nomes;
    // }
    
    public async Task<Admin> BuscarEmailAdmin()
    {
        // Supondo que _dbContext seja o seu contexto do Entity Framework
        var admin = await _context.Admin.FirstOrDefaultAsync(); // Ou qualquer outra lógica de busca que você precise

        if (admin != null)
        {
            return new Admin { Nome = admin.Nome };
        }

        return admin; 
    }

    
    public async Task<List<Admin>> BuscarSenhaAdmin()
    {
        var senhas = await _context.Admin
            .Where(a => !string.IsNullOrEmpty(a.Senha))
            .GroupBy(a => a.Senha)
            .Select(group => group.First())
            .ToListAsync();
        return senhas;
    }
    
    public async Task CriarAdmin(Admin obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<List<AdminViewModel>> BuscandoAdmin()
    {
        var admins = await _context.Admin
            .Select(admin => new AdminViewModel
            {
                Nome = admin.Nome,
                Email = admin.Email
            })
            .ToListAsync();

        return admins;
    }
    
    public async Task<Admin> BuscarNomeAdmin()
    {
        // Supondo que _dbContext seja o seu contexto do Entity Framework
        var admin = await _context.Admin.FirstOrDefaultAsync(); // Ou qualquer outra lógica de busca que você precise

        if (admin != null)
        {
            return new Admin { Nome = admin.Nome };
        }

        return null; // Ou outra lógica para tratar o caso em que o administrador não foi encontrado
    }

    public async Task DeletarAdmin(int id)
    {
        var admin = await _context.Admin.FindAsync(id);

        if (admin == null)
        {
            // O administrador não existe
            return;
        }

        try
        {
            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro ao excluir o administrador.", ex);
        }
    }


    
    
    public async Task Atualizar(Admin obj)
    {
        _context.Admin.Update(obj);
        await _context.SaveChangesAsync();
    }
    

    
    
    
    
    
    // Tentar Autenticação 
    // public async Task<Admin> BuscarPorLogin(string login)
    // {
    //     return await _context.Admin.FirstOrDefaultAsync(x => x.Email.ToUpper() == login.ToUpper());
    // }
    //
    // public async Task<bool> AutenticarAdmin(string login, string senha)
    // {
    //     var admin = await _context.Admin
    //         .FirstOrDefaultAsync(x => x.Email.ToUpper() == login.ToUpper() && x.Senha == senha);
    //
    //     return admin != null; // Retorna true se autenticação bem-sucedida, senão false
    // }
}

