using System;
using System.Collections.Generic;
using System.Text;
using enigma_core.Interfaces;
using enigma_core.Models;

namespace enigma_core.Validators
{
    public class RespuestasValidator : IModelValidator<Respuesta>
    {
        private Respuesta _model = new Respuesta();
        private Respuesta _modelToValidate;
        private List<string> _errors= new List<string>();

        public Respuesta model { get => _model; set => _model=value; }
        public Respuesta modelToValidate { set => _modelToValidate = value; }

        public List<string> errors => _errors;

        public RespuestasValidator(Respuesta modelToValidate)
        {
            _modelToValidate = modelToValidate;
        }

        public bool validateModel()
        {
            if (_modelToValidate == null)
            {
                _errors.Add("model is empty");
                return false;
            }

            if (_modelToValidate.edadDesde <= 0) _errors.Add("Edad desde es 0 o menor a 0");
            if (_modelToValidate.edadDesde <= 10) _errors.Add("Edad desde es menor a 10");
            if (_modelToValidate.edadHasta <= 0) _errors.Add("Edad hasta es 0 o menor a 0");
            if (_modelToValidate.edadHasta <= 10) _errors.Add("Edad hasta es menor a 10");
            if (_modelToValidate.edadHasta >= 100) _errors.Add("Edad ya no valida mas de 100 años");
            if (string.IsNullOrEmpty(_modelToValidate.respuesta))
            {
                _errors.Add("Respuesta esta vacia");
                return false;
            }
            if (_modelToValidate.respuesta.Length > 100) _errors.Add("Respuesta demaciado larga");



            return (_errors.Count>0) ? false :true;
        }
    }
}
