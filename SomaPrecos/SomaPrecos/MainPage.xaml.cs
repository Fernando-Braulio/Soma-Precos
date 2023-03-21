using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SomaPrecos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            AtualizaTela();
        }

        async void OnSaveButtonClicked(System.Object sender, System.EventArgs e)
        {
            Produto prod = new Produto();

            if (string.IsNullOrEmpty(vlrProd.Text))
                return;

            if (string.IsNullOrEmpty(idProd.Text))
            {
                prod.Nome = nomeProd.Text;
                prod.Valor = Convert.ToDecimal(vlrProd.Text);
            }
            else
            {
                prod.Id = Convert.ToInt16(idProd.Text);
                prod.Nome = nomeProd.Text;
                prod.Valor = Convert.ToDecimal(vlrProd.Text);
            }

            var suces = await App.Database.SaveProdutoAsync(prod);

            if (suces > 0)
            {
                idProd.Text = string.Empty;
                nomeProd.Text = string.Empty;
                vlrProd.Text = string.Empty;

                AtualizaTela();
            }

        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var prop = (Produto)BindingContext;

            if (prop != null)
                await App.Database.DeleteProdutoAsync(prop);
        }

        void OnSelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Produto prod = (Produto)e.CurrentSelection.FirstOrDefault();

                if (prod != null)
                {
                    idProd.Text = prod.Id.ToString();
                    nomeProd.Text = prod.Nome;
                    vlrProd.Text = prod.Valor.ToString();
                }
            }
        }

        async void AtualizaTela()
        {
            var produtos = await App.Database.GetProdutosAsync();
            cvProdutos.ItemsSource = produtos;
            total.Text = produtos.Sum(m => m.Valor).ToString();
        }
    }
}

