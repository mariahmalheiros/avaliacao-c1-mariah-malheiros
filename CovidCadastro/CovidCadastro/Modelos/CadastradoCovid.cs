using System;

namespace CovidCadastro.Requests
{
    public class CadastradoCovid
    {
        public int Id { get; set; }
        private string Nome { get; set; }
        private string Endereco { get; set; }
        private string Celular { get; set; }
        private double Peso { get; set; }
        private int AlturaCm { get; set; }
        private string ProblemasSaude { get; set; }

        public CadastradoCovid(string nome, string endereco, string celular, double peso, int alturaCm, string problemasSaude)
        {
            this.SetNome(nome);
            this.SetEndereco(endereco);
            this.SetCelular(celular);
            this.SetPeso(peso);
            this.SetAltura(alturaCm);
            this.SetProblemasSaude(problemasSaude);
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome não pode ser nulo ou em branco");
            this.Nome = nome;
        }
        public void SetEndereco(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new Exception("Endereço não pode ser nulo ou em branco");
            this.Endereco = endereco;
        }
        public void SetCelular(string celular)
        {
            if (string.IsNullOrWhiteSpace(celular))
                throw new Exception("Celular não pode ser nulo ou em branco");
            this.Celular = celular;
        }
        public void SetPeso(double peso)
        {
            if (peso <= 0)
                throw new Exception("Peso deve ser maior que 0");
            this.Peso = peso;
        }
        public void SetAltura(int alturaCm)
        {
            if (alturaCm <= 0)
                throw new Exception("Altura deve ser maior que 0");
            this.AlturaCm = alturaCm;
        }
        public void SetProblemasSaude(string problemasSaude)
        {
            this.ProblemasSaude = problemasSaude;
        }
    }
}
