using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using System.Windows.Threading;
using System.Windows.Interop;
using GreatCavern2;

namespace GreatCavern2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string response = null;

        public void DisplayTextToFlowDoc(string line)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => {
                Test.Inlines.Add(new Run(line));
            }));
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => {
                Test.Inlines.Add("\n");
            }));
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => {
                FindScrollViewer(Scroller).ScrollToBottom(); 
            }));
        }

        public void DisplayLocationName(string line)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                textBlock.Text = line;
            }));
        }

        public void UpdateInv(List<string> inv)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                listView.ItemsSource = inv;
            }));
        }

        
        public void UpdateLocationImage(System.Drawing.Bitmap Image)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => {
                image.Source = Imaging.CreateBitmapSourceFromHBitmap(Image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }));
    
        }


        System.Threading.Thread t;

        private void FlowDocument_Loaded(object sender, RoutedEventArgs e)
        {
            t = new System.Threading.Thread(DoThisAllTheTime);
            t.Start();
        }

        public void DoThisAllTheTime()
        {
            Globals.WindowFrame = this;
            Program.Logic();
        }

        private void textBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((e.Key == Key.Enter && textBox.Text != null))
            {
                e.Handled = true;
                response = textBox.Text;
                Test.Inlines.Add(new Run(response));
                Test.Inlines.Add(new Run("\n"));
                textBox.Text = null;
                response = null; 
            }
        }

        private void The_Great_Cavern_2_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.I && !textBox.IsKeyboardFocused)
            {
                e.Handled = true;
                if (listView.Visibility == Visibility.Collapsed)
                {
                    listView.Visibility = Visibility.Visible;
                }
                else
                {
                    listView.Visibility = Visibility.Collapsed;
                }
            }
        }

        public void UpdateMap(System.Drawing.Bitmap Image)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                Map.Source = Imaging.CreateBitmapSourceFromHBitmap(Image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
              
            }));
        }

        // Weird Magic
        public static ScrollViewer FindScrollViewer(FlowDocumentScrollViewer flowDocumentScrollViewer)
        {
            if (VisualTreeHelper.GetChildrenCount(flowDocumentScrollViewer) == 0)
            {
                return null;
            }

            // Border is the first child of first child of a ScrolldocumentViewer
            DependencyObject firstChild = VisualTreeHelper.GetChild(flowDocumentScrollViewer, 0);
            if (firstChild == null)
            {
                return null;
            }

            Decorator border = VisualTreeHelper.GetChild(firstChild, 0) as Decorator;

            if (border == null)
            {
                return null;
            }

            return border.Child as ScrollViewer;
        }
    }

}
