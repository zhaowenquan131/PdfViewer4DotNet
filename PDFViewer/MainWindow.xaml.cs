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
            PdfPath = @"D:\work\PDFsharp\assets\archives\grammar-by-example\GBE\ReferencePDFs\GDI 1.40\Paragraph-Footnotes.pdf";
            DataContext = this;
        }
    }
}