using ClassLibrary1;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject1
{
    public class DrawingGeneratorTests
    {
        [Fact]
        public void Generate_ShouldHandleOnePanel()
        {
            var odTest = new OpeningDimensions()
            {
                Panels = 1,
                Profile = 2,
                Width = 100
            };

            List<Vertical> output = DrawingGenerator.Generate(odTest);

            Assert.Equal(2, output.Count);
            Assert.Equal(0, output[0].Xcoordinate);
            Assert.Equal(98, output[1].Xcoordinate);

        }

        [Fact]
        public void Generate_ShouldHandleTwoPanels()
        {
            var odTest = new OpeningDimensions()
            {
                Panels = 2,
                Profile = 2,
                Width = 100
            };

            List<Vertical> output = DrawingGenerator.Generate(odTest);

            Assert.Equal(3, output.Count);
            Assert.Equal(0, output[0].Xcoordinate);
            Assert.Equal(49, output[1].Xcoordinate);
            Assert.Equal(98, output[2].Xcoordinate);

        }
        [Fact]
        public void Generate_ShouldHandleThreePanels()
        {
            var odTest = new OpeningDimensions()
            {
                Panels = 3,
                Profile = 2,
                Width = 100
            };

            List<Vertical> output = DrawingGenerator.Generate(odTest);

            Assert.Equal(4, output.Count);
            Assert.Equal(0, output[0].Xcoordinate);
            Assert.Equal((31 + 2/3d).ToString("0.##"), output[1].Xcoordinate.ToString("0.##"));
            Assert.Equal((63 + 1/3d).ToString("0.##"), output[2].Xcoordinate.ToString("0.##"));
            Assert.Equal(98, output[3].Xcoordinate);

        }

    }
}
