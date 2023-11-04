using AdocaoPets.Data;
using AdocaoPets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoPets.Services
{
    public class AnimalService
    {
        private readonly AdocaoPetsContext _context;

        public AnimalService(AdocaoPetsContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> BuscarTodoAsync()
        {
            return await _context.Animal.ToListAsync();
        }

        public async Task<List<Animal>> BuscarEspecieAsync()
        {
            var especies = await _context.Animal
                .Where(a => !string.IsNullOrEmpty(a.Especie))
                .GroupBy(a => a.Especie)
                .Select(group => group.First())
                .ToListAsync();

            return especies;
        }

        public async Task<List<Animal>> BuscarRacaAsync()
        {
            var racas = await _context.Animal
                .Where(a => !string.IsNullOrEmpty(a.Raca))
                .GroupBy(a => a.Raca)
                .Select(group => group.First())
                .ToListAsync();

            return racas;
        }

        public async Task<List<Animal>> BuscarPorteAsync()
        {
            var racas = await _context.Animal
                .GroupBy(a => a.Porte)
                .Select(group => group.First())
                .ToListAsync();

            return racas;
        }

        public async Task<List<Animal>> BuscarAtivosAsync()
        {
            return await _context.Animal
                .Where(a => a.Status == Status.Ativo)
                .ToListAsync();
        }

        public async Task<Animal> ObterDetalhesPorCodigoAsync(int codigo)
        {
            var animal = await _context.Animal.FirstOrDefaultAsync(a => a.Codigo == codigo);
            return animal;
        }

        // public async Task<List<Animal>> BuscarNomeAsync()
        // {
        //     var nomes = await _context.Animal
        //         .GroupBy(a => a.Nome)
        //         .Select(group => group.First())
        //         .ToListAsync();
        //
        //     return nomes;
        // }
    }
}
