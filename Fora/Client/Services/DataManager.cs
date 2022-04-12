﻿using Fora.Shared;
using System.Net.Http.Json;

namespace Fora.Client.Services
{
    public class DataManager : IDataManager
    {
        private readonly HttpClient _httpClient;
        public DataManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateInterest(InterestModel interestToAdd)
        {
            var response = await _httpClient.PostAsJsonAsync("api/interest", interestToAdd);

        }

        public async Task<List<InterestModel>> GetAllInterests()
        {
            List<InterestModel> interests = new();
            interests = await _httpClient.GetFromJsonAsync<List<InterestModel>>("api/interest");

            return interests;
        }

        public async Task<List<InterestModel>> GetUserInterests(int activeUserId)
        {
            List<InterestModel> userInterest = new();
            userInterest= await _httpClient.GetFromJsonAsync<List<InterestModel>>($"api/interest/check?activeUserId={activeUserId}");

            return userInterest;
        }

        public async Task<string> DeleteInterest(int id)
        {
            var result = await _httpClient.DeleteAsync("api/intesrest");
            return result.ToString(); //är detta strängen message?
        }
        // ***** THREAD *****

        public async Task<List<ThreadModel>> GetAllThreads(int interestID)
        {
            List<ThreadModel> allThreads = new();

            allThreads = await _httpClient.GetFromJsonAsync<List<ThreadModel>>($"api/thread/allThreads?interestID={interestID}");

            return allThreads;
        }

        public async Task CreateThread(ThreadModel threadToAdd)
        {
            var response = await _httpClient.PostAsJsonAsync("api/thread", threadToAdd);
        }

        // ***** MESSAGES *****

        public async Task<List<MessageModel>> GetAllMessages(int threadID)
        {
            List<MessageModel> allMessages = new();

            allMessages = await _httpClient.GetFromJsonAsync<List<MessageModel>>($"api/message/allMessages?threadID={threadID}");
            return allMessages;
        }

        public async Task CreateMessage(MessageModel messageToAdd)
        {
            var response = await _httpClient.PostAsJsonAsync("api/messages", messageToAdd);
        }
    }
}