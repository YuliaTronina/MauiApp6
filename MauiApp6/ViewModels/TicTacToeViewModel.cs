using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp6.Model;
using System.IO;


namespace MauiApp6.ViewModels
{
    public partial class TicTacToeViewModel:ObservableObject
    {
        //private readonly List<string> _players = new() { "X", "O" };
        //private int _currentPlayerIndex;
        //private bool _isGameOver;

        //[ObservableProperty]
        //private string currentPlayerText = "Ходит X";

        //[ObservableProperty]
        //private ObservableCollection<Field> fields = new();
     
      
        //[RelayCommand]
        //public void ButtonCommand(Field field)
        //  {
            
        //    if (_isGameOver || !string.IsNullOrEmpty(field.Value))
        //    {
        //        return;
        //    }

        //    field.Value = _players[_currentPlayerIndex];
        //    CurrentPlayerText = $"Ходит {_players[(_currentPlayerIndex + 1) % _players.Count]}";
        //    CheckWinCondition();
        //    NextTurn();
        //}

        //[RelayCommand]
        //public void NewGame()
        //{
        //    foreach (var field in Fields)
        //    {
        //        field.Value = "";
        //    }
        //    _currentPlayerIndex = 0;
        //    isGameOver = false;
        //    CurrentPlayerText = "Ходит X";
        //}

        //private void CheckWinCondition()
        //{
        //    var winningCombinations = new[]
        //    {
        //    // Горизонтальные линии
        //    new[] { 0, 1, 2 },
        //    new[] { 3, 4, 5 },
        //    new[] { 6, 7, 8 },
        //    // Вертикальные линии
        //    new[] { 0, 3, 6 },
        //    new[] { 1, 4, 7 },
        //    new[] { 2, 5, 8 },
        //    // Диагонали
        //    new[] { 0, 4, 8 },
        //    new[] { 2, 4, 6 }
        //};

        //    foreach (var combination in winningCombinations)
        //    {
        //        if (Fields[combination[0]].Value == Fields[combination[1]].Value &&
        //            Fields[combination[1]].Value == Fields[combination[2]].Value &&
        //            !string.IsNullOrEmpty(Fields[combination[0]].Value))
        //        {
        //            isGameOver = true;
        //            CurrentPlayerText = $"{_players[_currentPlayerIndex]} победил!";
        //            return;
        //        }
        //    }

        //    // Проверяем на ничью
        //    if (Fields.All(c => !string.IsNullOrEmpty(c.Value)))
        //    {
        //        isGameOver = true;
        //        CurrentPlayerText = "Ничья!";
        //    }
        //}

        //private void NextTurn()
        //{
        //    _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        //}


        private readonly List<string> _players = new() { "X", "O" };
        private int _currentPlayerIndex;
        
        [ObservableProperty]
        private bool _isGameOver;


        [ObservableProperty]
        private string currentPlayerText = "Ходит X";

        [ObservableProperty]
        private ObservableCollection<Field> fields = new();

        [RelayCommand]
        public void ButtonCommand(Field field)
        {
            if (_isGameOver || !string.IsNullOrEmpty(field.Value))
            {
                return;
            }

            field.Value = _players[_currentPlayerIndex];
            CurrentPlayerText = $"Ходит {_players[(_currentPlayerIndex + 1) % _players.Count]}";
            CheckWinCondition();
            NextTurn();
        }

        [RelayCommand]
        public void NewGame()
        {
            foreach (var field in Fields)
            {
                field.Value = "";
            }
            _currentPlayerIndex = 0;
            IsGameOver = false;
            CurrentPlayerText = "Ходит X";
        }

        private void CheckWinCondition()
        {
            var winningCombinations = new[]
            {
            // Горизонтальные линии
            new[] { 0, 1, 2 },
            new[] { 3, 4, 5 },
            new[] { 6, 7, 8 },
            // Вертикальные линии
            new[] { 0, 3, 6 },
            new[] { 1, 4, 7 },
            new[] { 2, 5, 8 },
            // Диагонали
            new[] { 0, 4, 8 },
            new[] { 2, 4, 6 }
        };

            foreach (var combination in winningCombinations)
            {
                if (Fields[combination[0]].Value == Fields[combination[1]].Value &&
                    Fields[combination[1]].Value == Fields[combination[2]].Value &&
                    !string.IsNullOrEmpty(Fields[combination[0]].Value))
                {
                    IsGameOver = true;
                    CurrentPlayerText = $"{_players[_currentPlayerIndex]} победил!";
                    return;
                }
            }

            // Проверяем на ничью
            if (Fields.All(c => !string.IsNullOrEmpty(c.Value)))
            {
                IsGameOver = true;
                CurrentPlayerText = "Ничья!";
            }
        }

        private void NextTurn()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }

        public TicTacToeViewModel()
        {
            for (int i = 0; i < 9; i++)
            {
                Fields.Add(new Field());
            }
        }

    }
}
