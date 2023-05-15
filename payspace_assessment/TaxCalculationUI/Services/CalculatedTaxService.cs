using AutoMapper;
using Newtonsoft.Json;
using System.Text;
using TaxCalculationUI.Contracts;
using TaxCalculationUI.Models;
using TaxCalculationUI.Models.CalculatedTax;
using TaxCalculationUI.Services;

namespace TaxCalculationUI.Services
{
    public partial class CalculatedTaxService : ICalculatedTaxService
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public CalculatedTaxService(HttpClient client, IMapper mapper)
        {
            this._mapper = mapper;
            this._httpClient = client;
            _httpClient.BaseAddress = new Uri("https://localhost:7250/");
        }

        public async Task<HttpResponseMessage> CreateCalculatedTax(CreateCalculatedTaxViewModel calculatedTax)
        {

            var createCalculatedTaxCommand = _mapper.Map<CreateCalculatedTaxCommand>(calculatedTax);
            var response = await _httpClient.PostAsync($"api/calculatedTax", new StringContent(JsonConvert.SerializeObject(createCalculatedTaxCommand), Encoding.UTF8, "application/json"));
            

            return response;
        }

        public async Task<HttpResponseMessage> DeleteCalculatedTax(int id)
        {

            var response = await _httpClient.DeleteAsync($"api/calculatedTax/{id}");

            return response;

        }

        public async Task<List<CalculatedTaxDto>> GetCalculatedTaxes()
        {
            var calculatedTax = new List<CalculatedTaxDto>();

            var response = await _httpClient.GetAsync("api/calculatedtax");
            if (response.IsSuccessStatusCode)
            {
                var respString = await response.Content.ReadAsStringAsync();
                calculatedTax = JsonConvert.DeserializeObject<List<CalculatedTaxDto>>(respString);
            }
           
            return calculatedTax;
        }

        public async Task<CalculatedTaxDto> GetDetailCalculatedTaxes(int id)
        {
            var calculatedTax = new CalculatedTaxDto();

            var response = await _httpClient.GetAsync($"api/calculatedtax/{id}");
            if (response.IsSuccessStatusCode)
            {
                var respString = await response.Content.ReadAsStringAsync();
                calculatedTax = JsonConvert.DeserializeObject<CalculatedTaxDto>(respString);
            }

            return calculatedTax;
        }

        public async Task<HttpResponseMessage> UpdateCalculatedTax(CalculatedTaxDto calculatedTax)
        {
            var updateCalculatedCommand = _mapper.Map<UpdateCalculatedTaxCommand>(calculatedTax);
            var response = await _httpClient.PutAsync($"api/calculatedTax/{updateCalculatedCommand.Id}", new StringContent(JsonConvert.SerializeObject(updateCalculatedCommand), Encoding.UTF8, "application/json"));
            return response;
        }

        

    }
}
