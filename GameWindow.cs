using System;        //Basis - Giver adgang til Enum, Random
using Avalonia;     // Avalonia base
using Avalonia.Controls;  // Kontrollere
using Avalonia.Interactivity;  //Event-typer 
using Avalonia.Layout;        // Layout
using Avalonia.Media;         // Styling

namespace AvaloniaApplication2_week5_RPSSL_GUI;

public class GameWindow : Window
{
    //Spillets mulige udfald
    enum Shape { Rock=0, Paper=1, Scissors=2, Lizard=3, Spock=4 }
    enum Result { Tie, PlayerWins, BotWins }

    //Felterne der bliver opdateret efter hver runde
    private TextBlock _botPick = new() { Margin = new Thickness(12), FontSize = 14 };
    private TextBlock _round   = new() { Margin = new Thickness(12), FontSize = 16 };
    private TextBlock _youTxt  = new();
    private TextBlock _botTxt  = new();
    
    //Score
    private int _you, _bot;

    public GameWindow()
    {
        Title = "RPSSL (Rock Paper Scissors Lizard Spock)";   //Title i det vindue som popper frem, når koderne kører 
        Width = 420; Height = 360;  //Størrelse

        // Række med knap valg 
        var rowButtons = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 8, Margin = new Thickness(12), HorizontalAlignment = HorizontalAlignment.Center };
        foreach (var name in new[] { "Rock", "Paper", "Scissors", "Lizard", "Spock" })
        {
            var b = new Button { Content = name, Tag = name };  //Gemmer valg-navn
            b.Click += OnPick;   //Når der klikkes - Spil en runde
            rowButtons.Children.Add(b);
        }

        // Scorepanel
        var score = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 16, Margin = new Thickness(12) };
        score.Children.Add(new TextBlock { Text = "Score:", FontWeight = FontWeight.Bold });
        score.Children.Add(_youTxt);
        score.Children.Add(_botTxt);

        //Reset-knap - Nulstiller score og tekster 
        var reset = new Button { Content = "Reset score", Margin = new Thickness(12), HorizontalAlignment = HorizontalAlignment.Center };
        reset.Click += (_, __) => { _you = _bot = 0; _round.Text = "Scores reset."; _botPick.Text = ""; UpdateScore(); };

        // Grid layout med 5 rækker 
        var grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition(GridLength.Auto), new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto), new RowDefinition(1, GridUnitType.Star),
                new RowDefinition(GridLength.Auto)
            }
        };
        Grid.SetRow(rowButtons, 0);  grid.Children.Add(rowButtons);
        Grid.SetRow(_botPick, 1);    grid.Children.Add(_botPick);
        Grid.SetRow(_round, 2);      grid.Children.Add(_round);
        Grid.SetRow(score, 3);       grid.Children.Add(score);
        Grid.SetRow(reset, 4);       grid.Children.Add(reset);

        Content = grid;  //Vinduets indhold
        UpdateScore();
    }

    //Event-handler: Kører hver gang en bruger klikker på en af knapperne
    private void OnPick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button b || b.Tag is null) return; //Sikkerhedstjek
        var player = Enum.Parse<Shape>(b.Tag.ToString()!, true);   //Læser spillerens valg
        var bot = (Shape)Random.Shared.Next(0, 5);  //Der vælges tilfældigt 

        // Fra opgave 29 - diff=p2-p1 afgør udfaldet
        int diff = (int)bot - (int)player;
        //Switch for korthed
        var res = diff switch
        {
            0 => Result.Tie,
            -4 or -2 or 1 or 3 => Result.PlayerWins,
            -3 or -1 or 2 or 4 => Result.BotWins,
            _ => Result.Tie
        };

        //Opdater score 
        if (res == Result.PlayerWins) _you++;
        else if (res == Result.BotWins) _bot++;

        //OPdater UI-tekster for runden 
        _botPick.Text = $"Agent picked: {bot}";
        _round.Text   = res switch { Result.Tie => "Tie", Result.PlayerWins => "You win!", _ => "Agent wins!" };
        UpdateScore();
    }

    // Viser score i de to Tekstblokke
    private void UpdateScore()
    {
        _youTxt.Text = $"You: {_you}";
        _botTxt.Text = $"Agent: {_bot}";
    }
}

//Forklaringer
    // "Tag" på knapperne bruges til at gemme hvilken form knappen repræsentere, så man kan enrum.parse den i onpick
    // "Random.Shared.Next(0,5)" Returnere 0-4 - Denne matcher Shape-enum
    // diff switch implementerer tabellen fra opgave 29 på en linje 
    // UpdateScore er en central metode der kun tegner score-teksten, så man undgår en duplikeret kode 
