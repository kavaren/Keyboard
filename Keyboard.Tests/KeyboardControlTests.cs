using NUnit.Framework;
using Keyboard.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Keyboard.Views.Tests
{
    [TestFixture()]
    public class KeyboardControlTests
    {
        [Apartment(ApartmentState.STA)]
        [Test()]
        public void KeyboardControlTest()
        {
            Assert.DoesNotThrow(() => new KeyboardControl());
        }
    }
}
