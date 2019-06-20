﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _518_coin_change_2___space
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// June 20, 2019
        /// study code:
        /// https://leetcode.com/problems/coin-change-2/discuss/99212/Knapsack-problem-Java-solution-with-thinking-process-O(nm)-Time-and-O(m)-Space
        /// Define the problem
        /// dp[i][j] : the number of combinations to make up amount j by using the first i types of coins
        /// state transitions:
        /// 1. not using the ith coin, only using the first i-1 coins to make up amount j, 
        /// then we have dp[i-1][j] ways.
        /// 2. using the ith coin, since we can use unlimited same coin, we need to know 
        /// how many ways to make up amount j - coins[i-1] by using first i coins(including ith), 
        /// which is dp[i][j-coins[i-1]]
        /// 
        /// Initialization: dp[i][0] = 1
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public static int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1]; 

            dp[0] = 1;          

            // space is optimized here as well. 
            foreach (var coin in coins)      
            {
                for (int value = coin; value <= amount; value++)         
                {
                    dp[value] += dp[value - coin];                                  
                }
            }

            return dp[amount];
        }
    }
}
