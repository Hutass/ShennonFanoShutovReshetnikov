using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShennonFanoShutovReshetnikov
{
    #region Tree

    internal class TreeNode<T>
    {
        public static bool TREE_LEFT = true;
        public static bool TREE_RIGHT = false;

        private T _value;
        private TreeNode<T> _left;
        private TreeNode<T> _right;
        private int _count;

        public TreeNode(T value)
        {
            _value = value;
            _count = 0;
        }

        public TreeNode<T> this[bool trig]
        {
            get
            {
                if (trig) return _left;
                else return _right;
            }
        }

        public TreeNode<T> Root { get; private set; }
        public TreeNode<T> Left { get => _left; set { _left = value; _left.Count = _count + 1; } }
        public TreeNode<T> Right { get => _right; set { _right = value; _right.Count = _count + 1; } }
        public int Count { get => _count; private set => _count = value; }

        public T Value { get => _value; set => _value = value; }

        public virtual TreeNode<T> AddChild(T value, bool trig)
        {
            var node = new TreeNode<T>(value) { Root = this };
            node.Count = _count + 1;
            if (trig)
                _left = node;
            else
                _right = node;
            return node;
        }
        public virtual TreeNode<T> AddChild(TreeNode<T> value, bool trig)
        {
            value.Root = this;
            var node = value;
            node.Count = _count + 1;
            if (trig)
                _left = node;
            else
                _right = node;
            return node;
        }

        public bool RemoveChild(TreeNode<T> node, bool trig)
        {
            if (trig)
            {
                if (_left != null)
                { _left = null; return true; }
                else
                    return false;
            }
            else
            {
                if (_right != null)
                { _right = null; return true; }
                else
                    return false;
            }

        }

        public void ActionDo(Action<T> action)
        {
            action(Value);
            if (_left != null) _left.ActionDo(action);
            if (_right != null) _right.ActionDo(action);
        }
        public void ActionNodeDo(Action<TreeNode<T>> action)
        {
            action(this);
            if (_left != null) _left.ActionNodeDo(action);
            if (_right != null) _right.ActionNodeDo(action);
        }

    }
    #endregion

}
