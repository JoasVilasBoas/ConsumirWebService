using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumirWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsumirWebService.DAL;

//Aluno: Joas Vilas Noas Fernandes
//Mat. : 1624586
namespace ConsumirWebService.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class EnderecoAPIController : ControllerBase
    {
        private readonly EnderecoDao _enderecoDao;

        public EnderecoAPIController(EnderecoDao enderecoDao)
        {
            _enderecoDao = enderecoDao;
        }

        //Get:api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult ListarEnderecos()
        {
            return Ok(_enderecoDao.Listar());
        }

        //Get:api/Endereco/ListarEndereco/81490506
        [HttpGet]
        [Route("ListarEndereco/{txtCep}")]
        public IActionResult ListarEndereco(string txtCep)
        {
            var endereco = _enderecoDao.RetornaConsultaCEP(txtCep);

            if (endereco == null)
            {
                return NotFound();
            }
                return Ok(endereco);
        }
                 
        //Post:/api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult CadastrarEndereco(Endereco endereco)
        {
            _enderecoDao.Cadastrar(endereco);
            return Created("", endereco);
        }

        //PUT:/api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult AlterarEndereco(Endereco endereco)
        {
            _enderecoDao.Alterar(endereco);
            return Created("", endereco);
        }

        //Delete:api/Endereco/DeletarEndereco/4
        [HttpDelete]
        [Route("DeletarEndereco/{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            _enderecoDao.DeletarId(id);
            return Ok();            
        }
    }
}
