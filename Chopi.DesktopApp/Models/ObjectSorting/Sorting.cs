using Chopi.Modules.Share.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace Chopi.DesktopApp.Models.ObjectSorting
{
    abstract class Sorting : BaseSelector
    {
        public Sorting(string title) : base(title) { }

        public abstract IEnumerable<T> Order<T>(IEnumerable<T> collection, string property)
            where T : ObjectConteinered;
    }

    internal class OBy : Sorting
    {
        public OBy() : base("А-Я") { }

        public override IEnumerable<T> Order<T>(IEnumerable<T> collection, string property)
        {
            return
                from item in collection
                orderby item[property]
                select item;
        }
    }

    internal class ODistinct : Sorting
    {
        public ODistinct() : base("Я-А") { }

        public override IEnumerable<T> Order<T>(IEnumerable<T> collection, string property)
        {
            return
                from item in collection
                orderby item[property] descending
                select item;
        }
    }
}
