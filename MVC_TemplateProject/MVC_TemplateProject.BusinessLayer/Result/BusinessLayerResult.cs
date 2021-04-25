using MVC_TemplateProject.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TemplateProject.BusinessLayer.Result
{
    public class BusinessLayerResult<T> where T : class
    {
        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }

        public List<ErrorMessageObj> Errors { get; set; }
        public T Result { get; set; }


        public void AddError(ErrorMessageCodes code, string message)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }
    }
}
