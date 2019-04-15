﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1026_Maximum_Difference
{
     public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaxAncestorDiff(TreeNode root)
        {
            var maxDiff = 0;
            var hashSet = new HashSet<int>();
            preorderTraversal(root, hashSet, ref maxDiff);

            return maxDiff;
        }

        private static void preorderTraversal(TreeNode root, HashSet<int> hashSet, ref int maxDiff)
        {
            hashSet.Add(root.val);

            if (root.left == root.right)
            {
                var array = hashSet.ToArray();
                var diff = Math.Abs(array.Max() - array.Min());
                maxDiff = maxDiff < diff ? diff : maxDiff;
                return;
            }

            if (root.left != null)
            {
                var newSet = new HashSet<int>(hashSet);
                preorderTraversal(root.left, newSet, ref maxDiff);
            }

            if (root.right != null)
            {
                var newSet = new HashSet<int>(hashSet);
                preorderTraversal(root.right, newSet, ref maxDiff);
            }
        }
    }
}
