using SteveMAUI.MVVM;
using System;
using TestControles.Data.Dto;

namespace TestControles.MVVM
{
    public class MonContexte : CsBaseContexte
    {
		private MesDonnees _maDonnee;

		public MesDonnees maDonnee
        {
			get { return _maDonnee; }
			set
			{
				_maDonnee = value;
				NotifierChangement(nameof(maDonnee));
			}
		}

		public MonContexte()
		{
			_maDonnee = new MesDonnees
			{
				uneChaineTexte = "blablabla",
				uneDate = new DateTime(2020, 3, 13)
			};
		}
	}
}
