using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace enigma_core.Models
{
    public class Pregunta
    {
        [BsonId]
        public ObjectId Id { set; get; }
        public int edadDesde { set; get; }
        public int edadHasta { set; get; }
        public string pregunta { set; get; }
        public List<Pregunta> variantesPreguntas { set; get; }
        public List<Respuesta> respuestasPosibles { set; get; }
        public bool activa { set; get; }

    }
}
