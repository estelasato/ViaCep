using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tarefa3_viaCep.Models;

namespace tarefa3_viaCep.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class getAddress : ContentPage
    {
        public getAddress()
        {
            InitializeComponent();
        }

        public void LimparCampos(object sender, EventArgs e)
        {
            valueCEP.Text = "";
            EntryLogradouro.Text = "";
            EntryBairro.Text = "";
            EntryLocalidade.Text = "";
            EntryUF.Text = "";
            EntryDDD.Text = "";
        }

        public async void PesquisaCEP(object sender, EventArgs e)
        {
            if (valueCEP.Text == null || valueCEP.Text.Length == 0)
            {
                await DisplayAlert("Erro.", "Não é possível pesquisar sem CEP!!!", "OK");
                FrmCep.BorderColor = Colors.Red;
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(String.Format("https://viacep.com.br/ws/{0}/json/", valueCEP.Text));

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var API = System.Text.Json.JsonSerializer.Deserialize<Address>(json);

                        EntryBairro.Text = API.bairro;
                        EntryUF.Text = API.uf;
                        EntryLocalidade.Text = API.localidade;
                        EntryLogradouro.Text = API.logradouro;
                        EntryDDD.Text = API.ddd;
                        valueCEP.Text = "";
                    }
                    else
                    {
                        DisplayAlert("Erro na busca.", "O CEP inserido é inválido.", "OK");
                        FrmCep.BorderColor = Colors.Red;
                    }
                }
            }
        }
    }
}