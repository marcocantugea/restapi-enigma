using System;
using System.Collections.Generic;
using System.Text;

namespace enigma_core.Interfaces
{
    interface IModelValidator<T>
    {
        T model { set; get; }
        T modelToValidate { set; }
        List<string> errors { get; }
        bool validateModel();
    }
}
