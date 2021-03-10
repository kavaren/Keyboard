using NUnit.Framework;
using Keyboard.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Keyboard.Views.Tests
{
    [TestFixture()]
    public class MainWindowTests
    {
        [Apartment(ApartmentState.STA)]
        [Test()]
        public void MainWindowTest()
        {
            Assert.DoesNotThrow(() => new MainWindow());
        }
    }
}
