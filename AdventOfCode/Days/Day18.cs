using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day18 : ISolution
    {
        public string PartOne(string[] input)
        {
            var board = input.Select(x => x.ToCharArray().ToList()).ToList();
            
            for (var i = 0; i < 100; i++)
            {
                board = ProgressBoard(board);
            }

            return board
                .Select(x => x.Count(y => y == '#'))
                .Sum()
                .ToString();
        }
        
        private static List<List<char>> ProgressBoard(List<List<char>> board)
        {
            var jMax = board.Count;
            var iMax = board.First().Count;

            var newBoard = new List<List<char>>();
            for (var j = 0; j < jMax; j++)
            {
                newBoard.Add(new List<char>());
                for (var i = 0; i < iMax; i++)
                {
                    var neighbourIMin = i == 0 ? 0 : i - 1;
                    var neighbourJMin = j == 0 ? 0 : j - 1;
                    var neighbourIMax = i + 1 == iMax ? i : i + 1;
                    var neighbourJMax = j + 1 == jMax ? j : j + 1;

                    var neighbourCount = 0;
                    for (var jNeighbour = neighbourJMin; jNeighbour <= neighbourJMax; jNeighbour++)
                    for (var iNeighbour = neighbourIMin; iNeighbour <= neighbourIMax; iNeighbour++)
                    {
                        if (jNeighbour == j && iNeighbour == i)
                        {
                        }
                        else if (board[jNeighbour][iNeighbour] == '#')
                        {
                            neighbourCount++;
                        }
                    }

                    switch (board[j][i])
                    {
                        case '#' when (neighbourCount == 3 || neighbourCount == 2):
                            newBoard[j].Add('#');
                            break;
                        case '#':
                            newBoard[j].Add('.');
                            break;
                        case '.' when neighbourCount == 3:
                            newBoard[j].Add('#');
                            break;
                        case '.':
                            newBoard[j].Add('.');
                            break;
                    }
                }
            }

            return newBoard;
        }

        public string PartTwo(string[] input)
        {
            var board = input.Select(x => x.ToCharArray().ToList()).ToList();
            
            board[0][0] = '#';
            board[0][^1] = '#';
            board[^1][0] = '#';
            board[^1][^1] = '#';  
            
            for (var i = 0; i < 100; i++)
            {
                board = ProgressBoard(board);
                board[0][0] = '#';
                board[0][^1] = '#';
                board[^1][0] = '#';
                board[^1][^1] = '#';

            }

            return board
                .Select(x => x.Count(y => y == '#'))
                .Sum()
                .ToString();
        }


        public int Day => 18;
    }
}