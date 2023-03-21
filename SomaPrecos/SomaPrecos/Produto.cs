using System;
using SQLite;

namespace SomaPrecos
{
	public class Produto
	{
		public Produto()
		{
		}

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
		public string Nome { get; set; }
		public decimal Valor { get; set; }

	}
}

