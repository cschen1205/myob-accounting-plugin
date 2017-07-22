using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Data
{
    public class TreeNode <T> 
    {
        public delegate double GetTreeNodeValue(T _obj);
        private GetTreeNodeValue mGetTreeNodeValue;

        private T mEntity;
        public T DataSource
        {
            get { return mEntity; }
        }

        public TreeNode<T> Find(T ent)
        {
            if (mEntity.Equals(ent)) return this;
            foreach (TreeNode<T> child_node in Children)
            {
                TreeNode<T> _obj = child_node.Find(ent);
                if (_obj != null) return _obj;
            }
            return null;
        }

        private TreeNode<T> mRoot;
        public TreeNode<T> Root
        {
            set { mRoot = value; }
            get { return mRoot; }
        }

        private TreeNode<T> mParent;
        public TreeNode<T> Parent
        {
            set { mParent = value; }
            get { return mParent; }
        }

        public double Percent
        {
            get
            {
                if (this == mRoot) return 100;

                double total = mGetTreeNodeValue(mRoot.DataSource);
                if (total == 0)
                {
                    return 0;
                }

                return mGetTreeNodeValue(DataSource) * 100 / total;
            }
        }

        private List<TreeNode<T> > mChildren=new List<TreeNode<T> >();
        public List<TreeNode<T> > Children
        {
            get { return mChildren; }
        }

        public TreeNode(T ent, GetTreeNodeValue delegate1)
        {
            mGetTreeNodeValue = delegate1;
            mEntity = ent;
        }

        public void AddChild(TreeNode<T> node)
        {
            node.Root = this.Root;
            node.Parent = this;
            mChildren.Add(node);
        }
    }
}
