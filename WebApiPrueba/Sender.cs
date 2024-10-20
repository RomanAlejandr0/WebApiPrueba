using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.InteropServices;

namespace WebApiPrueba
{
    public class Sender : IDisposable
    {
        public Sender()
        {
            //Url = ConfigurationManager.AppSettings["URLSUCService"];
        }

        public string Url { get; set; }

        public T PostRest<T>(string funcion, object objeto)
        {
            //try
            //{
            var json = JsonConvert.SerializeObject(objeto);

            var req = (WebRequest)HttpWebRequest.Create(Url + funcion);
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //NCR 2020.12.18 Se agrega Protocolo TLS
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {

                writer.Write(json);
            }

            var result = string.Empty;

            using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            var respuesta = JsonConvert.DeserializeObject(result, typeof(T));

            return (T)respuesta;

            //}
            //catch (Exception ex)
            //{
            //    return default(T);
            //}
        }

        public T PostRest<T>(string funcion, object objeto, string token)
        {
            //try
            //{
            var json = JsonConvert.SerializeObject(objeto);

            var req = (WebRequest)HttpWebRequest.Create(Url + funcion);
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            req.Headers.Add("Token", token);

            using (var writer = new StreamWriter(req.GetRequestStream()))
            {

                writer.Write(json);
            }

            var result = string.Empty;

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //NCR 2020.12.18 Se agrega Protocolo TLS
            using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            var respuesta = JsonConvert.DeserializeObject(result, typeof(T));

            return (T)respuesta;

            //}
            //catch (Exception ex)
            //{
            //    return default(T);
            //}
        }

        public T PostRest_ValidarUUIDv40<T>(string funcion, object objeto, string token)
        {
            //try
            //{
            var json = JsonConvert.SerializeObject(objeto);

            var req = (WebRequest)HttpWebRequest.Create(Url + funcion);
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            req.Headers.Add("Token", token);

            using (var writer = new StreamWriter(req.GetRequestStream()))
            {

                writer.Write(json);
            }

            var result = string.Empty;

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //NCR 2020.12.18 Se agrega Protocolo TLS
            using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            object model = new object();

            //var respuesta1 = JsonConvert.DeserializeObject<object>(result);

            //var respuesta1 = JsonConvert.DeserializeObject<info>(result);
            //dynamic restponse = JsonConvert.DeserializeObject(result);

            var respuesta = JsonConvert.DeserializeObject(result, typeof(T));

            return (T)respuesta;

            //}
            //catch (Exception ex)
            //{
            //    return default(T);
            //}
        }
        //JFO 2022.01.03
        //public T PostRest_ValidarUUIDv40Model<T>(string funcion, object objeto, string token)
        //{
        //    //try
        //    //{
        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(objeto);

        //        var req = (WebRequest)HttpWebRequest.Create(Url + funcion);
        //        req.Method = "POST";
        //        req.ContentType = "application/json; charset=utf-8";
        //        req.Headers.Add("Token", token);

        //        using (var writer = new StreamWriter(req.GetRequestStream()))
        //        {

        //            writer.Write(json);
        //        }

        //        var result = string.Empty;

        //        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //NCR 2020.12.18 Se agrega Protocolo TLS
        //        using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
        //        {
        //            result = reader.ReadToEnd();
        //        }

        //        //var respuesta1 = JsonConvert.DeserializeObject<Informacion>(result);
        //        //dynamic restponse = JsonConvert.DeserializeObject(result);
        //        //RespuestaDTO<List<RespuestaDTO<T>>> respuestaM = new RespuestaDTO<List<RespuestaDTO<T>>>();

        //        var respuesta = JsonConvert.DeserializeObject(result, typeof(RespuestaDTO<List<RespuestaDTO<ContenidoDato>>>));


        //        return (T)respuesta;
        //    }
        //    catch (Exception e)
        //    {
        //        return default(T);

        //    }

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return default(T);
        //    //}
        //}

        //public T GetRest<T>(string funcion)
        //{
        //    //try
        //    //{
        //    var req = (WebRequest)HttpWebRequest.Create(Url + funcion);
        //    req.Method = "GET";
        //    req.ContentType = "application/json; charset=utf-8";
        //    var result = string.Empty;

        //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //NCR 2020.12.18 Se agrega Protocolo TLS
        //    using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
        //    {
        //        result = reader.ReadToEnd();
        //    }
        //    var respuesta = JsonConvert.DeserializeObject(result, typeof(T));

        //    return (T)respuesta;

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return default(T);
        //    //}
        //}

        //public T GetRest<T>(string funcion, string token)
        //{
        //    //try
        //    //{
        //    var req = (WebRequest)HttpWebRequest.Create(Url + funcion);
        //    req.Method = "GET";
        //    req.ContentType = "application/json; charset=utf-8";
        //    req.Headers.Add("Token", token);
        //    var result = string.Empty;

        //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //NCR 2020.12.18 Se agrega Protocolo TLS
        //    using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
        //    {
        //        result = reader.ReadToEnd();
        //    }

        //    var respuesta = JsonConvert.DeserializeObject(result, typeof(T));

        //    return (T)respuesta;

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return default(T);
        //    //}
        //}

        //public T GetRest<T>(string funcion, string parametros, string token)
        //{
        //    //try
        //    //{
        //    var req = (WebRequest)HttpWebRequest.Create(Url + funcion + (string.IsNullOrEmpty(parametros) ? "" : "?" + parametros));
        //    req.Method = "GET";
        //    req.ContentType = "application/json; charset=utf-8";
        //    req.Headers.Add("Token", token);
        //    var result = string.Empty;

        //    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //NCR 2020.12.18 Se agrega Protocolo TLS
        //    using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
        //    {
        //        result = reader.ReadToEnd();
        //    }

        //    var respuesta = JsonConvert.DeserializeObject(result, typeof(T));

        //    return (T)respuesta;

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return default(T);
        //    //}
        //}

        #region "IDisposable"
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion
    }
}
