using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class FlatTreeWalker : ITreeWalker<Underlying, BaseNodeViewModel>
    {
        private const int LEAST_TREE_LEVEL = 2;
        private const string START_PATH_SEQ = ";\\";
        private const char NODE_DELIMITER = '\\';


        public string GetEndNodeKey(string[] nodes, Dictionary<string, BaseNodeViewModel> nodesTree, Action<object> addItem)
        {
            var key = nodes[0];
            var parent = default(BaseNodeViewModel);

            for(var i = 0; i < nodes.Length - LEAST_TREE_LEVEL; i++)
            {
                if(nodesTree.ContainsKey(key))
                {
                    parent = nodesTree[key];                    
                }
                else
                {                
                   var newChild = new NodeViewModel(nodes[i]);                   
                   if (parent == null)
                   {                       
                       addItem(newChild);
                   }
                   else
                   {
                       (parent as NodeViewModel).Children.Add(newChild);
                   }
                   parent = newChild;
                   nodesTree.Add(key, newChild);  
                }
                key += NODE_DELIMITER + nodes[i + 1];
            }
            
            key += NODE_DELIMITER + nodes[nodes.Length -1];

            return key;
        }

   
        public string[] GetFlatTreeNodes(string path)
        {
            if (string.IsNullOrEmpty(path))
                return new string[] { };

            var nodes = path.Split(NODE_DELIMITER);

            var lastElement = nodes.ElementAt(nodes.Length - 1);
            if (string.IsNullOrEmpty(lastElement))
                return new string[] { };

            return nodes.Length >= LEAST_TREE_LEVEL 
                ? nodes : new string[] { };
        }



        public string GetItemPath(Underlying treeRoot)
        {
            if (treeRoot == null)
            {
                //todo log
                return "";
            }
            if(string.IsNullOrEmpty(treeRoot.Id))
            {
                //
                return "";
            }
            if(string.IsNullOrEmpty(treeRoot.Path))
            {
                //
                return "";
            }           
            if(LEAST_TREE_LEVEL > treeRoot.Path.Count(f => f == NODE_DELIMITER))
            {

                return "";
            }

            var fromIndex = treeRoot.Path.IndexOf(START_PATH_SEQ);           
            var path = treeRoot.Path.Substring(fromIndex + START_PATH_SEQ.Length);

            return path;
        }
    }
}
