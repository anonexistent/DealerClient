using DealerAPI.Contracts.Input;
using DealerAPI.Model;
using DealerClient.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DealerClient.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private HttpClient _httpClient;

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

	private List<Dealer> dealers;
	public List<Dealer> Dealers
    {
		get { return GetDealers().Result; }
		set { dealers = value; }
	}

	private List<DealerType> dealerTypes;
	public List<DealerType> DealerTypes
    {
		get { return GetDealerTypes().Result; }
		set { dealerTypes = value; }
	}

	private async Task<List<Dealer>> GetDealers()
    {
        var response = _httpClient.GetStringAsync("https://localhost:7136/dealer/dealer/getList").Result;
        var dealers = JsonConvert.DeserializeObject<Dictionary<string,List<Dealer>>>(response);
        return dealers["dealers"];
    }

	private async Task<List<DealerType>> GetDealerTypes()
    {
        var response = _httpClient.GetStringAsync("https://localhost:7136/dealer/dealerType/getList").Result;
        var dealers = JsonConvert.DeserializeObject<Dictionary<string,List<DealerType>>>(response);
        return dealers["dealerTypes"];
    }

    public async Task<bool> CreateDealerAsync(CreateDealerBody dealerBody)
    {
        var jsonContent = JsonConvert.SerializeObject(dealerBody);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://localhost:7136/dealer/dealer/create", content);
        return response.IsSuccessStatusCode;
    }

    public MainViewModel()
    {
        _httpClient = new HttpClient();

    }
}