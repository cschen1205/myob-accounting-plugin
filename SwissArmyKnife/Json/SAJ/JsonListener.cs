using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwissArmyKnife.Json.SAJ
{
    public interface IJsonListener
    {
        void header(string header);
        void data(string value);
        void arrayStart();
        void arrayEnd();
        void objectStart();
        void objectEnd();
    }
}
