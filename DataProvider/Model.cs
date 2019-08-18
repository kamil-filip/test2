using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{


    public abstract class BaseNodeViewModel : INotifyPropertyChanged
    {
        public BaseNodeViewModel(string name)
        {
            Name = name;
        }

        private string _name;

        public string Name
        { get
            {
                return _name;
            }

            set
            {
                _name = value;
               
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    
    public class NodeViewModel : BaseNodeViewModel, INotifyCollectionChanged
    {
        public NodeViewModel(string name) : base(name)
        {
            Children = new ObservableCollection<BaseNodeViewModel>();
         //   Children.CollectionChanged += Children_CollectionChanged;

                           // Children.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

        }

        private void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged.Invoke(sender, e);
        }



        private ObservableCollection<BaseNodeViewModel> _children;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableCollection<BaseNodeViewModel> Children
        { get
            {
                return _children;
            }
            set
            {
                _children = value;
              //  _punchDetailModels.CollectionChanged += handler;

            }

        } 
    }

    public class UnderlyingViewModel : BaseNodeViewModel
    {
        public UnderlyingViewModel(string name) : base(name)
        {
        }

        public string Id { get; set; }
    } 
}
