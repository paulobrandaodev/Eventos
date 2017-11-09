using System;
using System.IO;
using System.Text;

namespace Data.ClassePai.ClasseFilhas{
    public class Teatro : Evento{
        public string[] Elenco { get; set; }
        public string Diretor { get; set; }
        public string GeneroPeca { get; set; }

        public Teatro()
        {
            
        }

        public Teatro(string titulo, string local, int lotacao, string duracao, int classificacao, DateTime data, string[] elenco, string generopeca)
        {
            base.Titulo = titulo;
            base.Local = local;
            base.Lotacao = lotacao;
            base.Duracao = duracao;
            base.Classificacao = classificacao;
            base.Data = data;
            Elenco = elenco;
            GeneroPeca = generopeca;
        }

        public override bool Cadastrar(){
            bool efetuado = false;
            StreamWriter arquivo = null;

            try{
                arquivo = new StreamWriter("teatro.csv", true);

                arquivo.Write(
                    Titulo+";"+
                    Local+";"+
                    Duracao+";"+
                    Data+";"+
                    Classificacao+";"+
                    GeneroPeca+";"+
                    Lotacao+";");
                    for (int i = 0; i < Elenco.Length; i++)
                       arquivo.Write(Elenco[i]+",");
                    arquivo.WriteLine("");
                    
                efetuado = true;

            }catch(Exception e){
                throw new Exception("Erro ao tentar gravar o arquivo : "+e);
            }finally{
                arquivo.Close();
            }

            return efetuado;
        }

        public override string Pesquisar(string Titulo){
            string resultado = "Título não encontrado";
            StreamReader ler = null;

            try
            {
                ler = new StreamReader("teatro.csv", Encoding.Default);
                string linha = "";
                while((linha = ler.ReadLine()) != null){
                    string[] dados = linha.Split(';');
                    if(dados[0] == Titulo){
                        resultado = linha;
                        break;
                    }
                }

            }
            catch (System.Exception e){
                resultado = ("Erro ao tentar pesquisar o arquivo : "+e);
            }finally{
                ler.Close();
            }

            return resultado;
        }

        public override string Pesquisar(DateTime DataEvento){
            string resultado = "Data não encontrada";
            StreamReader ler = null;

            try
            {
                ler = new StreamReader("show.csv", Encoding.Default);
                string linha = "";
                while((linha = ler.ReadLine()) != null){
                    string[] dados = linha.Split(';');
                    if(dados[3] == DataEvento.ToString()){
                        resultado = linha;
                        break;
                    }
                }

            }
            catch (System.Exception e){
                resultado = ("Erro ao tentar pesquisar o arquivo : "+e);
            }finally{
                ler.Close();
            }

            return resultado;
        }

        public string PesquisarAtor(string Ator){
            string resultado = "Ator não encontrado";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("teatro.csv", Encoding.Default);
                string linha = "";
                while((linha = ler.ReadLine()) != null){
                    string[] dados  = linha.Split(';');
                    string[] atores = dados[7].Split(',');
                        
                        foreach(string pesquisa in atores){
                          if(pesquisa == Ator){
                              resultado = "O ator "+pesquisa+" faz parte do elenco da peça "+dados[0]+"";
                              break;
                          }
                                                          
                        break;
                    }
                }

            }
            catch (System.Exception e){
                resultado = ("Erro ao tentar pesquisar o arquivo : "+e);
            }finally{
                ler.Close();
            }

            return resultado;
        }


    }
}