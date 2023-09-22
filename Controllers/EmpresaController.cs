﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutamentoApi.Dados;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private RecrutamentoContext _context;
        private IMapper _mapper;

        public EmpresaController(RecrutamentoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult AdicionaEmpresa([FromBody] CreateEmpresaDto empresaDto)
        {
            try
            {
                Empresa empresa = _mapper.Map<Empresa>(empresaDto);
                _context.Enderecos.Add(empresa.Endereco);
                _context.Empresas.Add(empresa);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperaEmpresaPorId), new { id = empresa.Id }, empresa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEmpresaPorId(int id)
        {
            try
            {
                var empresa = _context.Empresas.FirstOrDefault(empresa => empresa.Id == id);
                if (empresa == null) return NotFound();
                var empresaDto = _mapper.Map<ReadEmpresaDto>(empresa);
                return Ok(empresaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult RecuperaEmpresas([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            try
            {
                return Ok(_mapper.Map<List<ReadEmpresaDto>>(_context.Empresas.Skip(skip).Take(take).ToList()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("login")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string senha)
        {
            try
            {
                var empresa = _context.Empresas.FirstOrDefault(empresa => empresa.Email == email && empresa.Senha == senha);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                }
                return Ok(_mapper.Map<ReadEmpresaDto>(empresa));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEmpresa(int id, [FromBody] UpdateEmpresaDto curriculoDto)
        {
            try
            {
                var curriculo = _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
                if (curriculo == null) return NotFound();
                _mapper.Map(curriculoDto, curriculo);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCurriculo(int id)
        {
            try
            {
                var curriculo = _context.Curriculos.FirstOrDefault(curriculo => curriculo.CandidatoId == id);
                if (curriculo == null) return NotFound();
                _context.Remove(curriculo);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
