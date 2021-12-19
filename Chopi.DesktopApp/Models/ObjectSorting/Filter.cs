using Chopi.Modules.Share.Abstracts;

namespace Chopi.DesktopApp.Models.ObjectSorting
{
    internal class Filter : BaseSelector
    {
        public Filter(string title, string property)
            : base(title)
        {
            Property = property;
        }

        public string Property { get; set; }

        public bool IsEqual<T>(T entity, string search)
            where T : CachedObject
        {
            if (string.IsNullOrEmpty(search))
                return true;

            var obj = entity[Property];
            
            if (obj is null)
                return false;

            return obj.ToString().ToLower().Contains(search.ToLower());
        }
    }
}
