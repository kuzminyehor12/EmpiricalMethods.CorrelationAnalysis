using System;
using System.Collections.Generic;
using System.Text;

namespace EmpiricMethods_Lab1.DataProcessing.Validation
{
    public class MatrixException : Exception
    {
        public MatrixException() : base()
        {
                
        }

        public MatrixException(string msg) : base(msg)
        {
            
        }

        public MatrixException(string msg, Exception innerException) : base(msg, innerException)
        {
                
        }
    }
}
