using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Projeto_Prev_Queimaduras
{
    public partial class MainWindow : Window
    {
        private List<Pergunta> perguntas;
        private int indiceAtual = 0;
        private int pontuacao = 0;

        public MainWindow()
        {
            InitializeComponent();
            CarregarPerguntas();
            MostrarPergunta();
        }

        private void CarregarPerguntas()
        {
            perguntas = new List<Pergunta>
            {
                new Pergunta {
                    Texto = "Se a panela está no fogão com o cabo para fora, o que você deve fazer?",
                    Imagem = "imagens/panela.png", // coloque a imagem na pasta /imagens do projeto
                    Alternativas = new string[] { "Puxar a panela", "Avisar um adulto", "Jogar água" },
                    RespostaCorreta = 1
                },
                new Pergunta {
                    Texto = "Você pode brincar perto do fogão quando ele está ligado?",
                    Imagem = "imagens/fogao.png",
                    Alternativas = new string[] { "Sim, é divertido", "Não, é perigoso", "Só se estiver com amigos" },
                    RespostaCorreta = 1
                },
                new Pergunta {
                    Texto = "Antes de entrar no banho, o que deve ser feito?",
                    Imagem = "imagens/banho.png",
                    Alternativas = new string[] { "Testar a água com a mão", "Pular direto", "Colocar brinquedos" },
                    RespostaCorreta = 0
                }
            };
        }

        private void MostrarPergunta()
        {
            if (indiceAtual < perguntas.Count)
            {
                var p = perguntas[indiceAtual];
                txtPergunta.Text = p.Texto;

                // imagem
                if (!string.IsNullOrEmpty(p.Imagem))
                    imgPergunta.Source = new BitmapImage(new System.Uri(p.Imagem, System.UriKind.Relative));

                // alternativas
                btnOpcao1.Content = p.Alternativas[0];
                btnOpcao2.Content = p.Alternativas[1];
                btnOpcao3.Content = p.Alternativas[2];

                txtFeedback.Text = "";
            }
            else
            {
                txtPergunta.Text = "Fim do Quiz! 🎉";
                imgPergunta.Source = null;
                btnOpcao1.Visibility = Visibility.Collapsed;
                btnOpcao2.Visibility = Visibility.Collapsed;
                btnOpcao3.Visibility = Visibility.Collapsed;
                txtFeedback.Text = $"Pontuação final: {pontuacao}/{perguntas.Count}";
            }
        }

        private void btnOpcao_Click(object sender, RoutedEventArgs e)
        {
            if (indiceAtual >= perguntas.Count) return;

            var botao = sender as Button;
            int respostaSelecionada = 0;

            if (botao == btnOpcao1) respostaSelecionada = 0;
            else if (botao == btnOpcao2) respostaSelecionada = 1;
            else if (botao == btnOpcao3) respostaSelecionada = 2;

            if (respostaSelecionada == perguntas[indiceAtual].RespostaCorreta)
            {
                pontuacao++;
                txtFeedback.Text = "✅ Acertou! Muito bem!";
                txtFeedback.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                txtFeedback.Text = "❌ Ops! Tente de novo!";
                txtFeedback.Foreground = System.Windows.Media.Brushes.Red;
            }

            txtPontuacao.Text = $"Pontuação: {pontuacao}";
            indiceAtual++;
            MostrarPergunta();
        }
    }
}
