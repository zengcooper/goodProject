using BMW.Omc.ConfigService.Client.Instrument.Wrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Template1.Common.Web
{
    public class HttpClientX : HttpClient
    {
        #region Variables

        private readonly IAppInsightsTelemetryClient _aITelemetryClientWrapper;
        private const int _defaultTimeOut = 60;

        #endregion

        #region Constructors

        public HttpClientX(IAppInsightsTelemetryClient aITelemetryClientWrapper) : base()
        {
            _aITelemetryClientWrapper = aITelemetryClientWrapper;
        }
        public HttpClientX(IAppInsightsTelemetryClient aITelemetryClientWrapper,
            HttpMessageHandler handler) : base(handler)
        {
            _aITelemetryClientWrapper = aITelemetryClientWrapper;
        }

        public HttpClientX(IAppInsightsTelemetryClient aITelemetryClientWrapper,
            HttpMessageHandler handler, bool disposeHandler) : base(handler, disposeHandler)
        {
            _aITelemetryClientWrapper = aITelemetryClientWrapper;
        }

        #endregion

        #region Extension for HttpClient

        public async Task<T> PostAsync<T, Trequest>(string url, List<KeyValuePair<string, string>> headers, Trequest request, int? timeOut = null)
        {
            Timeout = new TimeSpan(0, 0, timeOut ?? _defaultTimeOut);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (headers != null && headers.Any())
                headers.ForEach(header => DefaultRequestHeaders.Add(header.Key, header.Value));

            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            HttpContent content = new ObjectContent<Trequest>(request, jsonFormatter);
            try
            {
                HttpResponseMessage response = await PostAsync(url, content);
                if (response == null)
                    return default(T);

                var result = await response.Content.ReadAsStringAsync();
                if (result != null)
                    return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception exception)
            {
                _aITelemetryClientWrapper.TrackException(exception);
            }
            return default(T);
        }
        public async Task<T> GetAsync<T>(string url, List<KeyValuePair<string, string>> headers = null, int? timeOut = null)
        {
            Timeout = new TimeSpan(0, 0, timeOut ?? _defaultTimeOut);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (headers != null && headers.Any())
                headers.ForEach(header => DefaultRequestHeaders.Add(header.Key, header.Value));
            try
            {
                HttpResponseMessage response = await GetAsync(url);
                if (response == null)
                    return default(T);

                var result = await response.Content.ReadAsStringAsync();
                if (result != null)
                    return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception exception)
            {
                _aITelemetryClientWrapper.TrackException(exception);
            }
            return default(T);
        }
        public async Task<T> PutAsync<T, Trequest>(string url, List<KeyValuePair<string, string>> headers, Trequest request, int? timeOut = null)
        {
            Timeout = new TimeSpan(0, 0, timeOut ?? _defaultTimeOut);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (headers != null && headers.Any())
                headers.ForEach(header => DefaultRequestHeaders.Add(header.Key, header.Value));

            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            HttpContent content = new ObjectContent<Trequest>(request, jsonFormatter);
            try
            {
                HttpResponseMessage response = await PutAsync(url, content);
                if (response == null)
                    return default(T);

                var result = await response.Content.ReadAsStringAsync();
                if (result != null)
                    return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception exception)
            {
                _aITelemetryClientWrapper.TrackException(exception);
            }
            return default(T);
        }
        public async Task<T> DeleteAsync<T>(string url, List<KeyValuePair<string, string>> headers, int? timeOut = null)
        {
            Timeout = new TimeSpan(0, 0, timeOut ?? _defaultTimeOut);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (headers != null && headers.Any())
                headers.ForEach(header => DefaultRequestHeaders.Add(header.Key, header.Value));

            try
            {
                HttpResponseMessage response = await DeleteAsync(url);
                if (response == null)
                    return default(T);

                var result = await response.Content.ReadAsStringAsync();
                if (result != null)
                    return JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception exception)
            {
                _aITelemetryClientWrapper.TrackException(exception);
            }
            return default(T);
        }

        #endregion
    }
}
