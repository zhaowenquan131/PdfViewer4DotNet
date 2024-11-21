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
        public PageItemData(BitmapSource pageSource, BitmapSource pageItemSource)
        {
            PageSource = pageSource;
            PageItemSource = pageItemSource;
        }

        public BitmapSource PageSource { get; set; }

        public BitmapSource PageItemSource { get; set; }


    }
}
