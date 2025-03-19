
using lab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class Comparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is not BankCard first || y is not BankCard second)
            {
                return 0;
            }
            else
            {
                return first.Number.CompareTo(second.Number);
            }
        }
    }
}