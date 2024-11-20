using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PdfViewer.Core.PDFViewer
{
    internal class PageItemData
    {
        public BitmapSource PageSource { get; set; }

        public PageItemData(BitmapSource pageSource)
        {
            PageSource = pageSource;
        }
    }
}
