using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using enigma_core.Models;
using enigma_core.Repository;
using MongoDB.Driver;
using MongoDB.Bson;

namespace XUnitTests.core.enigma_core_tests.Repositories
{
    public class RespuestasRepository_unitTests
    {
        private readonly ITestOutputHelper output;

        public RespuestasRepository_unitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async void test_addItem()
        {
            RespuestasRepository respuestasRepo = new RespuestasRepository();

            Respuesta newRespuesta = new Respuesta();
            newRespuesta.edadDesde = 15;
            newRespuesta.edadHasta = 18;
            newRespuesta.activa = true;
            newRespuesta.respuesta = "Encontraras tu primer amor pronto";

            await respuestasRepo.add(newRespuesta);

            var filter = Builders<Respuesta>.Filter.Eq(s => s.respuesta, newRespuesta.respuesta);
            List<Respuesta> respuestasEncontradas = await respuestasRepo.find(filter);

            foreach (Respuesta item in respuestasEncontradas)
            {
                Assert.Equal(newRespuesta.respuesta, item.respuesta);
                await respuestasRepo.delete(item.Id.ToString());
            }

        }

        [Fact]
        public async void test_updateItem()
        {
            RespuestasRepository respuestasRepo = new RespuestasRepository();

            Respuesta newRespuesta = new Respuesta();
            newRespuesta.edadDesde = 15;
            newRespuesta.edadHasta = 18;
            newRespuesta.activa = true;
            newRespuesta.respuesta = "Encontraras tu primer amor pronto";

            await respuestasRepo.add(newRespuesta);

           
            var filter = Builders<Respuesta>.Filter.Eq(s => s.respuesta, "Encontraras tu primer amor pronto");
            List<Respuesta> respuestasEncontradas = await respuestasRepo.find(filter);

            Respuesta itemFound = respuestasEncontradas[0];

            itemFound.respuesta = "Pronto tu mejor amigo se mudara lejos";

            await respuestasRepo.update(itemFound);

            Respuesta updatedItem = await respuestasRepo.getItemById(itemFound.Id.ToString());
            Assert.Equal("Pronto tu mejor amigo se mudara lejos", updatedItem.respuesta);
            await respuestasRepo.delete(updatedItem.Id.ToString());

            //filter = Builders<Respuesta>.Filter.Eq(s => s.respuesta, itemFound.respuesta);
            //List<Respuesta> itemsUpdatedFound = await respuestasRepo.find(filter);

            //foreach (Respuesta itemfound in itemsUpdatedFound)
            //{
            //    Assert.Equal("Pronto tu mejor amigo se mudara lejos", itemfound.respuesta);
            //    await respuestasRepo.delete(itemfound.Id.ToString());
            //}

        }

        [Fact]
        public async void test_GetLasItem()
        {

            RespuestasRepository respuestasRepo = new RespuestasRepository();

            Respuesta newRespuesta = new Respuesta();
            newRespuesta.edadDesde = 15;
            newRespuesta.edadHasta = 18;
            newRespuesta.activa = true;
            newRespuesta.respuesta = "Encontraras tu primer amor pronto";

            await respuestasRepo.add(newRespuesta);

            Respuesta resp = (await respuestasRepo.getLastInsertedRespuesta())[0];

            Assert.Equal(resp.edadDesde, newRespuesta.edadDesde);
            Assert.Equal(resp.edadHasta, newRespuesta.edadHasta);
            Assert.Equal(resp.respuesta, newRespuesta.respuesta);

            await respuestasRepo.delete(resp.Id.ToString());

        }
    }
}
