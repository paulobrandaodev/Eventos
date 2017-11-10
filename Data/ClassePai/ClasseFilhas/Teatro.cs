using System;
using System.IO;
using System.Text;

namespace Data.ClassePai.ClasseFilhas{
    /// <summary>
    /// Constrói o objeto para criação do evento de Teatro
    /// </summary>
    public class Teatro : Evento{
        public string[] Elenco { get; set; }
        public string Diretor { get; set; }
        public string GeneroPeca { get; set; }

        /// <summary>
        /// Método padrão
        /// </summary>
        public Teatro()
        {
            
        }

        /// <summary>
        /// Método completo para pegar os dados do evento
        /// </summary>
        /// <param name="titulo">Nome da peça</param>
        /// <param name="local">Local do espetáculo</param>
        /// <param name="lotacao">Número de cadeiras</param>
        /// <param name="duracao">Duração em minutos</param>
        /// <param name="classificacao">Classificação etária</param>
        /// <param name="data">Data de exibição</param>
        /// <param name="elenco">Atores que estão no elenco</param>
        /// <param name="generopeca">Gênero da peça</param>
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

        /// <summary>
        /// Cadastra a peça em um CSV
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
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

        /// <summary>
        /// Pesquisa o título da peça
        /// </summary>
        /// <param name="Titulo">Título em formato de texto</param>
        /// <returns>Resultado da busca</returns>
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

        /// <summary>
        /// Pesquisar por data 
        /// </summary>
        /// <param name="DataEvento">Formato : xx/xx/xxxx</param>
        /// <returns>Resultado da busca</returns>
        public override string Pesquisar(DateTime DataEvento){
            string resultado = "Data não encontrada";
            StreamReader ler = null;

            try
            {
                ler = new StreamReader("teatro.csv", Encoding.Default);
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

        /// <summary>
        /// Pesquisa por ator
        /// </summary>
        /// <param name="Ator">Nome do ator</param>
        /// <returns>Resultado da busca</returns>
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