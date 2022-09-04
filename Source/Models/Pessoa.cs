using System.Collections.Generic;

namespace Source.Models;

public class Pessoa
{
   //nome, idade, cpf, ativa
   public int Id { get; set; }
   public string Nome {get; set;} 
   public int Idade { get; set; }
   public string? Cpf { get; set; }
   public bool Ativado { get; set; }
   public List<Contrato> Contratos { get; set; }

   public Pessoa()
   {
     this.Nome = "template";
     this.Idade = 0;
     this.Contratos = new List<Contrato>();
     this.Ativado = true;
   }

   public Pessoa(string nome, int idade, string cpf)
   {
       this.Nome = nome;
       this.Idade = idade;
       this.Cpf = cpf;
       this.Contratos = new List<Contrato>();
       this.Ativado = true;
   }
}