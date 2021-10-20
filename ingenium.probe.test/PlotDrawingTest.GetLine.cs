using ingenium.probe.library;
using System;
using Xunit;

namespace ingenium.probe.test
{
    public partial class PlotDrawingTest {

        public class GetLine {

            /// <summary>
            /// Comprobamos si la línea vertical obtiene el punto final correcto
            /// </summary>
            [Fact]
            public void VerticalLine() {
                // assign
                var numberOfPoint = 10;
                var x = 30;
                var y = 30;
                var sumar = 1;

                // action
                var lineResult = PlotDrawing.GetLine(false, x, y, numberOfPoint, sumar);

                // assert
                Assert.True(lineResult.X == 30 && lineResult.Y == 50);


            }

            /// <summary>
            /// Comprobamos si la línea horizontal obtiene el punto final correcto
            /// </summary>
            [Fact]
            public void HorizontalLine()
            {
                // assign
                var numberOfPoint = 10;
                var x = 30;
                var y = 30;
                var sumar = 1;

                // action
                var lineResult = PlotDrawing.GetLine(true, x, y, numberOfPoint, sumar);

                // assert
                Assert.True(lineResult.X == 50 && lineResult.Y == 30);


            }

        }
    
    }
}
