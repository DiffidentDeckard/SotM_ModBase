using System;
using System.Collections.Generic;
using System.Linq;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;

namespace SotM_ModBase
{
    /// <summary>
    /// Extensions to make repeated code simpler
    /// </summary>
    public static class ModBaseExtensions
    {
        /// <summary>
        /// Gets all the keywords that this card currently has.
        /// Unlike the base GetAllKeywords(), the HashSet returned is case-insensitive for searches, and is guaranteed to only have unique entries (no duplicates).
        /// </summary>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>Returns a HashSet of all this card's keyword values. This will only contain unique keywords and is case-insensitive.</returns>
        public static HashSet<string> GetAllKeywordsEx(this CardController cc,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            // HashSet will guarantee only unique keywords.
            HashSet<string> uniqueKeywords = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase);

            // Get all the native keywords for this card
            uniqueKeywords.UnionWith(cc.Card.GetKeywords(evenIfUnderCard, evenIfFaceDown));

            // If we should include additional keywords....
            if (evenIfAdditional)
            {
                // Add those additional keywords to our returned list
                uniqueKeywords.UnionWith(cc.GameController.GetAdditionalKeywords(cc.Card));
            }

            // Return our HashSet
            return uniqueKeywords;
        }

        /// <summary>
        /// Gets all the keywords that the given card currently has.
        /// Unlike the base GetAllKeywords(), the list returned is case-insensitive for searches, and is guaranteed to only have unique entries (no duplicates).
        /// </summary>
        /// <param name="card">The Card whose keywords we are returning.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>Returns a HashSet of all the given card's keyword values. This will only contain unique keywords and is case-insensitive.</returns>
        public static HashSet<string> GetAllCardKeywordsEx(this GameController gc,
            Card card,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            return gc.FindCardController(card).GetAllKeywordsEx(evenIfAdditional, evenIfUnderCard, evenIfFaceDown);
        }

        /// <summary>
        /// Checks to see if this card has the given keyword.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="keyword">The keyword to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if the given keyword is found. False otherwise.</returns>
        public static bool HasKeywordEx(this CardController cc,
            string keyword,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            return cc.GetAllKeywordsEx(evenIfAdditional, evenIfUnderCard, evenIfFaceDown).Contains(keyword, StringComparer.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Checks to see if the given card has the given keyword.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="card">The card to check.</param>
        /// <param name="keyword">The keyword to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if the given keyword is found. False otherwise.</returns>
        public static bool CardHasKeywordEx(this GameController gc,
            Card card, string keyword,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            return gc.FindCardController(card).HasKeywordEx(keyword, evenIfAdditional, evenIfUnderCard, evenIfFaceDown);
        }

        /// <summary>
        /// Checks to see if this card has any of the given keywords.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="keywords">The list of keywords to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if any the given keywords are found. False otherwise.</returns>
        public static bool HasAnyOfKeywordsEx(this CardController cc,
            IEnumerable<string> keywords,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            HashSet<string> uniqueKeywords = new HashSet<string>(keywords, StringComparer.CurrentCultureIgnoreCase);
            return cc.GetAllKeywordsEx(evenIfAdditional, evenIfUnderCard, evenIfFaceDown).Overlaps(uniqueKeywords);
        }

        /// <summary>
        /// Checks to see if the given card has any of the given keywords.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="card">The card to check.</param>
        /// <param name="keywords">The list of keywords to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if any the given keywords are found. False otherwise.</returns>
        public static bool CardHasAnyOfKeywordsEx(this GameController gc,
            Card card, IEnumerable<string> keywords,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            return gc.FindCardController(card).HasAnyOfKeywordsEx(keywords, evenIfAdditional, evenIfUnderCard, evenIfFaceDown);
        }

        /// <summary>
        /// Checks to see if this card has all of the given keywords.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="keywords">The list of keywords to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if all the given keywords are found. False otherwise.</returns>
        public static bool HasAllOfKeywordsEx(this CardController cc,
            IEnumerable<string> keywords,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            HashSet<string> uniqueKeywords = new HashSet<string>(keywords, StringComparer.CurrentCultureIgnoreCase);
            return cc.GetAllKeywordsEx(evenIfAdditional, evenIfUnderCard, evenIfFaceDown).IsSupersetOf(uniqueKeywords);
        }

        /// <summary>
        /// Checks to see if the given card has all of the given keywords.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="card">The card to check.</param>
        /// <param name="keywords">The list of keywords to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if all the given keywords are found. False otherwise.</returns>
        public static bool CardHasAllOfKeywordsEx(this GameController gc,
            Card card, IEnumerable<string> keywords,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            return gc.FindCardController(card).HasAllOfKeywordsEx(keywords, evenIfAdditional, evenIfUnderCard, evenIfFaceDown);
        }

        /// <summary>
        /// Checks to see if this card has only a subset of the given keywords, and no other keywords.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="keywords">The list of keywords to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if no other keywords are found. False otherwise.</returns>
        public static bool HasOnlyKeywordsEx(this CardController cc,
            IEnumerable<string> keywords,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            HashSet<string> uniqueKeywords = new HashSet<string>(keywords, StringComparer.CurrentCultureIgnoreCase);
            return cc.GetAllKeywordsEx(evenIfAdditional, evenIfUnderCard, evenIfFaceDown).IsSubsetOf(uniqueKeywords);
        }

        /// <summary>
        /// Checks to see if the given card has only a subset of the given keywords, and no other keywords.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="card">The card to check.</param>
        /// <param name="keywords">The list of keywords to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if no other keywords are found. False otherwise.</returns>
        public static bool CardHasOnlyKeywordsEx(this GameController gc,
            Card card, IEnumerable<string> keywords,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            return gc.FindCardController(card).HasOnlyKeywordsEx(keywords, evenIfAdditional, evenIfUnderCard, evenIfFaceDown);
        }

        /// <summary>
        /// Checks to see if this card has all of the given keywords, and no other keywords.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="keywords">The list of keywords to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if all of the given keywords, and no other keywords, are found. False otherwise.</returns>
        public static bool HasAllOfAndOnlyKeywordsEx(this CardController cc,
            IEnumerable<string> keywords,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            HashSet<string> uniqueKeywords = new HashSet<string>(keywords, StringComparer.CurrentCultureIgnoreCase);
            return cc.GetAllKeywordsEx(evenIfAdditional, evenIfUnderCard, evenIfFaceDown).SetEquals(uniqueKeywords);
        }

        /// <summary>
        /// Checks to see if the given card has all of the given keywords, and no other keywords.
        /// Unlike the base DoesCardContainKeyword(), this is case-insensitive.
        /// </summary>
        /// <param name="card">The card to check.</param>
        /// <param name="keywords">The list of keywords to check for.</param>
        /// <param name="evenIfAdditional">If true, will include keywords added by effects. If false, will only include keywords natively on the card.</param>
        /// <param name="evenIfUnderCard">If true, will include the card's native keywords even if the card is under another card. If false, will not.</param>
        /// <param name="evenIfFaceDown">If true, will include the card's native keywords even if the card is face-down. If false, will not.</param>
        /// <returns>True if all of the given keywords, and no other keywords, are found. False otherwise.</returns>
        public static bool CardHasAllOfAndOnlyKeywordsEx(this GameController gc,
            Card card, IEnumerable<string> keywords,
            bool evenIfAdditional = true, bool evenIfUnderCard = false, bool evenIfFaceDown = false)
        {
            return gc.FindCardController(card).HasAllOfAndOnlyKeywordsEx(keywords, evenIfAdditional, evenIfUnderCard, evenIfFaceDown);
        }

        /// <summary>
        /// Returns all the individual selected cards from a list of SelectCardsDecisions
        /// </summary>
        public static IEnumerable<Card> GetSelectedCardsEx(this List<SelectCardsDecision> storedResults)
        {
            return storedResults.SelectMany(scd => scd.SelectCardDecisions).Select(scd => scd.SelectedCard);
        }
    }
}
