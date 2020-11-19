using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDFMorty.Validation;

namespace PDFMorty.UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidatePassword_PasswordConformsToRules_ReturnsTrue()
        {
            //arrange
            string password = "Imingr*atpa1n";
            //act
            var result = Validator.ValidatePassword(password);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidatePassword_PasswordTooShort_ReturnsFalse()
        {
            string password = "Othf*67";
            var result = Validator.ValidatePassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePassword_PasswordTooLong_ReturnsFalse()
        {
            string password = "Othf*6789012345678901";
            var result = Validator.ValidatePassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePassword_PasswordHasNoLetters_ReturnsFalse()
        {
            string password = "01234567*";
            var result = Validator.ValidatePassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePassword_PasswordHasNoLowercaseLetters_ReturnsFalse()
        {
            string password = "OTHFF67*N";
            var result = Validator.ValidatePassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePassword_PasswordHasNoUppercaseLetters_ReturnsFalse()
        {
            string password = "othff67*n";
            var result = Validator.ValidatePassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePassword_PasswordHasNoNumbers_ReturnsFalse()
        {
            string password = "Othffss*n";
            var result = Validator.ValidatePassword(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidatePassword_PasswordHasNoSymbolsFromRange_ReturnsFalse()
        {
            var password = "Ottff^&8(";
            var result = Validator.ValidatePassword(password);
            Assert.IsFalse(result);
        }
    }
}
