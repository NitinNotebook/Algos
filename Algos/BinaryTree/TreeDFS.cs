using System;
using System.Collections.Generic;

namespace Algos.BinaryTree
{
    public class TreeDFS
    {

        int maxDiameter = 0;
        public int FindHeight(TreeNode root)
        {
            if (root == null) return 0;

            int leftHeight = FindHeight(root.left);
            int rightHeight = FindHeight(root.right);
            maxDiameter = Math.Max(maxDiameter, 1 + leftHeight + rightHeight);
            return 1 + Math.Max(leftHeight, rightHeight);
        }


        public bool HasPathWithGivenSequence(TreeNode root, int[] sequence)
        {
            return HasPathWithGivenSequence_Helper(root, sequence, new int[] { });
        }

        private bool PathWithgivenSequence_helper(TreeNode root, int[] sequence, int index)
        {
            if (root == null) return index == sequence.Length;
            if (index == sequence.Length - 1 || sequence[index] != root.val) return false;

            return PathWithgivenSequence_helper(root.left, sequence, index + 1) || PathWithgivenSequence_helper(root.right, sequence, index + 1);
        }

        private bool HasPathWithGivenSequence_Helper(TreeNode root, int[] sequence, int[] prefix)
        {
            if (root == null) return false; //branch finished before sequence

            if (sequence[prefix.Length] != root.val) return false; //current char not matching in sequence, no pointing of pursuing further

            if (prefix.Length == sequence.Length - 1) return root.left == null && root.right == null; //last char match with the leaf node

            var newPrefix = new List<int>(prefix)
            {
                root.val
            };

            return HasPathWithGivenSequence_Helper(root.left, sequence, newPrefix.ToArray()) ||
                   HasPathWithGivenSequence_Helper(root.right, sequence, newPrefix.ToArray());
        }
        public void PrintPerimeter(TreeNode root)
        {
            var lstPerimeter = new List<int>();
            lstPerimeter.Add(root.val);
            LeftBoundary(root.left, lstPerimeter);
            LeafNodes(root, lstPerimeter);
            RightBoundary(root.right, lstPerimeter);
        }

        private void LeftBoundary(TreeNode root, List<int> boundary)
        {
            if (root == null) return;

            if (root.left != null)
            {
                boundary.Add(root.val);
                LeftBoundary(root.left, boundary);
            }
            else if (root.right != null)
            {
                boundary.Add(root.val);
                LeftBoundary(root.right, boundary);
            }
        }

        private void RightBoundary(TreeNode root, List<int> boundary)
        {
            if (root == null) return;

            if (root.right != null)
            {
                boundary.Add(root.val);
                RightBoundary(root.right, boundary);
            }
            else if (root.left != null)
            {
                boundary.Add(root.val);
                RightBoundary(root.left, boundary);
            }
        }

        private void LeafNodes(TreeNode root, List<int> boundary)
        {
            if (root == null) return;

            if (root.left == null && root.right == null) boundary.Add(root.val);

            LeafNodes(root.left, boundary);
            LeafNodes(root.right, boundary);
        }
    }
}
