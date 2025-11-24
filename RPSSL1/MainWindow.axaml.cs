using Avalonia.Controls;
using System;

namespace RPSSL1
{
    public partial class MainWindow : Window
    {
        enum Shape
        {
            Rock,
            Paper,
            Scissors,
            Lizard,
            Spock
        }

        int humanScore = 0;
        int agentScore = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayRound(Shape human)
        {
            Random r = new Random();
            Shape agent = (Shape)r.Next(0, 5);

            int result = Resolve(human, agent);

            if (result == 0)
                ResultText.Text = $"Tie! You: {human}, Agent: {agent}";
            else if (result == 1)
            {
                humanScore++;
                ResultText.Text = $"You win! You: {human}, Agent: {agent}";
            }
            else
            {
                agentScore++;
                ResultText.Text = $"Agent wins! You: {human}, Agent: {agent}";
            }

            ScoreText.Text = $"Score: You {humanScore} - {agentScore} Agent";
        }

        private void Rock_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => PlayRound(Shape.Rock);
        private void Paper_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => PlayRound(Shape.Paper);
        private void Scissors_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => PlayRound(Shape.Scissors);
        private void Lizard_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => PlayRound(Shape.Lizard);
        private void Spock_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) => PlayRound(Shape.Spock);

        private int Resolve(Shape p1, Shape p2)
        {
            if (p1 == p2)
                return 0;

            int diff = (int)p1 - (int)p2;

            if (diff == -4 || diff == -2 || diff == 1 || diff == 3)
                return 1;

            return -1;
        }
    }
}