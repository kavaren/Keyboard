using NUnit.Framework;
using Keyboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard.Models.Tests
{
    [TestFixture()]
    public class PhoneNumberTests
    {
        [SetUp()]
        public void SetUp()
        {
        }

        [Test()]
        public void PhoneNumberConstructorTest()
        {
            PhoneNumber _number = new PhoneNumber();
            Assert.NotNull(_number.Number);
        }

        [TestCase("+48790947657")]
        [TestCase("512259222")]
        [TestCase("+48592259222")]
        [TestCase("048592259222")]
        [TestCase("512 259 222")]
        [TestCase("59 225 92 22")]
        public void PhoneNumberConstructorArgumentTest(string inputStringNumber)
        {
            PhoneNumber _number = new PhoneNumber(inputStringNumber);
            Assert.NotNull(_number.Number);
        }

        [TestCase("+48790947657")]
        [TestCase("512259222")]
        [TestCase("+48592259222")]
        [TestCase("048592259222")]
        [TestCase("512 259 222")]
        [TestCase("59 225 92 22")]
        public void PhoneNumberCheckIfAnyNumberTest(string inputStringNumber)
        {
            PhoneNumber _number = new PhoneNumber(inputStringNumber);
            Assert.IsTrue(_number.Number.Any(char.IsDigit));
        }

        [TestCase("+48790947657")]
        [TestCase("512259222")]
        [TestCase("+48592259222")]
        [TestCase("048592259222")]
        [TestCase("512 259 222")]
        [TestCase("59 225 92 22")]
        public void PhoneNumberCheckIfThrowsTest(string inputStringNumber)
        {
            PhoneNumber _number = new PhoneNumber();
            Assert.DoesNotThrow(() => _number.Number = inputStringNumber);
        }
    }
}
