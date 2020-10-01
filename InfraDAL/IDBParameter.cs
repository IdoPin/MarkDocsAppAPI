using System;
using System.Collections.Generic;
using System.Text;

namespace DALContracts
{
    public interface IDBParameter
    {
        string ParameterName { get; set; }
        object Value { get; set; }
    }
}
