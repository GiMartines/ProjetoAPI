using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoUm.Data;
using ProjetoUm.Models;
using ProjetoUm.Services.Interfaces;

namespace ProjetoUm.Services.Implementations
{
    public class PersonagemService : IPersonagemService
    {
        private readonly AppDbContext _context;

        public PersonagemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personagem>> GetPersonagens()
        {
            return await _context.DBZ.ToListAsync();
        }

        public async Task<IEnumerable<Personagem>> GetPorTipo(string tipo)
        {
            return await _context.DBZ
                .Where(p => p.Tipo.ToLower() == tipo.ToLower())
                .ToListAsync();
        }


        public async Task<Personagem> GetPersonagem(int id)
        {
            return await _context.DBZ.FindAsync(id);
        }

        public async Task<Personagem> AddPersonagem(Personagem personagem)
        {
            _context.DBZ.Add(personagem);
            await _context.SaveChangesAsync();
            return personagem;
        }

        public async Task<Personagem> UpdatePersonagem(int id, Personagem personagemAtualizado)
        {
            var existente = await _context.DBZ.FindAsync(id);
            if (existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(personagemAtualizado);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletePersonagem(int id)
        {
            var personagem = await _context.DBZ.FindAsync(id);
            if (personagem == null) return false;

            _context.DBZ.Remove(personagem);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}