﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97_Interleave_strings
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1 == null || s2 == null || s3 == null)
                return false;

            var length1 = s1.Length;
            var length2 = s2.Length;
            var length3 = s3.Length;

            if (length3 != length1 + length2)
                return false;

            if (length1 == 0)
                return s2.CompareTo(s3) == 0;

            if (length2 == 0)
                return s1.CompareTo(s3) == 0;

            var rows = length1 + 1;
            var columns = length2 + 1;
            var dp = new bool[rows, columns];

            dp[0, 0] = true;
            // base case
            for (int col = 1; col < columns; col++)
            {
                dp[0, col] = s2[col - 1] == s3[col - 1] && dp[0, col - 1];
            }

            for (int row = 1; row < rows; row++)
            {
                dp[row, 0] = s1[row - 1] == s3[row - 1] && dp[row - 1, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < columns; col++)
                {
                    var s1Char = s1[row - 1];
                    var s2Char = s2[col - 1];
                    var s3Char = s3[row + col - 1];  // bug: my first writing is row + col - 2

                    dp[row, col] = (s3Char == s1Char && (row - 1 >= 0 && dp[row - 1, col])) ||
                                   (s3Char == s2Char && (col - 1 >= 0 && dp[row, col - 1]));
                }
            }

            return dp[rows - 1, columns - 1];
        }
    }
}
