using System;
using System.Collections.Generic;
using System.Text;
using enigma_core.Repository;
using enigma_core.Models;
using enigma_core.Validators;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace enigma_core.Services
{
    public class RespuestasService
    {
        private RespuestasRepository respuestasRepository = new RespuestasRepository();

        public async Task<Respuesta> addRespuesta(Respuesta item)
        {
            await respuestasRepository.add(item);
            return (await respuestasRepository.getLastInsertedRespuesta())[0];
        }

        public async Task<List<Respuesta>> getAllItems()
        {
            return await respuestasRepository.getAll();
        }

        public async Task<Respuesta> getItem(string id)
        {
            return await respuestasRepository.getItemById(id);
        }

        public async Task<Respuesta> getLastItemInseted()
        {
            return (await respuestasRepository.getLastInsertedRespuesta())[0];
        }

        public async Task updateItem(string id, Respuesta newItem)
        {
            newItem.Id = new ObjectId(id);
            await respuestasRepository.update(newItem);
        }

        public async Task deleteItem(string id)
        {
            await respuestasRepository.delete(id);
        }

        public RespuestasValidator validate(Respuesta item)
        {
            return new RespuestasValidator(item);
        }

    }
}
