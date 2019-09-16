﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YulsnApiClient.Models;

namespace YulsnApiClient.Client
{
    partial class YulsnClient
    {
        public async Task<YulsnContact> GetContact(string secret)
        {
            string url = "/api/v1/Contacts?secret=" + secret;

            using (var response = await httpClient.GetAsync(url))
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<YulsnContact>(await response.Content.ReadAsStringAsync());                
            }
        }

        public async Task DeleteContact(int contactId)
        {
            string url = "/api/v1/Contacts/" + contactId;

            await httpClient.DeleteAsync(url);
        }

        public async Task<List<int>> GetContactIds(int segmentId)
        {
            string url = "/api/v1/Contacts?segmentId=" + segmentId;
            url = $"/api/v1/Segments/{segmentId}/GetContactIds";

            using (var response = await httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<List<int>>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}