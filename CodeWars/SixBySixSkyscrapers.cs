//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CodeWars
//{
//    public class Skyscrapers
//    {
//        public static int[][] SolvePuzzle(int[] clues)
//        {
            
//            return null;
//        }

//        protected class SkyMapD
//        {
//            private int[][] _Map;
//            private int[][] _ClueRows;
//            private int[][] _ClueCols;

//            public SkyMapD(int[] clues)
//            {
//                InitClues(clues);
//                GenerateMap();
//            }

//            private void GenerateMap()
//            {
//                InitMap();
//                InitObviousClueOnMap();

//                TryMap(0, 0);
//            }

//            private bool TryMap(int y, int x)
//            {
//                if (y == 6)
//                    return true;

//                if (!ValidateMap(y, x))
//                    return false;

//                var nextY = x == 5 ? y + 1 : y;
//                var nextX = (x + 1) % 6;
//                if (_Map[y][x] > 0)
//                {
//                    var result = TryMap(nextY, nextX);
//                    if (result)
//                        return true;
//                }
//                else
//                {
//                    for (var i = 1; i <= 6; i++)
//                    {
//                        _Map[y][x] = i;
//                        var result = TryMap(nextY, nextX);

//                        if (result)
//                            return true;
//                    }
//                }

//                _Map[y][x] = 0;
//                return false;
//            }

//            private bool ValidateMap(int y, int x)
//            {
//                var result1 = ValidateRowCol(y, x);
//                var result2 = ValidateClues(y, x);
//                return result1 && result2;
//            }

//            private bool ValidateClues(int y, int x)
//            {
//                if (_ClueCols[x][0] > 0)
//                {
//                    var max = 0;
//                    var buildingCount = 0;
//                    for (var i = 0; i < 6; i++)
//                    {
//                        if (_Map[i][x] > max)
//                        {
//                            max = _Map[i][x];
//                            buildingCount++;
//                        }
//                    }

//                    if (_ClueCols[x][0] < buildingCount)
//                        return false;
//                }

//                if (_ClueCols[0][x] > 0)
//                {
//                    var max = 0;
//                    var buildingCount = 0;
//                    for (var i = 0; i < 6; i++)
//                    {
//                        if (_Map[i][x] > max)
//                        {
//                            max = _Map[i][x];
//                            buildingCount++;
//                        }
//                    }
//                }


//            }

//            private bool ValidateRowCol(int y, int x)
//            {
//                for (var i = 0; i < 6; i++)
//                {
//                    if (i != x && _Map[y][i] == _Map[y][x])
//                        return false;
//                    if (i != y && _Map[i][x] == _Map[y][x])
//                        return false;
//                }
//                return true;
//            }

//            private void InitMap()
//            {
//                _Map = new int[6][];
//                for(var i=0; i<6; i++)
//                    _Map[i] = new int[6];
//            }

//            private void InitObviousClueOnMap()
//            {
//                for (var i = 0; i < 6; i++)
//                {
//                    if (_ClueRows[i][0] == 6)
//                        for (var j = 0; j < 6; j++)
//                            _Map[j][i] = j + 1;
//                    else if (_ClueRows[i][1] == 6)
//                        for (var j = 0; j < 6; j++)
//                            _Map[j][i] = 6 - j;
//                    else if (_ClueRows[i][0] + _ClueRows[i][1] == 7)
//                        _Map[_ClueRows[i][0] - 1][i] = 6;

//                    if (_ClueCols[i][0] == 6)
//                        for (var j = 0; j < 6; j++)
//                            _Map[j][i] = j + 1;
//                    else if (_ClueCols[i][1] == 6)
//                        for (var j = 0; j < 6; j++)
//                            _Map[j][i] = 6 - j;
//                    else if (_ClueCols[i][0] + _ClueCols[i][1] == 7)
//                        _Map[_ClueCols[i][0] - 1][i] = 6;
//                }
//            }

//            private void InitClues(int[] clues)
//            {
//                _ClueRows = new int[6][];
//                _ClueCols = new int[6][];
//                for (var i = 0; i < 6; i++)
//                {
//                    _ClueRows[i] = new int[2];
//                    _ClueCols[i] = new int[2];
//                }
//                for (var i = 0; i < 6; i++)
//                {
//                    _ClueCols[i][0] = clues[i];
//                    _ClueRows[i][0] = clues[i + 6];
//                    _ClueCols[i][1] = clues[i + 12];
//                    _ClueRows[i][2] = clues[i + 18];
//                }
//            }
//        }
//    }
//}
