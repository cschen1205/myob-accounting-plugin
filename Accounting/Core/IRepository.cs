using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Core
{
    public interface IRepository
    {
        void CreateTable();
        void RecreateTable();
        void InvalidateDataStore();
    }
}
