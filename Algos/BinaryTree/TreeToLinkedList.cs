using System;
using System.Collections.Generic;

namespace Algos.BinaryTree
{
    public class TreeToLinkedList
    {
        public static void Test()
        {
            UnitTest(TreeNode.Create(new int?[] { 4, 2, 5, 1, 3, 6, 7 }));            
            UnitTest(TreeNode.Create(new int?[] { 1, 4, 4, null, 2, 2, null, 1, null, 6, 8, null, null, null, null, 1, 3 }));
        }

        private static void UnitTest(TreeNode root)
        {
            var lstInOrder = new List<int>();
            TreeNode.InOrder(root, lstInOrder);

            var converter = new TreeToLinkedList();
            converter.ConvertInOrder(root);

            var lstLinked = new List<int>();
            var llHead = converter.head;
            while (llHead != null)
            {
                lstLinked.Add(llHead.val);
                llHead = llHead.right;
            }

            string expected = string.Join(',', lstInOrder);
            string actual = string.Join(',', lstLinked);
            Console.WriteLine($"{expected == actual}, {expected};;; {actual}");
        }

        TreeNode head;
        TreeNode tail;
        public void ConvertInOrder(TreeNode root)
        {
            if (root == null) return;

            ConvertInOrder(root.left);

            if (head == null)
            {
                head = root;
            }
            else
            {
                tail.right = root;
                root.left = tail;
            }
            tail = root;

            ConvertInOrder(root.right);
        }

        //https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
        private void ConverPreOrder(TreeNode root)
        {
            if (root == null) return;
            TreeNode right = root.right;
            TreeNode left = root.left;
            root.left = null;
            root.left = null;
            if (head == null)
            {
                head = tail = root;                
            }
            else
            {
                tail.right = root;
                tail = root;
            }

            ConverPreOrder(left);
            ConverPreOrder(right);
        }

    }
}
