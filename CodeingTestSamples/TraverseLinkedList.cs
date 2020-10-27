using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	// Question : Given a linked list and two integers M and N. Traverse the linked list such that you retain M nodes then delete next N nodes, 
	// continue the same till the end of the linked list. 
	// For example, an input of M = 2, N = 2 Linked List: 1->2->3->4->5->6->7->8 should return Linked List: 1->2->5->6
	class TraverseLinkedList : IExecuter
	{
		public void Execute()
		{
			Console.WriteLine("Running Program Traverse LinkedList and Skip..\n");

			bool IsCompleted = false;

			while (!IsCompleted)
			{
				Console.Write("Enter nodes to keep : ");
				var inputkeep = Console.ReadLine();

				Console.Write("Enter nodes to delete : ");
				var inputdel = Console.ReadLine();

				if (int.TryParse(inputkeep, out int M) && int.TryParse(inputdel, out int N))
				{
					/* Initiallize LinkedList */
					LinkedList1 linkedList = new LinkedList1();
					linkedList.Push(1);
					linkedList.Push(2);
					linkedList.Push(3);
					linkedList.Push(4);
					linkedList.Push(5);
					linkedList.Push(6);
					linkedList.Push(7);
					linkedList.Push(8);

					Console.Write("\nGiven Linked List : ");
					linkedList.Print();

					SkipMdeleteN(ref linkedList, M, N);

					Console.Write("Output Linked List : ");
					linkedList.Print();

					IsCompleted = true;
				}
				else
					Console.WriteLine("Invalid Input, Try Again..");
			}
		}

		public void SkipMdeleteN(ref LinkedList1 linkedList, int nodesToKeep, int NodesToDel)
		{
			Node tempHead = linkedList.Head, temp;

			while (tempHead != null)
			{
				// Skip M Nodes
				for (int i = 1; i < nodesToKeep && tempHead.NextNode != null; i++)
					tempHead = tempHead.NextNode;

				// If we reached end of list, then return
				if (tempHead == null)
					return;

				// Start from next node and delete N nodes
				temp = tempHead.NextNode;
				for (int i = 1; i <= NodesToDel && temp != null; i++)
					temp = temp.NextNode;

				// Link the previous list with remaining nodes  
				tempHead.NextNode = temp;

				// Set current pointer for next iteration  
				tempHead = temp;
			}

		}
	}

	public class Node
	{
		internal int Data;
		internal Node NextNode;
		public Node(int data)
		{
			Data = data;
		}
	}

	class LinkedList1
	{
		internal Node Head;
		internal Node Current;

		/* Function to insert a node at the beginning */
		public void Push(int Data)
		{
			Node node = new Node(Data);

			/* Set head for the linked list */
			if (Head == null)
				Head = node;
			else if (Head.NextNode == null)
				Head.NextNode = node;

			/* Set the nextNode to newnode for CurrentNode */
			if (Current != null)
				Current.NextNode = node;

			/* move the current to point to the new node */
			Current = node;
		}

		public void Print()
		{
			Node temp = Head;
			while (temp != null)
			{
				Console.Write("{0} ", temp.Data);
				temp = temp.NextNode;
			}
			Console.Write("\n");
		}
	}
}
