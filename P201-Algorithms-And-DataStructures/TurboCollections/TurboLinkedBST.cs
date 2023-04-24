// namespace TurboCollections;
//
// public class TurboLinkedBST<T>
// {
//     public TurboLinkedBST<IComparable<T>>? Left;
//     public TurboLinkedBST<IComparable<T>>? Right;
//     public T Value;
//
//     public TurboLinkedBST<T>? Search(IComparable<T> value)
//     {
//         TurboLinkedBST<T> currentNode = Root;
//         if (Root.Value.Equals(value)) return currentNode;
//         while (true)
//         {
//             if (currentNode.Value.CompareTo((T)value) > 0)
//             {
//                 if (currentNode.LeftChild.Value.Equals(null)) break;
//                 currentNode = currentNode.LeftChild;
//             }
//             else (currentNode.Value.CompareTo((T)value) < 0)
//             {
//                 if (currentNode.RightChild.Value.Equals(null)) break;
//                 currentNode = currentNode.RightChild;
//             }
//             if (currentNode.Value.Equals(value)) return currentNode;
//         }
//         return null;
//     }
// }