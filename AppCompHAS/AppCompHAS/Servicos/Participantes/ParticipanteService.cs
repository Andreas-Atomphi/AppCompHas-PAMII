using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AppCompHAS.Models;
using AppCompHAS.ViewModels.Participantes;
using System.Linq;


namespace AppCompHAS.Servicos.Participantes
{
    public class ParticipanteService : Request
    {
        private readonly Request _request;
        private const string ApiUrlBase = "http://rodds93.somee.com/CompApi/Participante";

        public ParticipanteService()
        {
            _request = new Request();
        }
        public async Task<Participante> PostLoginParticipanteAsync(Participante p)
        {
            string urlComplementar = "/CredenciaisParticipante";
            return await _request.PostAsync(ApiUrlBase + urlComplementar, p);
        }
    }
}
