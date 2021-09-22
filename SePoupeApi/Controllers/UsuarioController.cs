using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SePoupeApi.Data.Entities;
using SePoupeApi.Data.Interfaces;
using SePoupeApi.Services.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SePoupeApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post(UsuarioRegisterModel model)
        {
            try
            {
                //create usuario object
                var usuario = new Usuario();
                usuario.Nome = model.Nome;
                usuario.Senha = model.Senha;
                usuario.CPF = model.CPF;
                usuario.Email = model.Email;
                usuario.Sexo = model.Sexo.ToString();
                usuario.Tipo = model.Tipo.ToString();
                usuario.Nascimento = model.Nascimento;

                _usuarioRepository.Create(usuario);
                var userId =_usuarioRepository.getByEmail(model.Email);

                return Ok($"Usario {usuario.Nome} com o id {userId},foi criado com sucesso");

            }
            catch (Exception e)
            {
                //HTTP status 500 - Internal Server Error
                return StatusCode(500, $"{e.Message}");
            }
        }
        [HttpPut]
        public IActionResult Put(UsuarioRegisterModel model)
        {
            try
            {
                if (_usuarioRepository.getByID(model.IdUsuario) != null)
                {
                    //create usuario object
                    var usuario = new Usuario();
                    usuario.IdUsuario = model.IdUsuario;
                    usuario.Nome = model.Nome;
                    usuario.Senha = model.Senha;
                    usuario.CPF = model.CPF;
                    usuario.Email = model.Email;
                    usuario.Sexo = model.Sexo.ToString();
                    usuario.Tipo = model.Tipo.ToString();
                    usuario.Nascimento = model.Nascimento;

                    _usuarioRepository.Update(usuario);

                    return Ok($"O usuario {usuario.Nome}, foi criado com sucesso.");
                }
                else
                {
                    //HTTP status 422 - Unprocessable Entity
                    return UnprocessableEntity(@"Usuario não registrado no sistema, verifique o id informado.");
                }
            }
            catch (Exception e)
            {
                //HTTP status 500 - Internal Server Error
                return StatusCode(500, $"{e.Message}");
            }
        }
        [HttpDelete("{IdUsuario:int}")]
        public IActionResult Delete(int IdUsuario)
        {
            try
            {
                var usuario = _usuarioRepository.getByID(IdUsuario);
                if (usuario != null)
                {
                    //create usuario object
                    usuario.IdUsuario = IdUsuario;

                    _usuarioRepository.Delete(usuario);

                    return Ok($"Usuario {usuario.Nome}, foi deletado com sucesso");

                }
                else
                {
                    //HTTP status 422 - Unprocessable Entity
                    return UnprocessableEntity(@"Usuario não registrado no sistema, verifique o id informado.");
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

                var usuarios = _usuarioRepository.Read();

                return Ok(usuarios);

            }
            catch (Exception e)
            {
                //HTTP status 500 - Internal Server Error
                return StatusCode(500, $"{e.Message}");
            }
        }
        [HttpGet("{IdUsuario:int}")]
        public IActionResult GetByID(int IdUsuario)
        {
            try
            {
                if (_usuarioRepository.getByID(IdUsuario) != null)
                {
                    var client = _usuarioRepository.getByID(IdUsuario);

                    return Ok(client);
                }
                else
                {
                    //HTTP status 422 - Unprocessable Entity
                    return UnprocessableEntity(@"Usuario não registrado no sistema, verifique o id informado.");
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
