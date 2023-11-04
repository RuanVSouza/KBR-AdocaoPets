using AdocaoPets.Data;
using AdocaoPets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoPets.Services
{
    public class SolicitanteService
    {
        private readonly AdocaoPetsContext _context;

        public SolicitanteService(AdocaoPetsContext context)
        {
            _context = context;
        }

        public async Task<List<Solicitante>> BuscarTudoAsync()
        {
            return await _context.Solicitante.ToListAsync();
        }

        public async Task<List<Solicitante>> BuscarNomeAsync()
        {
            var nomes = await _context.Solicitante
                .GroupBy(a => a.Nome)
                .Select(group => group.First())
                .ToListAsync();

            return nomes;
        }


        public async Task<List<Solicitante>> BuscarCPFAsync()
        {
            var cpf = await _context.Solicitante
                .GroupBy(a => a.Cpf)
                .Select(group => group.First())
                .ToListAsync();

            return cpf;
        }

        public async Task<List<Solicitante>> BuscarEmailAsync()
        {
            var email = await _context.Solicitante
                .GroupBy(a => a.Email)
                .Select(group => group.First())
                .ToListAsync();

            return email;
        }

        public async Task<List<Solicitante>> BuscarCelularAsync()
        {
            var celular = await _context.Solicitante
                .GroupBy(a => a.Celular)
                .Select(group => group.First())
                .ToListAsync();

            return celular;
        }

        public async Task<List<Solicitante>> BuscarNascimentoAsync()
        {
            var dataNascimento = await _context.Solicitante
                .GroupBy(a => a.DataNascimento)
                .Select(group => group.First())
                .ToListAsync();

            return dataNascimento;
        }

        public async Task CriarSolicitante(Solicitante obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        
        

        
        
    }
}
