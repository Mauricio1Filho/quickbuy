namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public override void Validate()
        {
            if(string.IsNullOrEmpty(Nome))
                AdicionarCritica("Campo Nome deve ser preenchido");

            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Campo Descricao deve ser preenchido");

            if(Preco == 0)
                AdicionarCritica("Campo Preco deve ser informado");

        }
    }
}