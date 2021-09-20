using OpenQA.Selenium;

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MatiasPili1216.ExpectedConditionsTools
{
    public class ExpectedConditionsForWebElement
    {
        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a
        /// page. This does not necessarily mean that the element is visible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located.</returns>
        public static Func<IWebElement, IWebElement> FindElement(By locator) => (element) => { return element.FindElement(locator); };

        public static Func<IWebElement, ReadOnlyCollection<IWebElement>> FindElements(By locator) => (element) => { return element.FindElements(locator); };

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page
        /// and visible. Visibility means that the element is not only displayed but
        /// also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebElement, IWebElement> ElementIsVisible(By locator)
        {
            return (element) =>
            {
                try
                {
                    return ElementIfVisible(element.FindElement(locator));
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that all elements present on the web page that
        /// match the locator are visible. Visibility means that the elements are not
        /// only displayed but also have a height and width that is greater than 0.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebElement, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By locator)
        {
            return (element) =>
            {
                try
                {
                    var elements = element.FindElements(locator);
                    return elements.Any(e => !e.Displayed) ? null : elements.Any() ? elements : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that all elements present on the web page that
        /// match the locator are visible. Visibility means that the elements are not
        /// only displayed but also have a height and width that is greater than 0.
        /// </summary>
        /// <param name="elements">list of WebElements</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<IWebElement, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(ReadOnlyCollection<IWebElement> elements)
        {
            return (element) =>
            {
                try
                {
                    return elements.Any(e => !e.Displayed) ? null : elements.Any() ? elements : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that all elements present on the web page that
        /// match the locator.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The list of <see cref="IWebElement"/> once it is located.</returns>
        public static Func<IWebElement, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator)
        {
            return (element) =>
            {
                try
                {
                    var elements = element.FindElements(locator);
                    return elements.Any() ? elements : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// An expectation for checking if the given text is present in the specified element.
        /// </summary>
        /// <param name="element">The WebElement</param>
        /// <param name="text">Text to be present in the element</param>
        /// <returns><see langword="true"/> once the element contains the given text; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> TextToBePresentInElement(IWebElement element, string text)
        {
            return (element) =>
            {
                try
                {
                    var elementText = element.Text;
                    return elementText.Contains(text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        /// <summary>
        /// An expectation for checking if the given text is present in the element that matches the given locator.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="text">Text to be present in the element</param>
        /// <returns><see langword="true"/> once the element contains the given text; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> TextToBePresentInElementLocated(By locator, string text)
        {
            return (element) =>
            {
                try
                {
                    var elementText = element.FindElement(locator)?.Text;
                    return elementText.Contains(text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        /// <summary>
        /// An expectation for checking if the given text is present in the specified elements value attribute.
        /// </summary>
        /// <param name="element">The WebElement</param>
        /// <param name="text">Text to be present in the element</param>
        /// <returns><see langword="true"/> once the element contains the given text; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> TextToBePresentInElementValue(IWebElement element, string text)
        {
            return (element) =>
            {
                try
                {
                    var elementValue = element.GetAttribute("value");
                    return elementValue != null && elementValue.Contains(text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        /// <summary>
        /// An expectation for checking if the given text is present in the specified elements value attribute.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="text">Text to be present in the element</param>
        /// <returns><see langword="true"/> once the element contains the given text; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> TextToBePresentInElementValue(By locator, string text)
        {
            return (element) =>
            {
                try
                {
                    var elementValue = element.FindElement(locator)?.GetAttribute("value");
                    return elementValue != null && elementValue.Contains(text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that an element is either invisible or not present on the DOM.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns><see langword="true"/> if the element is not displayed; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> InvisibilityOfElementLocated(By locator)
        {
            return (element) =>
            {
                try
                {
                    return !(element.FindElement(locator).Displayed);
                }

                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

        /// <summary>
        /// An expectation for checking that an element with text is either invisible or not present on the DOM.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="text">Text of the element</param>
        /// <returns><see langword="true"/> if the element is not displayed; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> InvisibilityOfElementWithText(By locator, string text)
        {
            return (element) =>
            {
                try
                {
                    var elementText = element.FindElement(locator)?.Text;
                    return string.IsNullOrEmpty(elementText) || !elementText.Equals(text);
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element with text is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

        /// <summary>
        /// An expectation for checking an element is visible and enabled such that you
        /// can click it.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and clickable (visible and enabled).</returns>
        public static Func<IWebElement, IWebElement> ElementToBeClickable(By locator)
        {
            return (element) =>
            {
                var result = ElementIfVisible(element.FindElement(locator));
                try
                {
                    return result != null && result.Enabled ? result : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// An expectation for checking an element is visible and enabled such that you
        /// can click it.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is clickable (visible and enabled).</returns>
        public static Func<IWebElement, IWebElement> ElementToBeClickable(IWebElement element)
        {
            return (element) =>
            {
                try
                {
                    return element != null && element.Displayed && element.Enabled ? element : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        /// <summary>
        /// Wait until an element is no longer attached to the DOM.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns><see langword="false"/> is the element is still attached to the DOM; otherwise, <see langword="true"/>.</returns>
        public static Func<IWebElement, bool> StalenessOf(IWebElement element)
        {
            return (element) =>
            {
                try
                {
                    return element == null || !element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            };
        }

        /// <summary>
        /// Wait until an element is no longer attached to the DOM.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns><see langword="false"/> is the element is still attached to the DOM; otherwise, <see langword="true"/>.</returns>
        public static Func<IWebElement, bool> StalenessOfVisible(IWebElement element)
        {
            return (element) =>
            {
                try
                {
                    return element == null || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            };
        }

        /// <summary>
        /// An expectation for checking if the given element is selected.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns><see langword="true"/> given element is selected.; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> ElementToBeSelected(IWebElement element)
        {
            return ElementToBeSelected(element, true);
        }

        /// <summary>
        /// An expectation for checking if the given element is in correct state.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="selected">selected or not selected</param>
        /// <returns><see langword="true"/> given element is in correct state.; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> ElementToBeSelected(IWebElement element, bool selected)
        {
            return (element) => element.Selected == selected;
        }

        /// <summary>
        /// An expectation for checking if the given element is selected.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns><see langword="true"/> given element is selected.; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> ElementToBeSelected(By locator)
        {
            return ElementSelectionStateToBe(locator, true);
        }

        /// <summary>
        /// An expectation for checking if the given element is in correct state.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="selected">selected or not selected</param>
        /// <returns><see langword="true"/> given element is in correct state.; otherwise, <see langword="false"/>.</returns>
        public static Func<IWebElement, bool> ElementSelectionStateToBe(By locator, bool selected)
        {
            return (element) =>
            {
                try
                {
                    return element.FindElement(locator).Selected == selected;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        private static IWebElement ElementIfVisible(IWebElement element) => element.Displayed ? element : null;
    }
}