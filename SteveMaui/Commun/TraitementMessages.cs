using System;
using System.IO;

namespace SteveMAUI.Commun
{
    public static class TraitementMessages
    {
        /// <summary>
        /// Imprime un message d'erreur à la console. A été pensée dans le cas où on reçoit
        /// une exception.
        /// </summary>
        /// <param name="pMessageParent">
        /// Le message à inscrire. Si null/vide, une belle exception est garochée.
        /// </param>
        /// <param name="pInnerMessage">
        /// Si présent, imprime le ex.InnerException.Message qui nous a été donné.
        /// </param>
        /// <param name="pStackTrace">
        /// La stack trace de l'exception.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Si pMessageParent est null/empty, cette exception sortira.
        /// </exception>
        public static void ImprimerMessage(string pMessageParent, string pInnerMessage, string pStackTrace)
        {
            if (string.IsNullOrEmpty(pMessageParent))
            {
                throw new ArgumentNullException(nameof(pMessageParent));
            }

            if (pInnerMessage == null)
            {
                pInnerMessage = string.Empty;
            }

            if (pStackTrace == null)
            {
                pStackTrace = string.Empty;
            }

            Console.WriteLine(string.Format("Message de tête : {0}; inner message : {1}; stack trace : {2}",
                string.Concat(pMessageParent, Environment.NewLine),
                string.Concat(pInnerMessage, Environment.NewLine),
                pStackTrace));
        }

        /// <summary>
        /// Imprime un message d'erreur dans un fichier. A été pensée dans le cas où on reçoit
        /// une exception.
        /// </summary>
        /// <param name="pMessageParent">
        /// Le message à inscrire. Si null/vide, une belle exception est garochée.
        /// </param>
        /// <param name="pInnerMessage">
        /// Si présent, imprime le ex.InnerException.Message qui nous a été donné.
        /// </param>
        /// <param name="pStackTrace">
        /// La stack trace de l'exception.
        /// </param>
        /// <param name="fichierSortie">
        /// Le fichier dans lequel on imprime l'erreur.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Si pMessageParent ou fichierSortie est null/empty, cette exception sortira.
        /// </exception>
        public static void ImprimerMessage(string pMessageParent, string pInnerMessage, string pStackTrace, StreamWriter fichierSortie)
        {
            if (string.IsNullOrEmpty(pMessageParent))
            {
                throw new ArgumentNullException(nameof(pMessageParent));
            }

            if(fichierSortie == null)
            {
                throw new ArgumentNullException(nameof(fichierSortie));
            }

            if (pInnerMessage == null)
            {
                pInnerMessage = string.Empty;
            }

            if (pStackTrace == null)
            {
                pStackTrace = string.Empty;
            }

            fichierSortie.WriteLine(string.Format("Message de tête : {0}; inner message : {1}; stack trace : {2}",
                string.Concat(pMessageParent, Environment.NewLine),
                string.Concat(pInnerMessage, Environment.NewLine),
                pStackTrace));
        }
    }
}
