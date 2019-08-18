using DataProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
  /*  INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }*/

    public partial class MainWindow : Window
    {

        public ObservableCollection<BaseNodeViewModel> MyData { get; set; } = new ObservableCollection<BaseNodeViewModel>();

        public MainWindow()
        {
            InitializeComponent();

            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            //worker.RunWorkerCompleted += worker_RunWorkerCompleted;

        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        Underlying und;

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {

            UnderlyingGenerator dp = new UnderlyingGenerator();

            Action<int> workMethod = (i) => tc.AddOrUpdate(und, MyData);


            while (UnderlyingGenerator.counter < 32000)
            {

                und = dp.GetUnderlying();

                myTree.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                                workMethod, 0);
            }

        }

        TreeConverter<Underlying> tc;

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
                    
        }

        private readonly BackgroundWorker worker = new BackgroundWorker();


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tc = new TreeConverter<Underlying>();
            worker.RunWorkerAsync();


            //            


            //          UnderlyingGenerator.counter = 0;


            //var t = MyData.ElementAt(0) as NodeViewModel;

            //t.Children.ElementAt(0).Name = "2";

            //  tc.TreeMap.ElementAt(0).Value.Name = "yest1";

            //tc.TreeMap["Level0\\Some1\\cat1"].Name = "yea yea yea";
            //(tc.TreeMap["Level0\\Some1\\cat1"] as NodeViewModel).Children.Add(new NodeViewModel("MyTest"));// = "yea yea yea";

        }
    }
}
