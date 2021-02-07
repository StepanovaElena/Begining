using System;
using System.Collections.Generic;
using System.Text;

namespace Begining
{
	public class Node
	{
		public int Data;		
		public Node Parent;
		public BinaryTree _tree;
		private Node _left;
		private Node _right;

		public Node(int value, Node parent, BinaryTree tree)
		{
			Data = value;
			Parent = parent;
			_tree = tree;
		}

		public Node Left
		{
			get
			{
				return _left;
			}

			internal set
			{
				_left = value;

				if (_left != null)
				{
					_left.Parent = this;
				}
			}
		}

		public Node Right
		{
			get
			{
				return _right;
			}

			internal set
			{
				_right = value;

				if (_right != null)
				{
					_right.Parent = this;
				}
			}
		}		

		internal void Balance()
		{
			if (RightHeight - LeftHeight > 1)
			{
				if (Right != null && Right.BalanceFactor < 0)
				{
					LeftRightRotation();
				}

				else
				{
					LeftRotation();
				}
			}
			else if (LeftHeight - RightHeight > 1)
			{
				if (Left != null && Left.BalanceFactor > 0)
				{
					RightLeftRotation();
				}
				else
				{
					RightRotation();
				}
			}
		}

		private int BalanceFactor
		{
			get
			{
				return RightHeight - LeftHeight;
			}
		}

		private int LeftHeight
		{
			get
			{
				return MaxChildHeight(Left);
			}
		}

		private int RightHeight
		{
			get
			{
				return MaxChildHeight(Right);
			}
		}

		private int MaxChildHeight(Node node)
		{
			if (node != null)
			{
				return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
			}

			return 0;
		}

		private void LeftRotation()
		{

			// До
			//     12(this)     
			//      \     
			//       15     
			//        \     
			//         25     
			//     
			// После     
			//       15     
			//      / \     
			//     12  25  

			
			Node newRoot = Right;
			ReplaceRoot(newRoot);    
			Right = newRoot.Left;    
			newRoot.Left = this;
		}

		private void RightRotation()
		{
			// Было
			//     c (this)     
			//    /     
			//   b     
			//  /     
			// a     
			//     
			// Стало    
			//       b     
			//      / \     
			//     a   c  
			
			Node newRoot = Left;
			ReplaceRoot(newRoot);
			Left = newRoot.Right; 
			newRoot.Right = this;
		}

		private void LeftRightRotation()
		{
			Right.RightRotation();
			LeftRotation();
		}

		private void RightLeftRotation()
		{
			Left.LeftRotation();
			RightRotation();
		}

		private void ReplaceRoot(Node newRoot)
		{
			if (this.Parent != null)
			{
				if (this.Parent.Left == this)
				{
					this.Parent.Left = newRoot;
				}
				else if (this.Parent.Right == this)
				{
					this.Parent.Right = newRoot;
				}
			}
			else
			{
				_tree.Root = newRoot;
			}

			newRoot.Parent = this.Parent;
			this.Parent = newRoot;
		}
	}
}
