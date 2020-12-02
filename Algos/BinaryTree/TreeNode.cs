using System;
using System.Collections.Generic;

namespace Algos.BinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode Create(int?[] arrNodes)
        {
            TreeNode root = new TreeNode(arrNodes[0] ?? 0);

            var lastLevel = new List<TreeNode> { root };

            int i = 0;
            while (i < arrNodes.Length - 1)
            {
                var newLevel = new List<TreeNode>();
                for (int j = 0; j < lastLevel.Count; j++)
                {
                    if (i == arrNodes.Length - 1) break;

                    var val = arrNodes[++i];

                    if (val != null)
                    {
                        lastLevel[j].left = new TreeNode(val.Value);
                        newLevel.Add(lastLevel[j].left);
                    }

                    if (i == arrNodes.Length - 1) break;
                    val = arrNodes[++i];

                    if (val != null)
                    {
                        lastLevel[j].right = new TreeNode(val ?? 0);
                        newLevel.Add(lastLevel[j].right);
                    }
                }
                lastLevel = newLevel;
            }
            return root;
        }

        public static void InOrder(TreeNode root, List<int> result)
        {
            if (root == null) return;

            InOrder(root.left, result);

            result.Add(root.val);

            InOrder(root.right, result);
        }


        public static void PreOrder(TreeNode root, List<int> result)
        {
            if (root == null) ;

            result.Add(root.val);
            PreOrder(root.left, result);
            PreOrder(root.right, result);
        }
    }
}
