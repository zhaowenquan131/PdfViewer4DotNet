using PdfViewer.Core.PDFViewer;

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace PdfViewer.Core
{
    public class PdfViewer : ListBox
    {

        static PdfViewer()
        {
            // 通过 Application.LoadComponent 加载资源文件
            var dictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/PdfViewer.Core;component/PDFViewer/PdfViewerStyle.xaml")
            };

            // 将资源字典添加到当前控件的资源中
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
        public string FileSource
        {
            get { return (string)GetValue(FileSourceProperty); }
            set { SetValue(FileSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileSourceProperty =
            DependencyProperty.Register("FileSource", typeof(string), typeof(PdfViewer), new PropertyMetadata(null, OnFileSourceChanged));



        public int PageWidth
        {
            get { return (int)GetValue(PageWidthProperty); }
            set { SetValue(PageWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageWidthProperty =
            DependencyProperty.Register("PageWidth", typeof(int), typeof(PdfViewer), new PropertyMetadata(2100));



        public int PageHeight
        {
            get { return (int)GetValue(PageHeightProperty); }
            set { SetValue(PageHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageHeightProperty =
            DependencyProperty.Register("PageHeight", typeof(int), typeof(PdfViewer), new PropertyMetadata(2970));


        public Stretch ItemStretch
        {
            get { return (Stretch)GetValue(ItemStretchProperty); }
            set { SetValue(ItemStretchProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemStretchProperty =
            DependencyProperty.Register("ItemStretch", typeof(Stretch), typeof(PdfViewer), new PropertyMetadata(Stretch.None));



        public Stretch PageStretch
        {
            get { return (Stretch)GetValue(PageStretchProperty); }
            set { SetValue(PageStretchProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageStretch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageStretchProperty =
            DependencyProperty.Register("PageStretch", typeof(Stretch), typeof(PdfViewer), new PropertyMetadata(Stretch.None));



        private static void OnFileSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            /// <summary>
            /// Render whole PDF document using C# PDF Library
            /// </summary>
            var viewer = d as PdfViewer;
            string? path = e.NewValue.ToString();
            if (viewer != null && path != null)
            {
                ObservableCollection<PageItemData> itemSource = [];

                // 使用 PdfiumViewer 渲染 PDF
                using PdfiumViewer.PdfDocument pdfDocument = PdfiumViewer.PdfDocument.Load(path);
                for (int i = 0; i < pdfDocument.PageCount; i++)
                {
                    // 渲染单页为 Bitmap
                    using var bitmapItem = pdfDocument.Render(i, 300, 300, true);
                    var pageItemSource = BitmapSourceHelper.ConvertImageToBitmapSource(bitmapItem);
                    using var bitmapPage = pdfDocument.Render(i, viewer.PageWidth, viewer.PageHeight, 100, 100, true);
                    var pageSource = BitmapSourceHelper.ConvertImageToBitmapSource(bitmapPage);
                    PageItemData pageItem = new(pageSource, pageItemSource);
                    itemSource.Add(pageItem);
                }

                viewer.ItemsSource = itemSource;
            }

        }

        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register("ItemWidth", typeof(double), typeof(PdfViewer), new PropertyMetadata(0.0));




        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register("ItemHeight", typeof(double), typeof(PdfViewer), new PropertyMetadata(0.0));


    }
}
