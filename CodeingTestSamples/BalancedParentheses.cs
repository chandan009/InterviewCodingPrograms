using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	public class BalancedParentheses : IExecuter
	{
		//Algorithm:

		//- Declare a character stack S.
		//- Now traverse the expression string exp.
		//- If the current character is a starting bracket (‘(‘ or ‘{‘ or ‘[‘) then push it to stack.
		//- If the current character is a closing bracket(‘)’ or ‘}’ or ‘]’) then pop from stack and if the popped character is the matching starting bracket then fine else parenthesis are not balanced.
		//- After complete traversal, if there is some starting bracket left in stack then “not balanced”

		public void Execute()
		{
			Console.Write("\nEnter expression : ");
			var inputExpression = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(inputExpression))
			{
				Console.WriteLine("Empty string!!");
				return;
			}

			if (AreParenthesisBalanced(inputExpression.ToCharArray()))
				Console.WriteLine("Balanced ");
			else
				Console.WriteLine("Not Balanced ");

		}

		private static bool AreParenthesisBalanced(char[] exp)
		{
			/* Declare an empty character stack */
			Stack<char> st = new Stack<char>();

			/* Traverse the given expression to  
                check matching parenthesis */
			for (int i = 0; i < exp.Length; i++)
			{

				/*If the exp[i] is a starting  
                    parenthesis then push it*/
				if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
					st.Push(exp[i]);

				/* If exp[i] is an ending parenthesis  
                    then pop from stack and check if the  
                    popped parenthesis is a matching pair*/
				if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
				{

					/* If we see an ending parenthesis without  
                        a pair then return false*/
					if (st.Count == 0)
					{
						return false;
					}

					/* Pop the top element from stack, if  
                        it is not a pair parenthesis of character  
                        then there is a mismatch. This happens for  
                        expressions like {(}) */
					else if (!isMatchingPair(st.Pop(), exp[i]))
					{
						return false;
					}
				}
			}

			/* If there is something left in expression  
                then there is a starting parenthesis without  
                a closing parenthesis */

			if (st.Count == 0)
				return true; /*balanced*/
			else
			{ /*not balanced*/
				return false;
			}
		}

		private static bool isMatchingPair(char character1, char character2)
		{
			if (character1 == '(' && character2 == ')')
				return true;
			else if (character1 == '{' && character2 == '}')
				return true;
			else if (character1 == '[' && character2 == ']')
				return true;
			else
				return false;
		}
	}
}
