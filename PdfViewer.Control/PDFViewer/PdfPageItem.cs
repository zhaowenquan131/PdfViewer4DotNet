using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PdfViewer.Core
{
    internal class PdfPageItem : Control
    {

        static PdfPageItem()
        {
            var dictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/PdfViewer.Core;component/PDFViewer/PdfPageItemStyle.xaml")
            };

            // 将资源字典添加到当前控件的资源中
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
        public ImageSource PageItemSource
        {
            get { return (ImageSource)GetValue(PageItemSourceProperty); }
            set { SetValue(PageItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageItemSourceProperty =
            DependencyProperty.Register("PageItemSource", typeof(ImageSource), typeof(PdfPageItem), new PropertyMetadata(null));



        public Stretch ImageStretch
        {
            get { return (Stretch)GetValue(ImageStretchProperty); }
            set { SetValue(ImageStretchProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageStretch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageStretchProperty =
            DependencyProperty.Register("ImageStretch", typeof(Stretch), typeof(PdfPageItem), new PropertyMetadata(Stretch.None));



    }
}
