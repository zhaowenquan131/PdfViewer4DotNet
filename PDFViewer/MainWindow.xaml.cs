using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PDFViewerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string PdfPath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            PdfPath = @"C:\Users\wenqu\Documents\WeChat Files\wxid_7bdy2yts3x0j21\FileStorage\File\2024-11\Final-ONCD-Technical-Report.pdf";
            DataContext = this;
        }
    }
}