using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoUm.Models;

namespace ProjetoUm.Services.Interfaces
{
    public interface IPersonagemService
    {
        Task<IEnumerable<Personagem>> GetPersonagens();
        Task<IEnumerable<Personagem>> GetPorTipo(string tipo);

        Task<Personagem> AddPersonagem(Personagem personagem);
        Task<Personagem> GetPersonagem(int id);
        Task<Personagem> UpdatePersonagem(int id, Personagem personagemAtualizado);
        Task<bool> DeletePersonagem(int id);
    }
}