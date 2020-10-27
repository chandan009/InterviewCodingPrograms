using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	public class ReverseLinkedList : IExecuter
	{
		// Question : Given a linked list, write a function to reverse every k nodes (where k is an input to the function).
		public void Execute()
		{
			Console.WriteLine("Running Program Reverse LinkedList in group..\n");

			bool IsCompleted = false;

			while (!IsCompleted)
			{
				Console.Write("Enter number of group nodes to reverse : ");
				var inputNum = Console.ReadLine();

				if (int.TryParse(inputNum, out int inputNumDigit))
				{
					LinkedList llist = new LinkedList();

					/* Constructed Linked List is 1->2->3->4->5->6->  
					7->8->8->9->null */
					llist.push(9);
					llist.push(8);
					llist.push(7);
					llist.push(6);
					llist.push(5);
					llist.push(4);
					llist.push(3);
					llist.push(2);
					llist.push(1);
					
					Console.WriteLine("\nGiven Linked List");
					llist.printList();

					llist.head = llist.reverse(llist.head, inputNumDigit);

					Console.WriteLine("\nReversed list\n");
					llist.printList();

					IsCompleted = true;
				}
				else
					Console.WriteLine("Invalid Input, Try Again..");
			}
		}
	}

	public class LinkedList
	{
		public Node head; // head of list  

		/* Linked list Node*/
		public class Node
		{
			public int data;
			public Node next;
			public Node(int d)
			{
				data = d;
				next = null;
			}
		}

		public Node reverse(Node head, int k)
		{
			Node current = head;
			Node next = null;
			Node prev = null;

			int count = 0;

			/* Reverse first k nodes of linked list */
			while (count < k && current != null)
			{
				next = current.next;
				current.next = prev;
				prev = current;
				current = next;
				count++;
			}

			/* next is now a pointer to (k+1)th node  
                Recursively call for the list starting from current.  
                And make rest of the list as next of first node */
			if (next != null)
				head.next = reverse(next, k);

			// prev is now head of input list  
			return prev;
		}


		/* Utility functions */

		/* Inserts a new Node at front of the list. */
		public void push(int new_data)
		{
			/* 1 & 2: Allocate the Node &  
                    Put in the data*/
			Node new_node = new Node(new_data);

			/* 3. Make next of new Node as head */
			new_node.next = head;

			/* 4. Move the head to point to new Node */
			head = new_node;
		}

		/* Function to print linked list */
		public void printList()
		{
			Node temp = head;
			while (temp != null)
			{
				Console.Write(temp.data + " ");
				temp = temp.next;
			}
			Console.WriteLine();
		}
	}
}
