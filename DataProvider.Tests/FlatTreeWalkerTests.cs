using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Tests
{
    [TestClass]
    public class FlatTreeWalkerTests
    {
        private ITreeWalker<Underlying, BaseNodeViewModel> _treeWalker;

        [TestInitialize]
        public void Initialize()
        {
            _treeWalker = new FlatTreeWalker();
            
        }




        
        [TestMethod]
        public void GetEndNodeKey_NewNodes_AddSubNodes()
        {
            var nodes = new string[] { "Level0", "Some0", "cat0", "dog0", "underlyingName0" };
            var treeMap = new Dictionary<string, BaseNodeViewModel>();
            var observable = new ObservableCollection<NodeViewModel>();

            observable.CollectionChanged += Observable_CollectionChanged;

            /*
            var output = _treeWalker.GetEndNodeKey(nodes, treeMap, (a) =>
            {
                observable.Add(a as NodeViewModel);
            });

            Assert.AreEqual(1, observable.Count);
            Assert.AreEqual(3, treeMap.Count);
            Assert.IsTrue(treeMap.ContainsKey("Level0\\Some0"));
            Assert.IsTrue(treeMap.ContainsKey("Level0\\Some0\\cat0"));
            Assert.IsTrue(treeMap.ContainsKey("Level0"));

    */

            observable.Add(new NodeViewModel("TT"));
            observable.ElementAt(0).Children.Add(new NodeViewModel("TEST"));
            observable.ElementAt(0).Name = "t";//Children.Add(new NodeViewModel("TEST"));

        //    (treeMap["Level0"] as NodeViewModel).Children.ElementAt(0).Name = "testtes";



        }

        private void Observable_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int i = 2;
        }

        private static BaseNodeViewModel AddSubNode(ObservableCollection<BaseNodeViewModel> tree, string name, BaseNodeViewModel parent)
        {
            var newChild = new NodeViewModel(name);
            if (parent == null)
            {
                tree.Add(newChild);
                parent = newChild;
            }
            else
            {
                (parent as NodeViewModel).Children.Add(newChild);                
            }
 
            return newChild;
        }


        [TestMethod]
        public void GetEndNodeKey_ExistingNodes_ReturnsKey()
        {
            var nodes = new string[] { "Level0", "Some0", "cat0", "dog0", "underlyingName0" };

            var treeMap = new Dictionary<string, BaseNodeViewModel>();
            treeMap.Add("Level0", new NodeViewModel("Level1"));
            treeMap.Add("Level0\\Some0", new NodeViewModel("Some0"));
            treeMap.Add("Level0\\Some0\\cat0", new NodeViewModel("cat0"));

            var endNodeKey = _treeWalker.GetEndNodeKey(nodes, treeMap, (a) => { } );

            Assert.AreEqual("Level0\\Some0\\cat0\\dog0\\underlyingName0", endNodeKey);
        }


        [DataTestMethod]
        [DataRow("ToRemove0;\\Level0\\Some0\\cat0\\dog0\\underlyingName0", "Level0\\Some0\\cat0\\dog0\\underlyingName0")]
        [DataRow("underlyingName0", "")]
        [DataRow("ToRemove0;\\Level0", "")]
        [DataRow("ToRemove0;\\Level0\\Some0", "Level0\\Some0")]
        public void GetItemPath_ValidSequence_ReturnsPath(string source , string expected)
        {
            var und = new Underlying(source, "Id0000");

            var output = _treeWalker.GetItemPath(und);

            Assert.AreEqual(expected, output);
        }
        
        [DataTestMethod]
        [DataRow("Level0\\Some0\\cat0\\dog0\\underlyingName0", 5)]
        [DataRow("Level0\\Some0", 2)]
        [DataRow("Level0\\", 0)]
        [DataRow("Level0", 0)]
        [DataRow("Level0\\Some0\\", 0)]
        [DataRow("", 0)]
        public void GetFlatTreeNodes_ValidPath_ReturnsExpectedNodesCount(string source, int expected)
        {
            var output = _treeWalker.GetFlatTreeNodes(source);

            Assert.AreEqual(expected, output.Length);
        }

        [TestMethod]
        public void GetFlatTreeNodes_ValidPath_ReturnsExpectedNodes()
        {
            var path = "Level0\\Some0\\cat0\\dog0\\underlyingName0";

            var output = _treeWalker.GetFlatTreeNodes(path);

            Assert.AreEqual("Level0", output[0]);
            Assert.AreEqual("Some0", output[1]);
            Assert.AreEqual("cat0", output[2]);
            Assert.AreEqual("dog0", output[3]);
            Assert.AreEqual("underlyingName0", output[4]);
        }
    }
}

