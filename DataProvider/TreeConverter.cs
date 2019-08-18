using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{

    public class TreeConverter<TSource> 
        where TSource : Underlying        
    {

        private ITreeWalker<Underlying, BaseNodeViewModel> _treeWalker;

        public TreeConverter()
        {
            TreeMap = new Dictionary<string, BaseNodeViewModel>();
            _treeWalker = new FlatTreeWalker();
        }

        protected Dictionary<string, BaseNodeViewModel> _treeMap;
        public Dictionary<string, BaseNodeViewModel> TreeMap
        {
            get
            {
                return _treeMap;
            }
            private set
            {
                _treeMap = value;
            }
        }

        public void AddOrUpdate(TSource endNode, ObservableCollection<BaseNodeViewModel> tree)
        {
            var path = _treeWalker.GetItemPath(endNode);
            if(!Update(path, endNode))
            {
                var pathNodes = _treeWalker.GetFlatTreeNodes(path);
                var endNodeKey = _treeWalker.GetEndNodeKey(pathNodes, TreeMap,
                    (node) =>
                    {
                        tree.Add(node as NodeViewModel);
                    });


                Add(endNodeKey, tree);
            }          
        }

     
        private void Add(object endNodeKey, ObservableCollection<BaseNodeViewModel> tree)
        {
           // throw new NotImplementedException();
        }

        private bool Update(string path, TSource endNode)
        {
            return false;
         //   throw new NotImplementedException();
        }

       


  
    }


  

}
