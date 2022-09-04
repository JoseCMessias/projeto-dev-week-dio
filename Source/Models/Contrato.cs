namespace Source.Models;
using System.Collections.Generic;

public class Contrato
{
    public int Id { get; set; }
    public DateTime DataCiacao { get; set; }
    public string TokenId { get; set; }
    public double Valor { get; set; }  
    public bool Papo { get; set; }
    public int PessoaId { get; set; }

    public Contrato()
    {
        this.DataCiacao = DateTime.Now;
        this.Valor = 0;
        this.TokenId = "00000";
        this.Papo = false;
    }   

    public Contrato(string tokenID, double valor)
    {
        this.DataCiacao = DateTime.Now;
        this.TokenId = tokenID;
        this.Valor = valor;
        this.Papo = false;
    }
}