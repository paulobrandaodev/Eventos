

using System;

namespace Data.ClassePai{
    public abstract class Evento{
        public string Titulo { get; set; }
        public string Local { get; set; }
        public int Lotacao { get; set; }
        public DateTime Data { get; set; }
        public string Duracao { get; set; }
        public int Classificacao { get; set; }
        public Ingresso Ingresso { get; set; }

        public Evento(){}
        public Evento(string titulo,string local, int lotacao, DateTime data, string duracao, int classificacao, Ingresso ingresso){
            Titulo = titulo;
            Local = local;
            Lotacao = lotacao;
            Data = data;
            Duracao = duracao;
            Classificacao = classificacao;
            Ingresso = ingresso;
        }

        public virtual bool Cadastrar(){
            
            return false;
        }
        public virtual string Pesquisar(DateTime DataEvento){
        return "";
        }
        public virtual string Pesquisar(string TituloEvento){
        
        return "";
        }
    }
}