using System;
using System.IO;
using System.Text;

namespace Data.ClassePai.ClasseFilhas{
    /// <summary>
    /// Constrói o objeto para criação do evento de Cinema
    /// </summary>
    public class Cinema : Evento{
        public DateTime[] Sessao { get; set; }
        public string GeneroCinema { get; set; }

        /// <summary>
        /// Cria os Filmes
        /// </summary>
        public Cinema()
        {
            
        }

        /// <summary>
        /// Cria o objeto filme
        /// </summary>
        /// <param name="titulo">Título do filme</param>
        /// <param name="local">Local do filme</param>
        /// <param name="lotacao">Total de membros da platéia</param>
        /// <param name="duracao">Duração do filme em minutos</param>
        /// <param name="classificacao">Classificação etária</param>
        /// <param name="data">Data de exibição</param>
        /// <param name="sessao">Horários das Sessões</param>
        /// <param name="generocinema">Gênero do filme</param>
        public Cinema(string titulo, string local, int lotacao, string duracao, int classificacao, DateTime data, DateTime[] sessao, string generocinema)
        {
            base.Titulo = titulo;
            base.Local = local;
            base.Lotacao = lotacao;
            base.Duracao = duracao;
            base.Classificacao = classificacao;
            base.Data = data;
            Sessao = sessao;
            GeneroCinema = generocinema;
        }

        /// <summary>
        /// Cadastra o filme
        /// </summary>
        /// <returns>Verdadeiro ou falso</returns>
        public override bool Cadastrar(){
            bool efetuado = false;
            StreamWriter arquivo = null;

            try{
                arquivo = new StreamWriter("cinema.csv", true);

                arquivo.Write(
                    Titulo+";"+
                    Local+";"+
                    Duracao+";"+
                    Data+";"+
                    Classificacao+";"+
                    GeneroCinema+";"+
                    Lotacao+";");
                    for (int i = 0; i < Sessao.Length; i++)
                       arquivo.Write(Sessao[i]+",");
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
        /// Pesquisa o título do filme
        /// </summary>
        /// <param name="Titulo">String com o título desejado</param>
        /// <returns></returns>
        public override string Pesquisar(string Titulo){
            string resultado = "Título não encontrado";
            StreamReader ler = null;

            try
            {
                ler = new StreamReader("cinema.csv", Encoding.Default);
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
        /// Pesquisa a data da exibição
        /// </summary>
        /// <param name="DataEvento">Formato xx/xx/xxxx</param>
        /// <returns></returns>
        public override string Pesquisar(DateTime DataEvento){
            string resultado = "Data não encontrada";
            StreamReader ler = null;

            try
            {
                ler = new StreamReader("cinema.csv", Encoding.Default);
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
        /// Pesquisa sobre todas as seções disponíveis
        /// </summary>
        /// <param name="DataSessao">Formato : xx/xx/xxxx</param>
        /// <returns></returns>
        public string PesquisarSessao(DateTime DataSessao){
            string resultado = "Sessão não encontrada";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("teatro.csv", Encoding.Default);
                string linha = "";
                while((linha = ler.ReadLine()) != null){

                    string[] dados  = linha.Split(';');
                    string[] sessoes = dados[7].Split(',');
                        
                        foreach(string pesquisa in sessoes){
                          if(pesquisa == DataSessao.ToString()){
                              resultado = "Sessão das "+pesquisa+" encontrada";
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