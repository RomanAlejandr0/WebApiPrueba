using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using WebApiPrueba.Entidades;

namespace WebApiPrueba.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {

            var httpClient = new WSCancelaciones.WSCFDICancelacionSoapClient(new WSCancelaciones.WSCFDICancelacionSoapClient.EndpointConfiguration());


            var user = new ServiceReference1.NumberConversionSoapTypeClient(new NumberConversionSoapTypeClient.EndpointConfiguration());

            var ere = await user.NumberToDollarsAsync(12m);

            string pathCertificado = "C:\\Users\\roman\\Documents\\TrabajoVisualArturo\\ErhMas.Administracion\\Server\\assets\\LTC220407TR4.cer";
            string pathLlave = "C:\\Users\\roman\\Documents\\TrabajoVisualArturo\\ErhMas.Administracion\\Server\\assets\\LTC220407TR4.key";

            byte[] certificadoBites = System.IO.File.ReadAllBytes(pathCertificado);
            byte[] llaveBites = System.IO.File.ReadAllBytes(pathLlave);

            var cCertificado = Convert.ToBase64String(certificadoBites);
            var cLlave = Convert.ToBase64String(llaveBites);



            var respue = new WSCancelaciones.GuardarCertificadoSUCRequestBody("SUCHEC1017", "HEC1017*23", "LTC220407TR4", cCertificado, cLlave, "");

            var respues = new WSCancelaciones.GuardarCertificadoSUCRequest(respue);

            var response = new WSCancelaciones.GuardarCertificadoSUCResponseBody();

            //httpClient.SolicitarCancelacionSUCV40Async();

            return new List<Autor>()
            { 
                new Autor(){ Id = 1, Nombre = "Felipe" },
                new Autor(){ Id = 2 ,Nombre = "Claudia" }
            };

        }
    }
}
