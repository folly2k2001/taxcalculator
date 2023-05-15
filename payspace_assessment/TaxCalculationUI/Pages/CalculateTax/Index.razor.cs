using Blazored.Toast.Services;
using TaxCalculationUI.Contracts;
using TaxCalculationUI.Models.CalculatedTax;
using Microsoft.AspNetCore.Components;

namespace TaxCalculationUI.Pages.CalculateTax
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ICalculatedTaxService CalculateTaxService { get; set; }

        [Inject]
        IToastService toastService { get; set; }
        public List<CalculatedTaxDto> calculatedTaxVM { get; private set; }
        public CalculatedTaxDto EditCalculatedTaxVM { get; private set; } = new CalculatedTaxDto();
        public CreateCalculatedTaxViewModel calculatedTax { get; private set; } = new CreateCalculatedTaxViewModel();
        public bool editflag { get; private set; } = false;
        public string Message { get; set; } = string.Empty;


        protected async Task DeleteCalculatedTax(int id)
        {
            var response = await CalculateTaxService.DeleteCalculatedTax(id);
            if (response.IsSuccessStatusCode)
            {
                toastService.ShowSuccess("Calculated Tax deleted Successfully");
                await OnInitializedAsync();
            }
            else
            {
                Message = response.ReasonPhrase;
            }
        }

        protected async Task PreEditCalculatedTax(int id)
        {
            var response = calculatedTaxVM.Where(x=>x.Id == id).FirstOrDefault();
            if (response != null)
            {
                EditCalculatedTaxVM = response;
                editflag = true;
            }
            else
            {
                Message = $"Record with id: {id} not found";
            }
        }

        protected async Task EditCalculatedTax()
        {
            
            var updateResponse = await CalculateTaxService.UpdateCalculatedTax(EditCalculatedTaxVM);
            if (updateResponse.IsSuccessStatusCode)
            {
                toastService.ShowSuccess("Calculated Tax updated Successfully");
                editflag = false;
                await OnInitializedAsync();
            }
            else
            {
                Message = updateResponse.ReasonPhrase;
            }

            
        }

        protected async Task CalculateTax()
        {
            var response = await CalculateTaxService.CreateCalculatedTax(calculatedTax);

            if (response.IsSuccessStatusCode)
            {
                var respString = await response.Content.ReadAsStringAsync();
                toastService.ShowSuccess("Tax calculated and created Successfully");
                NavigationManager.NavigateTo("/calculatetax/");
            }
         

            Message = response.ReasonPhrase;
            await OnInitializedAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            calculatedTaxVM = await CalculateTaxService.GetCalculatedTaxes();
        }
    }
}