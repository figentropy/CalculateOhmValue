using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;



namespace Infrastructure.ExceptionManager
{
    public class FileLogger : IExceptionManager
    {

        public void Handle(Exception error)
        {
            // Exception handling code goes here....
            // Use of a tool like Log4Net to assist with logging would be good (or whatever tool is standard for the organization).
        }

    }
}
