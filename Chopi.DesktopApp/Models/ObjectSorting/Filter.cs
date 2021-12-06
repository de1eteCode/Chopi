namespace Chopi.DesktopApp.Models.ObjectSorting
{
    internal class Filter
    {
        public Filter(string title, string property)
        {
            Title = title;
            Property = property;
        }

        public string Title { get; set; }
        public string Property { get; set; }

        public bool IsEqual<T>(T obj, string serach)
            where T : class
        {
            if (obj is null)
                return false;

            if (string.IsNullOrEmpty(serach))
                return true;

            // todo: Реализовать фильтрацию

            return true;
        }
    }
}
