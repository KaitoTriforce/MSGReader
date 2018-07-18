//
// DomField.cs
//
// Author: Kees van Spelde <sicos2002@hotmail.com>
//
// Copyright (c) 2013-2018 Magic-Sessions. (www.magic-sessions.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

namespace MsgReader.Rtf
{
    /// <summary>
    /// Document field element
    /// </summary>
    internal class DomField : DomElement
    {
        #region Constructor
        public DomField()
        {
            Method = RtfDomFieldMethod.None;
        }
        #endregion

        #region Properties
        // ReSharper disable UnusedMember.Global
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// Method
        /// </summary>
        public RtfDomFieldMethod Method { get; set; }

        /// <summary>
        /// Instructions
        /// </summary>
        public string Instructions
        // ReSharper restore UnusedMember.Global
        {
            get
            {
                foreach (DomElement element in Elements)
                {
                    var container = element as ElementContainer;
                    if (container != null)
                    {
                        if (container.Name == Consts.Fldinst)
                            return container.InnerText;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Result
        /// </summary>
        public ElementContainer Result
        {
            get
            {
                foreach (DomElement element in Elements)
                {
                    var container = element as ElementContainer;
                    if (container != null)
                    {
                        if (container.Name == Consts.Fldrslt)
                            return container;
                    }
                }
                return null;
            }
        }

        public string ResultString => Result != null ? Result.InnerText : null;
        // ReSharper restore UnusedAutoPropertyAccessor.Global
        // ReSharper disable once MemberCanBePrivate.Global
        #endregion

        #region ToString
        public override string ToString()
        {
            return "Field"; // +strInstructions + " Result:" + this.ResultString;
        }
        #endregion
    }
}