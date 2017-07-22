using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Core.Data
{
    public class Hierarchy<T>
    {
        IList<T> mEntities;
        Dictionary<int, List<TreeNode<T> >> mTreeHierarchy = new Dictionary<int, List<TreeNode<T> >>();

        public delegate int GetLevelDelegate(T _obj);
        public delegate bool IsParentDelegate(T parent, T child);
        

        private GetLevelDelegate mGetLevelDelegate;
        private IsParentDelegate mIsParentDelegate;

        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }

        public Hierarchy(IList<T> _grp, int rootLevel, GetLevelDelegate delegate1, IsParentDelegate delegate2, TreeNode<T>.GetTreeNodeValue delegate3)
        {
            mGetLevelDelegate = delegate1;
            mIsParentDelegate = delegate2;

             mEntities= _grp;

             MaxLevel = 0;
             MinLevel = 100000;
             int level = 0;
             foreach (T ent in mEntities)
             {
                 level = mGetLevelDelegate(ent);
                 if (level > MaxLevel) MaxLevel = level;
                 if (level < MinLevel) MinLevel = level;
             }

             for (int i = MinLevel; i <= MaxLevel; ++i)
             {
                 mTreeHierarchy[i]=new List<TreeNode<T> >();
             }
             
             foreach (T ent in mEntities)
             {
                 level = mGetLevelDelegate(ent);
                 mTreeHierarchy[level].Add(new TreeNode<T>(ent, delegate3));
             }

             level = MinLevel;
             while (level < MaxLevel)
             {
           
                 if (level == rootLevel)
                 {
                     foreach (TreeNode<T> node in mTreeHierarchy[level])
                     {
                         node.Root = node;
                     }
                 }
                foreach (TreeNode<T> node in mTreeHierarchy[level])
                {
                    foreach (TreeNode<T> child_node in mTreeHierarchy[level + 1])
                    {
                        if (mIsParentDelegate(node.DataSource, child_node.DataSource))
                        {
                            node.AddChild(child_node);
                        }
                    }
                }
                level++;
            }
        }

        public List<TreeNode<T> > getLevel(int level)
        {
            return mTreeHierarchy[level];
        }

        public TreeNode<T> Find(T ent)
        {
            foreach (TreeNode<T> node in getLevel(MinLevel))
            {
                TreeNode<T> _obj = node.Find(ent);
                if (_obj != null) return _obj;
            }
            return null;
        }

        public List<TreeNode<T> > this[int level]
        {
            get {
                return getLevel(level);
            }
        }
    }
}
