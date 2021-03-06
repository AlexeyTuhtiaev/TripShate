﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TripShare.Back.Models;

namespace TripShare.UI.Services
{
    public interface IApiClient
    {
        Task<Trip> GetTripAsync(int id);
        Task<List<Trip>> GetTripsAsync();
        Task PutTripAsync(Trip tripToUpdate);
        Task AddTripAsync(Trip tripToAdd);
        Task RemoveTripAsync(int id);

    }

    class ApiClient : IApiClient
    {
        private readonly HttpClient _HttpClient;

        public ApiClient(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task AddTripAsync(Trip tripToAdd)
        {
            var response = await _HttpClient.PostJsonAsync("/api/Trip", tripToAdd);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Trip> GetTripAsync(int id)
        {
            var response = await _HttpClient.GetAsync($"/api/Trip/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsJsonAsync<Trip>();
        }

        public async Task<List<Trip>> GetTripsAsync()
        {
            var response = await _HttpClient.GetAsync("/api/Trip");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsJsonAsync<List<Trip>>();
        }

        public async Task PutTripAsync(Trip tripToUpdate)
        {
            var response = await _HttpClient.PutJsonAsync($"/api/Trip/{tripToUpdate.Id}", tripToUpdate);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveTripAsync(int id)
        {
            var response = await _HttpClient.DeleteAsync($"/api/Trip/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
