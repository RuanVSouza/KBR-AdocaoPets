using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace AdocaoPets.Models.ViewModels;

public class FormViewModel
{

        public  List<Solicitante> Solicitante{ get; set; }
        

                [Required(ErrorMessage = "O campo Nome é obrigatório.")]
                [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho deve estar entre 3 e 60 caracteres.")]
                public string Nome { get; set; } // obrigatório

                [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O formato do CPF é inválido.")]
                [Required(ErrorMessage = "O campo CPF é obrigatório.")]
                public string Cpf { get; set; } // Alterei para string para lidar com CPFs formatados

                [Required(ErrorMessage = "O campo Email é obrigatório.")]
                [DataType(DataType.EmailAddress)]
                [EmailAddress(ErrorMessage = "Insira um E-mail válido")]
                public string Email { get; set; }

                [Required(ErrorMessage = "O campo Celular é obrigatório.")]
                public string Celular { get; set; }

                [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
                [DataType(DataType.Date)]
                [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
                public DateTime DataNascimento { get; set; }
                
                [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
                public DateTime DataInsercao { get; set; } 
        }
