using System.Collections.Generic;
using System.Linq;
using CovidCadastro.Modelos;
using CovidCadastro.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CovidCadastro.Controllers
{
    [Route("api/covid")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // Colocar arquivo onde será salvo os dados ou fazer conexão com banco de dados
        public List<CadastradoCovid> Cadastrados; 

        /// <summary>
        /// Listar todos os cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<CadastradoCovid>> Listar()
        {
            return this.Cadastrados;
        }

        /// <summary>
        /// Recuperar cadastrado unico através do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<CadastradoCovid> Recuperar(int id)
        {
            return this.Cadastrados[id];
        }

        /// <summary>
        /// Cadastrar pessoa
        /// </summary>
        /// <param name="requisicao"></param>
        [HttpPost]
        public void Inserir([FromBody]RequisicaoCadastro requisicao)
        {
            var cadastrado = new CadastradoCovid(requisicao.Nome, requisicao.Endereco, requisicao.Celular, requisicao.Peso, requisicao.AlturaCm, requisicao.ProblemasSaude);
            this.Cadastrados.Add(cadastrado);
            cadastrado.Id = Cadastrados.IndexOf(cadastrado);
        }

        /// <summary>
        /// Editar dados de um cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requisicao"></param>
        [HttpPatch("{id}")]
        public void Editar(int id, [FromBody]RequisicaoCadastro requisicao)
        {
            var editado = this.Cadastrados[id];

            editado.SetNome(requisicao.Nome);
            editado.SetEndereco(requisicao.Endereco);
            editado.SetCelular(requisicao.Celular);
            editado.SetPeso(requisicao.Peso);
            editado.SetAltura(requisicao.AlturaCm);
            editado.SetProblemasSaude(requisicao.ProblemasSaude);
        }

        /// <summary>
        /// Excluir cadastrado do sistema
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Excluir(int id)
        {
            this.Cadastrados.Remove(this.Cadastrados[id]);
        }
    }
}
