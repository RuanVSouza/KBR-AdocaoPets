
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AdocaoPets.Models;

public class Admin 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // automático do banco
    
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]        
    [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho deve estar entre 3 e 60 caracteres.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(10, MinimumLength = 6, ErrorMessage = "O tamanho deve estar entre 6 e 10 caracteres.")]
    public string Senha { get; set; }
    
    [Required(ErrorMessage = "O campo ConfirmaSenha é obrigatório.")]
    [NotMapped]  // Não mapeie isso para o banco de dados
    [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
    public string ConfirmaSenha { get; set; }
    
    [Required(ErrorMessage = "O campo Email é obrigatório.")]     
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Insira um E-mail valido")]
    public string Email { get; set; }

    public Admin(){}
    
    public Admin(int id, string nome,  string email,string senha)
    {
        Id = id;
        Nome = nome;
        Senha = senha;
        Email = email;
    }

    public bool senhaValida(string senha)
    {
        return Senha == senha;
    }
}