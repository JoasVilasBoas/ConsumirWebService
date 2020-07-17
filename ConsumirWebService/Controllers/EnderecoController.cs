using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using ConsumirWebService.Models;
using ConsumirWebService.DAL;

//Aluno: Joas Vilas Noas Fernandes
//Mat. : 1624586
namespace ConsumirWebService.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoDao _enderecoDao;

        public EnderecoController(EnderecoDao enderecoDao)
        {
            _enderecoDao = enderecoDao;
        }

        public IActionResult Index()
        {
            return View(_enderecoDao.Listar());
        }

        [HttpGet]
        public IActionResult Cadastrar(string txtCEP)
        {
            return View(PesquisarCEP(txtCEP));
        }

        [HttpPost]
        public IActionResult Cadastrar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoDao.Cadastrar(endereco);

                return RedirectToAction("Index");
            }
            else
            {
                return View(endereco);
            }
        }

        [HttpGet]
        public IActionResult Alterar(int Id)
        {
            var endereco = _enderecoDao.RetornaConsultaId(Id);

            return View(endereco);
        }

        [HttpPost]
        public IActionResult Alterar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoDao.Alterar(endereco);

                return RedirectToAction("Index");
            }
            else
            {
                return View(endereco);
            }
        }


        [HttpGet]
        public IActionResult Deletar(int Id)
        {
            var endereco = _enderecoDao.RetornaConsultaId(Id);
            return View(endereco);
        }

        [HttpPost]
        public IActionResult Deletar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoDao.Deletar(endereco);

                return RedirectToAction("Index");
            }
            else
            {
                return View(endereco);
            }
        }

        public Endereco PesquisarCEP(string txtCEP)
        {
            string url = $@"https://viacep.com.br/ws/{txtCEP}/json";
            WebClient cliente = new WebClient();
            string resultado = cliente.DownloadString(url);
            GsonCEP objCEP = JsonConvert.DeserializeObject<GsonCEP>(resultado);

            Endereco endereco = new Endereco();

            endereco.Cep = objCEP.cep;
            endereco.Logradouro = objCEP.logradouro;
            endereco.Complemento = objCEP.complemento;
            endereco.Bairro = objCEP.bairro;
            endereco.Localidade = objCEP.localidade;
            endereco.Uf = objCEP.uf;
           
            return endereco;

        }
    }
}
