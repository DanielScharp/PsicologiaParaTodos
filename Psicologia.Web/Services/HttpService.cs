using Newtonsoft.Json;
using Psicologia.Web.App;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace Psicologia.Web.Services
{
    public class HttpService<T> : IDisposable
    {
        private readonly string _apiUri;
        private readonly string _moduloId;
        private readonly string _apiFotosUri;
        private readonly TokenCookie _tokenCookie;

        public HttpService(IConfiguration configuration, TokenCookie tokenCookie)
        {
            _apiUri = configuration["ApiUri"];
            _moduloId = configuration["ModuloId"];
            _apiFotosUri = configuration["ApiFotosUri"];
            _tokenCookie = tokenCookie;
        }


        public T ReturnService(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _tokenCookie.Token);
                    client.DefaultRequestHeaders.Add("ModuloId", _moduloId);

                    var urlService = _apiUri + "/" + uri;
                    var response = client.GetAsync(urlService).Result;

                    var content = response.Content.ReadAsStringAsync().Result;

                    if (content.Contains("Authorization has been denied"))
                    {
                        throw new InvalidOperationException("Token expirado!");
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(JsonConvert.DeserializeObject<MensagemApi>(content).ExceptionMessage);
                    }

                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReturnServiceAsString(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _tokenCookie.Token);
                    client.DefaultRequestHeaders.Add("ModuloId", _moduloId);

                    var urlService = _apiUri + "/" + uri;
                    var response = client.GetAsync(urlService).Result;

                    var content = response.Content.ReadAsStringAsync().Result;

                    if (content.Contains("Authorization has been denied"))
                    {
                        throw new InvalidOperationException("Token expirado!");
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(JsonConvert.DeserializeObject<MensagemApi>(content).ExceptionMessage);
                    }

                    return content;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ReturnServiceAsDataTable(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _tokenCookie.Token);
                    client.DefaultRequestHeaders.Add("ModuloId", _moduloId);

                    var urlService = _apiUri + "/" + uri;
                    var response = client.GetAsync(urlService).Result;

                    var content = response.Content.ReadAsStringAsync().Result;

                    if (content.Contains("Authorization has been denied"))
                    {
                        throw new InvalidOperationException("Token expirado!");
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(JsonConvert.DeserializeObject<MensagemApi>(content).ExceptionMessage);
                    }

                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(content, typeof(DataTable));
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T ExecuteService(object obj, string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var stream = JsonConvert.SerializeObject(obj);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(stream);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _tokenCookie.Token);
                    client.DefaultRequestHeaders.Add("ModuloId", _moduloId);

                    var urlService = _apiUri + "/" + uri;
                    var response = client.PostAsync(urlService, byteContent).Result;

                    var content = response.Content.ReadAsStringAsync().Result;

                    if (content.Contains("Authorization has been denied"))
                    {
                        throw new InvalidOperationException("Token expirado!");
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(JsonConvert.DeserializeObject<MensagemApi>(content).ExceptionMessage);
                    }

                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ExecuteServiceAsString(object obj, string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var stream = JsonConvert.SerializeObject(obj);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(stream);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _tokenCookie.Token);
                    client.DefaultRequestHeaders.Add("ModuloId", _moduloId);

                    var urlService = _apiUri + "/" + uri;
                    var response = client.PostAsync(urlService, byteContent).Result;

                    var content = response.Content.ReadAsStringAsync().Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(JsonConvert.DeserializeObject<MensagemApi>(content).ExceptionMessage);
                    }

                    return content;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecuteServiceAsDataTable(object obj, string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var stream = JsonConvert.SerializeObject(obj);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(stream);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _tokenCookie.Token);
                    client.DefaultRequestHeaders.Add("ModuloId", _moduloId);

                    var urlService = _apiUri + "/" + uri;
                    var response = client.PostAsync(urlService, byteContent).Result;

                    var content = response.Content.ReadAsStringAsync().Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(JsonConvert.DeserializeObject<MensagemApi>(content).ExceptionMessage);
                    }

                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(content, typeof(DataTable));
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T ExecuteApiFotos(object obj, string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var stream = JsonConvert.SerializeObject(obj);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(stream);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var urlService = _apiFotosUri + "/" + uri;
                    var response = client.PostAsync(urlService, byteContent).Result;

                    var content = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T ReturnApiFotos(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlService = _apiFotosUri + "/" + uri;
                    var response = client.GetAsync(urlService).Result;

                    var content = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            //Nothing to do
        }
    }
}
