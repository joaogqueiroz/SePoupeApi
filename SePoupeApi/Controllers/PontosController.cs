using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SePoupeApi.Data.Entities;
using SePoupeApi.Data.Interfaces;
using SePoupeApi.Services.Models.Pontos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPontosRepository _pontosRepository;

        public PontosController(IUsuarioRepository usuarioRepository, IPontosRepository pontosRepository)
        {
            _usuarioRepository = usuarioRepository;
            _pontosRepository = pontosRepository;
        }

        [HttpPost]
        public IActionResult Post(PontosRegisterModel model)
        {
            try
            {
                //create pontos object
                var pontos = new Pontos();
                pontos.Nivel1 = model.Nivel1;
                pontos.Nivel2 = model.Nivel2;
                pontos.Nivel3 = model.Nivel3;
                pontos.IdUsuario = model.IdUsuario;
                _pontosRepository.Create(pontos);

                return Ok($"Pontuação criada com sucesso.");

            }
            catch (Exception e)
            {
                //HTTP status 500 - Internal Server Error
                return StatusCode(500, $"{e.Message}");
            }
        }
        [HttpPut]
        public IActionResult Put(PontosEditModel model)
        {
            try
            {
                if (_pontosRepository.getByID(model.IdUsuario) != null)
                {
                    //create pontos object
                    var pontos = new Pontos();
                    pontos.IdPontos = model.IdPontos;
                    pontos.Nivel1 = model.Nivel1;
                    pontos.Nivel2 = model.Nivel2;
                    pontos.Nivel3 = model.Nivel3;
                    pontos.IdUsuario = model.IdUsuario;
                    _pontosRepository.Update(pontos);

                    return Ok($"Pontuação atualizada com sucesso.");
                }
                else
                {
                    //HTTP status 422 - Unprocessable Entity
                    return UnprocessableEntity(@"Pontuação não encontrada no sistema, verifique o id informado.");
                }
            }
            catch (Exception e)
            {
                //HTTP status 500 - Internal Server Error
                return StatusCode(500, $"{e.Message}");
            }
        }
        [HttpDelete("{IdPontos:int}")]
        public IActionResult Delete(int IdPontos)
        {
            try
            {
                var pontos = _pontosRepository.getByID(IdPontos);
                if (pontos != null)
                {
                    //create usuario object
                    pontos.IdPontos = IdPontos;

                    _pontosRepository.Delete(pontos);

                    return Ok($"Pontuação com ID {pontos.IdPontos}, foi deletada com sucesso");

                }
                else
                {
                    //HTTP status 422 - Unprocessable Entity
                    return UnprocessableEntity(@"Pontuação não encontrada no sistema, verifique o id informado.");
                }
            }
            catch (Exception e)
            {
                //HTTP status 500 - Internal Server Error
                return StatusCode(500, $"{e.Message}");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var pontos = _pontosRepository.Read();

                return Ok(pontos);

            }
            catch (Exception e)
            {
                //HTTP status 500 - Internal Server Error
                return StatusCode(500, $"{e.Message}");
            }
        }
        [HttpGet("{IdPontos:int}")]
        public IActionResult GetByID(int IdPontos)
        {
            try
            {
                if (_pontosRepository.getByID(IdPontos) != null)
                {
                    var client = _pontosRepository.getByID(IdPontos);

                    return Ok(client);
                }
                else
                {
                    //HTTP status 422 - Unprocessable Entity
                    return UnprocessableEntity(@"Pontuação não encontrada no sistema, verifique o id informado.");
                }
            }
            catch (Exception e)
            {
                //HTTP status 500 - Internal Server Error
                return StatusCode(500, $"{e.Message}");
            }
        }
    }
}
