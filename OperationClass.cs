using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GayaProject
{
    class OperationClass
    {
        public OperationType operation;
        public int operationID;
        public string operationName;

    }

    public enum OperationType
    {
        PLUS,
        MINUS,
        MIN,
        MAX,
        MULTIPLY,
        CONCAT,
    }
}
