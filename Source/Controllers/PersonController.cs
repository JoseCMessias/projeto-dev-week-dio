using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using Source.Models;
using Source.Persistence;

namespace Source.Controllers;

[ApiController]
[Route("[controller]")] 
public class PersonController : ControllerBase
{
    private DatabaseContext _context { get; set; }

    public PersonController(DatabaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Pessoa>> Get()

    {  
       var result = _context.Pessoas.Include(p => p.Contratos).ToList();
       if(!result.Any())
       {
        return NoContent();
       }
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id){
        var pessoa =_context.Pessoas.FirstOrDefault(e => e.Id == id);
        return Ok(pessoa);
    }

    [HttpGet("nome/{nome}")]
    public IActionResult GetByName(string nome){
       var pessoa = _context.Pessoas.FirstOrDefault(e => e.Nome == nome);
       return Ok(pessoa);
    }

    [HttpPost]
    public ActionResult<Pessoa> Post([FromBody]Pessoa pessoa)
    {
        try
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
        
        return Created("criado", pessoa);
    }

    [HttpPut("{id}")]
    public ActionResult<object> Update([
        FromRoute]int id, 
        [FromBody]Pessoa pessoa
        )
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);

        if(result is null){
            return NotFound(new {
                msg = "Redistro não encontrado",
                status = HttpStatusCode.NotFound
            });
        }

        try
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {  
            return Ok(new{
                msg = $"houve um erro ao enviar mensagem de atualização do  {id} atualizados",
                status = HttpStatusCode.NotFound
        });
        }
        
        return Ok(new{
           msg = $"Dados do id  {id} atualizados",
           status = HttpStatusCode.OK
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<Object>Delete([FromRoute]int id)
    {
        var result = _context.Pessoas.SingleOrDefault(e => e.Id == id);
        if(result is null)
        {
            return BadRequest(new {
                msg = "Conteudo inexistente, solicitação inválida", 
                status = HttpStatusCode.BadRequest
                });
        }

        _context.Pessoas.Remove(result);
        _context.SaveChanges();

        return Ok(new{
            msg = $"Delete pessoa de Id {id}",
            ststus = HttpStatusCode.OK
        });
    }
}