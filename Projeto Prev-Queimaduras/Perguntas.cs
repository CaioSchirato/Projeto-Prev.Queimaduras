namespace Projeto_Prev_Queimaduras
{
    public class Pergunta
    {
        public string Texto { get; set; }
        public string Imagem { get; set; } // caminho da imagem
        public string[] Alternativas { get; set; }
        public int RespostaCorreta { get; set; } // índice da resposta correta (0,1,2)
    }
}
