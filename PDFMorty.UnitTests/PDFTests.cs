using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDFMorty.Entities;
using PDFMorty.PDF;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDFMorty.UnitTests
{
    [TestClass]
    public class PDFTests
    {
        [TestMethod]
        public void PDFCreator_CharacterDocument_MadeSuccessfully()
        {
            Character character = CharacterBuilder.Init()
                                                    .WithName("Jordan Niedzielski")
                                                    .WithStatus("Alive")
                                                    .OfGender("Men")
                                                    .From("Earth")
                                                    .SpeciesOf("Human")
                                                    .PlayedIn((ushort) 0)
                                                    .LastSeenAt(".NET debugger")
                                                    .Build();
            PDFCreator pdf = new PDFCreator($"characters.pdf", new List<Character> { character });
            Assert.IsNotNull(pdf);
        }
    }
}
