﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YulsnApiClient.Models;
using System.Net.Http;
using System.Web;

namespace YulsnApiClient.Client
{
    partial class YulsnClient
    {
        public Task<YulsnReadPointDto> GetPoint(int pointId) =>
            SendAsync<YulsnReadPointDto>($"/api/v1/Points/{pointId}");

        public Task<List<YulsnReadPointDto>> GetPoints(int contactId, string type = null, DateTimeOffset? dateTimeFrom = null, DateTimeOffset? dateTimeTo = null) =>
            SendAsync<List<YulsnReadPointDto>>($"api/v1/Points?contactId={contactId + (type != null ? $"&type={type}" : "") + (dateTimeFrom != null ? $"&datetimeFrom={HttpUtility.UrlEncode(((DateTimeOffset)dateTimeFrom).ToString("O"))}" : "") + (dateTimeTo != null ? $"&dateTimeTo={HttpUtility.UrlEncode(((DateTimeOffset)dateTimeTo).ToString("O"))}" : "")}");

        public Task<List<YulsnReadPointSumDto>> GetPointSums(int contactId, string type = null) =>
            SendAsync<List<YulsnReadPointSumDto>>($"api/v1/Points/Sums?contactId={contactId + (type != null ? $"&type={type}" : "")}");

        public Task CancelPoint(int pointId) =>
            SendAsync<object>(HttpMethod.Post, $"api/v1/Points/{pointId}/Cancel");

        public Task<YulsnReadPointDto> CreatePoint<T>(T yulsnCreatePointDto) where T : YulsnCreatePointDto =>
            SendAsync<YulsnReadPointDto>(HttpMethod.Post, "api/v1/Points", yulsnCreatePointDto);
    }
}