using OpenQA.Selenium;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MatiasPili1216.FindElementTools
{
    /// <summary>
    /// Mechanism used to locate elements within a document using a series of other lookups.  This class
    /// will find all DOM elements that matches at least one of the locators in sequence
    /// </summary>
    public class ByChainedOR : By
    {
        private readonly By[] bys;

        /// <summary>
        /// Initializes a new instance of the <see cref="ByChainedOR"/> class with one or more <see cref="By"/> objects.
        /// </summary>
        /// <param name="bys">One or more <see cref="By"/> references</param>
        public ByChainedOR(params By[] bys) { this.bys = bys; }

        /// <summary>
        /// Find a single element.
        /// </summary>
        /// <param name="context">Context used to find the element.</param>
        /// <returns>The element that matches</returns>
        public override IWebElement FindElement(ISearchContext context) => FindElements(context)?.First();

        /// <summary>
        /// Finds many elements
        /// </summary>
        /// <param name="context">Context used to find the element.</param>
        /// <returns>A readonly collection of elements that match.</returns>
        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            List<IWebElement> List = new();

            foreach (var by in bys)
            {
                var elements = by.FindElements(context, 10);

                if (elements != null)
                {
                    List.AddRange(elements);
                }
            }

            return new ReadOnlyCollection<IWebElement>(List);
        }
    }
}
