using System;
namespace Dio.Series

{
    public class Serie : EntidadeBase
    {
        public Serie(Genero genero, string titulo, string descricao, int ano)
        {
            this.Genero = genero;
            this.Titulo = titulo;
            this.descricao = descricao;
            this.Ano = ano;

        }
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido {get; set;}

        public Serie(int id, Genero genero, string Titulo, string descricao, int ano)
        {
            this.ID = id;
            this.Genero = genero;
            this.Titulo = Titulo;
            this.descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título:  " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.descricao + Environment.NewLine;
            retorno += "ANo de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;

            return retorno;
        }
        
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.ID;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }
    }
}
