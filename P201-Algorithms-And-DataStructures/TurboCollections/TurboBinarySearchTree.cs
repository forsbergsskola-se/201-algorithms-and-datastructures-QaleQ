using System.Collections;
using System.Security.Cryptography;

namespace TurboCollections;

public class TurboBinarySearchTree<T>
{
    readonly IComparable<T>[] _values = new IComparable<T>[1_000_000];
    public Node Root => new(0, this);
    int GetLeftChildIndex(int nodeIndex) => 2 * nodeIndex + 1;
    int GetRightChildIndex(int nodeIndex) => 2 * nodeIndex + 2;
    IComparable<T>? GetValue(int nodeIndex) => _values[nodeIndex];

    void SetValue(int nodeIndex, IComparable<T> value)
    {
        if (_values.Length <= nodeIndex) { /* resize */ }
        _values[nodeIndex] = value;
    }

    public Node? Search(IComparable<T> value)
    {
        Node currentNode = Root;
        while (currentNode.Value != null)
        {
            int difference = currentNode.Value.CompareTo((T)value);
            if (difference == 0) return currentNode;
            currentNode = difference > 0 ? currentNode.LeftChild : currentNode.RightChild;
        }
        return null;
    }
    
    public void Insert(IComparable<T> value)
    {
        Node currentNode = Root;
        while (currentNode.Value != null)
        {
            int difference = currentNode.Value.CompareTo((T)value);
            if (difference == 0) return;
            currentNode = difference > 0 ? currentNode.LeftChild : currentNode.RightChild;
        }
        SetValue(currentNode.NodeIndex, value);
    }

    public void Delete(IComparable<T> value)
    {
        // Node node = Search(value);
        // Node left = node.LeftChild;
        // Node right = node.RightChild;
        //
        // if (left.Value == null && right.Value == null) node.Value = null;
        // else if (left.Value == null || right.Value == null) node.Value = left.Value ?? right.Value;
        // else
        // {
        //     Node currentNode = left;
        //     while (currentNode.RightChild.Value != null) currentNode = currentNode.RightChild;
        //     node.Value = currentNode.Value;
        //     Node currentNodeLeftChild = currentNode.LeftChild;
        //     currentNodeLeftChild.Value = currentNode.Value;
        // }
    }

    public IEnumerable<T> GetInPostOrder(Node node)
    {
        if (node.LeftChild.Value != null)
            foreach (var n in GetInOrder(node.LeftChild))
                yield return n;
        if (node.RightChild.Value != null)
            foreach (var n in GetInOrder(node.RightChild))
                yield return n;
        yield return (T)node.Value;
    }

    public IEnumerable<T> GetInOrder(Node node)
    {
        if (node.LeftChild.Value != null)
            foreach (var n in GetInOrder(node.LeftChild))
                yield return n;
        yield return (T)node.Value;
        if (node.RightChild.Value != null)
            foreach (var n in GetInOrder(node.RightChild))
                yield return n;
    }
    public IEnumerable<T> GetEnumerator => GetInOrder(Root);
    
    
    public IEnumerable<T> GetInReverseOrder(Node node)
    {
        if (node.RightChild.Value != null)
            foreach (var n in GetInReverseOrder(node.RightChild))
                yield return n;
        yield return (T)node.Value;
        if (node.LeftChild.Value != null)
            foreach (var n in GetInReverseOrder(node.LeftChild))
                yield return n;
    }

    public readonly struct Node
    {
        public readonly int NodeIndex;
        readonly TurboBinarySearchTree<T> _tree;

        public IComparable<T>? Value
        {
            get => _tree.GetValue(NodeIndex);
            set => _tree.SetValue(NodeIndex, value);
        }

        public Node(int nodeIndex, TurboBinarySearchTree<T> tree)
        {
            NodeIndex = nodeIndex;
            _tree = tree;
        }

        public Node LeftChild => new(_tree.GetLeftChildIndex(NodeIndex), _tree);
        public Node RightChild => new(_tree.GetRightChildIndex(NodeIndex), _tree);
    }
}