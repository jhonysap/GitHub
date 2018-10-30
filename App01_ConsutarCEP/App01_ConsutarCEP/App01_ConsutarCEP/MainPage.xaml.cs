using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsutarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Validações.
            string cep = CEP.Text.Trim();

            if (isValidCep(cep))
            {
                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                RESULTADO.Text = string.Format("Endereço: Rua: {2} - {3},  Cidade: {0} - {1}", end.localidade, end.uf, end.logradouro, end.bairro);
            }
        }

        private bool isValidCep(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve conter 8 caracteres", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve ser composto apenas por números ", "OK");

                valido = false;
            }
            return valido;
        }
    }
}
