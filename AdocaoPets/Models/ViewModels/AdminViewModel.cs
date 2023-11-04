using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdocaoPets.Models.ViewModels;

public class AdminViewModel
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]        
    [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho deve estar entre 3 e 60 caracteres.")]
    public string Nome  { get; set; }
    
    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(10, MinimumLength = 6, ErrorMessage = "O tamanho da sua senha é entre 6 e 10 caracteres.")]
    public string Senha { get; set; }
    
   public Admin admin { get; set; }
    
    [Required(ErrorMessage = "O campo Email é obrigatório.")]     
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Insira um E-mail valido")]
    public string Email { get; set; }
    
    public  Admin Admin { get; set; }
    
    
    
    public AdminViewModel(){}
}