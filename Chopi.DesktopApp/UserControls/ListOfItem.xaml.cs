using System.Windows;
using System.Windows.Controls;

namespace Chopi.DesktopApp.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ListOfItem.xaml
    /// </summary>
    public partial class ListOfItem : UserControl
    {

        public static readonly DependencyProperty ListItemTemplateProperty =
            DependencyProperty.Register("ListItemTemplate", typeof(DataTemplate), typeof(ListOfItem), new PropertyMetadata(null));

        public static readonly DependencyProperty ListContextMenuProperty =
            DependencyProperty.Register("ListContextMenu", typeof(ContextMenu), typeof(ListOfItem), new PropertyMetadata(null));

        public ContextMenu ListContextMenu
        {
            get { return (ContextMenu)GetValue(ListContextMenuProperty); }
            set { SetValue(ListContextMenuProperty, value); }
        }

        public DataTemplate ListItemTemplate
        {
            get { return (DataTemplate)GetValue(ListItemTemplateProperty); }
            set { SetValue(ListItemTemplateProperty, value); }
        }

        public ListOfItem()
        {
            InitializeComponent();
        }
    }
}
