using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models
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
