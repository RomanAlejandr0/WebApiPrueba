using Microsoft.AspNetCore.Mvc;
using STP;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security;

namespace WebApiPrueba.Controllers
{
    [ApiController]

    [Route("[operacionesSTP]")]
    public class OperacionesSTPController : ControllerBase
    {
        private byte[] ruta;
        private SecureString? password;

        [HttpPost]
        public async Task<long> ConsultarOrdenPago()
        {
            //var numberConversionClient = new ServiceReference1.NumberConversionSoapTypeClient(new ServiceReference1.NumberConversionSoapTypeClient.EndpointConfiguration());
            //var WSCancelacionesClient = new WSCancelaciones.WSCFDICancelacionSoapClient(WSCancelaciones.WSCFDICancelacionSoapClient.EndpointConfiguration.WSCFDICancelacionSoap);
            
            var STPClient = new STP.SpeiActualizaServicesClient(new STP.SpeiActualizaServicesClient.EndpointConfiguration());
            
            var OrdenPagoWS = new ordenPagoWS()
            {
                claveRastreo = "123456789",
                conceptoPago = "Prueba SOAP",
                cuentaBeneficiario = "646180193700000009",
                cuentaOrdenante = "646180193700000009",
                empresa = "EMPRESAPRUEBA",
                fechaOperacion = 20231124,//NO OBLIGATORIO
                firma = "",
                folioOrigen = "", //NO OBLIGATORIO
                institucionContraparte = 90646,
                institucionOperante = 90646,
                monto = 1,
                nombreBeneficiario = "Nombre Beneficiario",
                nombreOrdenante = "Nombre Ordenante",
                referenciaNumerica = 123456,
                rfcCurpBeneficiario = "ND",
                rfcCurpOrdenante = "ND",
                tipoCuentaBeneficiario = 3,
                tipoCuentaOrdenante = 3,
                tipoPago = 1
            };


            var registraOrden = await STPClient.registraOrdenAsync(OrdenPagoWS, "");

            return 0;
        }


        public string Firma(ordenPagoWS ordenPago)
        {
            string cadenaOriginal = origenString(ordenPago);

            //if (debug)
            //{
            //    Console.WriteLine("Cadena original: " + cadenaOriginal);
            //}

            X509Certificate2 x509 = new X509Certificate2(ruta, password);
            RSACryptoServiceProvider rsaProvider = (RSACryptoServiceProvider)x509.PrivateKey;
            SHA256 hasher = SHA256CryptoServiceProvider.Create();
            byte[] hashValue = rsaProvider.SignData(System.Text.Encoding.UTF8.GetBytes(cadenaOriginal), hasher);
            string signature = System.Convert.ToBase64String(hashValue);
          
            //if (debug)
            //{
            //    Console.WriteLine("Firma: " + signature);
            //}

            return signature;
        }

        private string origenString(ordenPagoWS ordenPago)
        {
            throw new NotImplementedException();
        }
    }
}
