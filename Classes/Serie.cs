using System.Collections.Generic;

namespace SeriesApp
{
    public class Serie : EntidadeBase
    {
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        public Serie (int id, Genero genero, string title, string desc, int ano){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = title;
            this.Descricao = desc;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + "\n";
            retorno += "Titulo: " + this.Titulo + "\n";
            retorno += "Descrição: " + this.Descricao + "\n";
            retorno += "Ano de Início: " + this.Ano + "\n";
            retorno += "Excluido: " + this.Excluido + "\n";
            return retorno;
        }

        public string retornaTitulo(){
            return  this.Titulo;
        }

        public int retornaId(){
            return this.Id;
        }

        public void Excluir(){
            this.Excluido = true;
        }

        public bool retornaExcluido(){
            return this.Excluido;
        }
    }
}