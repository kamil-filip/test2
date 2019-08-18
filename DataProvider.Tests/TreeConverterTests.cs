using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.Protected;
using Moq;

namespace DataProvider.Tests
{





    [TestClass]
    public class TreeConverterTests
    {

       // private TreeConverter<Underlying, BaseNodeViewModel> _treeConverter;

        [TestInitialize]
        public void Initialize()
        {
         //   _treeConverter = new TreeConverter<Underlying, BaseNodeViewModel>();
        }

        [TestMethod]
        public void GetTreeNode_ValidPath_ReturnsValidNbOfNodes()
        {
//            var testPath = "ToRemove0;\\Level0\\Some0\\cat0\\dog0\\underlyingName0";
//            var output = _treeConverter.GetTreeNodes()



                /*
                 mockCustomerNameFormatter.Protected()
                .Setup<string>("ProtectedFunction", ItExpr.IsAny<string>())
                .Returns("here can be any value")
                .Verifiable();
                */
        }

        /*   [TestMethod]
           public void AddOrUpdate_AddNewItemNewBranch_AddAsManyElementsAsValidNodesAreInThePath()
           {
               var und = new Underlying("ToRemove0;\\Level0\\Some0\\cat0\\dog0\\underlyingName0", "Id0000");
               var tree = new ObservableCollection<BaseNodeViewModel>();

               _treeConverter.AddOrUpdate(und, tree);

               Assert.AreEqual(5, _treeConverter.TreeMap.Count);
           }*/

        /*
                [TestMethod]
                public void AddOrUpdate_AddNewItemExistingBranch_UpdateExistingBranchWithNewChilds()
                {


                }

                [TestMethod]
                public void AddOrUpdate_AddNewItem_RaiseOnPropertyChangeEvent()
                {

                }

                [TestMethod]
                public void AddOrUpdate_UpdateItem_RaiseOnPropertyChangeEvent()
                {

                }

                [TestMethod]
                public void AddOrUpdate_AddNewItem_AddNothingAndLogWhenPathIsNotCorrect()
                {


                }


                [TestMethod]
                public void AddOrUpdate_UpdateExistingItem_EndNodeLevel()
                {

                }

                [TestMethod]
                public void AddOrUpdate_UpdateExistingItem_NodeLevel()
                {

                }
                */





    }
}
