using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using enigma_core.Models;
using enigma_core.Validators;

namespace XUnitTests.enigma_core_tests.Validators
{
    public class RespuestasValidator_unitTest
    {

        private readonly ITestOutputHelper output;

        public RespuestasValidator_unitTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void test_Validator_EmptyModel()
        {
            
            RespuestasValidator validator = new RespuestasValidator(null);

            Assert.False(validator.validateModel());
        }

        [Fact]
        public void test_Validator_EdadDesde_LessThan0()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = -3;

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.True(validator.errors.Contains("Edad desde es 0 o menor a 0"));
        }

        [Fact]
        public void test_Validator_EdadDesde_ValidateAge10()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 10;

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.True(validator.errors.Contains("Edad desde es menor a 10"));
        }

        [Fact]
        public void test_Validator_EdadDesde_ValidateAge11()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 11;

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.False(validator.errors.Contains("Edad desde es 0 o menor a 0"));
        }

        [Fact]
        public void test_Validator_EdadHasta_LestThan0()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 11;
            resp.edadHasta = -19;

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.True(validator.errors.Contains("Edad hasta es 0 o menor a 0"));
        }

        [Fact]
        public void test_Validator_EdadHasta_ValidateAge10()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 11;
            resp.edadHasta = 10;

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.True(validator.errors.Contains("Edad hasta es menor a 10"));
        }

        [Fact]
        public void test_Validator_EdadHasta_ValidateAge11()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 11;
            resp.edadHasta = 11;

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.False(validator.errors.Contains("Edad hasta es menor a 10"));
        }

        [Fact]
        public void test_Validator_EdadHasta_ValidateAgeUntil100()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 11;
            resp.edadHasta = 1000;

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.True(validator.errors.Contains("Edad ya no valida mas de 100 años"));
        }

        [Fact]
        public void test_Validator_EdadHasta_ValidateRespuestaEmpty()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 11;
            resp.edadHasta = 1000;

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.True(validator.errors.Contains("Respuesta esta vacia"));
        }

        [Fact]
        public void test_Validator_EdadHasta_ValidateRespuestaMoreThan100chars()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 11;
            resp.edadHasta = 1000;
            resp.respuesta = "hznjobdrgvtkdzdyqqoqrovsqywndhuznyyrngpvmfeloaxwefzqlzxbtflibkrtdsfehrizmiokhqsuishlavofkdzlsynxnxzx23";

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.False(validator.validateModel());
            Assert.True(validator.errors.Contains("Respuesta demaciado larga"));
        }

        [Fact]
        public void test_Validator_EdadHasta_ValidateRespuestaOk()
        {
            Respuesta resp = new Respuesta();
            resp.edadDesde = 11;
            resp.edadHasta = 16;
            resp.respuesta = "Esta es una respusta valida";

            RespuestasValidator validator = new RespuestasValidator(resp);
            Assert.True(validator.validateModel());
            Assert.False(validator.errors.Count>0);
        }

    }
}
