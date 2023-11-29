using System;
using System.Windows.Input;

namespace SteveMAUI.MVVM
{
    [Obsolete("Utiliser à la place la classe Command du namespace Microsoft.Maui.Controls")]
    public class CsBaseCommande : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly Action<object?> m_objAction;
        private readonly Predicate<object?>? m_objPredicat;

        public CsBaseCommande(Action<object?> action) : this(action, null) { }

        public CsBaseCommande(Action<object?> action, Predicate<object?>? predicat)
        {
            Action<object?> actionLocale = action ?? throw new ArgumentNullException(nameof(action));
            m_objAction = actionLocale;
            m_objPredicat = predicat;
        }

        public bool CanExecute(object? parameter)
        {
            bool blnRetour = false;
            if (m_objPredicat == null)
                blnRetour = true;
            else
                blnRetour = m_objPredicat(parameter);

            return blnRetour;
        }

        public void Execute(object? parameter)
        {
            m_objAction(parameter);
        }
    }
}
