using OpenQA.Selenium;

using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MatiasPili1216.ExpectedConditionsTools
{
    public class ExpectedConditionsForWebElement<T> where T : IWebElement
    {
        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a
        /// page. This does not necessarily mean that the element is visible.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located.</returns>
        public static Func<T, IWebElement> ElementExists(By locator)
        {
            return (t) => { return t.FindElement(locator); };
        }

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page
        /// and visible. Visibility means that the element is not only displayed but
        /// also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
        public static Func<T, IWebElement> ElementIsVisible(By locator)
        {
            return (t) =>
            {
                try
                {
                    return ElementIfVisible(t.FindElement(locator));
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
        public static Func<T, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(By locator)
        {
            return (t) =>
            {
                try
                {
                    var elements = t.FindElements(locator);
                    return elements.Any(element => !element.Displayed) ? null : elements.Any() ? elements : null;
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
        public static Func<T, ReadOnlyCollection<IWebElement>> VisibilityOfAllElementsLocatedBy(ReadOnlyCollection<IWebElement> elements)
        {
            return (t) =>
            {
                try
                {
                    return elements.Any(element => !element.Displayed) ? null : elements.Any() ? elements : null;
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
        public static Func<T, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator)
        {
            return (t) =>
            {
                try
                {
                    var elements = t.FindElements(locator);
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
        public static Func<T, bool> TextToBePresentInElement(IWebElement element, string text)
        {
            return (t) =>
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
        public static Func<T, bool> TextToBePresentInElementLocated(By locator, string text)
        {
            return (t) =>
            {
                try
                {
                    var element = t.FindElement(locator);
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
        /// An expectation for checking if the given text is present in the specified elements value attribute.
        /// </summary>
        /// <param name="element">The WebElement</param>
        /// <param name="text">Text to be present in the element</param>
        /// <returns><see langword="true"/> once the element contains the given text; otherwise, <see langword="false"/>.</returns>
        public static Func<T, bool> TextToBePresentInElementValue(IWebElement element, string text)
        {
            return (t) =>
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
        public static Func<T, bool> TextToBePresentInElementValue(By locator, string text)
        {
            return (t) =>
            {
                try
                {
                    var element = t.FindElement(locator);
                    var elementValue = element.GetAttribute("value");
                    if (elementValue != null)
                    {
                        return elementValue.Contains(text);
                    }
                    else
                    {
                        return false;
                    }
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
        public static Func<T, bool> InvisibilityOfElementLocated(By locator)
        {
            return (t) =>
            {
                try
                {
                    var element = t.FindElement(locator);
                    return !element.Displayed;
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
        public static Func<T, bool> InvisibilityOfElementWithText(By locator, string text)
        {
            return (t) =>
            {
                try
                {
                    var element = t.FindElement(locator);
                    var elementText = element.Text;
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
        public static Func<T, IWebElement> ElementToBeClickable(By locator)
        {
            return (t) =>
            {
                var element = ElementIfVisible(t.FindElement(locator));
                try
                {
                    return element != null && element.Enabled ? element : null;
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
        public static Func<T, IWebElement> ElementToBeClickable(IWebElement element)
        {
            return (t) =>
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
        public static Func<T, bool> StalenessOf(IWebElement element)
        {
            return (t) =>
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
        public static Func<T, bool> StalenessOfVisible(IWebElement element)
        {
            return (t) =>
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
        public static Func<T, bool> ElementToBeSelected(IWebElement element)
        {
            return ElementToBeSelected(element, true);
        }

        /// <summary>
        /// An expectation for checking if the given element is in correct state.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="selected">selected or not selected</param>
        /// <returns><see langword="true"/> given element is in correct state.; otherwise, <see langword="false"/>.</returns>
        public static Func<T, bool> ElementToBeSelected(IWebElement element, bool selected)
        {
            return (t) => element.Selected == selected;
        }

        /// <summary>
        /// An expectation for checking if the given element is selected.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns><see langword="true"/> given element is selected.; otherwise, <see langword="false"/>.</returns>
        public static Func<T, bool> ElementToBeSelected(By locator)
        {
            return ElementSelectionStateToBe(locator, true);
        }

        /// <summary>
        /// An expectation for checking if the given element is in correct state.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <param name="selected">selected or not selected</param>
        /// <returns><see langword="true"/> given element is in correct state.; otherwise, <see langword="false"/>.</returns>
        public static Func<T, bool> ElementSelectionStateToBe(By locator, bool selected)
        {
            return (t) =>
            {
                try
                {
                    var element = t.FindElement(locator);
                    return element.Selected == selected;
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