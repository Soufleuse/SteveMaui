using SteveMAUI.MVVM;
using System;

namespace TestControles.Data.Dto
{
    public class MesDonnees : CsBaseContexte
    {
		private string _uneChaineTexte = string.Empty;

		public string uneChaineTexte
        {
			get { return _uneChaineTexte; }
			set
			{
				if(string.Compare(uneChaineTexte, value) != 0)
                {
                    _uneChaineTexte = value;
					NotifierChangement(nameof(uneChaineTexte));
                }
			}
		}

		private DateTime _uneDate;

		public DateTime uneDate
        {
			get { return _uneDate; }
			set
			{
				if(uneDate != value)
				{
					_uneDate = value;
					NotifierChangement(nameof(uneDate));
				}
			}
		}

		private bool _EstDateValide = false;
        public bool EstDateValide
		{
			get { return EstDateValide; }
			set { _EstDateValide = value; }
		}

		private bool _EstTexteValide = false;
        public bool EstTexteValide
		{
			get { return _EstTexteValide; }
			set { _EstTexteValide = value; }
		}

		private bool _EstNumeriqueValide = false;
        public bool EstNumeriqueValide
		{
			get { return _EstNumeriqueValide; }
			set { _EstNumeriqueValide = value; }
		}
    }
}
