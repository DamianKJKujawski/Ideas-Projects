using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using BTree_Database.BTree_;



// TODO : ADD ENCRYPTION !

namespace BTree_Database
{
    [Serializable]
    public class BTree<T> where T : IComparable<T>
    {
        #region VARIABLES/PROPERTIES:

            private BTreeNode<T> root_;
            private readonly int degree_;

        #endregion



        #region INIT/DISPOSAL:

            public BTree(int degree)
            {
                this.degree_ = degree;
                root_ = new BTreeNode<T>();
            }

        #endregion



        #region PRIVATE:

            private void Insert_NonFull(BTreeNode<T> node, T key)
            {
                int _index = node.Keys.Count - 1;

                if (node.is_leaf)
                {
                    while (_index >= 0 && key.CompareTo(node.Keys[_index]) < 0) {
                    _index--;
                    }
                    node.Keys.Insert(_index + 1, key);
                }
                else
                {
                    while (_index >= 0 && key.CompareTo(node.Keys[_index]) < 0) {
                        _index--;
                    }

                    _index++;
                    if (node.Children[_index].Keys.Count == (2 * degree_) - 1)
                    {
                        Split_Child(node, _index);
                        if (key.CompareTo(node.Keys[_index]) > 0)
                            _index++;
                    }
                    Insert_NonFull(node.Children[_index], key);
                }
            }

            private void Split_Child(BTreeNode<T> parent, int childIndex)
            {
                BTreeNode<T> _child = parent.Children[childIndex];
                BTreeNode<T> _newChild = new BTreeNode<T>
                {
                    is_leaf = _child.is_leaf
                };

                for (int i = 0; i < degree_ - 1; i++)
                {
                    _newChild.Keys.Add(_child.Keys[degree_ + i]);
                    _child.Keys.RemoveAt(degree_ + i);
                }

                if (!_child.is_leaf)
                {
                    for (int i = 0; i < degree_; i++)
                    {
                        _newChild.Children.Add(_child.Children[degree_ + i]);
                    }
                    _child.Children.RemoveRange(degree_, degree_);
                }

                parent.Keys.Insert(childIndex, _child.Keys[degree_ - 1]);
                parent.Children.Insert(childIndex + 1, _newChild);
                _child.Keys.RemoveAt(degree_ - 1);
            }

            private void Traverse(BTreeNode<T> node)
            {
                if (node != null)
                {
                    for (int i = 0; i < node.Children.Count; i++)
                    {
                        Traverse(node.Children[i]);
                        if (i < node.Keys.Count)
                        {
                            Console.Write(node.Keys[i] + " ");
                        }
                    }
                }
            }

            private T Search(BTreeNode<T> node, T key)
            {
                int index = 0;
                while (index < node.Keys.Count && key.CompareTo(node.Keys[index]) > 0)
                {
                    index++;
                }
                if (index < node.Keys.Count && key.CompareTo(node.Keys[index]) == 0)
                {
                    return node.Keys[index];
                }
                else if (node.is_leaf)
                {
                    return default; // Key not found
                }
                else
                {
                    return Search(node.Children[index], key);
                }
            }

        #endregion



        #region PUBLIC:

            public void Insert(T key)
            {
                if (root_.Keys.Count == (2 * degree_) - 1)
                {
                    BTreeNode<T> newRoot = new BTreeNode<T>();
                    newRoot.Children.Add(root_);
                    Split_Child(newRoot, 0);
                    root_ = newRoot;
                }
                Insert_NonFull(root_, key);
            }

            public T Search(T key) {
                return Search(root_, key);
            }

            public void Traverse() {
                Traverse(root_);
            }



            public void Save_ToFile(string fileName)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fileStream, root_);
                    }
                    Console.WriteLine("B-tree saved to file: " + fileName);
                }
                catch (Exception ex) {
                    Console.WriteLine("Error saving B-tree to file: " + ex.Message);
                }
            }

            public void Load_FromFile(string fileName)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        root_ = (BTreeNode<T>)formatter.Deserialize(fileStream);
                    }
                    Console.WriteLine("B-tree loaded from file: " + fileName);
                }
                catch (Exception ex) {
                    Console.WriteLine("Error loading B-tree from file: " + ex.Message);
                }
            }

        #endregion
    }
}
