using System;
using System.Collections.Generic;



namespace BTree_Database.BTree_
{
    [Serializable]
    public class BTreeNode<T> where T : IComparable<T>
    {
        #region VARIABLES/PROPERTIES:

            public List<T> Keys { get; private set; }
            public List<BTreeNode<T>> Children { get; private set; }
            public bool is_leaf;

        #endregion



        #region INIT/DISPOSAL:

            public BTreeNode()
            {
                Keys = new List<T>();
                Children = new List<BTreeNode<T>>();
                is_leaf = true;
            }

        #endregion



        #region PUBLIC:

            public int Get_ChildIndex(T key)
            {
                int _index = 0;
                while (_index < Keys.Count && key.CompareTo(Keys[_index]) > 0)
                {
                    _index++;
                }

                return _index;
            }

        #endregion
    }
}

