using System;
using System.Collections.Generic;

namespace DataProvider
{
    public interface ITreeWalker<TSource, TOut>
    {
        string GetItemPath(TSource treeRoot);
        string[] GetFlatTreeNodes(string path);
        string GetEndNodeKey(string[] nodes, Dictionary<string, TOut> nodesTree, Action<object> addItem);
    }
}
