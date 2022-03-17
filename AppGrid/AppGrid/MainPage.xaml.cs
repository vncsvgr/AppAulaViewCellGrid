using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppGrid
{
    public partial class MainPage : ContentPage
    {
        List<Aluno> aluno = new List<Aluno>
        {
            new Aluno { Nome="João", Curso="Desenvolvimento", Cidade="Jau"},
            new Aluno { Nome="José", Curso="Administração", Cidade="Bariri"},
            new Aluno { Nome="Paulo", Curso="Mecânica", Cidade="Bocaina"},
            new Aluno { Nome="Antonio", Curso="Edificações", Cidade="Bauru"}
        };

        public MainPage()
        {
            InitializeComponent();

            lstAlunos.ItemsSource = aluno;
        }

        async void lstAlunos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var a = e.SelectedItem as Aluno;

            var resp = await DisplayAlert("Exclusão", "Deseja excluir o aluno? " + a.Nome, "Sim", "Não");

            if (resp)
            {
                var item = aluno.Find(x => x.Nome == a.Nome);
                aluno.Remove(item);
                lstAlunos.ItemsSource = null;
                lstAlunos.ItemsSource = aluno;
            }
        }

        private void sbAlunos_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstAlunos.ItemsSource = aluno.Where(
                x => x.Nome.ToUpper().Contains(sbAlunos.Text.ToUpper()));
        }
    }
}