using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	class TreeNode
	{
		public int item;
		public TreeNode leftc;
		public TreeNode rightc;
		public void display()
		{
			Console.Write("[");
			Console.Write(item);
			Console.Write("]");
		}
	}
	class Tree
	{
		public TreeNode root;
		public Tree()
		{
			root = null;
		}
		public TreeNode ReturnRoot()
		{
			return root;
		}
		public void Insert(int id)
		{
			TreeNode newNode = new TreeNode();
			newNode.item = id;
			if (root == null)
				root = newNode;
			else
			{
				TreeNode current = root;
				TreeNode parent;
				while (true)
				{
					parent = current;
					if (id < current.item)
					{
						current = current.leftc;
						if (current == null)
						{
							parent.leftc = newNode;
							return;
						}
					}
					else
					{
						current = current.rightc;
						if (current == null)
						{
							parent.rightc = newNode;
							return;
						}
					}
				}
			}
		}
		public void Preorder(TreeNode Root)
		{
			if (Root != null)
			{
				Console.Write(Root.item + " ");
				Preorder(Root.leftc);
				Preorder(Root.rightc);
			}
		}
		public void Inorder(TreeNode Root)
		{
			if (Root != null)
			{
				Inorder(Root.leftc);
				Console.Write(Root.item + " ");
				Inorder(Root.rightc);
			}
		}
		public void Postorder(TreeNode Root)
		{
			if (Root != null)
			{
				Postorder(Root.leftc);
				Postorder(Root.rightc);
				Console.Write(Root.item + " ");
			}
		}
	}
	public class TreeSort : IExecuter
	{
		public void Execute()
		{
			Tree theTree = new Tree();
			theTree.Insert(20);
			theTree.Insert(25);
			theTree.Insert(45);
			theTree.Insert(15);
			theTree.Insert(67);
			theTree.Insert(43);
			theTree.Insert(80);
			theTree.Insert(33);
			theTree.Insert(67);
			theTree.Insert(99);
			theTree.Insert(91);
			Console.WriteLine("Inorder Traversal : ");
			theTree.Inorder(theTree.ReturnRoot());
			Console.WriteLine(" ");
			Console.WriteLine();
			Console.WriteLine("Preorder Traversal : ");
			theTree.Preorder(theTree.ReturnRoot());
			Console.WriteLine(" ");
			Console.WriteLine();
			Console.WriteLine("Postorder Traversal : ");
			theTree.Postorder(theTree.ReturnRoot());
			Console.WriteLine(" ");
			Console.ReadLine();
		}
	}
}

