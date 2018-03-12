using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;


namespace Infrastructure.ExceptionManager
{

    public class EmailLogger : IExceptionManager
    {

        public void Handle(Exception error)
        {
            // Exception handling code goes here....
        }

    }
}
