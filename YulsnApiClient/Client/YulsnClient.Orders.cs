﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YulsnApiClient.Models;

namespace YulsnApiClient.Client
{
    public partial class YulsnClient
    {
        public Task<RO> GetOrderAsync<RO, RL>(int orderId) where RO : YulsnReadOrderDto<RL> where RL : YulsnReadOrderLineDto =>
            SendAsync<RO>($"/api/v1/Orders/{orderId}");

        public Task<List<RO>> GetOrdersByContactIdAsync<RO, RL>(int contactId) where RO : YulsnReadOrderDto<RL> where RL : YulsnReadOrderLineDto =>
            SendAsync<List<RO>>($"/api/v1/Orders?contactid={contactId}");

        public Task<List<RO>> GetOrdersByExtOrderIdAsync<RO, RL>(string extOrderId) where RO : YulsnReadOrderDto<RL> where RL : YulsnReadOrderLineDto =>
            SendAsync<List<RO>>($"/api/v1/Orders?extOrderId={extOrderId}");

        public Task<RO> CreateOrderAsync<RO, RL, CO, CL>(CO order) where RO : YulsnReadOrderDto<RL> where RL : YulsnReadOrderLineDto where CO : YulsnCreateOrderDto<CL> where CL : YulsnCreateOrderLineDto =>
            SendAsync<RO>(HttpMethod.Post, $"/api/v1/Orders", order);

        /// <summary>Update order - only provided fields will be changed</summary>
        public Task<RO> UpdateOrderAsync<RO, RL>(int orderId, Dictionary<string, object> updateFields) where RO : YulsnReadOrderDto<RL> where RL : YulsnReadOrderLineDto =>
            SendAsync<RO>(new HttpMethod("PATCH"), $"api/v1/Orders/{orderId}", updateFields);

        public Task<List<RO>> SearchOrdersAsync<RO, RL>(List<YulsnSearchFieldDto> yulsnSearchFileldDtos) where RO : YulsnReadOrderDto<RL> where RL : YulsnReadOrderLineDto =>
            SendAsync<List<RO>>(new HttpMethod("SEARCH"), $"api/v1/Orders", yulsnSearchFileldDtos);
    }
}