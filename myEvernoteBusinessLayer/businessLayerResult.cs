using MyEvernoteEntities;
using MyEvernoteEntities.errorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEvernoteBusinessLayer
{
   public  class businessLayerResult<T> where T:class
    {
        public List<errorMessageObj> errorMessage { get; set; }

        public T result { get; set; }

        public businessLayerResult()
        {
            errorMessage = new List<errorMessageObj>();
        }

        public void addError(errorMessageCode code, string message) {

            errorMessage.Add(new errorMessageObj() { code=code, errorMessage=message});

        }
    }
}
