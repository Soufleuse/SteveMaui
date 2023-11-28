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
	}
}
