using Patagames.Pdf.Enums;
using Patagames.Pdf.Net;

using PdfViewer.Core.PDFViewer;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PdfViewer.Core
{
    public class PdfViewer : Selector
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

        private static void OnFileSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            /// <summary>
            /// Render whole PDF document using C# PDF Library
            /// </summary>
            var viewer = d as PdfViewer;
            string? path = e.NewValue.ToString();
            if (viewer != null && path != null)
            {
                ObservableCollection<PageItemData> itemSource = new ObservableCollection<PageItemData>();

                using var doc = PdfDocument.Load(path); // C# Read PDF Document
                foreach (var page in doc.Pages)
                {
                    int width = (int)(page.Width / 72.0 * 96);
                    int height = (int)(page.Height / 72.0 * 96);
                    using var bitmap = new PdfBitmap(width, height, true);
                    bitmap.FillRect(0, 0, width, height, Patagames.Pdf.FS_COLOR.White);
                    page.Render(bitmap, 0, 0, width, height, PageRotate.Normal, RenderFlags.FPDF_LCD_TEXT);

                    System.Drawing.Image image = bitmap.GetImage();
                    var imageSource = BitmapSourceHelper.ConvertImageToBitmapSource(image);
                    itemSource.Add(new PageItemData(imageSource));
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
