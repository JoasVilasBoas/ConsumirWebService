using ConsumirWebService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsumirWebService.DAL
{
    public class EnderecoDao
    {
        private readonly Context _context;

        public EnderecoDao(Context context)
        {
            _context = context;
        }

        public List<Endereco> Listar()
        {
            return _context.Enderecos.ToList();

        }

        public void Cadastrar(Endereco consultaCEP)
        {
            _context.Enderecos.Update(consultaCEP);
            _context.SaveChanges();
        }

        public Endereco RetornaConsultaId(int Id)
        {
            return _context.Enderecos.Find(Id);
        }

        public Endereco RetornaConsultaCEP(string txtCEP)
        {
            var cep = Funcoes.FormatarCep(txtCEP);

            if (Funcoes.ValidaCEP(cep))
            {
                var endereco = _context.Enderecos
                         .Where(s => s.Cep == cep)
                         .ToList();

                return endereco[0];

            }
            return null;
        }

        public void Alterar(Endereco consultaCEP)
        {
            _context.Enderecos.Update(consultaCEP);
            _context.SaveChanges();
        }

        public void Deletar(Endereco consultaCEP)
        {
            _context.Enderecos.Remove(consultaCEP);
            _context.SaveChanges();
        }

        public void DeletarId (int Id)
        {
            _context.Enderecos.Remove(_context.Enderecos.Find(Id));
            _context.SaveChanges();
        }
    }

}
