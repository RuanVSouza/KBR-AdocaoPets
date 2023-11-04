using AdocaoPets.Models;

namespace AdocaoPets.Data;

public class PovoandoService
{
    private readonly AdocaoPetsContext _context;
    // private readonly AdminContext _adminContext;

    public PovoandoService(AdocaoPetsContext context)
    {
        _context = context;
    }

    public void Povoar()
    {
        if (_context.Animal.Any() ||
            _context.Solicitante.Any() ||
            _context.Admin.Any())
        {
            return;
        }

        Animal a1 = new Animal(675092, "Bili", "Cachorro", "Maltes",
            3, 4, "Pequeno", "Petz Casa Grande, Diadema - SP",
            "Cachorro Fofo", Status.Ativo, "Macho");
        
        Animal a2 = new Animal(873012, "Tini", "Gato", "American Shorthair",
            3, 5, "Médio", "Bom Retiro, Curitiba - PR",
            "Frajolinha Fêmea de narizinho rosa", Status.Ativo, "Femea");
   
        Animal a3 = new Animal(309123, "Luna", "Cachorro", "Maltes",
            8, 10, "Grande", "Petz Vila Gomes, São Paulo - SP",
            "Cachorrinha que gosta de dormir e carinhoso", Status.Inativo,"Femea");
        
        Animal a4 = new Animal(129381, "Bird", "Gato", "Persa",
            3, 5, "Medio", "Petz Centro, Teresina - PI",
            "Gatinho expressista que adora um carinho", Status.Ativo, "Macho");
        
        Animal a5 = new Animal(3123519, "Suzy", "Gato", "Ashera ",
            6, 4, "Medio", "Petz Parque Imperial, São Paulo - SP",
            "Gatinha que se impressiona facil", Status.Ativo,"Femea");
        
        Animal a6 = new Animal(231042, "Teco", "Gato", "Siames ",
            2, 3, "Pequeno", "Petz Centro, Teresina - PI",
            "Gatinho posista que impressiona todos", Status.Ativo, "Macho");
        
        Animal a7 = new Animal(232093, "Bruce", "Cachorro", "Buldogue ",
            5, 7, "Pequeno", "Petz Buritis, Belo Horizonte - MG",
            "Cachorrinho fofo que adora um carinho", Status.Ativo, "Macho");
        
        Animal a8 = new Animal(231032, "Maya", "Cachorro", "Puddle ",
            2, 3, "Pequeno", "Petz Vila Joana, Jundiaí - SP",
            "Cachorrinha fofa que adora passear no parque", Status.Ativo, "Femea");
        
        Animal a9 = new Animal(412398, "Bela", "Cachorro", "Golden Retriever",
            5, 10, "Grande", "Petz Guará I, Brasília - DF",
            "Cachorrinha para quem gosta de um abraço grande", Status.Ativo, "Femea");
        
        Animal a10 = new Animal(230131, "Gaia", "Gato", "Egipcio",
            6, 5, "Medio", "Petz Igrejinha, Capanema - PA",
            "Gata manhosa que gosta de olhar a vista de cima da casa", Status.Inativo, "Femea");
        
        Animal a11 = new Animal(005612, "Koda", "Coelho", "Anão Holandês",
            3, 7, "Pequeno", "Petz Centro, Teresina - PI",
            "Isso mesmo que voce está vendo! um lindo coelho para voce cuidar com todo amor e carinho", Status.Ativo, "Macho");
        
        Animal a12 = new Animal(093132, "Luke", "Cachorro", "Golden Retriever",
            6, 10, "Grande", "Petz Warta, Londrina - PR",
            "Um lindo Golden para aqueles que gostam de companherimos", Status.Ativo, "Macho");
        
        Admin admin = new Admin(1, "Ruan", "superAdmin@teste.com", "123456789");
        
        _context.Admin.AddRange(admin);
        _context.Animal.AddRange(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
        _context.SaveChanges();
    }
}