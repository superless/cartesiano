using ingenium.probe.library;
using System;
using System.Linq;
using Xunit;

namespace ingenium.probe.test
{
    public partial class PlotDrawingTest {

        public class GetPlot {

            /// <summary>
            /// Comprobamos si la línea vertical obtiene el punto final correcto
            /// </summary>
            [Fact]
            public void PlanoCartesiano() {
                // assign
                var numberOfPoint = 10;
                var x = 30;
                var y = 30;
                var sumar = 1;
                // action
                var (origenX, finalX, origenY, finalY, x_points, y_points) = PlotDrawing.GetPlot(x, y, numberOfPoint, sumar);

                // assert
                Assert.True(origenY.X == 30 && origenY.Y == 30);
                Assert.True(finalY.X == 30 && finalY.Y == 50);
                Assert.True(origenX.X == 20 && origenX.Y == 40);
                Assert.True(finalX.X == 40 && finalX.Y == 40);
                Assert.True(x_points[0].X == 21 && x_points[0].Y == 40);
                Assert.True(x_points.Last().X == 39 && x_points.Last().Y == 40);
                Assert.True(y_points[0].X == 30 && y_points[0].Y == 31);
                Assert.True(y_points.Last().X == 30 && y_points.Last().Y == 49);
            }

            /// <summary>
            /// Comprobamos si la línea vertical obtiene el punto final correcto, considerando numeros negativos
            /// </summary>
            [Fact]
            public void PlanoCartesianoNegativo()
            {
                // assign
                var numberOfPoint = 10;
                var x = 0;
                var y = -10;
                var sumar = 1;
                // action
                var (origenX, finalX, origenY, finalY, x_points, y_points) = PlotDrawing.GetPlot(x, y, numberOfPoint, sumar);

                // assert
                Assert.True(origenY.X == 0 && origenY.Y == -10);
                Assert.True(finalY.X == 0 && finalY.Y == 10);
                Assert.True(origenX.X == -10 && origenX.Y == 0);
                Assert.True(finalX.X == 10 && finalX.Y == 0);
                Assert.True(x_points[0].X == -9 && x_points[0].Y == 0);
                Assert.True(x_points.Last().X == 9 && x_points.Last().Y == 0);
                Assert.True(y_points[0].X == 0 && y_points[0].Y == -9);
                Assert.True(y_points.Last().X == 0 && y_points.Last().Y == 9);
            }



        }
    
    }
}
