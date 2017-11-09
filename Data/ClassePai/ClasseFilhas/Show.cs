using System;
using System.IO;
using System.Text;

namespace Data.ClassePai.ClasseFilhas
{
    public class Show : Evento
    {
        public string GeneroMusical { get; set; }
        public string Artista { get; set; }
        
        public Show()
        {
            
        }
        public Show(string titulo, string local, int lotacao, string duracao, int classificacao, DateTime data, string artista, string generoMusical)
        {
            base.Titulo = titulo;
            base.Local = local;
            base.Lotacao = lotacao;
            base.Duracao = duracao;
            base.Classificacao = classificacao;
            base.Data = data;
            Artista = artista;
            GeneroMusical = generoMusical;
        }
        public override bool Cadastrar(){
            bool efetuado = false;
            StreamWriter arquivo = null;

            try{
                arquivo = new StreamWriter("show.csv", true);
                arquivo.WriteLine(
                    Titulo+";"+
                    Local+";"+
                    Duracao+";"+
                    Data+";"+
                    Artista+";"+
                    GeneroMusical+";"+
                    Lotacao+";"+
                    Classificacao
                );
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
                ler = new StreamReader("show.csv", Encoding.Default);
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

    }
}