using IdentityVerificationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCKimlikService;

namespace IdentityVerificationAPI.Business
{
    public class VerifyManager : IVerifyManager
    {
        public async Task<bool> VerifyPerson(Person person) {
            try
            {
                KPSPublicSoapClient servis = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
                TCKimlikNoDogrulaResponse durum = await servis.TCKimlikNoDogrulaAsync(person.TC, person.Ad, person.Soyad, person.DogumYili);
                return durum.Body.TCKimlikNoDogrulaResult;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
