using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Chopi.DesktopApp.UserControls
{
    public partial class Paginator : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty RangeProperty =
            DependencyProperty.Register(nameof(Range), typeof(int), typeof(Paginator),
                new FrameworkPropertyMetadata(2, FrameworkPropertyMetadataOptions.Inherits, UpdatePages, null, false, UpdateSourceTrigger.PropertyChanged));

        private static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(int), typeof(Paginator),
                new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.Inherits, UpdatePages, null, false, UpdateSourceTrigger.PropertyChanged));

        public static readonly DependencyProperty MinPageProperty =
            DependencyProperty.Register(nameof(MinPage), typeof(int), typeof(Paginator),
                new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.Inherits, UpdatePages, null, false, UpdateSourceTrigger.PropertyChanged));

        public static readonly DependencyProperty MaxPageProperty =
            DependencyProperty.Register(nameof(MaxPage), typeof(int), typeof(Paginator),
                new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.Inherits, ChangeMaxPages, null, false, UpdateSourceTrigger.PropertyChanged));

        public Paginator()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #region Properties

        /// <summary>
        /// Диапазон страниц. Работает от центральной страницы, то есть, если диапазон - 2, то отображается 5 страниц (2 + 1 + 2)
        /// </summary>
        public int Range
        {
            get => (int)GetValue(RangeProperty);
            set => SetValue(RangeProperty, value);
        }

        /// <summary>
        /// Минимальная страница
        /// </summary>
        public int MinPage
        {
            get => (int)GetValue(MinPageProperty);
            set => SetValue(MinPageProperty, value);
        }

        /// <summary>
        /// Максимальная страница
        /// </summary>
        public int MaxPage
        {
            get => (int)GetValue(MaxPageProperty);
            set
            {
                if (value < MinPage)
                    return;

                SetValue(MaxPageProperty, value);
            }
        }

        /// <summary>
        /// Текущая страница
        /// </summary>
        public int CurrentPage
        {
            get => (int)GetValue(CurrentPageProperty);
            set
            {
                if (value < MinPage)
                    return;

                SetValue(CurrentPageProperty, value);
            }
        }

        /// <summary>
        /// Возвращает список страниц. Возвращаемые страницы зависят от текущей страницы и диапазона.
        /// Прожорливая штука, лучше найти замену ей.
        /// </summary>
        public IEnumerable<PageRecord> Pages
        {
            get
            {
                int start;
                int end;
                var min = MinPage + Range;
                var max = MaxPage - Range;

                if (CurrentPage < min)
                {
                    start = MinPage;
                    end = MinPage + Range * 2;
                }
                else if (CurrentPage > max)
                {
                    end = MaxPage;
                    start = MaxPage - Range * 2;
                }
                else
                {
                    start = CurrentPage - Range;
                    end = CurrentPage + Range;
                }

                if (start < MinPage)
                    start = MinPage;
                if (end > MaxPage)
                    end = MaxPage;

                for (int page = start; page <= end && page <= MaxPage; page++)
                {
                    yield return new PageRecord(page, page == CurrentPage);
                }
            }
        }

        #endregion
        #region Buttons

        private void GoFirst(object sender, RoutedEventArgs e)
        {
            if (CurrentPage != MinPage)
                CurrentPage = MinPage;
        }
        private void GoPrevious(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > MinPage)
                CurrentPage--;
        }
        private void GoNext(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < MaxPage)
                CurrentPage++;
        }
        private void GoLast(object sender, RoutedEventArgs e)
        {
            if (CurrentPage != MaxPage)
                CurrentPage = MaxPage;
        }

        /// <summary>
        /// Обработчик кликов по страницам
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Аргументы</param>
        private void GoPage(object sender, RoutedEventArgs e)
        {
            var send = (Button)sender;
            CurrentPage = ((PageRecord)send.DataContext).Number;
        }

        #endregion
        #region Events

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static void UpdatePages(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Paginator pag)
            {
                pag.OnPropertyChanged(nameof(pag.Pages));
            }
        }

        private static void ChangeMaxPages(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Paginator pag)
            {
                if (pag.MaxPage < pag.MinPage)
                {
                    pag.MaxPage = pag.MinPage;
                    return;
                }

                if (pag.CurrentPage > pag.MaxPage)
                    pag.CurrentPage = pag.MaxPage;

                pag.OnPropertyChanged(nameof(pag.Pages));
            }
        }

        #endregion
    }

    public record PageRecord
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Выбрана она или нет. От этого свойства зависит подстветка на UI.
        /// </summary>
        public bool IsSelected { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">Номер страницы</param>
        /// <param name="isSelected">Выбрана?</param>
        public PageRecord(int number, bool isSelected)
        {
            Number = number;
            IsSelected = isSelected;
        }
    }
}
