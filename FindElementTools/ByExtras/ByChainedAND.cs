using OpenQA.Selenium;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MatiasPili1216.FindElementTools
{
    /// <summary>
    /// Mechanism used to locate elements within a document using a series of other lookups.  This class
    /// will find all DOM elements that matches each of the locators in sequence
    /// </summary>
    public class ByChainedAND : By
    {
        private readonly By[] bys;

        /// <summary>
        /// Initializes a new instance of the <see cref="ByChainedOR"/> class with one or more <see cref="By"/> objects.
        /// </summary>
        /// <param name="bys">One or more <see cref="By"/> references</param>
        public ByChainedAND(params By[] bys) { this.bys = bys; }

        /// <summary>
        /// Find a single element.
        /// </summary>
        /// <param name="context">Context used to find the element.</param>
        /// <returns>The element that matches</returns>
        public override IWebElement FindElement(ISearchContext context)
        {
            try
            {
                return FindElements(context)?.First();
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        /// <summary>
        /// Finds many elements
        /// </summary>
        /// <param name="context">Context used to find the element.</param>
        /// <returns>A readonly collection of elements that match.</returns>
        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            if (bys.Length == 0) { return null; }

            List<IWebElement> elements = new();

            foreach (var by in bys)
            {
                var newElements = by.FindElements(context, 10)?.ToList();

                if (newElements != null)
                {
                    if (elements.Any())
                    {
                        elements = newElements.Where(e => elements.Contains(e)).ToList();
                    }
                    else
                    {
                        elements.AddRange(newElements);
                    }
                    
                }
            }

            return new ReadOnlyCollection<IWebElement>(elements);
        }
    }
}